using System;
using System.ComponentModel.DataAnnotations;

namespace Seeder.Core.Entities.Items
{
    public class Todo
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(250)]
        public string Name { get; set; }
    }
}
