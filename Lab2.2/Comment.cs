using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogNamespace
{
    public class Comment
    {
        public string TextOfComment { get; set; }
        public List<AnswerComment> AnswerComments { get; set; }
        public UserInfo Commentator { get; set; }
        public int Id { get; set; }
    }
}
