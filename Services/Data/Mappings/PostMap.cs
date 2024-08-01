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
    public class PostMap : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.ToTable("Post");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            builder.Property(x => x.UserId)
                .IsRequired()
                .HasColumnName("UserId")
                .HasColumnType("int");

            builder.Property(x => x.LinkId)
                .HasColumnName("LinkId")
                .HasColumnType("int");

            builder.Property(x => x.LinkTreeId)
                .HasColumnName("LinkTreeId")
                .HasColumnType("int");

            builder.HasOne(x => x.User)
                .WithMany(x => x.Posts)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Link)
                .WithMany(x => x.Posts)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.LinkTree)
                .WithMany(x => x.Posts)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
