var builder = WebApplication.CreateBuilder(args);

//adiciona o serviço de controllers
builder.Services.AddControllers();

var app = builder.Build();

//Mapear os contollers
app.MapControllers();

app.Run();
