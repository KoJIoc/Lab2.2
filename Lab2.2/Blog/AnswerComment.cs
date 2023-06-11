using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog
{
	public class AnswerComment
	{
		public string TextOfComment { get; set; }
		public UserInfo AnswerCommentator { get; set; }
		public int Id { get; set; }
	}
}
