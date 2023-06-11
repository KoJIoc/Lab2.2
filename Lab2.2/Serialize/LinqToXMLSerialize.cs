using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogLibrary;
using Lab2._2.Interface;

namespace Lab2._2.Serialize
{
	public class LinqToXMLSerialize: IBlogLoader
	{
		public void Save(Blog blog, string xmlPath)
		{
			Functions.LinqToXMLWriteBlog(blog, xmlPath);
		}
		public Blog Load(string xmlPath)
		{
			Blog blog = new Blog();
			blog = Functions.LinqToXMLReadBlog(xmlPath);
			return blog;
		}
	}
}
