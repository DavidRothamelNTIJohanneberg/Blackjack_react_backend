var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
//Game game = new Game();

int amount_of_players = 0;

app.MapGet("/", () => "Hello World!");
app.MapGet("/amount_of_players", (int amount) => amount_of_players = amount);
app.MapGet("/players", () => amount_of_players);

app.Run();
