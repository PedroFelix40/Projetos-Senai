using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

//adiciona o serviço de controllers
builder.Services.AddControllers();

//Adiciona serviço de autenticação JWT Bearer
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
        // valida quem está solicitando
        ValidateIssuer = true,

        // Valida quem está recebendo
        ValidateAudience = true,

        // define se o tempo de expiração do token será validado
        ValidateLifetime = true,

        // forma de criptografia e ainda a validaçao da chave de autenticação
        IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("inlock-chave-atenticacao-webapi-dev")),

        // valida o tempo de expiracao do token 
        ClockSkew = TimeSpan.FromMinutes(5),

        // De onde está vindo 
        ValidIssuer = "webapi.inlock.tarde",

        // Para onde está indo
        ValidAudience = "webapi.inlock.tarde"
    };
});

//Adiciona o gerador do Swagger à coleção de serviços no Program.cs
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "API InLock Tarde",
        Description = "API para gerenciamento de uma empresa no ramo de games - Introdução a sprint 2 - API",
        Contact = new OpenApiContact
        {
            Name = "Pedro Felix - Senai Informatica",
            Url = new Uri("https://github.com/PedroFelix40")
        },
    });

    // Configura o swagger para utilizar o arquivo xml
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));

    // Usando autenticação do Swagger
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

//Habilita o middleware para atender ao documento JSON
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//Serve para atender à interface do usuário do Swagger na raiz do aplicativo (
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    options.RoutePrefix = string.Empty;
});

// Usar autenticação
app.UseAuthentication();

// Usar autorização
app.UseAuthorization();

//Mapear os contollers
app.MapControllers();

app.Run();
