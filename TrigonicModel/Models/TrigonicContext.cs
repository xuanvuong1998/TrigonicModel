using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TrigonicModel.Models
{
    public partial class TrigonicContext : DbContext
    {
        public TrigonicContext()
        {
            
        }

        public TrigonicContext(DbContextOptions<TrigonicContext> options)
            : base(options)
        {
            
        }

        public virtual DbSet<InvestmentTerm> InvestmentTerm { get; set; }
        public virtual DbSet<PaymentAccount> PaymentAccount { get; set; }
        public virtual DbSet<Project> Project { get; set; }
        public virtual DbSet<ProjectBonus> ProjectBonus { get; set; }
        public virtual DbSet<TeamMember> TeamMember { get; set; }
        public virtual DbSet<TermType> TermType { get; set; }
        public virtual DbSet<Transaction> Transaction { get; set; }
        public virtual DbSet<TransactionBonus> TransactionBonus { get; set; }
        public virtual DbSet<UserAccount> UserAccount { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=localhost;Database=SWD_TRIGONIC;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<InvestmentTerm>(entity =>
            {
                entity.Property(e => e.TermTypeId).HasColumnName("TermTypeID");

                entity.HasOne(d => d.TermType)
                    .WithMany(p => p.InvestmentTerm)
                    .HasForeignKey(d => d.TermTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_InvestmentTerm_TermType");
            });

            modelBuilder.Entity<PaymentAccount>(entity =>
            {
                entity.Property(e => e.AccountNumber)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.OwnerName)
                    .IsRequired()
                    .HasMaxLength(250);
            });

            modelBuilder.Entity<Project>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Creator)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.ImageUrl)
                    .HasColumnName("ImageURL")
                    .HasMaxLength(500);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.TermId).HasColumnName("TermID");

                entity.HasOne(d => d.CreatorNavigation)
                    .WithMany(p => p.Project)
                    .HasForeignKey(d => d.Creator)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Project_UserAccount1");

                entity.HasOne(d => d.Term)
                    .WithMany(p => p.Project)
                    .HasForeignKey(d => d.TermId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Project_InvestmentTerm");
            });

            modelBuilder.Entity<ProjectBonus>(entity =>
            {
                entity.Property(e => e.BonusDesc).IsRequired();

                entity.Property(e => e.Title).HasMaxLength(250);

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.ProjectBonus)
                    .HasForeignKey(d => d.ProjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProjectBonus_Project1");
            });

            modelBuilder.Entity<TeamMember>(entity =>
            {
                entity.Property(e => e.AvatarImageUrl)
                    .HasColumnName("AvatarImageURL")
                    .HasMaxLength(500);

                entity.Property(e => e.Description).IsRequired();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.Position)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.TeamMember)
                    .HasForeignKey(d => d.ProjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TeamMember_Project");
            });

            modelBuilder.Entity<TermType>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Desp).IsRequired();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Transaction>(entity =>
            {
                entity.HasKey(e => e.TransactionNumber);

                entity.Property(e => e.TransactionNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Actor)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.ProjectId).HasColumnName("ProjectID");

                entity.HasOne(d => d.ActorNavigation)
                    .WithMany(p => p.Transaction)
                    .HasForeignKey(d => d.Actor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Transaction_UserAccount");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.Transaction)
                    .HasForeignKey(d => d.ProjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Transaction_Project");
            });

            modelBuilder.Entity<TransactionBonus>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.TransactionNumber)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Bonus)
                    .WithMany(p => p.TransactionBonus)
                    .HasForeignKey(d => d.BonusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TransactionBonus_ProjectBonus");

                entity.HasOne(d => d.TransactionNumberNavigation)
                    .WithMany(p => p.TransactionBonus)
                    .HasForeignKey(d => d.TransactionNumber)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TransactionBonus_Transaction");
            });

            modelBuilder.Entity<UserAccount>(entity =>
            {
                entity.HasKey(e => e.Username);

                entity.Property(e => e.Username).HasMaxLength(250);

                entity.Property(e => e.Address).HasMaxLength(500);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.PaymentId).HasColumnName("PaymentID");

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Payment)
                    .WithMany(p => p.UserAccount)
                    .HasForeignKey(d => d.PaymentId)
                    .HasConstraintName("FK_UserAccount_PaymentType");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
