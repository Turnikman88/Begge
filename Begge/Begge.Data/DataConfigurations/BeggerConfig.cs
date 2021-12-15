using Begge.Models.DatabaseModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Begge.Data.DataConfigurations
{
    class BeggerConfig : IEntityTypeConfiguration<Begger>
    {
        public void Configure(EntityTypeBuilder<Begger> builder)
        {
            builder.HasIndex(x => x.Email).IsUnique();

            builder.Property(x => x.Email).IsRequired();

            builder.Property(x => x.FirstName).IsRequired();

            builder.Property(x => x.LastName).IsRequired();

            builder.Property(x => x.LastName).IsRequired();
        }
    }
}
