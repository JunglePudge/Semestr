using GameProject.API.Services;

var builder = WebApplication.CreateBuilder(args);

// Регистрация сервисов
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<GameInitializationService>();

// Регистрация GameService с инициализацией
builder.Services.AddSingleton(sp =>
{
    var initService = sp.GetRequiredService<GameInitializationService>();
    var board = initService.InitializeBoard(20); // Пример размера доски
    var players = new List<Player>
    {
        new Player { Id = 1, Name = "Player 1" },
        new Player { Id = 2, Name = "Player 2" },
        new Player { Id = 3, Name = "Player 3" },
        new Player { Id = 4, Name = "Player 4" }
    };
    var cardDeck = initService.InitializeCardDeck();

    return new GameService(board, players, cardDeck);
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
