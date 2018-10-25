using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using log4net;
using Lifestoned.DataModel.Content;
using Lifestoned.DataModel.Gdle;
using Lifestoned.DataModel.Recipe;
using Newtonsoft.Json;
using Lifestoned.DataModel.Shared;
using Lifestoned.DataModel.WorldRelease;

namespace Lifestoned.Providers
{
    public class LocalContentProvider : IContentProvider
    {
        private static readonly ILog log = LogManager.GetLogger("LocalContentProvider");

        protected string ContentPath { get; private set; }

        private object weenieCacheMutex = new object();

        protected ConcurrentDictionary<uint, Weenie> Weenies { get; private set; }

        protected object contentCacheMutex = new object();

        protected ConcurrentDictionary<Guid, Content> Content { get; private set; }

        public LocalContentProvider()
        {
        }

        public LocalContentProvider(string path)
            : this()
        {
            ContentPath = path;

            Reload();
        }

        public Release CutWorldRelease(string token, ReleaseType releaseType)
        {
            throw new NotImplementedException();
        }

        public byte[] GetCurrentWorldRelease(string token)
        {
            throw new NotImplementedException();
        }

        public Release GetCurrentWorldReleaseInfo(string token)
        {
            throw new NotImplementedException();
        }

        public byte[] GetWorldRelease(string token, string fileName)
        {
            throw new NotImplementedException();
        }

        public Release GetWorldReleaseInfo(string token, string fileName)
        {
            throw new NotImplementedException();
        }

        public List<Content> GetAllContent(string token)
        {
            throw new NotImplementedException();
        }

        public Content GetContent(string token, Guid contentGuid)
        {
            Content c = null;
            Content.TryGetValue(contentGuid, out c);
            return c;
        }

        public HttpStatusCode SaveContent(string token, Content content)
        {
            if (SaveContent(content))
                return HttpStatusCode.OK;

            return HttpStatusCode.InternalServerError;
        }

        private bool SaveContent(Content content)
        {
            if (content == null)
                throw new ArgumentNullException(nameof(content));

            if (content.ContentGuid == null)
                content.ContentGuid = Guid.NewGuid();

            try
            {
                JsonSerializerSettings settings = new JsonSerializerSettings();
                settings.NullValueHandling = NullValueHandling.Ignore;

                string path = Path.Combine(ContentPath, "content", $"{content.ContentGuid}.json");
                string text = JsonConvert.SerializeObject(content, settings);

                File.WriteAllText(path, text);

                Content[content.ContentGuid.Value] = content;

                return true;
            }
            catch (Exception ex)
            {
                log.ErrorFormat("Error saving content : {0}", ex);
                return false;
            }
        }

        public bool CreateWeenie(string token, Weenie weenie)
        {
            return SaveWeenie(weenie);
        }

        public Weenie GetWeenie(string token, uint weenieClassId)
        {
            Weenie result = null;
            Weenies.TryGetValue(weenieClassId, out result);
            return result;
        }

