using MyNotebookApp.Areas.Identity.Data;
using MyNotebookApp.Model;

namespace MyNotebookApp.Repositories
{
    public class CategoryRepository
    {

        private readonly MyNotebookAppContext _context;
        public CategoryRepository(MyNotebookAppContext context)
        {
            _context = context;
        }
        public List<Category> GetCategoriesOfUser(Guid userId)
        {
            return _context.Categories.Where(z => z.Id == userId).ToList();

        }

        public List<Category> GetByTitle(string title, Guid userId)
        {
            return _context.Categories.Where(n => n.Name.Contains(title) && n.Id == userId).ToList();

        }


        public Category GetCategory(Guid Id)
        {
            return _context.Categories.FirstOrDefault(x => x.Id == Id);

        }


        public void Create(string title, Guid userId)
        {
            var user = _context.Users.FirstOrDefault(x => x.Id == userId);
            var category = new Category
            {
                Id = Guid.NewGuid(),
                Name = title
            };

            _context.Categories.Add(category);
            _context.SaveChanges();
        }


        public void EditCategory(Guid Id, string title)
        {
            var category = _context.Categories.FirstOrDefault(n => n.Id == Id);
            category.Name = title;
            _context.SaveChanges();
        }




        public void RemoveCategory(Guid Id)
        {
            var categoryToRemove = _context.Categories.FirstOrDefault(c => c.Id == Id);
            if (categoryToRemove != null)
            {
                _context.Categories.Remove(categoryToRemove);
                _context.SaveChanges();
            }
        }


    }



}
