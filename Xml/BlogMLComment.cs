using System;
using System.Xml.Serialization;

namespace BlogML.Core.Xml
{
    [Serializable]
    public sealed class BlogMLComment : BlogMLNode
    {
        [XmlAttribute("user-name")]
        public string UserName { get; set; }

        [XmlAttribute("user-url")]
        public string UserUrl { get; set;}

        [XmlAttribute("user-email")]
        public string UserEMail { get; set; }

        [XmlElement("content")]
        public BlogMLContent Content { get; set; } = new BlogMLContent();
    }
}
