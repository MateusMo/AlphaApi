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

    public class LinkTreeMap : IEntityTypeConfiguration<LinkTree>
    {
        public void Configure(EntityTypeBuilder<LinkTree> builder)
        {
            builder.ToTable("LinkTree");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            builder.Property(x => x.UserId)
                .IsRequired()
                .HasColumnName("UserId")
                .HasColumnType("int");

            builder.Property(x => x.Name)
               .IsRequired()
               .HasColumnName("Name")
               .HasColumnType("NVARCHAR")
               .HasMaxLength(100);

            builder.Property(x => x.Description)
               .IsRequired()
               .HasColumnName("Description")
               .HasColumnType("NVARCHAR")
               .HasMaxLength(250);

            builder.Property(x => x.Clicks)
               .IsRequired()
               .HasColumnName("Clicks")
               .HasColumnType("Bigint");

            builder.HasOne(x => x.User)
                .WithMany(x => x.LinkTrees)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.Links)
                .WithOne(x => x.LinkTree)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
