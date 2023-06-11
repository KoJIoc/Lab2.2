using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using Newtonsoft.Json;
using BlogLibrary;
namespace Lab2
{
	public class Functions
	{
		public static void SAXXMLWriteBlog(Blog blog, string xmlPath)
		{
			XmlWriterSettings settings = new XmlWriterSettings();
			settings.Indent = true;
			XmlWriter xw = XmlWriter.Create(xmlPath, settings);
			xw.WriteStartDocument();
				xw.WriteStartElement("blog");
					xw.WriteAttributeString("id", blog.Id.ToString());
					SaxWriteArticles(xw, blog);
					xw.WriteElementString("titleOfBlog", blog.Title);
					xw.WriteElementString("descriptionOfBlog", blog.Description);
					SaxWriteOwner(xw, blog);
				xw.WriteEndElement();
			xw.WriteEndDocument();
			xw.Flush();
			xw.Close();
		}
		public static Blog SAXXMLReadBlog(string xmlPath)
		{
			Article article = new Article();
			Comment comment = new Comment();
			AnswerComment answerComment = new AnswerComment();
			UserProfile commentator = new UserProfile();
			UserProfile owner = new UserProfile();
			UserProfile answerCommentator = new UserProfile();
			Tag tag = new Tag();
			List<Comment> comments = new List<Comment>();
			Blog blog = new Blog();
			List<Article> articles = new List<Article>();
			List<AnswerComment> answerComments = new List<AnswerComment>();
			List<Tag> tags = new List<Tag>();
			XmlReader xr = XmlReader.Create(xmlPath);
			string element = "";
			while (xr.Read())
			{
				if (xr.NodeType == XmlNodeType.Element)
				{
					element = xr.Name;
					switch (element)
					{
						case "blog":
							blog.Id = int.Parse(xr.GetAttribute("id"));
							break;
						case "article":
							article.Id = int.Parse(xr.GetAttribute("id"));
							break;
						case "comment":
							comment.Id = int.Parse(xr.GetAttribute("id"));
							break;
						case "answerComment":
							answerComment.Id = int.Parse(xr.GetAttribute("id"));
							break;
						case "commentator":
							commentator.Id = int.Parse(xr.GetAttribute("id"));
							break;
						case "answerCommentator":
							answerCommentator.Id = int.Parse(xr.GetAttribute("id"));
							break;
						case "owner":
							owner.Id = int.Parse(xr.GetAttribute("id"));
							break;
						case "tag":
							tag.Id = int.Parse(xr.GetAttribute("id"));
							break;

					}
				}
				else if (xr.NodeType == XmlNodeType.Text)
				{
					switch (element)
					{
						case "descriptionOfArticle":
							article.Description = xr.Value;
							break;
						case "dateOfCreation":
							article.DateOfCreation = DateTime.Parse(xr.Value);
							break;
						case "textOfComment":
							comment.TextOfComment = xr.Value;
							break;
						case "textOfAnswerComment":
							answerComment.TextOfComment = xr.Value;
							break;
						case "firstnameOfAnswerCommentator":
							answerCommentator.Firstname = xr.Value;
							break;
						case "lastnameOfAnswerCommentator":
							answerCommentator.Lastname = xr.Value;
							break;
						case "firstnameOfOwner":
							owner.Firstname = xr.Value;
							break;
						case "lastnameOfOwner":
							owner.Lastname = xr.Value;
							break;
						case "firstnameOfCommentator":
							commentator.Firstname = xr.Value;
							break;
						case "lastnameOfCommentator":
							commentator.Lastname = xr.Value;
							break;
						case "titleOfBlog":
							blog.Title = xr.Value;
							break;
						case "descriptionOfBlog":
							blog.Description = xr.Value;
							break;
						case "titleOfTag":
							tag.Title = xr.Value;
							break;
						case "descriptionOfTag":
							tag.Description = xr.Value;
							break;

					}
				}
				else if (xr.NodeType == XmlNodeType.EndElement)
				{
					switch (xr.Name)
					{
						case "article":
							articles.Add(article);
							break;
						case "tag":
							tags.Add(tag);
							break;
						case "comment":
							comments.Add(comment);
							break;
						case "answerComment":
							answerComments.Add(answerComment);
							break;
						case "comments":
							article.Comments = comments;
							break;
						case "articles":
							blog.Articles = articles;
							break;
						case "answerComments":
							comment.AnswerComments = answerComments;
							break;
						case "tags":
							article.Tags = tags;
							break;
						case "answerCommentator":
							answerComment.AnswerCommentator = answerCommentator;
							break;
						case "commentator":
							comment.Commentator = commentator;
							break;
						case "owner":
							blog.Owner = owner;
							break;
					}
				}
			}
			return blog;
		}
		public static void LinqToXMLWriteBlog(Blog _blog, string xmlPath)
		{
			XDocument doc = new XDocument();
			XElement blog = new XElement("blog");
			blog.Add(new XAttribute("id", _blog.Id));
			LinqWriteArticles(_blog, blog);
			blog.Add(new XElement("titleOfBlog", _blog.Title));
			blog.Add(new XElement("descriptionOfBlog", _blog.Description));
			LinqWriteOwner(_blog, blog);
			doc.Add(blog);
			doc.Save(xmlPath);
		}
		public static Blog LinqToXMLReadBlog(string xmlPath)
		{
			Blog blog = new Blog();
			XDocument doc = XDocument.Load(xmlPath);
			XElement blogElement = doc.Element("blog");
			XAttribute idBlog = blogElement.Attribute("id");
			blog.Id = int.Parse(idBlog.Value);
			LinqReadOwner(blogElement, blog);
			LinqReadArticles(blogElement, blog);
			blog.Title = blogElement.Element("titleOfBlog").Value;
			blog.Description = blogElement.Element("descriptionOfBlog").Value;
			return blog;
		}
		public static void JSONWriteBlog(Blog blog, string jsonPath)
		{
			string json = JsonConvert.SerializeObject(blog);
			File.WriteAllText(jsonPath, json);
		}
		public static Blog JSONReadBlog(string jsonPath)
		{
			string json = File.ReadAllText(jsonPath);
			Blog blog = JsonConvert.DeserializeObject<Blog>(json);
			return blog;
		}
		public static void LinqReadOwner(XElement blogElement, Blog blog)
		{
			UserProfile owner = new UserProfile();
			XElement xOwner = blogElement.Element("owner");
			owner.Firstname = xOwner.Element("firstnameOfOwner").Value;
			owner.Lastname = xOwner.Element("lastnameOfOwner").Value;
			owner.Id = int.Parse(xOwner.Attribute("id").Value);
			blog.Owner = owner;
			
		}
		public static void LinqReadArticles(XElement blogElement, Blog blog)
		{
			Article article = new Article();
			List<Article> articles = new List<Article>();
			XElement xArticles = blogElement.Element("articles");
			foreach (XElement xArticle in xArticles.Elements("article"))
			{
				article.Id = int.Parse(xArticle.Attribute("id").Value);
				article.Description = xArticle.Element("descriptionOfArticle").Value;
				article.DateOfCreation = DateTime.Parse(xArticle.Element("dateOfCreation").Value);
				LinqReadTags(xArticle, article);
				LinqReadComments(xArticle, article);
				articles.Add(article);
			}
			blog.Articles = articles;
		}
		public static void LinqReadComments(XElement xArticle, Article article)
		{
			Comment comment = new Comment();
			List<Comment> comments = new List<Comment>();
			UserProfile commentator = new UserProfile();
			XElement xComments = xArticle.Element("comments");
			foreach (XElement xComment in xComments.Elements("comment"))
			{
				comment.Id = int.Parse(xComment.Attribute("id").Value);
				comment.TextOfComment = xComment.Element("textOfComment").Value;
				XElement xCommentator = xComment.Element("commentator");
				commentator.Firstname = xCommentator.Element("firstnameOfCommentator").Value;
				commentator.Lastname = xCommentator.Element("lastnameOfCommentator").Value;
				commentator.Id = int.Parse(xCommentator.Attribute("id").Value);
				LinqReadAnswerComments(xComment, comment);
				comment.Commentator = commentator;
				comments.Add(comment);
			}
			article.Comments = comments;
		}
		public static void LinqReadTags(XElement xArticle, Article article)
		{
			Tag tag = new Tag();
			List<Tag> tags = new List<Tag>();
			XElement xTags = xArticle.Element("tags");
			foreach (XElement xTag in xTags.Elements("tag"))
			{
				tag.Id = int.Parse(xTag.Attribute("id").Value);
				tag.Description = xTag.Element("descriptionOfTag").Value;
				tag.Title = xTag.Element("titleOfTag").Value;
				tags.Add(tag);
			}
			article.Tags = tags;
		}
		public static void LinqReadAnswerComments(XElement xComment, Comment comment)
		{
			AnswerComment answerComment = new AnswerComment();
			UserProfile answerCommentator = new UserProfile();
			List<AnswerComment> answerComments = new List<AnswerComment>();
			XElement xAnswerComments = xComment.Element("answerComments");
			foreach (XElement xAnswerComment in xAnswerComments.Elements("answerComment"))
			{
				answerComment.Id = int.Parse(xAnswerComment.Attribute("id").Value);
				answerComment.TextOfComment = xAnswerComment.Element("textOfAnswerComment").Value;
				XElement xAnswerCommentator = xAnswerComment.Element("answerCommentator");
				answerCommentator.Firstname = xAnswerCommentator.Element("firstnameOfAnswerCommentator").Value;
				answerCommentator.Lastname = xAnswerCommentator.Element("lastnameOfAnswerCommentator").Value;
				answerCommentator.Id = int.Parse(xAnswerCommentator.Attribute("id").Value);
				answerComment.AnswerCommentator = answerCommentator;
				answerComments.Add(answerComment);
			}
			comment.AnswerComments = answerComments;
		}
		public static void SaxWriteAnswerComments(XmlWriter xw, Comment comment)
		{
			xw.WriteStartElement("answerComments");
			List<AnswerComment> answerComments = comment.AnswerComments;
			foreach (var answerComment in answerComments)
			{
				xw.WriteStartElement("answerComment");
				xw.WriteAttributeString("id", answerComment.Id.ToString());
				xw.WriteElementString("textOfAnswerComment", answerComment.TextOfComment);
				xw.WriteStartElement("answerCommentator");
				xw.WriteAttributeString("id", answerComment.AnswerCommentator.Id.ToString());
				xw.WriteElementString("firstnameOfAnswerCommentator", answerComment.AnswerCommentator.Firstname);
				xw.WriteElementString("lastnameOfAnswerCommentator", answerComment.AnswerCommentator.Lastname);
				xw.WriteEndElement();
				xw.WriteEndElement();
			}
			xw.WriteEndElement();
		}
		public static void SaxWriteComments(XmlWriter xw, Article article)
		{
			xw.WriteStartElement("comments");
			List<Comment> comments = article.Comments;
			foreach (var comment in comments)
			{
				xw.WriteStartElement("comment");
				xw.WriteAttributeString("id", comment.Id.ToString());
				xw.WriteElementString("textOfComment", comment.TextOfComment);
				SaxWriteAnswerComments(xw, comment);
				xw.WriteStartElement("commentator");
				xw.WriteAttributeString("id", comment.Commentator.Id.ToString());
				xw.WriteElementString("firstnameOfCommentator", comment.Commentator.Firstname);
				xw.WriteElementString("lastnameOfCommentator", comment.Commentator.Lastname);

				xw.WriteEndElement();
				xw.WriteEndElement();
			}
			xw.WriteEndElement();
		}
		public static void SaxWriteTags(XmlWriter xw, Article article)
		{
			xw.WriteStartElement("tags");
			List<Tag> tags = article.Tags;
			foreach (var tag in tags)
			{
				xw.WriteStartElement("tag");
				xw.WriteAttributeString("id", tag.Id.ToString());
				xw.WriteElementString("titleOfTag", tag.Title);
				xw.WriteElementString("descriptionOfTag", tag.Description);
				xw.WriteEndElement();
			}
			xw.WriteEndElement();
		}
		public static void SaxWriteArticles(XmlWriter xw, Blog blog)
		{
			xw.WriteStartElement("articles");
			foreach (var article in blog.Articles)
			{
				xw.WriteStartElement("article");
				xw.WriteAttributeString("id", article.Id.ToString());
				xw.WriteElementString("descriptionOfArticle", article.Description);
				xw.WriteElementString("dateOfCreation", article.DateOfCreation.ToString("dd-MM-yyyy"));
				SaxWriteComments(xw, article);
				SaxWriteTags(xw, article);
				xw.WriteEndElement();
			}
			xw.WriteEndElement();
		}
		public static void SaxWriteOwner(XmlWriter xw, Blog blog)
		{
			xw.WriteStartElement("owner");
			xw.WriteAttributeString("id", blog.Owner.Id.ToString());
			xw.WriteElementString("firstnameOfOwner", blog.Owner.Firstname);
			xw.WriteElementString("lastnameOfOwner", blog.Owner.Lastname);
			xw.WriteEndElement();
		}
		
