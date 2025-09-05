using Microsoft.JSInterop.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//MAP. ENDPOINT method
app.MapGet("hellous/", GetHello);
app.MapGet("/", () => "Hello Net24S!"); // Using "anonomous functions"


app.Run();

string GetHello()

//look for all assets in te same folder, where the programm (dll's etc.) ew (usually bin/Debug/net9.0)
{
    var helloFolder = new DirectoryInfo(Directory.GetCurrentDirectory());
    var helloPath = Path.Combine(helloFolder.FullName, "hello.txt");

    //Check that file exists, otherwise it may reult into HTTP ERROR CODE 500
    // print to console absolute path (FullName)
    Console.WriteLine($"Reading hello from: {helloPath}");
    // in spe

    var message = File.ReadAllText(helloPath);
    return "Read from FILE:\n\n" + message;
}




// Deploy with:
// az webapp up --name maria-cedersten -g test1 --location westeurope --sku B1 --os-type linux