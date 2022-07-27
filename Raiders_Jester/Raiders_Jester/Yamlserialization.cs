using System;
using System.IO;
using YamlDotNet.Serialization;

namespace Raiders_Jester
{

    public class YamlSerialization
    {
        
        public static string contents; 
        public static string token;
        public static string ipaddress;
        public static string port;
        public static string onlinemessage;
        public static string offlinemessage;
        public static string yamlconfigfilename = "Config.yaml";
        

        

        public static void Config_Yaml()
        {
            var botconfig = new Yamlconfig.botconfig
            {
                token = "insert bot token here",
                ipaddress = "insert ipaddress here",
                port = "insert port here",
                onlinemessage = "insert message here",
                offlinemessage = "insert message here"
                

            };

            

            if (File.Exists(yamlconfigfilename))
            {
                using (StreamReader sr = new StreamReader(yamlconfigfilename))
                {
                    string[] contentarray = new string[5];

                    for (int i = 0; i < 5; i++)
                    {
                        var eachline = sr.ReadLine();
                        contentarray[i] = eachline;

                        contents = contentarray[i];

                        var input = new StringReader(contents);
                        var deserializer = new DeserializerBuilder().Build();
                        var botconfigcontents = deserializer.Deserialize<Yamlconfig.botconfig>(input);
                        token = botconfigcontents.token;
                        ipaddress = botconfigcontents.ipaddress;
                        port = botconfigcontents.port;
                        onlinemessage = botconfigcontents.onlinemessage;
                        offlinemessage = botconfigcontents.offlinemessage;

                        
                    }



                    




                    

                    
                    
                    
                    



                }





            }

            else
            {
                using FileStream fs = new FileStream(yamlconfigfilename, FileMode.Create);
                fs.Dispose();

                var serializer = new SerializerBuilder().Build();
                var yaml_botconfig = serializer.Serialize(botconfig);
               

                using (StreamWriter sw = new StreamWriter(yamlconfigfilename))
                {
                    sw.WriteLine(yaml_botconfig);
                    
                }

                if (File.Exists(yamlconfigfilename))
                {
                    Console.WriteLine("Config.YAML was created");
                    Console.WriteLine("Please fill out the Config.YAML file with appropriate information");
                    Console.WriteLine("Press a key to exit");
                    Console.ReadKey();

                    Environment.Exit(0);
                }
            }
        }
    }
}
