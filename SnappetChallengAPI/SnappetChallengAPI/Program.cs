using SnappetChallengAPI.Controllers;
using SnappetChallengAPI.Repository;
using SnappetChallengAPI.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddControllers(options => options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddScoped<IStudentController, StudentController>();
builder.Services.AddScoped<StudentRepository, StudentRepository>();
builder.Services.AddScoped<StudentService, StudentService>();



var app = builder.Build();

app.UseCors(options => options.WithOrigins("http://localhost:3000").AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin());

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


//app.UseAuthorization();

app.MapControllers();

app.Run();
