using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Services.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Data.Migrations
{
    public class RankingMap : IEntityTypeConfiguration<Ranking>
    {
        public void Configure(EntityTypeBuilder<Ranking> builder)
        {
            builder.ToTable("Ranking");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            builder.Property(x => x.UserId)
                .IsRequired()
                .HasColumnName("UserId")
                .HasColumnType("int");

            builder.Property(x => x.UserName)
                .IsRequired()
                .HasColumnName("UserName")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(100);

            builder.Property(x => x.LinkId)
                .IsRequired()
                .HasColumnName("LinkId")
                .HasColumnType("int");

            builder.Property(x => x.LinkName)
                .IsRequired()
                .HasColumnName("LinkName")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(100);

            builder.Property(x => x.Photo)
                .IsRequired()
                .HasColumnName("Photo")
                .HasColumnType("int");

            builder.Property(x => x.Clicks)
                .IsRequired()
                .HasColumnName("Clicks")
                .HasColumnType("bigint");
        }
    }
}
