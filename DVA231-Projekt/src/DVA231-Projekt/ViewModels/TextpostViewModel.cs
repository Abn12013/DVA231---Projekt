using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DVA231_Projekt.ViewModels
{
    public class TextpostViewModel
    {
        public int Id { get; set; }

        public DateTime Created { get; set; } = DateTime.UtcNow;

        public string Title { get; set; }

        public string Message { get; set; }

    }
}
