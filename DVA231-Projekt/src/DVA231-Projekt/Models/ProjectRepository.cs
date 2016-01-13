using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DVA231_Projekt.Models
{
    public class ProjectRepository : IProjectRepository
    {
        private ProjectContext _context;

        public ProjectRepository(ProjectContext context)
        {
            _context = context;
        }

        public IEnumerable<Textpost> GetAllTextPosts()
        {
            return _context.Textposts.OrderBy(t => t.UserName).ToList();
        }
    }
}
