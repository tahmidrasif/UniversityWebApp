﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using UniversityWebApp.Areas.Admin.Models;

namespace UniversityWebApp.Repository
{
    public class MyDbContext:DbContext
    {
        public MyDbContext()
            : base("UniversityWebApp")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder); //
        }

        public DbSet<User> Users { get; set; }
    }
}