        public bool DeleteWeenie(string token, uint weenieClassId)
        {
            try
            {
                Weenie weenie = null;
                if (Weenies.TryRemove(weenieClassId, out weenie))
                {
                    string path = Path.Combine(ContentPath, "weenies", $"{weenieClassId}.json");
                    File.Delete(path);
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<WeenieSearchResult> RecentChanges(string token)
        {
            var copy = Weenies.Values.Select(w => w)
                .Where(w => w.LastModified != null)
                .OrderByDescending(w => w.LastModified)
                .Take(100);

            return copy.Select(w => new WeenieSearchResult()
            {
                Description = w.StringStats.Find(p => p.Key == (int)StringPropertyId.ShortDesc)?.Value,
                LastModified = w.LastModified,
                ModifiedBy = w.ModifiedBy,
                Name = w.Name,
                ItemType = (ItemType?)w.ItemType,
                WeenieClassId = w.WeenieId,
                WeenieType = w.WeenieType_Binder,
                IsDone = w.IsDone,
                HasSandboxChange = !w.IsDone
            }).ToList();
        }

        public List<WeenieSearchResult> AllUpdates(string token)
        {
            var copy = Weenies.Values.Select(w => w)
                .Where(w => w.LastModified != null)
                .OrderByDescending(w => w.LastModified);

            return copy.Select(w => new WeenieSearchResult()
            {
                Description = w.StringStats.Find(p => p.Key == (int)StringPropertyId.ShortDesc)?.Value,
                LastModified = w.LastModified,
                ModifiedBy = w.ModifiedBy,
                Name = w.Name,
                ItemType = (ItemType?)w.ItemType,
                WeenieClassId = w.WeenieId,
                WeenieType = w.WeenieType_Binder,
                IsDone = w.IsDone,
                HasSandboxChange = !w.IsDone && w.LastModified != null
            }).ToList();
        }

        public bool UpdateWeenie(string token, Weenie weenie)
        {
            return SaveWeenie(weenie);
        }

        public List<WeenieSearchResult> WeenieSearch(string token, SearchWeeniesCriteria criteria)
        {
            var copy = Weenies.Values.Select(w => w);

            if (criteria != null)
            {
                if (criteria.WeenieClassId.HasValue)
                    copy = copy.Where(w => w.WeenieId == criteria.WeenieClassId);

                if (criteria.ItemType.HasValue)
                    copy = copy.Where(w => w.ItemType == (int)criteria.ItemType);

                if (criteria.WeenieType.HasValue)
                    copy = copy.Where(w => w.WeenieTypeId == (int)criteria.WeenieType);

                if (!string.IsNullOrWhiteSpace(criteria.PartialName))
                    copy = copy.Where(w => w.Name.ToLower().Contains(criteria.PartialName.ToLower()));

                if (criteria.PropertyCriteria?.Count > 0)
                {
                    criteria.PropertyCriteria.ForEach(pc =>
                    {
                        try
                        {
                            if (string.IsNullOrEmpty(pc.PropertyValue))
                                return;

                            switch (pc.PropertyType)
                            {
                                case PropertyType.PropertyBool:
                                    copy = copy.Where(w => w.BoolStats.Any(p => p.Key == pc.PropertyId && p.BoolValue == bool.Parse(pc.PropertyValue)));
                                    break;
                                case PropertyType.PropertyDataId:
                                    copy = copy.Where(w => w.DidStats.Any(p => p.Key == pc.PropertyId && p.Value == uint.Parse(pc.PropertyValue)));
                                    break;
                                case PropertyType.PropertyDouble:
                                    copy = copy.Where(w => w.FloatStats.Any(p => p.Key == pc.PropertyId && p.Value == double.Parse(pc.PropertyValue)));
                                    break;
                                case PropertyType.PropertyInt:
                                    copy = copy.Where(w => w.IntStats.Any(p => p.Key == pc.PropertyId && p.Value == int.Parse(pc.PropertyValue)));
                                    break;
                                case PropertyType.PropertyInt64:
                                    copy = copy.Where(w => w.Int64Stats.Any(p => p.Key == pc.PropertyId && p.Value == long.Parse(pc.PropertyValue)));
                                    break;
                                case PropertyType.PropertyString:
                                    copy = copy.Where(w => w.StringStats.Any(p => p.Key == pc.PropertyId && p.Value.Contains(pc.PropertyValue)));
                                    break;
                                default:
                                    log.Warn($"Weenie search for unsupported property type {pc.PropertyType}");
                                    break;
                            }
                        }
                        catch (Exception ex)
                        {
                            log.Error($"Weenie Search {ex.ToString()}");
                        }
                    });
                }
            }

            return copy.Select(w => new WeenieSearchResult()
            {
                Description = w.StringStats.Find(p => p.Key == (int)StringPropertyId.ShortDesc)?.Value,
                LastModified = w.LastModified,
                ModifiedBy = w.ModifiedBy,
                Name = w.Name,
                ItemType = (ItemType?)w.ItemType,
                WeenieClassId = w.WeenieId,
                WeenieType = (WeenieType?)w.WeenieTypeId,
                IsDone = w.IsDone,
                HasSandboxChange = !w.IsDone && w.LastModified != null
            }).ToList();
        }

        public void Reload()
        {
            LoadWeenies();
            LoadContent();
        }

        protected void LoadContent()
        {
            lock (contentCacheMutex)
            {
                Content = new ConcurrentDictionary<Guid, Content>();

                string path = Path.Combine(ContentPath, "content");
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);

                foreach (string filePath in Directory.EnumerateFiles(path, "*.json"))
                {
                    try
                    {
                        string text = File.ReadAllText(filePath);
                        Content content = JsonConvert.DeserializeObject<Content>(text);

                        if (content.ContentGuid != null)
                            Content.TryAdd(content.ContentGuid.Value, content);
                        else
                            log.WarnFormat("Content {0} was missing identifier", filePath);
                    }
                    catch (Exception ex)
                    {
                        log.ErrorFormat("Failed to load final content at {0} : {1}", filePath, ex.ToString());
                    }
                }
            }
        }

        protected void LoadWeenies()
        {
            lock (weenieCacheMutex)
            {
                Weenies = new ConcurrentDictionary<uint, Weenie>();

                string path = Path.Combine(ContentPath, "weenies");
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);

                // Load in background so the site is still usable while busy
                ThreadPool.QueueUserWorkItem((state) =>
                {
                    int maxTasks = Environment.ProcessorCount;
                    int taskCount = 0;

                    foreach (string filePath in Directory.EnumerateFiles(path, "*.json"))
                    {
                        Interlocked.Increment(ref taskCount);

                        ThreadPool.QueueUserWorkItem((fileState) =>
                        {
                            try
                            {
                                string file = fileState as string;
                                if (string.IsNullOrEmpty(file))
                                    return;

                                string content = File.ReadAllText(file);

                                Weenie weenie = JsonConvert.DeserializeObject<Weenie>(content);
                                weenie.CleanDeletedAndEmptyProperties();
                                Weenies.TryAdd(weenie.WeenieId, weenie);
                            }
                            catch (Exception ex)
                            {
                                log.ErrorFormat("Failed to load final weenie at {0} : {1}", fileState, ex.ToString());
                            }
                            finally
                            {
                                Interlocked.Decrement(ref taskCount);
                            }
                        },
                        filePath);

                        while (taskCount > maxTasks)
                        {
                            Thread.Sleep(1);
                        }
                    }

                    while (taskCount > 0)
                        Thread.Sleep(1);

                });
            }
        }

        private bool SaveWeenie(Weenie weenie)
        {
            if (weenie == null)
                throw new ArgumentNullException(nameof(weenie));

            try
            {
                JsonSerializerSettings settings = new JsonSerializerSettings();
                settings.NullValueHandling = NullValueHandling.Ignore;

                string path = Path.Combine(ContentPath, "weenies", $"{weenie.WeenieId}.json");
                string content = JsonConvert.SerializeObject(weenie, settings);

                File.WriteAllText(path, content);

                Weenies[weenie.WeenieId] = weenie;

                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<Recipe> RecipeSearch(string token, SearchRecipesCriteria criteria)
        {
            throw new NotImplementedException();
        }

        public bool UpdateRecipe(string token, Recipe recipe)
        {
            throw new NotImplementedException();
        }

        public Recipe GetRecipe(string token, Guid recipeGuid)
        {
            throw new NotImplementedException();
        }
    }
}