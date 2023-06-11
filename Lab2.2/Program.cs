using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Text.Json;
using System.Xml.Linq;
using System.Net.Http.Headers;
using BlogLibrary;
using Lab2._2.Serialize;
using System.Xml.Schema;

namespace Lab2
{
	public class Program
	{
		static void Main()
		{
			string saxXmlPath = "C:\\Users\\User\\source\\repos\\Lab2.2\\Lab2.2\\BlogSAX.xml";
			string linqToXmlPath = "C:\\Users\\User\\source\\repos\\Lab2.2\\Lab2.2\\BlogLinqToXML.xml";
			string jsonPath = "C:\\Users\\User\\source\\repos\\Lab2.2\\Lab2.2\\BlogJSON.json";
			List<Role> roles = new List<Role>();
			Role role1 = new Role() { Id=1, Description="DescriptionOfRole", Title ="TitleOfRole"};
			roles.Add(role1);
			UserProfile user1 = new UserProfile() { Firstname="Firstname", Lastname="Lastname",  Id=1 };
			List<UserProfile> users = new List<UserProfile>();
			users.Add(user1);
			List<Article> articles = new List<Article>();
			List<Comment> comments = new List<Comment>();
			List<AnswerComment> answerComments = new List<AnswerComment>();
			AnswerComment answerComment1 = new AnswerComment() { Id=1, AnswerCommentator=user1, TextOfComment="TextOfAnswerComment"};
			answerComments.Add(answerComment1);
			Comment comment1 = new Comment() { TextOfComment="TextOfComment", Id=1, AnswerComments=answerComments, Commentator=user1};
			comments.Add(comment1);
			List<Tag> tags = new List<Tag>();
			Tag tag1 = new Tag();
			tag1.Id = 1;
			tag1.Description = "DescriptionOfTag";
			tag1.Title = "TitleOfTag";
			tags.Add(tag1);
			DateTime date1 = new DateTime(2023, 5, 17);
			Article article1 = new Article() { Id=1, Description="DescriptionOfArticle", Comments = comments, DateOfCreation=date1, Tags=tags};
			articles.Add(article1);
			Blog blog1 = new Blog() { Articles=articles, Description="DescriptionOfBlog", Id=1, Owner=user1, Title="TitleOfBlog"};
			string saxXmlPathRead = "C:\\Users\\User\\source\\repos\\Lab2.2\\Lab2.2\\BlogSAXRead.xml";
			string linqToXmlPathRead = "C:\\Users\\User\\source\\repos\\Lab2.2\\Lab2.2\\BlogLinqToXMLRead.xml";
			string jsonPathRead = "C:\\Users\\User\\source\\repos\\Lab2.2\\Lab2.2\\BlogJSONRead.json";
			SAXXMLSerialize sax = new SAXXMLSerialize();
			sax.Save(blog1, saxXmlPath);
			Blog blog2 = new Blog();
			blog2 = sax.Load(saxXmlPath);
			LinqToXMLSerialize linq = new LinqToXMLSerialize();
			Blog blog3 = new Blog();
			blog3 = blog1;
			linq.Save(blog3, linqToXmlPath);
			Blog blog4 = new Blog();
			blog4 = linq.Load(linqToXmlPath);
			JSONSerialize json = new JSONSerialize();
			Blog blog5 = new Blog();
			blog5 = blog1;
			json.Save(blog5, jsonPath);
			Blog blog6 = new Blog();
			blog6 = json.Load(jsonPath);
			json.Save(blog1, jsonPathRead);
			Blog blog7 = json.Load(jsonPathRead);
			sax.Save(blog1, saxXmlPathRead);
			linq.Save(blog4, linqToXmlPathRead);
			string xsdPath = "C:\\Users\\User\\source\\repos\\Lab2.2\\Lab2.2\\BlogXMLSchema.xsd";
			string xmlPath = "C:\\Users\\User\\source\\repos\\Lab2.2\\Lab2.2\\BlogSAX.xml";
			
		}
		
	}
}
