// See https://aka.ms/new-console-template for more information

//// using 作用域
//{
//    using var stream = File.OpenWrite(@"E:\practice\C#\ConsoleApp2\测试.txt");
//    using var writer = new StreamWriter(stream);
//    writer.Write("你好，傻逼2");
//}
//var context = File.ReadAllText(@"E:\practice\C#\ConsoleApp2\测试.txt");
//Console.WriteLine(context);


//record 练习

Records records = new Records(2);
records.Id = 1;
Console.WriteLine(records.Id.ToString() + " --- " + records.Name);

public class Records
{
    public Records(int Id)
    {
        this.Id = Id;
    }

    public int Id { get; private set; }
    public string Name { get; set; } = "";

    // private set 可以通过构造函数赋值、也可以通过类内部赋值
    void SetId()
    {
        this.Id = 3;
    }
}
