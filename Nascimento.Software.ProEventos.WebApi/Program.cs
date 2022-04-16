using System.Reflection;
using Application.Commands.Handlers;
using Infra.Context;
using Infra.Repository.Eventos;
using Infra.Repository.Palestrantes;
using MediatR;
using Newtonsoft.Json;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers().AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore
);
// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddCors();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>();
builder.Services.AddScoped<IEventoRepository, EventoRepository>();
builder.Services.AddScoped<IPalestranteRepository, PalestranteRepository>();
builder.Services.AddSingleton(typeof(ILogger), typeof(Logger<Program>));

builder.Services.AddMediatR(typeof(AdicionarEventoHandler).GetTypeInfo().Assembly);
builder.Services.AddLogging();

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

app.UseCors(cors => { cors.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin(); });
app.Run();