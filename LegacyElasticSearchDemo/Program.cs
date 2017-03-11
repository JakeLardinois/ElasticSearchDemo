using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nest;

namespace LegacyElasticSearchDemo
{
    class Program
    {
        public static Uri node;
        public static ConnectionSettings settings;
        public static ElasticClient client;

        static void Main(string[] args)
        {
            node = new Uri("http://localhost:9200");
            settings = new ConnectionSettings(node);
            settings.DefaultIndex("my_blog");
            client = new ElasticClient(settings);

            //Creates an index in Elastic Search called my_blog...
            /*var CreateIndexResponse = client.CreateIndex("my_blog", c => c
                .Mappings(ms =>
                    ms.Map<Post>(m => m.AutoMap()))
                .Settings(s => s
                    .NumberOfShards(1)
                    .NumberOfReplicas(1))
            );*/

            // Uncomment these methods to perform operations
            //InsertData();
            PerformTermQuery();
        }

        public static void InsertData()
        {
            var newBlogPost = new Post
            {
                UserId = 1,
                PostDate = DateTime.Now,
                PostText = "This is another blog post."
            };

            var newBlogPost2 = new Post
            {
                UserId = 2,
                PostDate = DateTime.Now,
                PostText = "This is a third blog post."
            };

            var newBlogPost3 = new Post
            {
                UserId = 2,
                PostDate = DateTime.Now.AddDays(5),
                PostText = "This is a blog post from the future."
            };

            client.Index(newBlogPost);
            client.Index(newBlogPost2);
            client.Index(newBlogPost3);
        }

        public static void PerformTermQuery()
        {
            var result =
            client.Search<Post>(s => s
                .Query(p => p.Term(q => q.PostText, "blog")));
        }
    }
}
