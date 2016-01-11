using System;
using Microsoft.Data.Entity;

/*
The entity framework uses context objects as the basis of a collection of entities that it wants to store in the database
    */
namespace DVA231_Projekt.Models
{
    public class ProjectContext : DbContext
    {

        public ProjectContext()
        {
            //Create the database and execute migrations
            db.Database.EnsureCreated();
            //Database.Migrate();
        }

        public DbSet<Textpost> Textposts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connString = Startup.Configuration["Data:ProjectContextConnection"];
            //Optionsbuilder exposes the entities, using SQL Server.
            //Other types of db servers could be shown here if configured, such as MongoDB
            optionsBuilder.UseSqlServer(connString);

            base.OnConfiguring(optionsBuilder);
        }
    }
}
