using Report.Api.Data;
using Report.Api.Repository;
using Report.API.Helper;
using Report.API.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IReportContext, ReportContext>();
builder.Services.AddSingleton<IReportRepository, ReportRepository>();
builder.Services.AddSingleton(typeof(GoogleSheetsHelper));
builder.Services.AddSingleton<IGoogleSheetService, GoogleSheetService>();

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
