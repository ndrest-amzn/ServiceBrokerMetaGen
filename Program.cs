using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using YamlDotNet.Serialization;
using System.Text;

namespace ServiceBrokerMetaGen
{
    class Program
    {
        static void Main(string[] args)
        {
            LoadJsonTemplate();
        }

        static void LoadJsonTemplate()
        {
            Console.WriteLine("Create ServiceBroker MetaData for template");
            Console.WriteLine("==========================================");
            Console.WriteLine(" ");
            Console.WriteLine("Enter in path to JSON template:");
            string input = Console.ReadLine();

            try
            {
                string json = "";
                using (StreamReader r = new StreamReader(input))
                {
                    json = r.ReadToEnd();
                }
                TraverseJson(json);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                Console.WriteLine(" ");
                Console.WriteLine("Press Key to Retry");
                Console.ReadKey();
                Console.Clear();
                LoadJsonTemplate();
            }

        }

        static void TraverseJson(string json)
        {
            JObject rss = JObject.Parse(json);
            var list = new Dictionary<string, string>();

            foreach (JProperty item in rss["Parameters"])
            {
                list.Add(item.Name, (string)item.Value["Default"]);
            }
            CreateJsonMeta(list);
        }

        static void CreateJsonMeta(Dictionary<string, string> pValues)
        {
            MetaData output = new MetaData();
            AWSServiceBrokerSpecification specificiation = new AWSServiceBrokerSpecification();
            ServicePlans oServicePlans = new ServicePlans();

            specificiation.Tags = new List<string>()
            {
                "",
                ""
            };

            oServicePlans.production = new ServicePlan()
            {
                DisplayName = "Production",
                Description = "Configuration designed for production deployments",
                ParameterValues = pValues
            };

            oServicePlans.dev = new ServicePlan()
            {
                DisplayName = "Development",
                Description = "Configuration designed for development and testing deployments",
                ParameterValues = pValues
            };

            oServicePlans.custom = new ServicePlan()
            {
                DisplayName = "Custom",
                Description = "Custom Configuration for Advanced deployments",
                ParameterValues = new Dictionary<string, string>()
            };

            specificiation.ServicePlans = oServicePlans;
            output.AWSServiceBrokerSpecification = specificiation;

            string json = JsonConvert.SerializeObject(output, Formatting.Indented);
            json = json.Replace("AWSServiceBrokerSpecification", "AWS::ServiceBroker::Specification");
            var yamlSerializer = new SerializerBuilder().Build();
            string yaml = yamlSerializer.Serialize(output);
            yaml = yaml.Replace("AWSServiceBrokerSpecification", "AWS::ServiceBroker::Specification");

            Console.WriteLine(" ");
            Console.WriteLine("==================================JSON========================================");
            Console.WriteLine(" ");
            Console.WriteLine(json);
            Console.WriteLine(" ");
            Console.WriteLine("==================================YAML========================================");
            Console.WriteLine(" ");
            Console.WriteLine(yaml);
            Console.WriteLine(" ");
            Console.WriteLine("==================================END=========================================");
            Console.ReadKey();
        }

        class MetaData
        {
            public AWSServiceBrokerSpecification AWSServiceBrokerSpecification;
        }
        class AWSServiceBrokerSpecification
        {
            public string Version = "1";
            public List<string> Tags;
            public string Name = "";
            public string DisplayName = "";
            public string LongDescription = "";
            public string ImageUrl = "";
            public string DocumentationUrl = "";
            public string ProviderDisplayName = "Amazon Web Services";
            public ServicePlans ServicePlans;
        }

        class ServicePlans
        {
            public ServicePlan production;
            public ServicePlan dev;
            public ServicePlan custom;
        }

        class ServicePlan
        {
            public string DisplayName = "";
            public string Description = "";
            public string LongDescription = "";
            public string Cost = "";
            public Dictionary<string, string> ParameterValues;
        }
    }
}
