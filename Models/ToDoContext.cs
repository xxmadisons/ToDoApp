using System;
using Microsoft.EntityFrameworkCore;

namespace ToDoApp.Models
{
    public class ToDoContext : DbContext
    {
        public ToDoContext(DbContextOptions<ToDoContext> options) : base(options)
        {
            //blank for now
        }

        public DbSet<ToDoResponse> Responses { get; set; }

        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {

            mb.Entity<Category>().HasData(
                new Category { CategoryID = 1, CategoryName = "Home" },
                new Category { CategoryID = 2, CategoryName = "School" },
                new Category { CategoryID = 3, CategoryName = "Work" },
                new Category { CategoryID = 4, CategoryName = "Church" }
            );

            mb.Entity<ToDoResponse>().HasData(

                   new ToDoResponse
                   {
                       TaskID = 1,
                       CategoryID = 2,
                       Task = "Finish 413 mission #6",
                       DueDate = "02/09/2022",
                       Quadrant = 1,
                       Completed = false,
                   }
           );
        }
    }
}
