using Library.Controllers;
using Library.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddControllers();
builder.Services.AddServerSideBlazor();
builder.Services.AddControllersWithViews();
builder.Services.AddTransient<JsonFileBookService>();
builder.Services.AddTransient<JsonFileUserService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthorization();



app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "customRoute",
        pattern: "Users/DeleteBook",
        defaults: new { controller = "User", action = "DeleteBook" });
    endpoints.MapRazorPages();
    endpoints.MapControllers();
    endpoints.MapBlazorHub();
});


app.Run();
