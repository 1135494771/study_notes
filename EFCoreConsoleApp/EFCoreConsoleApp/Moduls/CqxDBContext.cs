using EFCoreConsoleApp.Moduls.Books;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Formatting.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreConsoleApp.Moduls
{
    public class CqxDBContext : DbContext
    {
        //public static readonly ILoggerFactory MyLoggerFactory = LoggerFactory.Create(b =>
        //{
        //    //链式变成设置Serilog配置
        //    Log.Logger = new LoggerConfiguration()
        //    .MinimumLevel.Debug()
        //    .Enrich.FromLogContext()
        //    .WriteTo.Console(new JsonFormatter())
        //    .CreateLogger();
        //    //注入Serilog
        //    b.AddSerilog();
        //});

        public static readonly ILoggerFactory MyLoggerFactory = LoggerFactory.Create(b => b.AddConsole());

        public DbSet<Book> Books { get; set; }

        //配置连接字符串或者添加配置
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=1.116.169.186,1401;Database=cqx;Trusted_Connection=True;User Id=sa;Password=Str0ngPassword!;Trusted_Connection=false");
            optionsBuilder.UseBatchEF_MSSQL();
            optionsBuilder.UseLoggerFactory(MyLoggerFactory);
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
