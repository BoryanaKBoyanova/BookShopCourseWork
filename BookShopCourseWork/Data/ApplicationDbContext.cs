using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using BookShopCourseWork.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookShopCourseWork.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<AuthorBook> AuthorBooks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=BB-454;Database=BookShop;Trusted_Connection=True;MultipleActiveResultSets=true");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AuthorBook>().HasKey(ab => new { ab.AuthorId, ab.BookId });

            modelBuilder.Entity<AuthorBook>()
                .HasOne<Author>(ab => ab.Author)
                .WithMany(b => b.AuthorBooks)
                .HasForeignKey(ab => ab.AuthorId);


            modelBuilder.Entity<AuthorBook>()
                .HasOne<Book>(sc => sc.Book)
                .WithMany(b => b.AuthorBooks)
                .HasForeignKey(ab => ab.BookId);

            modelBuilder.Entity<GenreBook>().HasKey(gb => new { gb.GenreId, gb.BookId });

            modelBuilder.Entity<GenreBook>()
                .HasOne<Genre>(gb => gb.Genre)
                .WithMany(b => b.GenreBooks)
                .HasForeignKey(gb => gb.GenreId);


            modelBuilder.Entity<GenreBook>()
                .HasOne<Book>(gb => gb.Book)
                .WithMany(b => b.GenreBooks)
                .HasForeignKey(gb => gb.BookId);

            modelBuilder.Entity<OrderBook>().HasKey(ob => new { ob.OrderId, ob.BookId });

            modelBuilder.Entity<OrderBook>()
                .HasOne<Order>(ob => ob.Order)
                .WithMany(b => b.OrderBooks)
                .HasForeignKey(ob => ob.OrderId);


            modelBuilder.Entity<OrderBook>()
                .HasOne<Book>(ob => ob.Book)
                .WithMany(b => b.OrderBooks)
                .HasForeignKey(ob => ob.BookId);
            modelBuilder.Entity<Book>()
            .HasOne<Publisher>(b => b.Publisher)
            .WithMany(p => p.Books)
            .HasForeignKey(b => b.PublisherId);
            base.OnModelCreating(modelBuilder);
        }
    }
}
