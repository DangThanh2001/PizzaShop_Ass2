using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PizzaShop.Data;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<PizzaShopContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("PizzaShopContext") ?? throw new InvalidOperationException("Connection string 'PizzaShopContext' not found.")));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

#region session
builder.Services.AddHttpContextAccessor();
builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession();
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
else
{
    app.UseDeveloperExceptionPage();
    app.UseMigrationsEndPoint();
}

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<PizzaShopContext>();
    context.Database.EnsureCreated();
    //DbInitializer.Initialize(context);
}

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

//session
app.UseSession();

app.Run();