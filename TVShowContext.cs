using Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class TVShowContext:DbContext
    {
        public TVShowContext() : base()
        {

        }
        public DbSet<Show> Shows { get; set; }
        public DbSet<Contestant> Contestants { get; set; }
        public DbSet<ShowContestant> ShowContestants { get; set; }
        public DbSet<Quiz> Quizes { get; set; }
        public DbSet<Question> Questions {  get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Show>().ToTable("Show");
            modelBuilder.Entity<Show>()
                .HasKey(s => s.id);

            modelBuilder.Entity<Contestant>().ToTable("Contestant");
            modelBuilder.Entity<Contestant>()
                .HasKey(c=>c.id);

            modelBuilder.Entity<ShowContestant>().ToTable("Show_Contestant");
            modelBuilder.Entity<ShowContestant>()
               .HasKey(sc => new { sc.showId, sc.contestantId });
            modelBuilder.Entity<ShowContestant>()
                .HasOne(s => s.Show)
                .WithMany(sc => sc.ShowContestant)
                .HasForeignKey(s => s.showId);
            modelBuilder.Entity<ShowContestant>()
                .HasOne(c => c.Contestant)
                .WithMany(sc => sc.ShowContestant)
                .HasForeignKey(c => c.contestantId);

            modelBuilder.Entity<Quiz>().ToTable("Quiz");
            modelBuilder.Entity<Quiz>()
                .HasKey(q=>q.id);
            modelBuilder.Entity<Quiz>()
                .HasOne(q => q.Show)
                .WithMany(q => q.Quizes)
                .HasForeignKey(q => q.showId)
                .HasConstraintName("show_id");

            modelBuilder.Entity<Question>().ToTable("Question");
            modelBuilder.Entity<Question>()
                .HasKey(q => q.id);
            modelBuilder.Entity<Question>()
                .HasOne(q=>q.Quiz)
                .WithMany(q => q.Questions)
                .HasForeignKey(q=>q.quizId)
                .HasConstraintName("question_id");
            base.OnModelCreating(modelBuilder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=STUDENT15;Initial Catalog=TVShow;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }
    }
}
