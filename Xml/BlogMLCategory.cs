using System;
using System.Xml.Serialization;

namespace BlogML.Core.Xml
{
    [Serializable]
    public sealed class BlogMLCategory : BlogMLNode
    {
        [XmlAttribute("description")]
        public string Description { get; set; }

        [XmlAttribute("parentref")]
        public string ParentRef { get; set; }
    }
}
