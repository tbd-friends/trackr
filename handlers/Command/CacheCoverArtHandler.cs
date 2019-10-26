using System;
using System.IO;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Threading;
using System.Threading.Tasks;
using handlers.Commands;
using MediatR;
using Microsoft.Extensions.Configuration;

namespace handlers
{
    public class CacheCoverArtHandler : IRequestHandler<CacheCoverArt, string>
    {
        private readonly IConfiguration _configuration;
        private readonly IHttpClientFactory _httpFactory;

        public CacheCoverArtHandler(IConfiguration configuration, IHttpClientFactory httpFactory)
        {
            _configuration = configuration;
            _httpFactory = httpFactory;
        }

        public async Task<string> Handle(CacheCoverArt request, CancellationToken cancellationToken)
        {
            string savePath = _configuration["coverArt:path"];
            
            var savedFilePath = Path.Combine(AppContext.BaseDirectory, savePath, $"{request.Id}");

            using (var client = _httpFactory.CreateClient())
            {
                var imageRequest = await client.GetAsync($"{request.Url}", cancellationToken);

                if (imageRequest.IsSuccessStatusCode)
                {
                    await File.WriteAllBytesAsync($"{savedFilePath}",
                        await imageRequest.Content.ReadAsByteArrayAsync(), cancellationToken);
                }
            }

            return savedFilePath;
        }
    }
}