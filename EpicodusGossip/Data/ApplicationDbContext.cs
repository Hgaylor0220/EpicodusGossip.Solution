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

        public virtual DbSet<Student> Students { get; set; }
        public DbSet<Gossip> Gossips { get; set; }
        public DbSet<StudentGossip> StudentGossip { get; set; }

        public ApplicationDbContext(DbContextOptions options) : base(options) { }



    }
}