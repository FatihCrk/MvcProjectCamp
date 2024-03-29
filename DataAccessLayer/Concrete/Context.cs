﻿using System.Data.Entity;
using EntityLayer.Concrete;

namespace DataAccessLayer.Concrete
{
    public class Context:DbContext
    {

        public DbSet<About> Abouts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Content> Contents { get; set; }
        public DbSet<Heading> Headings { get; set; }
        public DbSet<Writer> Writers { get; set; }
        public DbSet <Message> Messages { get; set; }
        public DbSet<ImageFile> ImageFiles { get; set;}
        public DbSet<Admin> Admins { get; set; }

        public DbSet<Role> Roles { get; set; }
        public DbSet<MyAbout> MyAbouts { get; set; }
        
        /*DbSet Bağlantıları*/

     
    }
}
