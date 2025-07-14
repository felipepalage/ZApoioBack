using ZApoioBack.Repository.Interfaces;
using ZApoioBack.Repository.Implementations;
using ZApoioBack.Service.Interfaces;
using ZApoioBack.Service.Implementations;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IDeployService, DeployService>();
builder.Services.AddScoped<IDeployRepository, DeployRepository>();
builder.Services.AddScoped<IProgressoService, ProgressoService>();
builder.Services.AddScoped<IProgressoRepository, ProgressoRepository>();


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAll");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
