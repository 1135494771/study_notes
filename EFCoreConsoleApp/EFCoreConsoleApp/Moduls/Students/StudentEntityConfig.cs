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
        /* 不建议使用高级特性 */
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            //设置数据库表名
            builder.ToTable("T_Students");
            //设置为主键
            builder.HasKey(x => x.Id);
            //设置字符串最大长度 --> string类型如果不设置长度默认为 nvarchar(MAX)
            builder.Property(x => x.Name).HasMaxLength(50);
            builder.Property(x => x.Address).HasMaxLength(100);
            //设置 允许 Null 值 (默认true, 不允许为 Null)
            builder.Property(x => x.Age).IsRequired();
            builder.Property(x => x.Sex).IsRequired();
            //排除属性映射 
            builder.Ignore(x => x.Birthday);
            //手动设置列名
            builder.Property(x => x.other).HasColumnName("others");
            //手动设置列名类型
            builder.Property(x => x.other).HasColumnType("nvarchar(100)");
            //手动设置列名默认值
            builder.Property(x => x.other).HasDefaultValue("hello");
        }
    }
}
