using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogLibrary;
using Lab2._2.Interface;

namespace Lab2._2.Serialize
{
	public class JSONSerialize: IBlogLoader
	{
		public void Save(Blog blog, string jsonPath)
		{
			Functions.JSONWriteBlog(blog, jsonPath);
		}
		public Blog Load(string jsonPath)
		{
			Blog blog = new Blog();
			blog = Functions.JSONReadBlog(jsonPath);
			return blog;
		}
	}
}
