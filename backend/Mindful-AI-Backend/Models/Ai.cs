using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mindful_AI_Backend.Models
{
   
    [Table("Ai")]
    public class Ai
    {
        [Key]
        public int Id { get; set; }
        
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
