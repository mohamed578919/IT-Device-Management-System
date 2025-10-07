using ListDevice.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListDevice.Infrastructure.DataContext
{
    public class ListDeviceContext : DbContext
    {
        public ListDeviceContext(DbContextOptions<ListDeviceContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //Validat Device------------------------
            modelBuilder.Entity<Device>(entity =>
            {
                entity.Property(d => d.DeviceName)
                      .IsRequired()
                      .HasMaxLength(50);

                entity.Property(d => d.SerialNo)
                      .HasMaxLength(100);

                entity.Property(d => d.Memo)
                      .HasMaxLength(500);

                entity.HasOne(d => d.Category)
                      .WithMany(c => c.Devices)
                      .HasForeignKey(d => d.CategoryId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.CurrentUser)
                      .WithMany(u => u.Devices)
                      .HasForeignKey(d => d.CurrentUserId)
                      .OnDelete(DeleteBehavior.SetNull);

                // PropertiesJson as text
                entity.Property(d => d.PropertiesJson)
                      .HasColumnType("nvarchar(max)");

                entity.HasData(
                new Device
                {
                    Id = 1,
                    DeviceName = "HP LaserJet Pro",
                    SerialNo = "PR-12345",
                    AcquisitionDate = new DateTime(2023, 5, 10),
                    Memo = "Office Printer",
                    CategoryId = 1, // Printer
                    CurrentUserId = null,
                    PropertyValues = new Dictionary<string, string>
                     {
                        { "IP Address", "192.168.1.25" },
                        { "Is Color", "True" },
                        { "Brand", "HP" }
                    }
                },
                new Device
                {
                    Id = 2,
                    DeviceName = "Dell Latitude",
                    SerialNo = "LT-67890",
                    AcquisitionDate = new DateTime(2022, 11, 2),
                    Memo = "For IT Department",
                    CategoryId = 2,
                    CurrentUserId = 1,// Printer

                    PropertyValues = new Dictionary<string, string>
                        {
                            { "Processor", "Intel Core i7" },
                            { "HD", "512GB SSD" },
                            { "RAM", "16GB" },
                            { "Display", "15.6 inch" },
                            { "IP Address", "192.168.1.50" },
                            { "Brand", "Dell" },
                            { "Current User", "1" }
                        }
                });
            });
            //Validat Device------------------------



            //Validat Category------------------------

            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(c => c.CategoryName)
                      .IsRequired()
                      .HasMaxLength(100);

                // One-to-Many: Category -> Devices
                entity.HasMany(c => c.Devices)
                      .WithOne(d => d.Category)
                      .HasForeignKey(d => d.CategoryId);

                // One-to-Many: Category -> Property 
                entity.HasMany(c => c.CategoryProperties)
                      .WithOne(cp => cp.Category)
                      .HasForeignKey(cp => cp.CategoryId);

                entity.HasData(
                        new Category { Id = 1, CategoryName = "Laptop" },
                        new Category { Id = 2, CategoryName = "Desktop" },
                        new Category { Id = 3, CategoryName = "Printer" },
                        new Category { Id = 4, CategoryName = "Switch" },
                        new Category { Id = 5, CategoryName = "screen" }
                       );
            });
            //Validat Category------------------------



            //Validat Property------------------------

            modelBuilder.Entity<Property>(entity =>
            {
                entity.ToTable("Properties");

                entity.HasKey(p => p.Id);

                entity.Property(p => p.PropertyName)
                      .IsRequired()
                      .HasMaxLength(100);

                entity.Property(p => p.InputType)
                      .IsRequired()
                      .HasMaxLength(50);

                
                entity.HasMany(p => p.CategoryProperties)
                      .WithOne(cp => cp.Property)
                      .HasForeignKey(cp => cp.PropertyId);

                entity.HasData(
                     new Property { Id = 1, PropertyName = "HD", InputType = "text" },
                     new Property { Id = 2, PropertyName = "Processor", InputType = "text" },
                     new Property { Id = 3, PropertyName = "Dimensions", InputType = "text" },
                     new Property { Id = 4, PropertyName = "MAC Address", InputType = "text" },
                     new Property { Id = 5, PropertyName = "IP Address", InputType = "text" },
                     new Property { Id = 6, PropertyName = "Allow USB", InputType = "checkbox" },
                     new Property { Id = 7, PropertyName = "Current User", InputType = "lookup" },
                     new Property { Id = 8, PropertyName = "Network Speed", InputType = "text" },
                     new Property { Id = 9, PropertyName = "Operating System", InputType = "text" },
                     new Property { Id = 10, PropertyName = "Ports", InputType = "number" },
                     new Property { Id = 11, PropertyName = "Is Color", InputType = "checkbox" },
                     new Property { Id = 12, PropertyName = "Brand", InputType = "text" },
                     new Property { Id = 13, PropertyName = "RAM", InputType = "text" },
                     new Property { Id = 14, PropertyName = "Display", InputType = "text" },
                     new Property { Id = 15, PropertyName = "X…", InputType = "text" },
                     new Property { Id = 16, PropertyName = "Y…", InputType = "text" }
                     );
            });
            //Validat Property------------------------


            //Validat CategoryProperty------------------------

            modelBuilder.Entity<CategoryProperty>(entity =>
            {
                entity.ToTable("CategoryProperties");

                // Composite Key
                entity.HasKey(cp => new { cp.CategoryId, cp.PropertyId });

                // One-to-Many  CategoryProperties -> Category
                entity.HasOne(cp => cp.Category)
                      .WithMany(c => c.CategoryProperties)
                      .HasForeignKey(cp => cp.CategoryId);

                // One-to-Many  CategoryProperties -> Property
                entity.HasOne(cp => cp.Property)
                      .WithMany(p => p.CategoryProperties)
                      .HasForeignKey(cp => cp.PropertyId);


                entity.HasData(
            //  Printer 
            new { CategoryId = 3, PropertyId = 5 },   // IP
            new { CategoryId = 3, PropertyId = 11 },  // Is Color
            new { CategoryId = 3, PropertyId = 12 },  // Brand

            //  Laptop
            new { CategoryId = 1, PropertyId = 2 },   // Processor
            new { CategoryId = 1, PropertyId = 1 },   // HD
            new { CategoryId = 1, PropertyId = 13 },  // RAM
            new { CategoryId = 1, PropertyId = 14 },  // Display
            new { CategoryId = 1, PropertyId = 5 },   // IP
            new { CategoryId = 1, PropertyId = 12 },  // Brand
            new { CategoryId = 1, PropertyId = 7 },   // Current User

            //  Switch
            new { CategoryId = 4, PropertyId = 10 },  // Ports
            new { CategoryId = 4, PropertyId = 8 },   // Network Speed
            new { CategoryId = 4, PropertyId = 5 },   // IP
            new { CategoryId = 4, PropertyId = 12 },  // Brand
            new { CategoryId = 4, PropertyId = 15 },  // X…
            new { CategoryId = 4, PropertyId = 16 },   //Y…

            //  Desktop
            new { CategoryId = 2, PropertyId = 2 },   // Processor
            new { CategoryId = 2, PropertyId = 1 },   // HD
            new { CategoryId = 2, PropertyId = 13 },  // RAM
            new { CategoryId = 2, PropertyId = 14 },  // Display
            new { CategoryId = 2, PropertyId = 5 },   // IP
            new { CategoryId = 2, PropertyId = 12 },  // Brand
            new { CategoryId = 2, PropertyId = 7 },   // Current User

            //  screen
            new { CategoryId = 5, PropertyId = 12 },   // Brand
            new { CategoryId = 5, PropertyId = 15 },   // X…
            new { CategoryId = 5, PropertyId = 16 }  // Y…
             );
            });
            //Validat CategoryProperty------------------------


            //Validat User------------------------

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("Users");

                entity.HasKey(u => u.Id);

                entity.Property(u => u.FullName)
                      .IsRequired()
                      .HasMaxLength(200);

                entity.Property(u => u.Department)
                      .HasMaxLength(100);

                // One-to-Many  User -> Devices
                entity.HasMany(u => u.Devices)
                      .WithOne(d => d.CurrentUser)
                      .HasForeignKey(d => d.CurrentUserId)
                      .OnDelete(DeleteBehavior.SetNull);

                entity.HasData(
                    new User { Id = 1, FullName = "Mohamed Mostafa", Department = "IT" },
                    new User { Id = 2, FullName = "Sara Ali", Department = "HR" },
                    new User { Id = 3, FullName = "Omar Hassan", Department = "Finance" },
                    new User { Id = 4, FullName = "Nada Ibrahim", Department = "Marketing" },
                    new User { Id = 5, FullName = "Ahmed Youssef", Department = "Operations" }
                );
            });
            //Validat User------------------------




        }


        public DbSet<Category> categories { get; set; }
        public DbSet<Device> Devices { get; set; }
        public DbSet<CategoryProperty> categoryProperties { get; set; }

        public DbSet<Property> properties { get; set; }

        public DbSet<User> users { get; set; }

    }
}
