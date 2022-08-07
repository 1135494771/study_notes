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

  - #### Fluent API

    - 约定配置

      ``` FluentAPI 的主要规则
      1.数据表列的名字采用实体类属性的名字，列的数据类型采用和实体类属性类型最兼容的类型；
      2.数据表列的可空性取决于对应实体类属性的可空性；
      3.名字为Id的属性默认设置为主键，如果主键为short，int 或者long 类型，则默认采用自增字段，如果主键为Guid类型，则采用默认的Guid生成机制生成主键值。
      
      举例：设置数据库表名
      builder.ToTable("T_Books");
      把配置写到单独的配置类中。

      缺点：复杂； 优点：解耦
      ```

      ``` FluentAPI 的一些配置
      /* FluentAPI 的一些配置 */
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
      ```

  - #### Data Annotation

    - 把配置以特性的形式标注在实体类中

      ``` Data Annotation
      举例：设置数据库表名
      [Table("T_Books")]
      public class Book {
         public int id { get; set; }
      }
     
      缺点：耦合度高； 优点：简单
      ```

  - #### EF Core 主键

    - 主键生成策略：自动增长、Guid、Hi/Lo算法等。
    - 自动增长 --> 优点：简单；缺点：数据库迁移以及分布式系统中比较麻烦；并发性能差。
    - Guid算法(或UUID算法)生成一个全局  唯一的Id。适合于分布式系统。优点：简单、高并发；缺点：磁盘占用空间大。
    - Hi/Lo算法：EFCore 支持Hi/Lo算法来有优化自增列。主键值由俩部分组成：高位（Hi）和低位（Lo），高位由数据库生成，俩个高位之间间隔若干个值，由程序在本地生成低位，低位的值由本地自增生成。不同进程或集群中不同服务器获取的Hi值不会重复，而本地进程计算的Lo则可以保证在本地高效率的生成主键值。但是HiLo不是EFCore的标准。

  - #### 通过代码方式查看EFCore生成的SQL语句

    - 1.标准日志

    - 2.简单日志

    - 3.ToQueryString 日志

      - EF Core的Where方法返回IQueryable类型，DbSet也实现了IQueryable接口。IQueryable有扩展方法ToQueryString()可以获取SQL。注意：不需要真的执行查询才获取SQL语句；只能获取查询操作。

  - #### EF Core关系配置

    - 一对多

      ``` 一对多实体类
      /// <summary>
      /// 文章类
      /// 一对多
      /// 一个文章对应多个评论内容
      /// </summary>
      public class Article
      {
          public long Id { get; set; }
          public string Title { get; set; }
          public string Content { get; set; }

          /// <summary>
          /// 关联实体类
          /// </summary>
          public List<Comment> comments { get; set; } = new List<Comment>();
      }

      /// <summary>
      /// 评论类
      /// 一对多
      /// 一个评论对应一个文章
      /// </summary>
      public class Comment
      {
          public long Id { get; set; }
          public string Message { get; set; }

          /// <summary>
          /// 关联实体类
          /// </summary>
          public Article article { get; set; }
      }

      //在一的那端关联多的那端配置
      public class CommentEntityConfig : IEntityTypeConfiguration<Comment>
      {
          public void Configure(EntityTypeBuilder<Comment> builder)
          {
              builder.ToTable("T_Comments");
              builder.HasKey(x => x.Id);
              //通过 HasOne 、 WithMany 绑定
              builder.HasOne(x=>x.TheArticle).WithMany(x=>x.comments);
          }
      }
      ```



  
  
