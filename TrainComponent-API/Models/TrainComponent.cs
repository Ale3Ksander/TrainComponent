using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace TrainComponent.Models
{
    [Index(nameof(UniqueNumber) ,IsUnique = true)]
    public class TrainComponent
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;
        
        [Required]
        [MaxLength(50)]
        public string UniqueNumber { get; set; } = string.Empty;
        

        public bool CanAssignQuantity { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be a positive integer.")]
        public int? Quantity { get; set; }
    }
}
