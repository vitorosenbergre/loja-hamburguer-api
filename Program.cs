using Microsoft.EntityFrameworkCore;
using MyEFProject.Data;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Configurar a string de conexão com o MySQL
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Configurar o AppDbContext com a string de conexão
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(connectionString, 
                     new MySqlServerVersion(new Version(8, 0, 30))));

// Adicionar controladores
builder.Services.AddControllers();

// Habilitar CORS
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin()  // Permitir requisições de qualquer origem
               .AllowAnyMethod()  // Permitir qualquer método HTTP (GET, POST, PUT, DELETE)
               .AllowAnyHeader(); // Permitir qualquer cabeçalho
    });
});

// Adicionar serviços para o Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    // Definir a versão da API no Swagger
    options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "Minha API",
        Version = "v1",
        Description = "Uma API simples para testar Swagger"
    });
});

var app = builder.Build();

// Usar a página de erro no ambiente de desenvolvimento
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

// Habilitar o Swagger apenas no ambiente de desenvolvimento
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Minha API v1");
        c.RoutePrefix = string.Empty;  // Isso faz o Swagger ficar disponível na raiz (http://localhost:5000)
    });
}

// Habilitar o CORS para permitir requisições de qualquer origem
app.UseCors();

// Redirecionamento HTTPS
//app.UseHttpsRedirection();

// Caso tenha algum middleware de autenticação, coloque-o aqui, por exemplo:
// app.UseAuthentication();
// app.UseAuthorization();

app.MapControllers();

// Rodar a aplicação
app.Run();
