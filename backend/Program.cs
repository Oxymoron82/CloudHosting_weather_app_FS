var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapGet("hellous/", GetHello);

app.Run();

string GetHello()

{
    var helloFolder = new DirectoryInfo(Directory.GetCurrentDirectory());
    var helloPath = Path.Combine(helloFolder.FullName, "hello.txt");

    //alternative shorter Syntax



    //print to console absolute path (FullName)
    Console.WriteLine($"Reading hello from: {helloPath}");

    var message = File.ReadAllText(helloPath);

    return "Read from FILE:\n\n" + message;
}
