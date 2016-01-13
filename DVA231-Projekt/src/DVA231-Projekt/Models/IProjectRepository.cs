using System.Collections.Generic;

namespace DVA231_Projekt.Models
{
    public interface IProjectRepository
    {
        IEnumerable<Textpost> GetAllTextPosts();
    }
}