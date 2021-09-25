using BloggingSystem.DAL;
using BloggingSystem.DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloggingSystem.BL.Dtos
{
  public  class ArticleViewModel
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Please enter valid title between 3 and 50", MinimumLength = 3)]
        public string Title { get; set; }
        [Required]
        [StringLength(250, ErrorMessage = "Please enter valid Description between 3 and 50", MinimumLength = 3)]
        public string Description { get; set; }
        public string Photo { get; set; }
        [DataType(DataType.Date), Required]
        public DateTime Date { get; set; }
        public string CategoryName { get; set; }

        // public virtual Category Category { get; set; }
        public int CategoryId { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
     
        public virtual applicationUser ApplicationUserIdentity { get; set; }

    }
}
