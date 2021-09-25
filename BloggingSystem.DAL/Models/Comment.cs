using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloggingSystem.DAL.Models
{
    [Table("Comment")]
    public class Comment
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Please enter valid Text between 3 and 50", MinimumLength = 3)]
        public string Text { get; set; }
        [DefaultValue(true)]
        public bool Approved { get; set; }
        [Required]
        public string Reason { get; set; }

        [ForeignKey("Article")]
        public int ArticleId { get; set; }
        public virtual Article Article { get; set; }
        [ForeignKey("ApplicationUserIdentity")]
        public string ApplicationUserIdentity_Id { get; set; }
        public virtual applicationUser ApplicationUserIdentity { get; set; }

    }
}
