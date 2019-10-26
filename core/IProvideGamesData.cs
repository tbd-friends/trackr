using System.Collections.Generic;
using System.Threading.Tasks;
using viewmodels;

namespace core
{
    public interface IProvideGamesData
    {
        Task<IEnumerable<string>> FindCoverArtThumbnails(string name);
    }
}