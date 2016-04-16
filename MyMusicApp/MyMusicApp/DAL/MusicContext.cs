﻿using MyMusicApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMusicApp.DAL
{
    public class MusicContext : DbContext
    {
        public MusicContext() : base("MusicContext") { }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Song> Songs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Entity<Song>().HasRequired(a => a.Artist).WithMany().WillCascadeOnDelete(false);
        }    
    }
}
