using BlogLibrary;
using Lab2._2.Serialize;
using Lab2._2;
using System.Xml.Linq;
using System.Xml.Schema;
using System.Xml;
using Newtonsoft.Json.Schema;
using Newtonsoft.Json.Linq;

namespace Lab2._2Test
{
	[TestClass]
	public class BlogTests
	{
		[TestMethod]
		public void SAXLoadTesting()
		{
			string xmlPath = "C:\\Users\\User\\source\\repos\\Lab2.2\\Lab2.2\\BlogLinqToXML.xml";
			DateTime date1 = new DateTime(2023, 5, 17);
			UserProfile user1 = new UserProfile() { Id = 1, Firstname = "Firstname", Lastname = "Lastname" };
			List<UserProfile> users = new List<UserProfile>();
			users.Add(user1);
			List<Article> articles = new List<Article>();
			List<Comment> comments = new List<Comment>();
			List<AnswerComment> answerComments = new List<AnswerComment>();
			AnswerComment answerComment1 = new AnswerComment() { Id = 1, AnswerCommentator = user1, TextOfComment = "TextOfAnswerComment" };
			answerComments.Add(answerComment1);
			Comment comment1 = new Comment() { TextOfComment = "TextOfComment", Id = 1, AnswerComments = answerComments, Commentator = user1 };
			comments.Add(comment1);
			List<Tag> tags = new List<Tag>();
			Tag tag1 = new Tag();
			tag1.Id = 1;
			tag1.Description = "DescriptionOfTag";
			tag1.Title = "TitleOfTag";
			tags.Add(tag1);
			Article article1 = new Article() { Id = 1, Description = "DescriptionOfArticle", Comments = comments, DateOfCreation = date1, Tags = tags };
			articles.Add(article1);
			Blog expectedBlog = new Blog() { Articles = articles, Description = "DescriptionOfBlog", Id = 1, Owner = user1, Title = "TitleOfBlog" };
			Blog blog = new Blog();
			SAXXMLSerialize sax = new SAXXMLSerialize();
			blog = sax.Load(xmlPath);
			Assert.AreEqual(blog.Id, expectedBlog.Id);
			Assert.IsTrue(Functions.UserAreEqual(blog.Owner, expectedBlog.Owner));
			Assert.AreEqual(blog.Title, expectedBlog.Title);
			Assert.AreEqual(blog.Description, expectedBlog.Description);
			Assert.IsTrue(Functions.BlogArticlesAreEqual(blog, expectedBlog));
		}
		[TestMethod]
		public void SAXSaveTesting()
		{
			string xmlPath = "C:\\Users\\User\\source\\repos\\Lab2.2\\Lab2.2\\BlogSAX.xml";
			string expectedXmlPath = "C:\\Users\\User\\source\\repos\\Lab2.2\\Lab2.2\\BlogSAXRead.xml";
			DateTime date1 = new DateTime(2023, 5, 17);
			UserProfile user1 = new UserProfile() { Id = 1, Firstname = "Firstname", Lastname = "Lastname" };
			List<UserProfile> users = new List<UserProfile>();
			users.Add(user1);
			List<Article> articles = new List<Article>();
			List<Comment> comments = new List<Comment>();
			List<AnswerComment> answerComments = new List<AnswerComment>();
			AnswerComment answerComment1 = new AnswerComment() { Id = 1, AnswerCommentator = user1, TextOfComment = "TextOfAnswerComment" };
			answerComments.Add(answerComment1);
			Comment comment1 = new Comment() { TextOfComment = "TextOfComment", Id = 1, AnswerComments = answerComments, Commentator = user1 };
			comments.Add(comment1);
			List<Tag> tags = new List<Tag>();
			Tag tag1 = new Tag();
			tag1.Id = 1;
			tag1.Description = "DescriptionOfTag";
			tag1.Title = "TitleOfTag";
			tags.Add(tag1);
			Article article1 = new Article() { Id = 1, Description = "DescriptionOfArticle", Comments = comments, DateOfCreation = date1, Tags = tags };
			articles.Add(article1);
			Blog blog = new Blog() { Articles = articles, Description = "DescriptionOfBlog", Id = 1, Owner = user1, Title = "TitleOfBlog" };
			string expectedFileString = File.ReadAllText(expectedXmlPath);
			SAXXMLSerialize sax = new SAXXMLSerialize();
			sax.Save(blog, xmlPath);
			string FileString = File.ReadAllText(xmlPath);
			Assert.AreEqual(FileString, expectedFileString);

		}
		[TestMethod]
		public void LinqToXMLLoadTesting()
		{
			string xmlPath = "C:\\Users\\User\\source\\repos\\Lab2.2\\Lab2.2\\BlogLinqToXML.xml";
			DateTime date1 = new DateTime(2023, 5, 17);
			UserProfile user1 = new UserProfile() { Id = 1, Firstname = "Firstname", Lastname = "Lastname"};
			List<UserProfile> users = new List<UserProfile>();
			users.Add(user1);
			List<Article> articles = new List<Article>();
			List<Comment> comments = new List<Comment>();
			List<AnswerComment> answerComments = new List<AnswerComment>();
			AnswerComment answerComment1 = new AnswerComment() { Id = 1, AnswerCommentator = user1, TextOfComment = "TextOfAnswerComment"};
			answerComments.Add(answerComment1);
			Comment comment1 = new Comment() { TextOfComment = "TextOfComment", Id = 1, AnswerComments = answerComments, Commentator = user1 };
			comments.Add(comment1);
			List<Tag> tags = new List<Tag>();
			Tag tag1 = new Tag();
			tag1.Id = 1;
			tag1.Description = "DescriptionOfTag";
			tag1.Title = "TitleOfTag";
			tags.Add(tag1);
			Article article1 = new Article() { Id = 1, Description = "DescriptionOfArticle", Comments = comments, DateOfCreation = date1, Tags = tags };
			articles.Add(article1);
			Blog expectedBlog = new Blog() { Articles = articles, Description = "DescriptionOfBlog", Id = 1, Owner = user1, Title = "TitleOfBlog" };
			Blog blog = new Blog();
			LinqToXMLSerialize linq = new LinqToXMLSerialize();
			blog = linq.Load(xmlPath);
			Assert.AreEqual(blog.Id, expectedBlog.Id);
			Assert.IsTrue(Functions.UserAreEqual(blog.Owner, expectedBlog.Owner));
			Assert.AreEqual(blog.Title, expectedBlog.Title);
			Assert.AreEqual(blog.Description, expectedBlog.Description);
			Assert.IsTrue(Functions.BlogArticlesAreEqual(blog, expectedBlog));
		}
		[TestMethod]
		public void LinqToXMLSaveTesting()
		{
			string xmlPath = "C:\\Users\\User\\source\\repos\\Lab2.2\\Lab2.2\\BlogLinqToXML.xml";
			string expectedXmlPath = "C:\\Users\\User\\source\\repos\\Lab2.2\\Lab2.2\\BlogLinqToXMLRead.xml";
			DateTime date1 = new DateTime(2023, 5, 17);
			UserProfile user1 = new UserProfile() { Id = 1, Firstname = "Firstname", Lastname = "Lastname" };
			List<UserProfile> users = new List<UserProfile>();
			users.Add(user1);
			List<Article> articles = new List<Article>();
			List<Comment> comments = new List<Comment>();
			List<AnswerComment> answerComments = new List<AnswerComment>();
			AnswerComment answerComment1 = new AnswerComment() { Id = 1, AnswerCommentator = user1, TextOfComment = "TextOfAnswerComment" };
			answerComments.Add(answerComment1);
			Comment comment1 = new Comment() { TextOfComment = "TextOfComment", Id = 1, AnswerComments = answerComments, Commentator = user1 };
			comments.Add(comment1);
			List<Tag> tags = new List<Tag>();
			Tag tag1 = new Tag();
			tag1.Id = 1;
			tag1.Description = "DescriptionOfTag";
			tag1.Title = "TitleOfTag";
			tags.Add(tag1);
			Article article1 = new Article() { Id = 1, Description = "DescriptionOfArticle", Comments = comments, DateOfCreation = date1, Tags = tags };
			articles.Add(article1);
			Blog blog = new Blog() { Articles = articles, Description = "DescriptionOfBlog", Id = 1, Owner = user1, Title = "TitleOfBlog" };
			string expectedFileString = File.ReadAllText(expectedXmlPath);
			SAXXMLSerialize sax = new SAXXMLSerialize();
			sax.Save(blog, xmlPath);
			string FileString = File.ReadAllText(xmlPath);
			Assert.AreEqual(FileString, expectedFileString);
		}
		[TestMethod]
		public void JSONLoadTesting()
		{
			string jsonPath = "C:\\Users\\User\\source\\repos\\Lab2.2\\Lab2.2\\BlogJSON.json";
			DateTime date1 = new DateTime(2023, 5, 17);
			UserProfile user1 = new UserProfile() { Id = 1, Firstname = "Firstname", Lastname = "Lastname" };
			List<UserProfile> users = new List<UserProfile>();
			users.Add(user1);
			List<Article> articles = new List<Article>();
			List<Comment> comments = new List<Comment>();
			List<AnswerComment> answerComments = new List<AnswerComment>();
			AnswerComment answerComment1 = new AnswerComment() { Id = 1, AnswerCommentator = user1, TextOfComment = "TextOfAnswerComment" };
			answerComments.Add(answerComment1);
			Comment comment1 = new Comment() { TextOfComment = "TextOfComment", Id = 1, AnswerComments = answerComments, Commentator = user1 };
			comments.Add(comment1);
			List<Tag> tags = new List<Tag>();
			Tag tag1 = new Tag();
			tag1.Id = 1;
			tag1.Description = "DescriptionOfTag";
			tag1.Title = "TitleOfTag";
			tags.Add(tag1);
			Article article1 = new Article() { Id = 1, Description = "DescriptionOfArticle", Comments = comments, DateOfCreation = date1, Tags = tags };
			articles.Add(article1);
			Blog expectedBlog = new Blog() { Articles = articles, Description = "DescriptionOfBlog", Id = 1, Owner = user1, Title = "TitleOfBlog" };
			Blog blog = new Blog();
			JSONSerialize json =new JSONSerialize();
			blog = json.Load(jsonPath);
			Assert.AreEqual(blog.Id, expectedBlog.Id);
			Assert.IsTrue(Functions.UserAreEqual(blog.Owner, expectedBlog.Owner));
			Assert.AreEqual(blog.Title, expectedBlog.Title);
			Assert.AreEqual(blog.Description, expectedBlog.Description);
			Assert.IsTrue(Functions.BlogArticlesAreEqual(blog, expectedBlog));
		}
		[TestMethod]
		public void JSONSaveTesting()
		{
			string jsonPath = "C:\\Users\\User\\source\\repos\\Lab2.2\\Lab2.2\\BlogJSON.json";
			string expectedJsonPath = "C:\\Users\\User\\source\\repos\\Lab2.2\\Lab2.2\\BlogJSONRead.json";
			DateTime date1 = new DateTime(2023, 5, 17);
			UserProfile user1 = new UserProfile() { Id = 1, Firstname = "Firstname", Lastname = "Lastname" };
			List<UserProfile> users = new List<UserProfile>();
			users.Add(user1);
			List<Article> articles = new List<Article>();
			List<Comment> comments = new List<Comment>();
			List<AnswerComment> answerComments = new List<AnswerComment>();
			AnswerComment answerComment1 = new AnswerComment() { Id = 1, AnswerCommentator = user1, TextOfComment = "TextOfAnswerComment" };
			answerComments.Add(answerComment1);
			Comment comment1 = new Comment() { TextOfComment = "TextOfComment", Id = 1, AnswerComments = answerComments, Commentator = user1 };
			comments.Add(comment1);
			List<Tag> tags = new List<Tag>();
			Tag tag1 = new Tag();
			tag1.Id = 1;
			tag1.Description = "DescriptionOfTag";
			tag1.Title = "TitleOfTag";
			tags.Add(tag1);
			Article article1 = new Article() { Id = 1, Description = "DescriptionOfArticle", Comments = comments, DateOfCreation = date1, Tags = tags };
			articles.Add(article1);
			Blog blog = new Blog() { Articles = articles, Description = "DescriptionOfBlog", Id = 1, Owner = user1, Title = "TitleOfBlog" };
			string expectedFileString = File.ReadAllText(expectedJsonPath);
			JSONSerialize json = new JSONSerialize();
			json.Save(blog, jsonPath);
			string FileString = File.ReadAllText(jsonPath);
			Assert.AreEqual(FileString, expectedFileString);
		}
		[TestMethod]
		public void XMLValidateTesting()
		{
			string xsdPath = "C:\\Users\\User\\source\\repos\\Lab2.2\\Lab2.2\\BlogXMLSchema.xsd";
			string xmlPath = "C:\\Users\\User\\source\\repos\\Lab2.2\\Lab2.2\\BlogSAX.xml";
			XDocument doc = XDocument.Load(xmlPath);
			XmlSchemaSet schemas = new XmlSchemaSet();
			schemas.Add("", xsdPath);
			bool isValid = true;
			doc.Validate(schemas, (s, e) =>
			{
				Console.WriteLine(e.Message);
				isValid = false;
			});
			Assert.IsTrue(isValid);
		}
		
	}
}