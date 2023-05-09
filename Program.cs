using Microsoft.EntityFrameworkCore;
using Task10_11.Application.Interface;
using Task10_11.EFCore.DTOs;
using Task10_11.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<MyDbContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("MyDB"));
});

// DI

builder.Services.AddTransient<IAnnouncementService, AnnouncementService>();
builder.Services.AddTransient<IEventService, EventService>();
builder.Services.AddTransient<INewService, NewService>();
builder.Services.AddTransient<IQuestionService, QuestionService>();
builder.Services.AddTransient<IDocumentService, DocumentService>();
builder.Services.AddTransient<IDocumentItemService, DocumentItemService>();
builder.Services.AddTransient<IQuickLinkService, QuickLinkService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
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