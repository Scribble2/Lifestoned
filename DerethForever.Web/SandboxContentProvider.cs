/*****************************************************************************************
Copyright 2018 Dereth Forever

Permission is hereby granted, free of charge, to any person obtaining a copy of this
software and associated documentation files (the "Software"), to deal in the Software
without restriction, including without limitation the rights to use, copy, modify, merge,
publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons
to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or
substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED,
INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR
PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE
FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR
OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER
DEALINGS IN THE SOFTWARE.
*****************************************************************************************/
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using DerethForever.Web.Models.Account;
using DerethForever.Web.Models.Content;
using DerethForever.Web.Models.Recipe;
using DerethForever.Web.Models.WorldRelease;
using DerethForever.Web.Models.Weenie;
using log4net;
using Newtonsoft.Json;

namespace DerethForever.Web
{
    public class SandboxContentProvider : ISandboxContentProvider
    {
        private static readonly ILog log = LogManager.GetLogger("SandboxingContentProvider");

        private IContentProvider _backingProvider;

        private string _cacheDirectory;

        private ConcurrentDictionary<Guid, Dictionary<uint, string>> _weenieCache;
        private ConcurrentDictionary<Guid, Dictionary<Guid, string>> _recipeCache;
        private ConcurrentDictionary<Guid, Dictionary<Guid, string>> _contentCache;

        public SandboxContentProvider(IContentProvider backingProvider, string cacheDirectory)
        {
            _backingProvider = backingProvider;
            _cacheDirectory = cacheDirectory;

            ReloadCache();
        }

        public void ReloadCache()
        {
            if (!Directory.Exists(_cacheDirectory))
            {
                log.Error("caching directory does not exist: " + _cacheDirectory);
                log.Warn("caching is disabled.");
                return;
            }

            ReloadWeenieCache();
            ReloadRecipeCache();
            ReloadContentCache();
        }

        private void ReloadWeenieCache()
        {
            _weenieCache = new ConcurrentDictionary<Guid, Dictionary<uint, string>>();
            string weenieFolder = Path.Combine(_cacheDirectory, "weenies");

            if (!Directory.Exists(weenieFolder))
                Directory.CreateDirectory(weenieFolder);

            // build cache from disk
            var userDirectories = Directory.EnumerateDirectories(weenieFolder);

            foreach (var userDir in userDirectories)
            {
                Guid userGuid;
                string userGuidString = userDir.Substring(userDir.LastIndexOf("\\") + 1);
                if (!Guid.TryParse(userGuidString, out userGuid))
                    continue;

                _weenieCache.TryAdd(userGuid, new Dictionary<uint, string>());
                string userPath = Path.Combine(weenieFolder, userDir);

                var files = Directory.EnumerateFiles(userPath, "*.json");
                foreach (string file in files)
                {
                    try
                    {
                        // file is "{WeenieID}.json"
                        int begin = file.LastIndexOf("\\") + 1;
                        int end = file.IndexOf(".", begin);

                        string weenieIdString = file.Substring(begin, end - begin);
                        uint weenieId = uint.Parse(weenieIdString);

                        // weenie id 0 is invalid by definition
                        if (weenieId == 0)
                            continue;

                        _weenieCache[userGuid].Add(weenieId, Path.Combine(userPath, file));
                    }
                    catch (Exception ex)
                    {
                        log.Error($"Error loading {file} from weenie cache.", ex);
                    }
                }
            }
        }

        private void ReloadRecipeCache()
        {
            _recipeCache = new ConcurrentDictionary<Guid, Dictionary<Guid, string>>();
            string cacheFolder = Path.Combine(_cacheDirectory, "recipes");

            if (!Directory.Exists(cacheFolder))
                Directory.CreateDirectory(cacheFolder);

            // build cache from disk
            var userDirectories = Directory.EnumerateDirectories(cacheFolder);

            foreach (var userDir in userDirectories)
            {
                Guid userGuid;

                if (!Guid.TryParse(userDir, out userGuid))
                    continue;

                _recipeCache.TryAdd(userGuid, new Dictionary<Guid, string>());
                string userPath = Path.Combine(cacheFolder, userDir);

                var files = Directory.EnumerateFiles(userPath, "*.json");
                foreach (string file in files)
                {
                    try
                    {
                        // file is "{RecipeGuid}.json"
                        int begin = file.LastIndexOf("\\") + 1;
                        int end = file.IndexOf(".", begin);

                        string recipeGuidString = file.Substring(begin, end - begin);
                        Guid recipeGuid = Guid.Parse(recipeGuidString);

                        _recipeCache[userGuid].Add(recipeGuid, Path.Combine(userPath, file));
                    }
                    catch (Exception ex)
                    {
                        log.Error($"Error loading {file} from recipe cache.", ex);
                    }
                }
            }
        }

