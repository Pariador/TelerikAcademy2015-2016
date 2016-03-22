using System.ComponentModel.DataAnnotations;
namespace SocialNetwork.Models
{
    public class Image
    {
        public int Id { get; set; }

        [Required]
        public string ImageURL { get; set; }

        [Required]
        [MaxLength(4)]
        public string FileExtension { get; set; }

        public int UserProfileId { get; set; }

        public virtual UserProfile UserProfile { get; set; }
    }
}