using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;   
using SuperDigital.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperDigital.Infra.Data.Context
{


    public class SqlContext : DbContext
    {
        public SqlContext(DbContextOptions<SqlContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Conta>().ToTable("Conta");
            modelBuilder.Entity<Lancamento>().ToTable("Lancamento");

            modelBuilder.Entity<Conta>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(p => p.Saldo).IsRequired();
            });

            modelBuilder.Entity<Lancamento>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasIndex(e => e.Id);

                entity.Property(p => p.Id).IsRequired();
                
                entity.Property(p => p.Valor).IsRequired();

                entity.HasOne(d => d.Conta)
                .WithMany(p => p.Lancamentos)
                .HasForeignKey(d => d.Id);  
                
            });
        }

        public DbSet<Conta> Contas { get; set; }
        public DbSet<Lancamento> Lancamentos { get; set; }
    }
}
