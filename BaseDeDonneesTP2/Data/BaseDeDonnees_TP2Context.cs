using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using BaseDeDonneesTP2.Models;

namespace BaseDeDonneesTP2.Data
{
    public partial class BaseDeDonnees_TP2Context : DbContext
    {
        public BaseDeDonnees_TP2Context()
        {
        }

        public BaseDeDonnees_TP2Context(DbContextOptions<BaseDeDonnees_TP2Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Abilite> Abilites { get; set; } = null!;
        public virtual DbSet<AbiliteDunite> AbiliteDunites { get; set; } = null!;
        public virtual DbSet<Arme> Armes { get; set; } = null!;
        public virtual DbSet<ArmeDeModele> ArmeDeModeles { get; set; } = null!;
        public virtual DbSet<ArmeDistance> ArmeDistances { get; set; } = null!;
        public virtual DbSet<ArmeRapproche> ArmeRapproches { get; set; } = null!;
        public virtual DbSet<Changelog> Changelogs { get; set; } = null!;
        public virtual DbSet<Faction> Factions { get; set; } = null!;
        public virtual DbSet<Modele> Modeles { get; set; } = null!;
        public virtual DbSet<ModeleDansUnite> ModeleDansUnites { get; set; } = null!;
        public virtual DbSet<Unite> Unites { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=BD_TP2");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AbiliteDunite>(entity =>
            {
                entity.HasOne(d => d.Abilite)
                    .WithMany(p => p.AbiliteDunites)
                    .HasForeignKey(d => d.AbiliteId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_AbiliteDUnite_AbiliteID");

                entity.HasOne(d => d.Unite)
                    .WithMany(p => p.AbiliteDunites)
                    .HasForeignKey(d => d.UniteId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_AbiliteDUnite_UniteID");
            });

            modelBuilder.Entity<ArmeDeModele>(entity =>
            {
                entity.HasOne(d => d.Arme)
                    .WithMany(p => p.ArmeDeModeles)
                    .HasForeignKey(d => d.ArmeId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_ArmeeDeModele_ArmeID");

                entity.HasOne(d => d.Modele)
                    .WithMany(p => p.ArmeDeModeles)
                    .HasForeignKey(d => d.ModeleId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_ModeleDansUnite_ModeleID");
            });

            modelBuilder.Entity<ArmeDistance>(entity =>
            {
                entity.HasOne(d => d.Arme)
                    .WithMany(p => p.ArmeDistances)
                    .HasForeignKey(d => d.ArmeId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_ArmeDistance_ArmeID");
            });

            modelBuilder.Entity<ArmeRapproche>(entity =>
            {
                entity.HasOne(d => d.Arme)
                    .WithMany(p => p.ArmeRapproches)
                    .HasForeignKey(d => d.ArmeId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_ArmeRapproche_ArmeID");
            });

            modelBuilder.Entity<Changelog>(entity =>
            {
                entity.Property(e => e.InstalledOn).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<ModeleDansUnite>(entity =>
            {
                entity.HasOne(d => d.Modele)
                    .WithMany(p => p.ModeleDansUnites)
                    .HasForeignKey(d => d.ModeleId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_ModeleDansUnite_ModeleID");

                entity.HasOne(d => d.Unite)
                    .WithMany(p => p.ModeleDansUnites)
                    .HasForeignKey(d => d.UniteId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_ModeleDansUnite_UniteID");
            });

            modelBuilder.Entity<Unite>(entity =>
            {
                entity.HasOne(d => d.Faction)
                    .WithMany(p => p.Unites)
                    .HasForeignKey(d => d.FactionId)
                    .HasConstraintName("FK_Unite_FactionID");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
