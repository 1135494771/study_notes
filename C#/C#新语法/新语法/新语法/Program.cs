// See https://aka.ms/new-console-template for more information
{
    using var stream = File.OpenWrite(@"E:\practice\C#\ConsoleApp2\测试.txt");
    using var writer = new StreamWriter(stream);
    writer.Write("你好，傻逼2");
}
var context = File.ReadAllText(@"E:\practice\C#\ConsoleApp2\测试.txt");
Console.WriteLine(context);

