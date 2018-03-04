using System;
using System.Xml.Serialization;

namespace BlogML.Core.Xml
{
    [Serializable]
    public sealed class BlogMLAuthor : BlogMLNode
    {
        [XmlAttribute("email")]
        public string email { get; set; }
    }
}
