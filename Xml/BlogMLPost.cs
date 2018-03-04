using System;
using System.Xml.Serialization;
using System.Collections;

namespace BlogML.Core.Xml
{
    [Serializable]
    public sealed class BlogMLPost : BlogMLNode
    {
		[XmlAttribute("post-url")]
		public string PostUrl { get; set; }

        [XmlAttribute("hasexcerpt")]
        public bool HasExcerpt { get; set; }= false;

        [XmlAttribute("type")]
        public BlogPostTypes PostType{ get; set; } = new BlogPostTypes();

        [XmlAttribute("views")]
        public UInt32 Views { get; set; } = 0;

        [XmlElement("post-name")]
        public string PostName { get; set; }

        [XmlElement("content")]
        public BlogMLContent Content { get; set; } = new BlogMLContent();

        [XmlElement("excerpt")]
        public BlogMLContent Excerpt { get; set; } = new BlogMLContent();

        [XmlArray("authors")]
        [XmlArrayItem("author", typeof(BlogMLAuthorReference))]
        public AuthorReferenceCollection Authors { get; } = new AuthorReferenceCollection();
  
        [XmlArray("categories")]
        [XmlArrayItem("category", typeof(BlogMLCategoryReference))]
        public CategoryReferenceCollection Categories { get; }  = new CategoryReferenceCollection();

        [XmlArray("comments")]
        [XmlArrayItem("comment", typeof(BlogMLComment))]
        public CommentCollection Comments { get; }  = new CommentCollection();

        [XmlArray("trackbacks")]
        [XmlArrayItem("trackback", typeof(BlogMLTrackback))]
        public TrackbackCollection Trackbacks { get; }  = new TrackbackCollection();

        [XmlArray("attachments")]
        [XmlArrayItem("attachment", typeof(BlogMLAttachment))]
        public AttachmentCollection Attachments { get; } = new AttachmentCollection();

        [Serializable]
        public sealed class AuthorReferenceCollection : ArrayList
        {
            public new BlogMLAuthorReference this[int index]
            {
                get { return base[index] as BlogMLAuthorReference; }
            }

            public void Add(BlogMLAuthorReference value)
            {
                base.Add(value);
            }

            public BlogMLAuthorReference Add(string authorID)
            {
                BlogMLAuthorReference item = new BlogMLAuthorReference(){ 
                    Ref = authorID 
                };
                base.Add(item);
                return item;
            }
        }

        [Serializable]
        public sealed class CommentCollection : ArrayList
        {
            public new BlogMLComment this[int index]
            {
                get { return base[index] as BlogMLComment; }
            }

            public void Add(BlogMLComment value)
            {
                base.Add(value);
            }
        }

        [Serializable]
        public sealed class TrackbackCollection : ArrayList
        {
            public new BlogMLTrackback this[int index]
            {
                get { return base[index] as BlogMLTrackback; }
            }

            public void Add(BlogMLTrackback value)
            {
                base.Add(value);
            }
        }

        [Serializable]
        public sealed class CategoryReferenceCollection : ArrayList
        {
            public new BlogMLCategoryReference this[int index]
            {
                get { return base[index] as BlogMLCategoryReference; }
            }

            public void Add(BlogMLCategoryReference value)
            {
                base.Add(value);
            }

            public BlogMLCategoryReference Add(string categoryID)
            {
                BlogMLCategoryReference item = new BlogMLCategoryReference(){
                    Ref = categoryID
                };
                base.Add(item);
                return item;
            }
        }

        [Serializable]
        public sealed class AttachmentCollection : ArrayList
        {
            public new BlogMLAttachment this[int index]
            {
                get { return base[index] as BlogMLAttachment; }
            }

            public void Add(BlogMLAttachment value)
            {
                base.Add(value);
            }
        }
    }
}
