using Report.API.Data;
using Report.API.Repository;
using Report.API.Helper;
using Report.API.Service;
using Report.API.Service.Interfaces;
using MassTransit;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IReportContext, ReportContext>();
builder.Services.AddHttpClient();
builder.Services.AddTransient(typeof(GoogleSheetsHelper));
builder.Services.AddTransient<IGoogleSheetService, GoogleSheetService>();
builder.Services.AddTransient<IContactService, ContactService>();
builder.Services.AddTransient<IReportService, ReportService>();
builder.Services.AddSingleton<IReportRepository, ReportRepository>();
builder.Services.AddMassTransit(config =>
{
    config.UsingRabbitMq((ctx, cfg) =>
    {
        cfg.Host(builder.Configuration["EventBusSettings:HostAddress"]);
    });
});

builder.Services.AddControllers();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
