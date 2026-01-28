using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using static SimpleCarForum.Infra.Data.Constants.ValidationConstants;

namespace SimpleCarForum.Infra.Data.Models
{
    [Comment("Categories for the posts")]
    public class Category
    {
        [Key]
        [Comment("Unique identifier of the category")]
        public int Id { get; set; }

        [Required]
        [MaxLength(CategoryNameMaxLength)]
        [Comment("Name of the category")]
        public string Name { get; set; } = null!;

        [Required]
        [MaxLength(CategoryDescriptionMaxLength)]
        [Comment("Description of the category")]
        public string Description { get; set; } = null!;


        [Comment("Collection of all posts for the category")]
        public ICollection<Post> Posts { get; set; } = new List<Post>();
    }
}
