using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MyNotebookApp.Areas.Identity.Data;
using MyNotebookApp.Model;
using MyNotebookApp.Repositories;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("MyNotebookAppContextConnection") ?? throw new InvalidOperationException("Connection string 'MyNotebookAppContextConnection' not found.");

builder.Services.AddDbContext<MyNotebookAppContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<MyNotebookAppUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<MyNotebookAppContext>();

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddTransient<NotesRepository>();

builder.Services.AddControllers();


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
app.UseAuthentication();;

app.UseAuthorization();

app.MapRazorPages();
app.MapControllers();

app.Run();
