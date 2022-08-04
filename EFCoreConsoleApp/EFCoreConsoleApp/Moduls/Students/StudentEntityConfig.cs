using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreConsoleApp.Moduls.Students
{
    public class StudentEntityConfig : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.ToTable("T_Students");
            builder.HasKey(x => x.Id);
            builder.Property(x=>x.Name).HasMaxLength(50);
            builder.Property(x => x.Age).IsRequired();
            builder.Property(x => x.Sex).IsRequired();
            builder.Property(x => x.Address).HasMaxLength(100);
        }
    }
}
