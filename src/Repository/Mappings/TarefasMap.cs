using Infra.Data.Minimal.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Data.Minimal.Repository.Mappings
{
    public class TarefasMap : IEntityTypeConfiguration<Tarefas>
    {
        public void Configure(EntityTypeBuilder<Tarefas> builder)
        {
            builder.ToTable("tarefas");

            builder
                .HasKey(t => t.Id)
                .HasName("PK_tarefas");

            builder
                .Property(t => t.Titulo)
                .HasColumnName("titulo")
                .HasColumnType("varchar")
                .HasMaxLength(100);

            builder
                .Property(t => t.Descricao)
                .HasColumnName("descricao")
                .HasColumnType("varchar")
                .HasMaxLength(2000);

            builder
                .Property(t => t.Feito)
                .HasColumnName("feito")
                .HasColumnType("int")
                .HasDefaultValue(0);
        }
    }
}
