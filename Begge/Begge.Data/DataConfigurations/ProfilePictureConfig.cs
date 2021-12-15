using Begge.Models.DatabaseModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Begge.Data.DataConfigurations
{
    class ProfilePictureConfig : IEntityTypeConfiguration<ProfilePicture>
    {
        public void Configure(EntityTypeBuilder<ProfilePicture> builder)
        {
            builder.HasIndex(x => x.BeggerId).IsUnique();
            builder.HasIndex(x => x.OrganizationId).IsUnique();

            builder.HasOne(x => x.Begger)
                .WithOne(x => x.ProfilePicture)
                .HasForeignKey<ProfilePicture>(x => x.BeggerId)
                .OnDelete(DeleteBehavior.NoAction);


            builder.HasOne(x => x.Organization)
                .WithOne(x => x.ProfilePicture)
                .HasForeignKey<ProfilePicture>(x => x.OrganizationId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
