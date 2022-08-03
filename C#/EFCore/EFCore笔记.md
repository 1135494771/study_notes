# [EFCore](#EFCore)

## 目录

- ### ORM

  - ##### ORM概念

    ``` ORM概念
    ORM: Object Relation Mapping。 字面意思是对象关系映射。让开发者用对象的形式操作关系型数据库。ORM负责关系型数据库和对象之间的双向转换
    ```

  - ##### ORM框架

    ``` ORM框架
    EFCore、Dapper、SqlSugar、FreeSql 等。
    ```

  - ##### 技术选型

    ``` 技术选型
    1.建议：对于后台系统、信息系统和数据库相关工足量大的系统，且团队比较稳定，用EFCore；对于互联网系统等数据库相关工作量不大的系统，或团队不稳定的，用Dapper。
    2.在项目中也可以混用，只要注意EFCore缓存、Tracking等问题即可。
    ```


- ### EFCore

  - #### EFCore 与EF 比较

    ``` EFCore与EF比较
    1.EF有DBFirst、ModelFirst、CoreFirst。EFCore不支持DBFirst，推荐使用代码优先 CoreFirst。如果系统以前用过EF,现在要转为EFCore可以使用Scaffold-DBContext来生成代码实现DBFirst效果。但是推荐使用CoreFirst。
    2.EF会对实体上做一些标注做校验（比如：Regex、Required），EFCore追求轻量化，不会对实体进行校验。
    3.EF的一些类的命名空间以及一些方法的名称在EFCore中稍有不同。
    4.EF不再增加新的特性。
    ```

  - #### Migration

    - Migration 数据库迁移

      ``` Migration 数据库迁移
      概念：面向对象ORM开发中，数据库不是程序员的手动创建的，而是由Migration工具生成的。关系型数据库只是盛放数据模型的一个媒介而已，理想状态下 程序员不用关系数据库的操作。
            根据数据库的变化，自动更新数据库中的表以及表结构的操作，就叫做Migration（迁移）。迁移可以分为多步（项目升级），也可以进行回滚。
      ```

      ``` Migration 使用
      1.NuGet安装 Install-Package Microsoft.EntityFrameworkCore.Tools；
      2.使用: Add-Migration init (Add-Migration 【本次迁移的备注】)  --自动在项目的Migrations文件夹中生成操作数据库的C#代码。
              Update-database   --应用所有的迁移
              Update-database 【本次迁移的备注】  --指定版本进行迁移。
              Script-Migration  --生成最后一次迁移文件要执行的sql脚本
              Script-Migration D F  --生成版本D到版本F的SQL脚本
              Script-Migration D  --生成版本D到最新版本的SQL脚本
      ```

      | 迁移命令描述 | PMC命令(vs) |
      | ---- | ---- |
      | 创建迁移：migrationname为迁移名称 | add-migration migrationName |
      | 移除迁移(删除最近的一次迁移) | remove-migration |
      | 应用所有的迁移(使迁移文件应用到数据库) | update-database |
      | 指定版本进行迁移：migrationname为迁移名称 | update-database migrationName |
      | 生成对应版本的脚本 | Script-Migration |

  - #### 创建EF Core 项目

    - 步骤：1、创建实体类；2、建DBContext；3、生成数据库；4、编写调用EF Core业务代码

      - ``` 项目搭建
        /* 创建实体类 */ 
        public class Book
        {
            //主键
            public long Id { get; set; }

            //标题
            public string Title { get; set; }

            //发布日期
            public DateTime? PubTime { get; set; }

            //单价
            public decimal Price { get; set; }

            //作者
            public string Author { get; set; }

            //描述
            public string Introduction { get; set; }
        }
        ```

      - ``` 创建DBContext
        /* DbContext配置类，继承自 DbContext类 */
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
        ```

      - ``` 创建DBContext
        /* 实体配置类 */
        public class BookEntityConfig : IEntityTypeConfiguration<Book>
        {
            /* Book实体类 */
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
        ```     

    - NuGet安装 Install-Package Microsoft.EntityFrameworkCore.SqlServer

    - 