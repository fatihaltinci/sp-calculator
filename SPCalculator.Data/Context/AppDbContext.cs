using Microsoft.EntityFrameworkCore;
using SPCalculator.Entity.Entities;
using System.Reflection;

namespace SPCalculator.Data.Context
{
    public class AppDbContext : DbContext
    {
        protected AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Sprint> Sprints { get; set; }
        public DbSet<Function> Functions { get; set; }
        public DbSet<Parameter> Parameters { get; set; }
        public DbSet<SprintFunction> SprintFunctions { get; set; }
        public DbSet<SprintParameter> SprintParameters { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.Entity<SprintFunction>()
                .HasKey(sf => new { sf.SprintId, sf.FunctionId }); // Hangi sütunların birleşimi unique olacak

            modelBuilder.Entity<SprintFunction>()
                .HasOne(sf => sf.Sprint)
                .WithMany(s => s.SprintFunctions) // Sprintle Function arasında 1-N ilişki var
                .HasForeignKey(sf => sf.SprintId) // SprintId ForeignKey olarak kullanılacak
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<SprintFunction>()
                .HasOne(sf => sf.Function)
                .WithMany(f => f.SprintFunctions) // İlişkiyi kurduğumuz yer böylece ekstra sütun oluşmayacak
                .HasForeignKey(sf => sf.FunctionId);

            modelBuilder.Entity<SprintParameter>()
                .HasKey(sp => new { sp.SprintId, sp.ParameterId }); // Hangi sütunların birleşimi unique olacak

            modelBuilder.Entity<SprintParameter>()
                .HasOne(sp => sp.Sprint)
                .WithMany(s => s.SprintParameters) // Sprintle Parameter arasında 1-N ilişki var
                .HasForeignKey(sp => sp.SprintId) // SprintId ForeignKey olarak kullanılacak
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<SprintParameter>()
                .HasOne(sp => sp.Parameter)
                .WithMany(p => p.SprintParameters) // İlişkiyi kurduğumuz yer böylece ekstra sütun oluşmayacak
                .HasForeignKey(sp => sp.ParameterId);
        }
    }
}
