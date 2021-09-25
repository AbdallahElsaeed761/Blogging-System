using BloggingSystem.DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloggingSystem.BL.Dtos
{
    public class CategoryViewModel
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Please enter valid title between 3 and 50", MinimumLength = 3)]
        public string Name { get; set; }
        public virtual ICollection<Article> Articles { get; set; }
    }
}
