using System;
using RestSharp;
using RestSharp.Authenticators;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace C__API
{
    class Program
    {
        static void Main(string[] args)
        {
            //description
            Console.WriteLine("Get latest results about Covid 19");
            connectAPI();
        }
        public static void connectAPI()
        {
            //asks for region
            Console.WriteLine("Enter Region:");
            var region = Console.ReadLine();
            

            //connects to API and inserts requested region
            try{
                var client = new RestClient($"https://coronavirus-map.p.rapidapi.com/v1/summary/region?region={region}");
            var request = new RestRequest(Method.GET);
            request.AddHeader("x-rapidapi-key", "a06dee3403msh0ae4f394b8e74dap1715bcjsn8c026b1b16f8");
            request.AddHeader("x-rapidapi-host", "coronavirus-map.p.rapidapi.com");
            //prints API information
            var queryResult = client.Execute(request);
            Console.WriteLine(queryResult.Content);
            string status = queryResult.Content;
            writeToJson(status);
            }
            catch(InvalidCastException)
            {
                Console.WriteLine("ERROR: API request failed!");
            }   
            
            
            
        }
        public static void writeToJson(string status)
        {
            try{
                string pathToFile = "/home/ben/Desktop/JSON-FILES/test.json";
                string jsonString = JsonSerializer.Serialize(status);
                //write string to file
                System.IO.File.WriteAllText(pathToFile, jsonString);
                Console.WriteLine("...Data written successfully");
            }
            catch(InvalidCastException)
            {
                Console.WriteLine("ERROR: Failed to write data to JSON file!");
            } 
            


        }
    }
}
