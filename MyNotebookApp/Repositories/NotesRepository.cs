using MyNotebookApp.Areas.Identity.Data;
using MyNotebookApp.Model;

namespace MyNotebookApp.Repositories
{
    public class NotesRepository
    {
        private readonly MyNotebookAppContext _context;
        public NotesRepository(MyNotebookAppContext context)
        {
            _context = context;
        }
        public  void CreateNote(Note note)
        {
            _context.Notes.Add(note);
            _context.SaveChanges();
        }
       
        public Note GetNote(int id)
        {
            return _context.Notes.FirstOrDefault(n => n.Id == id);
        }
        public List<Note> GetNotesByUserId(string id)
        {
            return _context.Notes.Where(note=>note.MyNotebookAppUserId==id).ToList();
        }
        public void DeleteNote (int id)
        {
            var note = _context.Notes.FirstOrDefault(n => n.Id == id);
            if (note != null)
            {
                _context.Notes.Remove(note);
                _context.SaveChanges();
            }
        }
     
        public void UpdateNote (Note note)
        {
            if (note == null)
            {
                throw new ArgumentNullException(nameof(note));
            }
            _context.Notes.Update(note);
            _context.SaveChanges();
        }

        


    }
}
