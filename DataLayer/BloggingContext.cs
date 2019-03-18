using DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace DataLayer
{
    public class BloggingContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = (localdb)\\mssqllocaldb; Database = BloggingDb; Trusted_Connection = True; ")
            .EnableSensitiveDataLogging(true)
            .UseLoggerFactory(new ServiceCollection()
            .AddLogging(builder => builder.AddConsole()
                .AddFilter(DbLoggerCategory.Database.Command.Name, LogLevel.Information))
                .BuildServiceProvider().GetService<ILoggerFactory>());
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>()
                .HasOne(p => p.Photo)
                .WithOne(p => p.Person)
                .HasForeignKey<PersonPhoto>(p => p.PersonId);

            // ************************ Data Seeding ***************************

            modelBuilder.Entity<Person>().HasData(
               new { PersonId = 1, Name = "Person 1" },
               new { PersonId = 2, Name = "Person 2" },
               new { PersonId = 3, Name = "Person 3" },
               new { PersonId = 4, Name = "Person 4" },
               new { PersonId = 5, Name = "Person 5" },
               new { PersonId = 6, Name = "Person 6" }
               );

            modelBuilder.Entity<PersonPhoto>().HasData(
                new  { PersonPhotoId = 1, Caption = "PersonPhoto 1", Photo = new byte[] { 65, 66, 67 }, PersonId = 1 },
                new  { PersonPhotoId = 2, Caption = "PersonPhoto 2", Photo = new byte[] { 68, 69, 70 }, PersonId = 2 },
                new  { PersonPhotoId = 3, Caption = "PersonPhoto 3", Photo = new byte[] { 71, 72, 73 }, PersonId = 3 },
                new  { PersonPhotoId = 4, Caption = "PersonPhoto 4", Photo = new byte[] { 74, 75, 76 }, PersonId = 4 },
                new  { PersonPhotoId = 5, Caption = "PersonPhoto 5", Photo = new byte[] { 77, 78, 79 }, PersonId = 5 }
                );

            modelBuilder.Entity<Blog>().HasData(
                new { BlogId = 1, Url = "http://blog1.com", OwnerId = 1, Rating = 3 },
                new { BlogId = 2, Url = "http://blog2.com", OwnerId = 2, Rating = 2 },
                new { BlogId = 3, Url = "http://blog3.com", OwnerId = 3, Rating = 1 },
                new { BlogId = 4, Url = "http://blog5.com" }
                );

            modelBuilder.Entity<Post>().HasData(
                new  { PostId = 1, Title = "Post 1", Content = "Dette er Post 1 i Blog 1", Rating = 2, BlogId = 1, AuthorId = 1 },
                new  { PostId = 2, Title = "Post 2", Content = "Dette er Post 2 i Blog 1", Rating = 3, BlogId = 1, AuthorId = 4 },
                new  { PostId = 3, Title = "Post 3", Content = "Dette er Post 3 i Blog 1", Rating = 4, BlogId = 1, AuthorId = 4 },
                new  { PostId = 4, Title = "Post 1", Content = "Dette er post 1 i Blog 2", Rating = 1, BlogId = 2, AuthorId = 5 },
                new  { PostId = 5, Title = "Post 2", Content = "Dette er post 2 i Blog 2", Rating = 2, BlogId = 2, AuthorId = 6 },
                new  { PostId = 6, Title = "Post 1", Content = "Dette er post 1 i Blog 3", Rating = 3, BlogId = 3 }
                );

            modelBuilder.Entity<Tag>().HasData(
              new  { TagId = "Photo" },
              new  { TagId = "Sport" },
              new  { TagId = "News" },
              new  { TagId = "Money" },
              new  { TagId = "Living" },
              new  { TagId = "Children" }
              );

            modelBuilder.Entity<PostTag>().HasData(
              new  { PostTagId = 1, PostId = 1, TagId = "Sport" },
              new  { PostTagId = 2, PostId = 2, TagId = "Sport" },
              new  { PostTagId = 3, PostId = 2, TagId = "News" },
              new  { PostTagId = 4, PostId = 3, TagId = "News" },
              new  { PostTagId = 5, PostId = 4, TagId = "Living" },
              new  { PostTagId = 6, PostId = 5, TagId = "Photo" },
              new  { PostTagId = 7, PostId = 6, TagId = "News" }
              );
        }

    }
}
