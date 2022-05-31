using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using MyNotebookApp.Model;

namespace MyNotebookApp.Areas.Identity.Data;

// Add profile data for application users by adding properties to the MyNotebookAppUser class
public class MyNotebookAppUser : IdentityUser
{
    public Guid Id { get; set; }
    public List<Note> Notes { get; set; }
}

