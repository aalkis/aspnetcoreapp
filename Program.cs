using AspNetCoreApp.Middewares;
using Microsoft.Extensions.FileProviders;

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
app.UseStaticFiles(new StaticFileOptions{
    FileProvider= new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(),"node_modules")), RequestPath="/node_modules"
});

app.UseRouting();

app.UseMiddleware<ResponseEditingMiddleware>();
app.UseMiddleware<RequestEditingMiddleware>();
app.UseAuthorization();

app.MapControllerRoute(
    name:"areas",
    pattern: "{Area}/{Controller=Home}/{Action=Index}/{id?}"
);

app.MapControllerRoute(
    name: "default",
    pattern: "{Controller}/{Action}/{id?}",
    defaults:new {Controller="Home",Action="Index"});


app.Run();
