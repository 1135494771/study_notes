using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore
{
    //DbContext配置类，继承自 DbContext类
    public class MyDbContext : DbContext
    {
        //存放 DbSet实体
        public DbSet<Book> Books { get; set; }


        //配置连接字符串或者添加配置
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=1.116.169.186,1401;Initial Catalog=cqx;Persist Security Info=True;User ID=sa;Password=Str0ngPassword!;");
        }


        //从当前程序集加载所有的 IEntityTypeConfiguration
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Conventions.Add(new DecimalPrecisionAttributeConvention());
            base.OnModelCreating(modelBuilder);
            //从当前程序集加载所有的 IEntityTypeConfiguration
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
        }
    }
}
