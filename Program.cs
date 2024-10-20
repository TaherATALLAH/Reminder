using Microsoft.EntityFrameworkCore;
using Reminder.Domain.Interfaces;
using Reminder.Infrastructure.Entity;
using Reminder.Infrastructure.Services;

var builder = WebApplication.CreateSlimBuilder(args);

builder.Services.AddDbContext<ReminderDbContext>(options =>
    options.UseSqlite("Data Source= reminder.db"));
builder.Services.AddHttpClient<ICalendlyService, CalendlyService>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.MapControllers();
app.Run();
