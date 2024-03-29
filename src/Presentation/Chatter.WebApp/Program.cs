using Chatter.Persistence.Extensions;
using Chatter.WebApp.Extensions;
using Chatter.WebApp.HUB;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.ConfigureWebApps(builder.Configuration);

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
app.CustomStaticFiles();
app.UseRouting();

await app.UpdateApplicationDb();
app.SeedIdentity();

app.UseAuthentication();
app.UseAuthorization();

app.MapHub<ChatHub>("/chatHub");


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Room}/{action=Index}/{id?}");

app.Run();
