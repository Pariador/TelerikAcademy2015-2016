namespace SocialNetwork.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class ChatMessage
    {
        public int Id { get; set; }

        [Required]
        [MinLength(1)]
        public string Content { get; set; }

        public int FriendshipId { get; set; }

        public virtual Friendship Friendship { get; set; }

        public int AuthorId { get; set; }

        public virtual UserProfile Author { get; set; }

        [Index()]
        public DateTime SentAt { get; set; }

        public DateTime RecievedAt { get; set; }
    }
}