using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegacyElasticSearchDemo
{
    public class Post
    {
        public int UserId { get; set; }
        public DateTime PostDate { get; set; }
        public string PostText { get; set; }
    }
}
