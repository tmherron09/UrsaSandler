using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UrsaSandlerMemberSite.Services
{
    public class ImageService
    {
        public IConfiguration _config;

        public ImageService(IConfiguration config)
        {
            _config = config;
        }

        public async Task<string> GetMoviePostUrl(string title)
        {
            string key = _config["ImageApi:ServiceApiKey"];
            string host = _config["ImageApi:ServiceApiHost"];
            string query = HttpUtility.UrlEncode(title);

            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("x-rapidapi-key", key);
            client.DefaultRequestHeaders.Add("x-rapidapi-host", host);

            Uri posterRequest = new Uri("https://imdb-internet-movie-database-unofficial.p.rapidapi.com/film/" + query);

            var response = await client.GetAsync(posterRequest);

            var content = await response.Content.ReadAsStringAsync();
            JObject jsonString = JObject.Parse(content);
            var posterUrl = jsonString["poster"].ToString();
            if(posterUrl == "")
            {
                posterUrl = "https://picsum.photos/600/300";
            }
            return posterUrl;
        }

        public async Task<string> GetActorPhoto(string actorName)
        {
            string key = _config["ImageApi:ServiceApiKey"];
            string host = _config["ImageApi:ServiceApiHost"];
            string query = HttpUtility.UrlEncode(actorName);

            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("x-rapidapi-key", key);
            client.DefaultRequestHeaders.Add("x-rapidapi-host", host);

            Uri actorProfileRequest = new Uri("https://imdb-internet-movie-database-unofficial.p.rapidapi.com/search/" + query);

            var response = await client.GetAsync(actorProfileRequest);

            var content = await response.Content.ReadAsStringAsync();
            JObject jsonString = JObject.Parse(content);
            var actorProfileUrl = jsonString["names"][0]["image"].ToString();
            if (actorProfileUrl == "")
            {
                actorProfileUrl = "https://picsum.photos/200";
            }
            return actorProfileUrl;


        }


    }
}
