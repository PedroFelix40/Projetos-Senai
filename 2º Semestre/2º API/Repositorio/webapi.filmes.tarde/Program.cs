using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

//adiciona o servi�o de controllers
builder.Services.AddControllers();

//Adiciona servi�o de autentica��o JWT Bearer
builder.Services.AddAuthentication(options =>
{
    options.DefaultChallengeScheme = "JwtBearer";
    options.DefaultAuthenticateScheme = "JwtBearer";
})

//define os parametro de validacao do token 
.AddJwtBearer(options => { }); //paramos aqui... continuar na segunda

//Adiciona o gerador do Swagger � cole��o de servi�os no Program.cs
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "API Filmes Tarde",
        Description = "API para gerenciamento de filme - Introdu��o a sprint 2 - API",
        Contact = new OpenApiContact
        {
            Name = "Pedro Felix - Senai Informatica",
            Url = new Uri("https://github.com/PedroFelix40")
        },
    });

    // Configura o swagger para utilizar o arquivo xml
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

var app = builder.Build();

//Habilita o middleware para atender ao documento JSON
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//Serve para atender � interface do usu�rio do Swagger na raiz do aplicativo (
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    options.RoutePrefix = string.Empty;
});

//Mapear os contollers
app.MapControllers();

app.Run();
