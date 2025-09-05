using Microsoft.JSInterop.Infrastructure;
Console.WriteLine(@$"Current directory: {Directory.GetCurrentDirectory()}");

Console.WriteLine(@$"Executing Assembly:

{Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)}");

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//MAP. ENDPOINT method
app.MapGet("hellous/", GetHello);
app.MapGet("/", () => "Hello Net24S!"); // Using "anonomous functions"


app.Run();

string GetHello()

//look for all assets in te same folder, where the programm (dll's etc.) ew (usually bin/Debug/net9.0)
{
    var helloFolder = new DirectoryInfo(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location));

    //using path.combine allows use to not worry about the operating system separator

    var helloPath = Path.Combine(helloFolder.FullName, "hello.txt");

    //Check that file exists, otherwise it may reult into HTTP ERROR CODE 500
    // print to console absolute path (FullName)

    if (!File.Exists(helloPath))
    {
        return
    @$"Sorry, cant return hello fron file. File '{helloPath}' not found. Plese contact ur support";
    }

    // file was found OK, print debug info to console absolute path (FullName)
    Console.WriteLine($"File found! Reading hello from: {helloPath}");
    // in spe

    var message = File.ReadAllText(helloPath);
    return "Read from FILE:\n\n" + message;
}




// Deploy with:
// az webapp up --name maria-cedersten -g test1 --location westeurope --sku B1 --os-type linux