        private void ReloadContentCache()
        {
            _contentCache = new ConcurrentDictionary<Guid, Dictionary<Guid, string>>();
            string cacheFolder = Path.Combine(_cacheDirectory, "content");

            if (!Directory.Exists(cacheFolder))
                Directory.CreateDirectory(cacheFolder);

            // build cache from disk
            var userDirectories = Directory.EnumerateDirectories(cacheFolder);

            foreach (var userDir in userDirectories)
            {
                Guid userGuid;

                if (!Guid.TryParse(userDir, out userGuid))
                    continue;

                _contentCache.TryAdd(userGuid, new Dictionary<Guid, string>());
                string userPath = Path.Combine(cacheFolder, userDir);

                var files = Directory.EnumerateFiles(userPath, "*.json");
                foreach (string file in files)
                {
                    try
                    {
                        // file is "{ContentGuid}.json"
                        int begin = file.LastIndexOf("\\") + 1;
                        int end = file.IndexOf(".", begin);

                        string contentGuidString = file.Substring(begin, end - begin);
                        Guid contentGuid = Guid.Parse(contentGuidString);

                        _contentCache[userGuid].Add(contentGuid, Path.Combine(userPath, file));
                    }
                    catch (Exception ex)
                    {
                        log.Error($"Error loading {file} from content cache.", ex);
                    }
                }
            }
        }

        public List<Content> GetAllContentChanges()
        {
            List<Content> everything = new List<Content>();

            foreach (var c in _contentCache)
            {
                foreach (var file in c.Value.Values)
                {
                    everything.Add(JsonConvert.DeserializeObject<Content>(File.ReadAllText(file)));
                }
            }

            return everything;
        }

        public List<Recipe> GetAllRecipeChanges()
        {
            List<Recipe> everything = new List<Recipe>();

            foreach (var c in _recipeCache)
            {
                foreach (var file in c.Value.Values)
                {
                    everything.Add(JsonConvert.DeserializeObject<Recipe>(File.ReadAllText(file)));
                }
            }

            return everything;
        }

        public List<WeenieChange> GetAllWeenieChanges()
        {
            List<WeenieChange> everything = new List<WeenieChange>();

            foreach (var c in _weenieCache)
            {
                foreach (var file in c.Value.Values)
                {
                    var wc = JsonConvert.DeserializeObject<WeenieChange>(File.ReadAllText(file));
                    if (wc != null)
                        everything.Add(wc);
                }
            }

            return everything;
        }

        public List<WeenieChange> GetMyWeenieChanges(string token)
        {
            string userGuidString = JwtCookieManager.GetUserGuid(token);
            Guid userGuid = Guid.Parse(userGuidString);
            List<WeenieChange> mine = new List<WeenieChange>();

            if (_weenieCache.ContainsKey(userGuid))
            {
                var c = _weenieCache[userGuid];
                foreach (var file in c.Values)
                {
                    var wc = JsonConvert.DeserializeObject<WeenieChange>(File.ReadAllText(file));
                    if (wc != null)
                        mine.Add(wc);
                }
            }

            return mine;
        }

        public List<Content> GetAllContent(string token)
        {
            return _backingProvider.GetAllContent(token);
        }

        public Content GetContent(string token, Guid contentGuid)
        {
            Guid userGuid = Guid.Parse(JwtCookieManager.GetUserGuid(token));

            if (_contentCache.ContainsKey(userGuid) && _contentCache[userGuid].ContainsKey(contentGuid))
            {
                string file = _contentCache[userGuid][contentGuid];
                return JsonConvert.DeserializeObject<Content>(File.ReadAllText(file));
            }

            return _backingProvider.GetContent(token, contentGuid);
        }

