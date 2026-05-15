using Microsoft.EntityFrameworkCore;
using Clinic.Shared;
using Clinic.Shared.Model;

namespace Clinic.API.Data
{
    public class ClinicContext : DbContext
    {
        public ClinicContext(DbContextOptions<ClinicContext> options) : base(options) { }

        public DbSet<Specialty> Specialty { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Services> Services { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<MedicalRecord> MedicalRecords { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Facility> Facilities { get; set; }
        public DbSet<News> News { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // 1. Ánh xạ tên bảng SQL
            modelBuilder.Entity<Specialty>().ToTable("Specialties");
            modelBuilder.Entity<Role>().ToTable("Roles");
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<Doctor>().ToTable("Doctors");
            modelBuilder.Entity<Services>().ToTable("Services");
            modelBuilder.Entity<Appointment>().ToTable("Appointments");
            modelBuilder.Entity<MedicalRecord>().ToTable("MedicalRecords");
            modelBuilder.Entity<Invoice>().ToTable("Invoices");
            modelBuilder.Entity<Facility>().ToTable("Facilities");
            modelBuilder.Entity<News>().ToTable("News");

            // 2. Độ chính xác Decimal
            modelBuilder.Entity<Services>()
                .Property(s => s.Price)
                .HasPrecision(18, 2);
            modelBuilder.Entity<Invoice>()
                .Property(i => i.TotalAmount)
                .HasPrecision(18, 2);

            // 3. ✅ Quan hệ Appointment → MedicalRecords (1 - nhiều)
            modelBuilder.Entity<MedicalRecord>()
                .HasOne(m => m.Appointment)
                .WithMany(a => a.MedicalRecords)
                .HasForeignKey(m => m.AppointmentID)
                .OnDelete(DeleteBehavior.Cascade);

            // 4. ✅ Quan hệ Appointment → Invoices (1 - nhiều)
            modelBuilder.Entity<Invoice>()
                .HasOne(i => i.Appointment)
                .WithMany(a => a.Invoices)
                .HasForeignKey(i => i.AppointmentID)
                .OnDelete(DeleteBehavior.Cascade);

            // 5. ✅ Quan hệ Doctor → User (1 - 1)
            modelBuilder.Entity<Doctor>()
                .HasOne(d => d.User)
                .WithOne()
                .HasForeignKey<Doctor>(d => d.UserID)
                .OnDelete(DeleteBehavior.Restrict);

            // 6. ✅ Quan hệ Doctor → Specialty (nhiều - 1)
            modelBuilder.Entity<Doctor>()
                .HasOne(d => d.Specialty)
                .WithMany()
                .HasForeignKey(d => d.SpecialtyID)
                .OnDelete(DeleteBehavior.Restrict);

            // 7. ✅ Quan hệ Appointment → Patient/Doctor/Service
            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Patient)
                .WithMany()
                .HasForeignKey(a => a.PatientID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Doctor)
                .WithMany()
                .HasForeignKey(a => a.DoctorID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Service)
                .WithMany()
                .HasForeignKey(a => a.ServiceID)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}