using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Employeemanage.Models;

namespace Employeemanage.Data
{
    public class EmployeemanageContext : DbContext
    {
        public EmployeemanageContext(DbContextOptions<EmployeemanageContext> options)
            : base(options)
        {
        }

        public DbSet<Login> Login { get; set; } = default!;
        public DbSet<Admin> Admin { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<Admin>()
                .HasOne(a => a.Login)  
                .WithMany()  
                .HasForeignKey(a => a.EmployeeId)
                .OnDelete(DeleteBehavior.Cascade); 

            base.OnModelCreating(modelBuilder);
        }
    }
}