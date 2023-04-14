using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.DataAccess.Models;

namespace ToDoList.DataAccess.Context
{
    public class TaskDetailsDbContext : DbContext
    {
        public TaskDetailsDbContext(DbContextOptions options) : base(options)
        {
        }

        protected TaskDetailsDbContext()
        {

        }
        public DbSet<TaskDetailsModel> TaskDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TaskDetailsModel>(
                entity =>
                {
                    entity.HasKey("TaskID");
                    entity.Property("TaskID");
                    entity.Property("TaskName").HasMaxLength(50);
                    entity.Property("Description").IsRequired();
                    entity.Property("InsertedDate").HasColumnType("datatime");
                    entity.Property("ExpectedTime");
                    entity.Property("DayOfWeek").HasMaxLength(15);
                }
                );
        }
    }
}
