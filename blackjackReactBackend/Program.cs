using blackjackReactBackend.GameClasses;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
var game = new Game();

app.MapGet("/", () => "Hello World!");

app.Run();
