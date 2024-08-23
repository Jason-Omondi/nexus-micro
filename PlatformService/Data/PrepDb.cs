using PlatformService.Models;

namespace PlatformService.Data {
    public static class Prepdb {
        public static void PrepPopulation(IApplicationBuilder app){

            using (var serviceScope = app.ApplicationServices.CreateScope()){
                SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>());
            }
        }

        private static void SeedData(AppDbContext context){

            if (!context.Platforms.Any()){
                Console.WriteLine("--> Seeding data...");

                context.Platforms.AddRange(
                    new Platform() { Name = "Dot Net", Publisher = "Microsoft", Cost = "Free" },
                    new Platform() { Name = "SQL Server", Publisher = "Microsoft", Cost = "Free" },
                    new Platform() { Name = "Kubernetes", Publisher = "Cloud Native Computing Foundation", Cost = "Free" },
                    new Platform() { Name = "Docker", Publisher = "Cloud Native Computing Foundation", Cost = "Free" },
                    new Platform() { Name = "Kafka", Publisher = "Apache Foundation", Cost = "Free" },
                    new Platform() { Name = "Azure", Publisher = "Microsoft", Cost = "Paid" },
                    new Platform() { Name = "AWS", Publisher = "Amazon", Cost = "Paid" },
                    new Platform() { Name = "Google Cloud", Publisher = "Google", Cost = "Paid" },
                    new Platform() { Name = "Jenkins", Publisher = "CloudBees", Cost = "Free" },
                    new Platform() { Name = "GitHub", Publisher = "Microsoft", Cost = "Free" },
                    new Platform() { Name = "GitLab", Publisher = "GitLab Inc.", Cost = "Free" },
                    new Platform() { Name = "Terraform", Publisher = "HashiCorp", Cost = "Free" },
                    new Platform() { Name = "Ansible", Publisher = "Red Hat", Cost = "Free" },
                    new Platform() { Name = "Prometheus", Publisher = "Cloud Native Computing Foundation", Cost = "Free" },
                    new Platform() { Name = "Grafana", Publisher = "Grafana Labs", Cost = "Free" },
                    new Platform() { Name = "Elasticsearch", Publisher = "Elastic", Cost = "Free" },
                    new Platform() { Name = "Logstash", Publisher = "Elastic", Cost = "Free" },
                    new Platform() { Name = "Kibana", Publisher = "Elastic", Cost = "Free" },
                    new Platform() { Name = "Spring Boot", Publisher = "Pivotal", Cost = "Free" },
                    new Platform() { Name = "Node.js", Publisher = "OpenJS Foundation", Cost = "Free" },
                    new Platform() { Name = "NiFi", Publisher = "Apache Software Foundation", Cost = "Free" },
                    new Platform() { Name = "Oracle DB", Publisher = "Oracle", Cost = "Paid" },
                    new Platform() { Name = "QlikSense", Publisher = "Qlik", Cost = "Paid" },
                    new Platform() { Name = "Informatica", Publisher = "Informatica", Cost = "Paid" },
                    new Platform() { Name = "MongoDB", Publisher = "MongoDB Inc.", Cost = "Free" },
                    new Platform() { Name = "RabbitMQ", Publisher = "Pivotal", Cost = "Free" }
            
                );

                context.SaveChanges();

            } else {
                Console.WriteLine("--> We already have data");
            }
        }
    }
}