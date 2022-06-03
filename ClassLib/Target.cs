using System.ComponentModel.DataAnnotations;

namespace ClassLib
{
    public class Target
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        private string tags = "";
        [Required]
        [MaxLength(100)]
        public string Tags
        {
            get => tags;
            set => tags = value;
        }
    }
}