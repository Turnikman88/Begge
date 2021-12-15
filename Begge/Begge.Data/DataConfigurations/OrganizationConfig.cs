using Begge.Models.DatabaseModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Begge.Data.DataConfigurations
{
    class OrganizationConfig : IEntityTypeConfiguration<Organization>
    {
        public void Configure(EntityTypeBuilder<Organization> builder)
        {
            builder.HasOne(x => x.Begger)
                .WithMany(x => x.Organizations)
                .HasForeignKey(x => x.BeggerId);
        }
    }
}
