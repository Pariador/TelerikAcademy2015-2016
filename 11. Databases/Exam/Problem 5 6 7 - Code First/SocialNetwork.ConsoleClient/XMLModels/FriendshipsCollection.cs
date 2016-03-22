namespace SocialNetwork.ConsoleClient.XMLModels
{
    using System.Collections.Generic;

    using System;
    using System.Xml;
    using System.Xml.Serialization;

    [Serializable()]
    [XmlRoot("Friendships")]
    public class FriendshipsCollection
    {
        [XmlArrayItem("Friendship")]
        public Friendship[] Friendships { get; set; }
    }
}