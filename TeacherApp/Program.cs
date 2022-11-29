using Microsoft.EntityFrameworkCore;
using TeacherApp.Data;
using TeacherApp.Models;

var builder = WebApplication.CreateBuilder(args);
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<TeacherAppDbContext>(opts => {
  opts.UseSqlServer(
  builder.Configuration["ConnectionStrings:TeacherAppConnection"]);
});
builder.Services.AddScoped<ITeacherAppRepository, EFTeacherAppRepository>();
builder.Services.AddCors(options =>
{
	options.AddPolicy(name: MyAllowSpecificOrigins, policy =>
	{
		policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();

	});
});
var app = builder.Build();

// app.MapGet("/", () => "Hello World!");
app.UseStaticFiles();
app.UseCors(MyAllowSpecificOrigins);
app.MapControllerRoute("pagination", 
	"Students/Page{studentPage}",
	new { Controller = "Home", action = "Index"});
app.MapDefaultControllerRoute();

var dataText = System.IO.File.ReadAllText(@"Data\work.json");
SeedData.EnsurePopulated(dataText, app);

app.UseHttpsRedirection();

app.Run();

