using Microsoft.EntityFrameworkCore;
using OAA.Data.Map;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using OAA.Data.Models;

namespace OAA.Data
{
    public class ApplicationContext : IdentityDbContext<User>
    {
        //public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        //{
        //}
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //    new AuthorMap(modelBuilder.Entity<Author>());
        //    new BookMap(modelBuilder.Entity<Book>());
        //}


        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            new ArtistMap(builder.Entity<Artist>());
            new AlbumMap(builder.Entity<Album>());
            new TrackMap(builder.Entity<Track>());
            new SimilarMap(builder.Entity<Similar>());
            new UserMap(builder.Entity<User>());
        }
    }
}
