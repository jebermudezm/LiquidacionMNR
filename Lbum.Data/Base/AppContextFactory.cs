
namespace Lbum.Data.Base
{
    using Lbum.Data.Models;
    using System.Configuration;
    using System.Data.Entity.Infrastructure;
    public class AppContextFactory //: IDbContextFactory<AppDbContext>
    {
        private readonly AppDbContext _context;

        public AppContextFactory(AppDbContext context)
        {
            _context = context;
        }
        public AppDbContext Create()
        {

            return _context;
        }
    }
}