		public static bool UserAreEqual(UserProfile user1, UserProfile user2)
		{
			return (user1.Id == user2.Id && user1.Firstname == user2.Firstname && user2.Lastname == user1.Lastname);
		}
		public static bool AnswerCommentAreEqual(AnswerComment comment1, AnswerComment comment2)
		{
			return (comment1.Id == comment2.Id && comment1.TextOfComment == comment2.TextOfComment && UserAreEqual(comment1.AnswerCommentator, comment2.AnswerCommentator));
		}
		public static bool CommentAreEqual(Comment comment1, Comment comment2)
		{
			return (comment1.Id == comment2.Id && comment1.TextOfComment == comment2.TextOfComment && UserAreEqual(comment1.Commentator, comment2.Commentator));
		}
		public static bool TagAreEqual(Tag tag1, Tag tag2)
		{
			return (tag1.Id == tag2.Id && tag1.Description == tag2.Description && tag1.Title == tag2.Title);
		}
		public static bool ArticleAreEqual(Article article1, Article article2)
		{
			bool tagAreEqual = true;
			for(int i =0; i<article1.Tags.Count; i++)
			{
				if (!TagAreEqual(article1.Tags[i], article2.Tags[i]))
				{
					tagAreEqual = false;
				}
			}
			bool commentAreEqual = true;
			bool answerCommentAreEqual = true;
			for(int i = 0; i < article1.Comments.Count; i++)
			{
				for(int j =0; j < article1.Comments[i].AnswerComments.Count; j++)
				{
					if (!AnswerCommentAreEqual(article1.Comments[i].AnswerComments[j], article2.Comments[i].AnswerComments[j]))
					{
						answerCommentAreEqual = false;
					}
				}
			}
			for (int i = 0; i < article1.Comments.Count; i++)
			{
				if (!CommentAreEqual(article1.Comments[i], article2.Comments[i])&&!answerCommentAreEqual)
				{
					commentAreEqual = false;
				}
			}
			return (article1.Description == article2.Description && article1.Id == article2.Id &&tagAreEqual &&commentAreEqual);
		}
		public static bool BlogArticlesAreEqual(Blog blog1, Blog blog2)
		{
			bool articlesAreEqual = true;
			for(int i=0; i < blog1.Articles.Count; i++)
			{
				if (!ArticleAreEqual(blog1.Articles[i], blog2.Articles[i]))
				{
					articlesAreEqual = false;
				}
			}
			return articlesAreEqual;
		}
		public static void LinqWriteTags(Article _article, XElement article)
		{
			XElement tags = new XElement("tags");
			foreach (var _tag in _article.Tags)
			{
				XElement tag = new XElement("tag");
				tag.Add(new XAttribute("id", _tag.Id));
				tag.Add(new XElement("titleOfTag", _tag.Title));
				tag.Add(new XElement("descriptionOfTag", _tag.Description));
				tags.Add(tag);
			}
			article.Add(tags);
		}
		public static void LinqWriteOwner(Blog _blog, XElement blog)
		{
			XElement owner = new XElement("owner");
			owner.Add(new XAttribute("id", _blog.Owner.Id));
			owner.Add(new XElement("firstnameOfOwner", _blog.Owner.Firstname));
			owner.Add(new XElement("lastnameOfOwner", _blog.Owner.Lastname));

			blog.Add(owner);
		}
		public static void LinqWriteArticles(Blog _blog, XElement blog)
		{
			XElement articles = new XElement("articles");
			blog.Add(articles);
			foreach (var _article in _blog.Articles)
			{
				XElement article = new XElement("article");
				article.Add(new XAttribute("id", _article.Id));
				article.Add(new XElement("descriptionOfArticle", _article.Description));
				article.Add(new XElement("dateOfCreation", _article.DateOfCreation.ToString("dd-MM-yyyy")));
				LinqWriteComments(_article, article);
				LinqWriteTags(_article, article);
				articles.Add(article);
			}
		}
		public static void LinqWriteAnswerComments(Comment _comment, XElement comment)
		{
			XElement answerComments = new XElement("answerComments");
			foreach (var _answerComment in _comment.AnswerComments)
			{
				XElement answerComment = new XElement("answerComment");
				answerComment.Add(new XAttribute("id", _answerComment.Id));
				answerComment.Add(new XElement("textOfAnswerComment", _answerComment.TextOfComment));
				XElement answerCommentator = new XElement("answerCommentator");
				answerCommentator.Add(new XAttribute("id", _answerComment.AnswerCommentator.Id));
				answerCommentator.Add(new XElement("firstnameOfAnswerCommentator", _answerComment.AnswerCommentator.Firstname));
				answerCommentator.Add(new XElement("lastnameOfAnswerCommentator", _answerComment.AnswerCommentator.Lastname));

				answerComment.Add(answerCommentator);
				answerComments.Add(answerComment);
			}
			comment.Add(answerComments);
		}
		public static void LinqWriteComments(Article _article, XElement article)
		{
			XElement comments = new XElement("comments");
			foreach (var _comment in _article.Comments)
			{
				XElement comment = new XElement("comment");
				comment.Add(new XAttribute("id", _comment.Id));
				comment.Add(new XElement("textOfComment", _comment.TextOfComment));
				LinqWriteAnswerComments(_comment, comment);
				XElement commentator = new XElement("commentator");
				commentator.Add(new XAttribute("id", _comment.Commentator.Id));
				commentator.Add(new XElement("firstnameOfCommentator", _comment.Commentator.Firstname));
				commentator.Add(new XElement("lastnameOfCommentator", _comment.Commentator.Lastname));

				comment.Add(commentator);
				comments.Add(comment);
			}
			article.Add(comments);
		}
		
		
	}
}
