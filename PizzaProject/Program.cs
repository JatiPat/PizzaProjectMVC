using Microsoft.EntityFrameworkCore;
using PizzaProject.DataAccess.Data;
using PizzaProject.DataAccess.Repository;
using PizzaProject.DataAccess.Repository.IRepository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<PizzaDbContext>(options => //options is from PizzaDbContext cotr construtor
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();//Add this if you have services error
// Unable to resolve service for type 'PizzaProject.DataAccess.Repository.IRepository.IPizzaStyleRepository' 
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{area=Customer}/{controller=Home}/{action=Index}/{id?}"); //Must have area when added

app.Run();
