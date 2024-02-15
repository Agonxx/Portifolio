using BlazorBase.Api.Data;
using BlazorBase.Api.Repositories;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("ConexaoBanco");

builder.Services.AddResponseCompression(options =>
    options.MimeTypes = ResponseCompressionDefaults
    .MimeTypes
    .Concat(new[] { "application/octet-stream" }));

builder.Services.AddDbContext<DataContext>(opts =>
{
    opts.UseSqlServer(connectionString)
    .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
    opts.EnableSensitiveDataLogging();
},
    contextLifetime: ServiceLifetime.Transient,
    optionsLifetime: ServiceLifetime.Singleton);

builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(connectionString));


builder.Services.AddCors(options => options
    .AddDefaultPolicy(builder => builder
    .AllowAnyMethod()
    .AllowAnyHeader()
    .AllowAnyOrigin()));

builder.Services.AddScoped<UsuarioRepository>();
builder.Services.AddScoped<ExercicioRepository>();
builder.Services.AddScoped<SubDivisaoRepository>();
builder.Services.AddScoped<GrupoMuscularRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors();
app.Run();
