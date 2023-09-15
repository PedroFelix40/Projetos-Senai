using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();


//Adiciona servi�o de autentica��o JWT Bearer
builder.Services.AddAuthentication(options =>
{
    options.DefaultChallengeScheme = "JwtBearer";
    options.DefaultAuthenticateScheme = "JwtBearer";
})

//define os parametro de validacao do token 
.AddJwtBearer("JwtBearer", options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        // valida quem est� solicitando
        ValidateIssuer = true,

        // Valida quem est� recebendo
        ValidateAudience = true,

        // define se o tempo de expira��o do token ser� validado
        ValidateLifetime = true,

        // forma de criptografia e ainda a valida�ao da chave de autentica��o
        IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("inlock-chave-atenticacao-webapi-dev")),

        // valida o tempo de expiracao do token 
        ClockSkew = TimeSpan.FromMinutes(5),

        // De onde est� vindo 
        ValidIssuer = "webapi.inlock.tarde",

        // Para onde est� indo
        ValidAudience = "webapi.inlock.tarde"
    };
});

//Adiciona o gerador do Swagger � cole��o de servi�os no Program.cs
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "API InLock Tarde",
        Description = "API para gerenciamento de uma empresa no ramo de games - Introdu��o a sprint 2 - API",
        Contact = new OpenApiContact
        {
            Name = "Pedro Felix - Senai Informatica",
            Url = new Uri("https://github.com/PedroFelix40")
        },
    });

    // Configura o swagger para utilizar o arquivo xml
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));

    // Usando autentica��o do Swagger
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Values: Bearer TokenJWT"
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[]{}
        }
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Usar autentica��o
app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
