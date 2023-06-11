using Lab2._2.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogLibrary;
namespace Lab2._2.Serialize
{
	public class SAXXMLSerialize: IBlogLoader
	{
		public void Save(Blog blog, string xmlPath)
		{
			Functions.SAXXMLWriteBlog(blog, xmlPath);
		}
		public Blog Load(string xmlPath)
		{
			Blog blog = new Blog();
			blog = Functions.SAXXMLReadBlog(xmlPath);
			return blog;
		}
	}
}
