using Report.API.Data;
using Report.API.Repository;
using Report.API.Helper;
using Report.API.Service;
using Report.API.Service.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpClient();
builder.Services.AddTransient(typeof(GoogleSheetsHelper));
builder.Services.AddTransient<IGoogleSheetService, GoogleSheetService>();
builder.Services.AddTransient<IContactService, ContactService>();
builder.Services.AddTransient<IReportService, ReportService>();
builder.Services.AddSingleton<IReportContext, ReportContext>();
builder.Services.AddSingleton<IReportRepository, ReportRepository>();


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
