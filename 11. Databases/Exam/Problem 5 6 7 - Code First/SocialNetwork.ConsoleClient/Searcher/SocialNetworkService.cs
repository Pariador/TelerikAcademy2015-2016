namespace SocialNetwork.ConsoleClient.Searcher
{
    using System;
    using System.Linq;

    using System.Data.Entity;
    using System.Collections;
    using System.Collections.Generic;

    using SocialNetwork.Models;
    using SocialNetwork.Data;

    public class SocialNetworkService : ISocialNetworkService
    {
        /// <summary>
        /// Get Username, FirstName, LastName, and number of images for
        /// all users which registration year is greater than or equal to the provided year
        /// </summary>
        public IEnumerable GetUsersAfterCertainDate(int year)
        {
            IEnumerable res;
            using (var db = new SocialNetworkDbContext())
            {
                res = db.UserProfiles
                    .Where(u => u.RegistrationDate.Year <= year)
                    .Select(u => new 
                    {
                        u.Username,
                        u.FirstName,
                        u.LastName,
                        ImagesCount = u.Images.Count
                    })
                    .ToList();
            }

            return res;
        }

        /// <summary>
        /// Get all posts in which the user with the provided username is tagged.
        /// Select PostedOn, Content and all usernames of the tagged users in the post.
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public IEnumerable GetPostsByUser(string username)
        {
            IEnumerable res;
            using (var db = new SocialNetworkDbContext())
            {
                res = db.Posts
                    .Where(p => p.TeggedUserProfiles.Any(prof => prof.Username == username))
                    .Select(p => new 
                    {
                        p.PostingDate,
                        p.Content,
                        Usernames = p.TeggedUserProfiles
                            .Select(prof => prof.Username)
                    })
                    .ToList();
            }

            return res;
        }

        /// <summary>
        /// Get all approved friendships, ordered ascending by the friendship date and
        /// paged by the provided numbers. Select FirstUserUsername, FirstUserImage,
        /// SecondUserUsername, SecondUserImage. Images are just the URLs of the first image for each user.
        /// </summary>
        public IEnumerable GetFriendships(int page = 1, int pageSize = 25)
        {
            IEnumerable res;
            using (var db = new SocialNetworkDbContext())
            {
                res = db.Friendships
                    .OrderBy(fr => fr.ApprovalDate)
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize)
                    .Select(fr => new 
                    {
                        FirstUserUsername = fr.FirstUserProfile.Username,
                        FirstUserImage = fr.FirstUserProfile.Images.FirstOrDefault(),
                        SecondUserUsername = fr.SecondUserProfile.Username,
                        SecondUserImage = fr.SecondUserProfile.Images.FirstOrDefault()
                    })
                    .ToList();
            }

            return res;
        }

        /// <summary>
        /// Get all usernames of all the unique users with which the provided user by username
        /// has at least one chat message, ordered alphabetically.
        /// </summary>
        public IEnumerable GetChatUsers(string username)
        {
            IEnumerable res;
            using (var db = new SocialNetworkDbContext())
            {
                res = db.UserProfiles
                    .Where(u => u.Messages.Any(m => 
                        (m.Friendship.FirstUserProfile.Username == username) || 
                        (m.Friendship.SecondUserProfile.Username == username)
                    ))
                    .Select(u => u.Username)
                    .OrderBy(str => str)
                    .ToList();
            }

            return res;
        }
    }
}