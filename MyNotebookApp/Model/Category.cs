using MyNotebookApp.Areas.Identity.Data;

namespace MyNotebookApp.Model
{
    public class Category
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public List<Note> Notes{ get; set; }
        public string MyNotebookAppUserId { get; set; }
    }
}
