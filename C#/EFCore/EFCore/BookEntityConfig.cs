using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore
{
    /* 实体配置类 */
    public class BookEntityConfig : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            //生成指定的数据库表名
            builder.ToTable("T_Books");

            #region 设置列属性
            //设置主键
            builder.HasKey(x => x.Id);
            //设置 title字段属性 最大长度50，可为空
            builder.Property(x => x.Title).HasMaxLength(50).IsRequired(false);
            //设置 author字段属性 最大长度50，非空
            builder.Property(x => x.Author).HasMaxLength(50).IsRequired();
            //设置 price字段属性 默认值0
            builder.Property(x => x.Price).HasDefaultValue(0).HasColumnType("decimal(18,2)");
            //设置 Introduction字段属性
            builder.Property(x => x.Introduction).HasMaxLength(100);
            #endregion

        }
    }
}
