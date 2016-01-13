using System;
using System.Linq;

namespace DVA231_Projekt.Models
{
    public class ProjectContextSeedData
    {
        private ProjectContext _context;

        public ProjectContextSeedData(ProjectContext context)
        {
            _context = context;
        }

        public void EnsureSeedData()
        {
            if(!_context.Textposts.Any())
            {
                //Add new Data
                var firstTextPost = new Textpost()
                {
                    Created = DateTime.UtcNow,
                    Title = "Russia is the best",
                    UserName = "Putin",
                    Message = "Vote for Putin and make Russia great again"
                };

                //New object to be updated in the database
                _context.Textposts.Add(firstTextPost);

                var secondTextPost = new Textpost()
                {
                    Created = DateTime.UtcNow,
                    Title = "Russia conquers all",
                    UserName = "Putin",
                    Message = "Russia really is the best country in the world"
                };
                
                //New object to be updated in the database
                _context.Textposts.Add(secondTextPost);

                //Push the changes to the database
                _context.SaveChanges();

            }
        }

    }
}
