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

  - #### EFCore 与EF 比较

    - Migration 数据库迁移

      ``` Migration 数据库迁移
      概念：面向对象ORM开发中，数据库不是程序员的手动创建的，而是由Migration工具生成的。关系型数据库只是盛放数据模型的一个媒介而已，理想状态下 程序员不用关系数据库的操作。
            根据数据库的变化，自动更新数据库中的表以及表结构的操作，就叫做Migration（迁移）。迁移可以分为多步（项目升级），也可以进行回滚。
      ```

      ``` Migration 使用
      1.NuGet安装 Install-Package Microsoft.EntityFrameworkCore.Tools；
      2.使用：Add-Migration init (Add-Migration 【本次迁移的备注】)  --自动在项目的Migrations文件夹中生成操作数据库的C#代码。
              Update-database  --需要执行后才会应用对数据库的操作。
                
      ```