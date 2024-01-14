using BlogManagement.Application;
using BlogManagement.Persistence;
using BlogManagement.Identity;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddApplication();
builder.Services.AddPersistence(builder.Configuration);
builder.Services.AddIdentity(builder.Configuration);

builder.Services.AddCors(a =>
{
    a.AddPolicy("BlogManagement.Api",option =>
    {
        option.AllowAnyOrigin();
        option.AllowAnyHeader();
        option.AllowAnyMethod();
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.UseCors("BlogManagement.Api");

app.MapControllers();

app.Run();
