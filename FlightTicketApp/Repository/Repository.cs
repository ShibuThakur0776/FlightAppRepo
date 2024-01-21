using FlightTicketApp.Repository.IRepository;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Text.Json.Serialization;


namespace FlightTicketApp.Repository
{
    // Implementing IRepository Genric Interface
    public class Repository<T>: IRepository<T> where T : class
    {   // Creating a readonly property By IHttpClientFactory
        private readonly IHttpClientFactory _httpClientFactory;
        //creating  Dependency Injection 
        public Repository(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        //Create Method 
        public async Task<bool> CreateAsync(string url, T objToCreate)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, url);
            if(objToCreate != null)
            {
                //Serializing object into Json format
                request.Content = new StringContent(JsonConvert.SerializeObject(objToCreate)
                    ,Encoding.UTF8,"application/json");
            }
            // Creating Http Client
            var client = _httpClientFactory.CreateClient();
            //Api Calling
            HttpResponseMessage response = await client.SendAsync(request);
            // 201 == 201
            if(response.StatusCode == System.Net.HttpStatusCode.Created) 
                return true;
            else
                return false;
        }
        // boolean func for Deleting a Record
        public async Task<bool> DeleteAsync(string url, int id)
        {
            //Converting Id into String and Concatination with url
            var request = new HttpRequestMessage(HttpMethod.Delete, url+id.ToString());
            var client = _httpClientFactory.CreateClient();
            HttpResponseMessage response = await client.SendAsync(request);
            //200 == 200
            if(response.StatusCode == System.Net.HttpStatusCode.OK)
                return true;
            else 
                return false;
        }

        public async Task<IEnumerable<T>> GetAllAsync(string url)
        {
            //Http request object 
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            //Client is used to call Api Endpoint
            var client = _httpClientFactory.CreateClient();
            //Calling Api by its url passed by request object
            HttpResponseMessage response = await client.SendAsync(request);
            //Checking is status code is 200 or not ?
            if(response.StatusCode == System.Net.HttpStatusCode.OK)
            {   
                //Converting json into String 
                var jsonString = await response.Content.ReadAsStringAsync();
                //Converting string into object
                return JsonConvert.DeserializeObject<IEnumerable<T>>(jsonString);
            }
            return null;
        }

        public async Task<T> GetAsync(string url, int id)
        {
            var request = new HttpRequestMessage(HttpMethod.Get,url+id.ToString());
            var client = _httpClientFactory.CreateClient();
            // Calling Api To Get the record
            HttpResponseMessage response = await client.SendAsync(request);
            //200
            if(response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                //json String = {"Json"}
                var jsonString = await response.Content.ReadAsStringAsync();
                // Convert into json to object
                return JsonConvert.DeserializeObject<T>(jsonString);
            }
            return null;
        }

        public async Task<bool> UpdateAsync(string url, T objToUpdate)
        {
            var request = new HttpRequestMessage(HttpMethod.Put, url);
            if(objToUpdate != null)
            {
                request.Content = new StringContent(
                    JsonConvert.SerializeObject(objToUpdate),
                    Encoding.UTF8,"application/json");
            }
            var client = _httpClientFactory.CreateClient();
            HttpResponseMessage response = await client.SendAsync(request);
            if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                return true;
            else
                return false;
        }
    }
}
