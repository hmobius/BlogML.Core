#BlogML.Core

BlogML is an open XML standard for describing the contents of a blog.
The original repo forBlogML is [here](https://code.google.com/archive/p/blogml/)

## About BlogML
To understand the BlogML format, it is useful to understand some basic concepts:

At the top level, BlogML contains information about a Blog

- A Blog can contain multiple Posts
- Posts contain Content and can have Attachments, Trackbacks, and Comments
- Posts can be contained within Categories
- A distinctive feature of BlogML is its ability to store attachments and to richly describe the content held in posts.

The original BlogML discussion group was at [https://groups.google.com/forum/#!forum/blogml-discuss]

## About BlogML.Core
BlogML.Core is a set of .NET Core compatible libraries for working with the BlogML format. 
it is an update of the [BlogML .NET project](https://archive.codeplex.com/?p=blogml). 

This project provides a library that simplifies common tasks such as:

- Writing BlogML out to an XML file 
- Reading BlogML in via a strongly-typed .NET object graph
- Validating BlogML