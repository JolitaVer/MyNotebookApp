using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyNotebookApp.Areas.Identity.Data;
using MyNotebookApp.Model;

namespace MyNotebookApp.Areas.Identity.Data;

public class MyNotebookAppContext : IdentityDbContext<MyNotebookAppUser>
{
    public MyNotebookAppContext(DbContextOptions<MyNotebookAppContext> options)
        : base(options)
    {
    }
    public DbSet<Note> Notes { get; set; }
    public DbSet<Category> Categories { get; set; }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }
}
