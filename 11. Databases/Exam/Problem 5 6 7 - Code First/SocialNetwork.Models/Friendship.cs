namespace SocialNetwork.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Friendship
    {
        [Key, Column(Order = 0)]
        public int FirstUserProfileId { get; set; }

        public virtual UserProfile FirstUserProfile { get; set; }

        [Key, Column(Order = 1)]
        public int SecondUserProfileId { get; set; }

        public virtual UserProfile SecondUserProfile { get; set; }

        [Index()]
        public bool Approved { get; set; }

        public DateTime? ApprovalDate { get; set; }
    }
}