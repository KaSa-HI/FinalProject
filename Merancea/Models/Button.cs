using Merancea.Models;

namespace Merancea.Models
{
    public class Button
    {
        public int ButtonId { get; set; }
        public string Text { get; set; } = string.Empty;
        public string Attribute { get; set; } = string.Empty;

        public int PageId { get; set; }
        public virtual Page? Page { get; set; }

        public int? DestinationPageId { get; set; }
        public virtual Page? DestinationPage { get; set; }
    }

}
