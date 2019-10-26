using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using handlers.Commands;
using MediatR;
using Microsoft.EntityFrameworkCore.Internal;
using models;
using persistence;

namespace handlers
{
    public class AddGameCopyHandler : IRequestHandler<AddGameCopy>
    {
        private readonly GamesContext _dataStore;

        public AddGameCopyHandler(GamesContext dataStore)
        {
            _dataStore = dataStore;
        }

        public async Task<Unit> Handle(AddGameCopy request, CancellationToken cancellationToken)
        {
            var tagsToUse = await GetTags(request, cancellationToken);

            var gameCopy = new GameCopy
            {
                PricePaid = request.PricePaid,
                PurchasedOn = request.PurchasedOn,
                GameId = request.GameId,
                Tags = new List<GameCopyTag>(tagsToUse.Select(t => new GameCopyTag() { Tag = t }))
            };

            await _dataStore.GameCopies.AddAsync(gameCopy, cancellationToken);

            await _dataStore.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }

        private async Task<List<Tag>> GetTags(AddGameCopy request, CancellationToken cancellationToken)
        {
            List<Tag> tagsToUse = (from x in request.Tags
                join tags in _dataStore.Tags on x equals tags.Value
                select tags).ToList();

            var tagsThatNeedAdding = request.Tags.Where(t => tagsToUse.All(c => c.Value != t));

            foreach (var tagToAdd in tagsThatNeedAdding)
            {
                var tag = new Tag() {Value = tagToAdd, TimeStamp = DateTime.UtcNow};

                await _dataStore.Tags.AddAsync(tag, cancellationToken);

                tagsToUse.Add(tag);
            }

            return tagsToUse;
        }
    }
}