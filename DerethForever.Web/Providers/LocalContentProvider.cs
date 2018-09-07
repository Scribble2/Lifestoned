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
using DerethForever.Web.Models.Content;
using DerethForever.Web.Models.Recipe;
using DerethForever.Web.Models.WorldRelease;
using log4net;
using Lifestoned.DataModel.Gdle;
using Newtonsoft.Json;
using Lifestoned.DataModel.Shared;

namespace DerethForever.Web.Providers
{
    public class LocalContentProvider : IContentProvider
    {
        private static readonly ILog log = LogManager.GetLogger("LocalContentProvider");

        protected string ContentPath { get; private set; }

        protected ConcurrentDictionary<uint, Weenie> Weenies { get; private set; }

        [Flags]
        protected enum LoadingFlags
        {
            None = 0x0000,
            WeenieLoading = 0x0001,
            WeenieLoaded = 0x0002,

            Busy = WeenieLoading,
            Complete = WeenieLoaded
        }

        protected LoadingFlags LoadState { get; private set; }

        public LocalContentProvider()
        {
        }

        public LocalContentProvider(string path)
            : this()
        {
            ContentPath = path;

            Reload();
        }

        #region IContentProvider

        public bool CreateWeenie(string token, Weenie weenie)
        {
            return SaveWeenie(weenie);
        }

        public WorldRelease CutWorldRelease(string token, ReleaseType releaseType)
        {
            throw new NotImplementedException();
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

        public List<Content> GetAllContent(string token)
        {
            throw new NotImplementedException();
        }

        public Content GetContent(string token, Guid contentGuid)
        {
            throw new NotImplementedException();
        }

        public byte[] GetCurrentWorldRelease(string token)
        {
            throw new NotImplementedException();
        }

        public WorldRelease GetCurrentWorldReleaseInfo(string token)
        {
            throw new NotImplementedException();
        }

        public byte[] GetFullyLayeredPngIcon(uint weenieClassId)
        {
            throw new NotImplementedException();
        }

        public Recipe GetRecipe(string token, Guid recipeGuid)
        {
            throw new NotImplementedException();
        }

        public Weenie GetWeenie(string token, uint weenieClassId)
        {
            Weenie result = null;
            Weenies.TryGetValue(weenieClassId, out result);
            return result;
        }

        public byte[] GetWorldRelease(string token, string fileName)
        {
            throw new NotImplementedException();
        }

        public WorldRelease GetWorldReleaseInfo(string token, string fileName)
        {
            throw new NotImplementedException();
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
                WeenieType = (WeenieType?)w.WeenieType,
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
                WeenieType = (WeenieType?)w.WeenieType,
                IsDone = w.IsDone,
                HasSandboxChange = !w.IsDone && w.LastModified != null
            }).ToList();
        }

        public List<Recipe> RecipeSearch(string token, SearchRecipesCriteria criteria)
        {
            throw new NotImplementedException();
        }

        public HttpStatusCode UpdateContent(string token, Content content)
        {
            throw new NotImplementedException();
        }

        public bool UpdateRecipe(string token, Recipe recipe)
        {
            throw new NotImplementedException();
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
                    copy = copy.Where(w => w.WeenieType == (int)criteria.WeenieType);

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
                WeenieType = (WeenieType?)w.WeenieType,
                IsDone = w.IsDone,
                HasSandboxChange = !w.IsDone && w.LastModified != null
            }).ToList();
        }

        #endregion

        #region Loading

        public void Reload()
        {
            if ((LoadState & LoadingFlags.Busy) == LoadingFlags.None)
            {
                LoadState = LoadingFlags.None;

                LoadWeenies();
            }
        }

        private void SetLoadState(LoadingFlags state, LoadingFlags clear = LoadingFlags.None)
        {
            LoadState &= ~clear;
            LoadState |= state;

            if (LoadState.HasFlag(LoadingFlags.WeenieLoaded))
                Debug.WriteLine("Final Weenie Load Complete");
        }

        protected void LoadWeenies()
        {
            SetLoadState(LoadingFlags.WeenieLoading, LoadingFlags.WeenieLoaded);

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

                SetLoadState(LoadingFlags.WeenieLoaded, LoadingFlags.WeenieLoading);
            });
        }

        #endregion

        private bool SaveWeenie(Weenie weenie)
        {
            if (weenie == null)
                throw new ArgumentNullException(nameof(weenie));

            try
            {
                string path = Path.Combine(ContentPath, "weenies", $"{weenie.WeenieId}.json");
                string content = JsonConvert.SerializeObject(weenie);

                File.WriteAllText(path, content);

                Weenies[weenie.WeenieId] = weenie;

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}