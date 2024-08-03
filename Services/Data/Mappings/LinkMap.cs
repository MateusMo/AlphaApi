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
    public class LinkMap : IEntityTypeConfiguration<Link>
    {
        public void Configure(EntityTypeBuilder<Link> builder)
        {
            builder.ToTable("Link");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            builder.Property(x => x.UserId)
                .IsRequired()
                .HasColumnName("UserId")
                .HasColumnType("int");

            builder.Property(x => x.LinkTreeId)
                .IsRequired(false)
                .HasColumnName("LinkTreeId")
                .HasColumnType("int");

            builder.Property(x => x.Name)
                .IsRequired()
                .HasColumnName("Name")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(100);

            builder.Property(x => x.Url)
                .IsRequired()
                .HasColumnName("Url")
                .HasColumnType("NVARCHAR(2000)");

            builder.Property(x => x.Clicks)
                    .IsRequired()
                    .HasColumnName("Clicks")
                    .HasColumnType("bigint");

            builder.Property(x => x.IsActive)
                .IsRequired()
                .HasColumnName("IsActive")
                .HasColumnType("bit");

            builder.Property(x => x.Description)
                .IsRequired()
                .HasColumnName("Description")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(250);

            builder.Property(x => x.HasPassword)
                .IsRequired()
                .HasColumnName("HasPassword")
                .HasColumnType("bit");

            builder.Property(x => x.Password)
                .IsRequired(false)
                .HasColumnName("Password")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(40);

            builder.Property(x => x.HasMessage)
                    .IsRequired()
                    .HasColumnName("HasMessage")
                    .HasColumnType("bit");

            builder.Property(x => x.Message)
                .IsRequired(false)
                .HasColumnName("Message")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(250);

            builder.Property(x => x.Expires)
                .IsRequired()
                .HasColumnName("Expires")
                .HasColumnType("bit");

            builder.Property(x => x.ExpirationDate)
                .IsRequired(false)
                .HasColumnName("ExpirationDate")
                .HasColumnType("DateTime");

            builder.HasOne(x => x.LinkTree)
                .WithMany(x => x.Links)
                .OnDelete(DeleteBehavior.Restrict); 

            builder.HasOne(x => x.User)
                .WithMany(x => x.Links)
                .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
