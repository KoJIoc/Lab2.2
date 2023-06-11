using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog
{
    public class Blog
    {
        public List<Article> Articles { get; set; } = new List<Article>(); 
        public string Title { get; set; }
        public UserInfo Owner { get; set; }
        public string Description { get; set; }
        public int Id { get; set; }
    }
}
