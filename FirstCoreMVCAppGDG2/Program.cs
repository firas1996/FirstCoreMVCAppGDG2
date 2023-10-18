using FirstCoreMVCAppGDG2.Constraints;
using Microsoft.AspNetCore.Routing.Constraints;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

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
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapControllerRoute(
    name: "max",
    pattern: "{controller=Test}/{action=Max}/{x}/{y}",
    constraints: new { x = @"-?\d+" , y = @"-?\d+",
    port = new PortConstraint()
    //httpMethod = new HttpMethodRouteConstraint("POST")
    }
    );

app.Run();