        public Content GetContentFromSource(string token, Guid contentGuid)
        {
            return _backingProvider.GetContent(token, contentGuid);
        }

        public byte[] GetFullyLayeredPngIcon(uint weenieClassId)
        {
            return _backingProvider.GetFullyLayeredPngIcon(weenieClassId);
        }

        public byte[] GetWorldRelease(string token, string fileName)
        {
            return _backingProvider.GetWorldRelease(token, fileName);
        }

        public byte[] GetCurrentWorldRelease(string token)
        {
            return _backingProvider.GetCurrentWorldRelease(token);
        }

        public WorldRelease GetCurrentWorldReleaseInfo(string token)
        {
            return _backingProvider.GetCurrentWorldReleaseInfo(token);
        }

        public WorldRelease GetWorldReleaseInfo(string token, string fileName)
        {
            return _backingProvider.GetWorldReleaseInfo(token, fileName);
        }

        public Recipe GetRecipe(string token, Guid recipeGuid)
        {
            Guid userGuid = Guid.Parse(JwtCookieManager.GetUserGuid(token));

            if (_recipeCache.ContainsKey(userGuid) && _recipeCache[userGuid].ContainsKey(recipeGuid))
            {
                string file = _recipeCache[userGuid][recipeGuid];
                return JsonConvert.DeserializeObject<Recipe>(File.ReadAllText(file));
            }

            return _backingProvider.GetRecipe(token, recipeGuid);
        }

        public Recipe GetRecipeFromSource(string token, Guid recipeGuid)
        {
            return _backingProvider.GetRecipe(token, recipeGuid);
        }

        public Weenie GetWeenie(string token, uint weenieClassId)
        {
            if (token != null)
            {
                string userGuidString = JwtCookieManager.GetUserGuid(token);

                Guid userGuid = Guid.Parse(userGuidString);

                if (_weenieCache != null && _weenieCache.ContainsKey(userGuid) &&
                    _weenieCache[userGuid].ContainsKey(weenieClassId))
                {
                    string file = _weenieCache[userGuid][weenieClassId];
                    WeenieChange wc = JsonConvert.DeserializeObject<WeenieChange>(File.ReadAllText(file));
                    return wc.Weenie;
                }
            }

            return _backingProvider.GetWeenie(token, weenieClassId);
        }

        public Weenie GetWeenieFromSource(string token, uint weenieClassId)
        {
            return _backingProvider.GetWeenie(token, weenieClassId);
        }

        public List<Recipe> RecipeSearch(string token, SearchRecipesCriteria criteria)
        {
            return _backingProvider.RecipeSearch(token, criteria);
        }

        public HttpStatusCode UpdateContent(string token, Content content)
        {
            return _backingProvider.UpdateContent(token, content);
        }

        public bool UpdateWeenie(string token, Weenie weenie)
        {
            return SaveWeenie(token, weenie);
        }

        public List<WeenieSearchResult> WeenieSearch(string token, SearchWeeniesCriteria criteria)
        {
            return _backingProvider.WeenieSearch(token, criteria);
        }

        public List<WeenieSearchResult> RecentChanges(string token)
        {
            return _backingProvider.RecentChanges(token);
        }

        public List<WeenieSearchResult> AllUpdates(string token)
        {
            return _backingProvider.AllUpdates(token);
        }

        public bool CreateWeenie(string token, Weenie weenie)
        {
            return SaveWeenie(token, weenie);
        }

