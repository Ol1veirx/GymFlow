using GymFlow.Application.Services.Implementatios;
using GymFlow.Application.Services.Interfaces;
using GymFlow.Infraestructure.Persistence;
using GymFlow.Infraestructure.Repositories;
using GymFlow.Infraestructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApiDbContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("GymFlowConnectionString");
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});

builder.Services.AddScoped<IMemberServices, MemberServices>();
builder.Services.AddScoped<IInstructorService, InstructorService>();
builder.Services.AddScoped<IFitnessClassService, FitnessClassService>();

builder.Services.AddScoped<IMemberRepository, MemberRepository>();
builder.Services.AddScoped<IInstructorRepository, InstructorRepository>();
builder.Services.AddScoped<IFitnessClassRepository, FitnessClassRepository>();

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
