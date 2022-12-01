using System.ComponentModel.DataAnnotations.Schema;
using Merancea.Models;

namespace Merancea.Models
{
    public class Page
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public string CoverArt { get; set; } = string.Empty;

        public virtual ICollection<Button>? Buttons { get; set; }
    }
}
