var builder = WebApplication.CreateBuilder(args);

//adiciona o servi�o de controllers
builder.Services.AddControllers();

var app = builder.Build();

//Mapear os contollers
app.MapControllers();

app.Run();
