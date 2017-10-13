using Embrace.Repository.Entity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Embrace.Repository
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            this.Database.EnsureCreated();
        }

        public DbSet<Contacts> Contacts { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            #region Tables
            builder.Entity<Contacts>();
            #endregion

            #region Relationship
            builder.Entity<Contacts>().HasOne(x => x.ApplicationUser)
                .WithMany(y => y.Contacts).HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.Cascade); 
            #endregion

            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
