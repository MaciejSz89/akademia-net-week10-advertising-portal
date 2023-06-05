using AdvertisingPortal.Core;
using AdvertisingPortal.Core.Models.Domains;
using AdvertisingPortal.Core.Models.Repositories;

namespace AdvertisingPortal.Persistence.Repositories
{
    public class PictureRepository : IPictureRepository
    {
        private IApplicationDbContext _context;

        public PictureRepository(IApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(IEnumerable<Picture> pictures)
        {
            _context.Pictures.AddRange(pictures);
        }

        public void DeletePictures(string userId, IEnumerable<int> picturesToDeleteId)
        {
            var picturesToDelete = _context.Pictures
                                           .Where(x => x.UserId == userId 
                                                    && picturesToDeleteId.Contains(x.Id));

            _context.Pictures.RemoveRange(picturesToDelete);
        }
    }
}
