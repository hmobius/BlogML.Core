using System;
using System.Xml.Serialization;

namespace BlogML.Core.Xml
{
    [Serializable]
    public sealed class BlogMLTrackback : BlogMLNode
    {
        [XmlAttribute("url")]
        public string Url { get; set; }
    }
}
