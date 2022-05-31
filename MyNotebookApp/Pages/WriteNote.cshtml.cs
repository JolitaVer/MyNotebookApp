using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using System.ComponentModel.DataAnnotations;
using MyNotebookApp.Repositories;
using MyNotebookApp.Model;

namespace MyNotebookApp.Pages
{
    [Authorize]
    public class Note : PageModel
    {
        private readonly ILogger<Note> _logger;

        [BindProperty]
        public string Title { get; set; }
        [BindProperty]
        public string Text { get; set; }
        [BindProperty]
        public Guid CategoryId { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SearchInputTitle { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SearchCategoryTitle { get; set; }

        public List<Note> Notes { get; set; } = new List<Note>();
        public List<Category> CategoryForNote { get; set; } = new List<Category>();

        private readonly NotesRepository _notesRepository;
        private readonly CategoryRepository _categoryRepository;
        public Note(ILogger<Note> logger, NotesRepository notesRepository, CategoryRepository categoryRepository, Category category)
        {
            _notesRepository = notesRepository;
            _categoryRepository = categoryRepository;
            _logger = logger;

        }



        public void OnGet()
        {
            Guid.TryParse(User.FindFirstValue(ClaimTypes.NameIdentifier), out Guid userId);
            CategoryForNote = _categoryRepository.GetCategoriesOfUser(userId);

        }

    }
}
