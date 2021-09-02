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


        
        /*DbSet Bağlantıları*/

     
    }
}
