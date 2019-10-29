using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using EpicodusGossip.Models;

namespace EpicodusGossip.Data
{
    
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Gossip> Gossips { get; set; }   

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ApplicationUser>()
                .HasData(
                    new ApplicationUser { ApplicationUserId = 1, Name = "Hailey" },

                    new Gossip { GossipId= 1 , GossipTitle= "", GossipContent= "", ApplicationUserId = 1 }
                );
        }


        




    }
}