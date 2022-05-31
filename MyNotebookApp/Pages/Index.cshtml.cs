using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyNotebookApp.Model;
using MyNotebookApp.Repositories;
using System.Security.Claims;

namespace MyNotebookApp.Pages
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly NotesRepository _repository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public List<Note> Notes { get; set; }
        public string MyNotebookAppUser {get; set; }
        public IndexModel(ILogger<IndexModel> logger,
                          NotesRepository repository,
                          IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            _repository = repository;
            _httpContextAccessor = httpContextAccessor;
        }

        public void OnGet()
        {
            
        }
    }
}