using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hogwards
{
    public class StudyContext : DbContext
    {
        public DbSet <StudyPlan> StudyPlans { get; set; }
        public DbSet <StudyJournal> StudyJournals { get; set; }
        public DbSet <Student> Students { get; set; }
        public DbSet <Groupe> Groupes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Hogwards;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Student>()
               .HasOne(x => x.Groupe)
               .WithMany(c => c.Students)
               .HasForeignKey(b => b.GroupeId)
               .IsRequired(true);

            modelBuilder.Entity<StudyJournal>()
                .HasOne(x => x.StudyPlans)
                .WithMany(c => c.StudyJournal)
                .HasForeignKey(b => b.StudyPlanId)
                .IsRequired(true);

        }
    }
}
