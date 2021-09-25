using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloggingSystem.DAL.Models
{
    [Table("Article")]
    public class Article
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50,ErrorMessage ="Please enter valid title between 3 and 50",MinimumLength =3)]
        public string Title { get; set; }
        [Required]
        [StringLength(250, ErrorMessage = "Please enter valid Description between 3 and 50", MinimumLength = 3)]
        public string Description { get; set; }
        public string Photo { get; set; }
        [DataType(DataType.Date), Required]
        public DateTime Date { get; set; }
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public virtual Category Category  { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
        [ForeignKey("ApplicationUserIdentity")]
        public string ApplicationUserIdentity_Id { get; set; }
        public virtual applicationUser ApplicationUserIdentity { get; set; }

    }
}
