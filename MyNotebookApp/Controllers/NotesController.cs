using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyNotebookApp.Model;
using MyNotebookApp.Repositories;

namespace MyNotebookApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        private readonly NotesRepository _notesRepository;

        public NotesController(NotesRepository notesRepository)
        {
            _notesRepository = notesRepository;
        }
        [HttpGet("id")]
        public Note GetNote(int id)
        {
            return _notesRepository.GetNote(id);
        }
        [HttpGet]
        public List<Note> GetNotes()
        {
            return _notesRepository.GetNotes();
        }
        [HttpPost]
        public ActionResult CreateNote([FromBody] Note note)
        {
            _notesRepository.UpdateNote(note);
            return Ok();
        }
    }

    

}
