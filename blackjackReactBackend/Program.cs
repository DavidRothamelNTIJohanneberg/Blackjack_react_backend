using blackjackReactBackend.GameClasses;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapGet("/game", () => new Game());

app.Run();
