using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace BlogML.Core.Xml
{
    [Serializable]
    [XmlRoot(ElementName="blog", Namespace="http://www.blogml.com/2006/09/BlogML")]
	public sealed class BlogMLBlog
    {
		[XmlAttribute("root-url")]
		public string RootUrl { get; set; }

        [XmlElement("title")]
        public string Title { get; set; }

        [XmlElement("sub-title")]
        public string SubTitle { get; set; }

        [XmlAttribute("date-created", DataType="dateTime")]
        public DateTime DateCreated { get; set; } = DateTime.Now;

        [XmlArray("extended-properties")]
        [XmlArrayItem("property", typeof(Pair<string, string>))]
        public ExtendedPropertiesCollection ExtendedProperties { get;  } = new ExtendedPropertiesCollection();

        [XmlArray("authors")]
        [XmlArrayItem("author", typeof(BlogMLAuthor))]
        public AuthorCollection Authors { get;  } = new AuthorCollection();


        [XmlArray("posts")]
        [XmlArrayItem("post", typeof(BlogMLPost))]
        public PostCollection Posts { get;  } = new PostCollection();

        [XmlArray("categories")]
        [XmlArrayItem("category", typeof(BlogMLCategory))]
        public CategoryCollection categories { get;  } = new CategoryCollection();

        [Serializable]
        public sealed class AuthorCollection : List<BlogMLAuthor> { }

        [Serializable]
        public sealed class PostCollection : List<BlogMLPost> { }

        [Serializable]
        public sealed class CategoryCollection : List<BlogMLCategory> { }

        [Serializable]
        public sealed class ExtendedPropertiesCollection : List<Pair<string, string>> { }
    }
}
