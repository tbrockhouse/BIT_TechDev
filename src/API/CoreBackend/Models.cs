using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CoreBackend.Database
{
    public class TaskContext : DbContext
    {
       public DbSet<Task> Tasks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=./db.sqlite");
        }
    }

    public class Task
    {
        public int Id { get; set; }
        public string Description { get; set; }
    }


}
