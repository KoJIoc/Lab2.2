using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogLibrary;
namespace Lab2._2.Interface
{
	public interface IBlogLoader
	{
		public void Save(Blog blog, string filePath);
		public Blog Load(string filePath);
	}
}