        private bool SaveWeenie(string token, Weenie weenie)
        {
            if (_weenieCache == null)
                throw new ApplicationException("Sandboxing is not configured correctly.  See error logs for details.");

            string userGuidString = JwtCookieManager.GetUserGuid(token);
            Guid userGuid = Guid.Parse(userGuidString);
            string weenieFolder = Path.Combine(_cacheDirectory, "weenies", userGuid.ToString());

            if (!Directory.Exists(weenieFolder))
                Directory.CreateDirectory(weenieFolder);

            WeenieChange wc = null;
            string weenieFile = Path.Combine(weenieFolder, $"{weenie.WeenieClassId}.json");
            if (File.Exists(weenieFile))
            {
                // replace the weenie
                wc = JsonConvert.DeserializeObject<WeenieChange>(File.ReadAllText(weenieFile));
                wc.Weenie = weenie;
                wc.Submitted = false;
            }
            else
            {
                wc = new WeenieChange();
                wc.UserGuid = JwtCookieManager.GetUserGuid(token);
                wc.Weenie = weenie;
                wc.UserName = JwtCookieManager.GetUserDisplayName(token);
                wc.SubmissionTime = DateTime.Now;
            }

            string content = JsonConvert.SerializeObject(wc);
            File.WriteAllText(weenieFile, content);

            if (!_weenieCache.ContainsKey(userGuid))
                _weenieCache.TryAdd(userGuid, new Dictionary<uint, string>());

            if (!_weenieCache[userGuid].ContainsKey(weenie.WeenieClassId))
                _weenieCache[userGuid].Add(weenie.WeenieClassId, weenieFile);

            return true;
        }

        public bool UpdateRecipe(string token, Recipe recipe)
        {
            return _backingProvider.UpdateRecipe(token, recipe);
        }

        public bool DeleteWeenie(string token, uint weenieClassId)
        {
            return _backingProvider.DeleteWeenie(token, weenieClassId);
        }

        public WeenieChange GetSandboxedChange(Guid userGuid, uint weenieClassId)
        {
            if (_weenieCache.ContainsKey(userGuid) && _weenieCache[userGuid].ContainsKey(weenieClassId))
            {
                string fileName = _weenieCache[userGuid][weenieClassId];
                WeenieChange wc = JsonConvert.DeserializeObject<WeenieChange>(File.ReadAllText(fileName));
                return wc;
            }

            return null;
        }

        public WeenieChange GetMySandboxedChange(string token, uint weenieClassId)
        {
            string userGuidString = JwtCookieManager.GetUserGuid(token);
            Guid userGuid = Guid.Parse(userGuidString);
            if (_weenieCache.ContainsKey(userGuid) && _weenieCache[userGuid].ContainsKey(weenieClassId))
            {
                string fileName = _weenieCache[userGuid][weenieClassId];
                WeenieChange wc = JsonConvert.DeserializeObject<WeenieChange>(File.ReadAllText(fileName));
                return wc;
            }

            return null;
        }

        public void UpdateWeenieChange(string changeOwnerGuid, WeenieChange wc)
        {
            string userGuidString = changeOwnerGuid;
            uint wcid = wc.Weenie.WeenieClassId;
            Guid userGuid = Guid.Parse(userGuidString);

            string weenieFolder = Path.Combine(_cacheDirectory, "weenies", userGuid.ToString());

            if (!Directory.Exists(weenieFolder))
                Directory.CreateDirectory(weenieFolder);

            string weenieFile = Path.Combine(weenieFolder, $"{wcid}.json");
            string content = JsonConvert.SerializeObject(wc);
            File.WriteAllText(weenieFile, content);
        }

        public void DeleteWeenieChange(string changeOwnerGuid, WeenieChange wc)
        {
            string userGuidString = changeOwnerGuid;
            uint wcid = wc.Weenie.WeenieClassId;
            Guid userGuid = Guid.Parse(userGuidString);

            string weenieFolder = Path.Combine(_cacheDirectory, "weenies", userGuid.ToString());

            if (!Directory.Exists(weenieFolder))
                Directory.CreateDirectory(weenieFolder);

            if (_weenieCache[userGuid].ContainsKey(wc.Weenie.WeenieClassId))
                _weenieCache[userGuid].Remove(wc.Weenie.WeenieClassId);

            string weenieFile = Path.Combine(weenieFolder, $"{wcid}.json");
            if (File.Exists(weenieFile))
                File.Delete(weenieFile);
        }

        public bool UpdateWeenieInSource(string token, Weenie weenie)
        {
            return _backingProvider.UpdateWeenie(token, weenie);
        }

        public WorldRelease CutWorldRelease(string token, ReleaseType releaseType)
        {
            return _backingProvider.CutWorldRelease(token, releaseType);
        }
    }
}
