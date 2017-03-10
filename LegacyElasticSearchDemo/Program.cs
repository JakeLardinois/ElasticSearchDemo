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


            var CreateIndexResponse = client.CreateIndex("my_blog", c => c
                .Mappings(ms =>
                    ms.Map<Post>(m => m.AutoMap()))
                .Settings(s => s
                    .NumberOfShards(1)
                    .NumberOfReplicas(1))
            );
            
        }
    }
}
