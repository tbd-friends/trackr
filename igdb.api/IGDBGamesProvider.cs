using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Sockets;
using System.Threading.Tasks;
using core;
using core.Extensions;
using Newtonsoft.Json;
using viewmodels;

namespace igdb.api
{
    public class IGDBGamesProvider : IProvideGamesData
    {
        private readonly HttpClient _client;

        public IGDBGamesProvider(HttpClient client)
        {
            _client = client;
        }

        public async Task<IEnumerable<string>> FindCoverArtThumbnails(string name)
        {
            var request = await _client.PostAsync("games",
                new StringContent($"fields name, cover.url, platforms; search \"{name}\";limit 50;"));

            if (request.IsSuccessStatusCode)
            {
                return (from g in await request.Content.ReadAs<GameSearchResult[]>()
                        where g.Cover != null
                        select g.Cover.Url.Replace("t_thumb", "t_cover_small")).Distinct();
            }

            return null;
        }

        public class GameSearchResult
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public CoverArt Cover { get; set; }
            public int[] Platforms { get; set; }
            public string Slug { get; set; }

            public class CoverArt
            {
                public int Id { get; set; }
                public string Url { get; set; }
            }
        }


        public class Platform
        {
            public int Id { get; set; }
            public string Abbreviation { get; set; }
            [JsonProperty("alternative_name")]
            public string AlternativeName { get; set; }
            public int Category { get; set; }
            public int CreatedAt { get; set; }
            public string Name { get; set; }
        }
    }
}