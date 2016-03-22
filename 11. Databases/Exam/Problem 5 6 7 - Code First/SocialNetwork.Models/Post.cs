namespace SocialNetwork.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Post
    {
        private ICollection<UserProfile> taggedUserProfiles;

        public Post()
        {
            this.taggedUserProfiles = new HashSet<UserProfile>();
        }

        public int Id { get; set; }

        [Required]
        [MinLength(10)]
        public string Content { get; set; }

        public DateTime PostingDate { get; set; }

        public virtual ICollection<UserProfile> TeggedUserProfiles
        {
            get
            {
                return this.taggedUserProfiles;
            }

            set 
            {
                this.taggedUserProfiles = value;
            }
        }
    }
}