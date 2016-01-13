using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DVA231_Projekt.Models
{
    public class ProjectRepository : IProjectRepository
    {
        private ProjectContext _context;
        private ILogger<ProjectRepository> _logger;

        public ProjectRepository(ProjectContext context, ILogger<ProjectRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public IEnumerable<Textpost> GetAllTextPosts()
        {
            try
            {
                return _context.Textposts.OrderBy(t => t.UserName).ToList();
            }
            catch(Exception ex)
            {
                _logger.LogError("Could not get textposts from database", ex);
                return null; //Could instead return an empty collection or simply throw the exception
            }
        }
    }
}
