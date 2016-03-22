namespace SourceControlSystem.Models
{
    using System.ComponentModel.DataAnnotations;

    public class License
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
