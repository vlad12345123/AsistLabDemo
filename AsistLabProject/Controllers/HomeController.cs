using AsistLabProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;

namespace AsistLabProject.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public async Task<IActionResult> Posts()
        {
            var client = new RestClient("https://jsonplaceholder.typicode.com/posts");
            var request = new RestRequest(Method.GET);
            IRestResponse response = await client.ExecuteAsync(request);
            var content = JsonConvert.DeserializeObject<JArray>(response.Content);
            var posts = content.Select(x => new Posts
            {
                Id = (int)x["id"],
                UserId = (int)x["userId"],
                Title = (string)x["title"],
                Body = (string)x["body"]
            }).ToList();

            return View(posts);
        }

        public async Task<IActionResult> Photos()
        {
            var client = new RestClient("https://jsonplaceholder.typicode.com/photos");
            var request = new RestRequest(Method.GET);
            IRestResponse response = await client.ExecuteAsync(request);
            var content = JsonConvert.DeserializeObject<JArray>(response.Content);

            // in this case i create data with List JObjects and work with that   

            var jAlbumsArray = content.ToObject<List<JObject>>(); 

            foreach (var obj in jAlbumsArray)      
            {
                if (jAlbumsArray.IndexOf(obj) == 1)                      
                {
                    foreach (var p in obj.Properties())            
                    {
                        if (p.Name == "title")           
                            obj["title"] = "this title is changed";  //replace some data
                    }
                }
            }

            //Thats 2 option work with JArray data (by index), in this case we work directly (i think thats option better for single changes)

            var jAlbums = JArray.FromObject(jAlbumsArray);

            jAlbums[2]["title"] = "somedata"; //replace some string in third object

            //Thats 3 option (by token) and in this case we can delete some data, which they could not in the past..

            jAlbums.SelectToken("[3]").Remove(); //remove fourth object

            //Group by title
            var jObjectGroup = jAlbums.GroupBy(x => x["title"]).ToList();



            var albums = jAlbums.Select(x => new Photos
            {
                Id = (int)x["id"],
                AlbumId = (int)x["albumId"],
                Title = (string)x["title"],
                Url = (string)x["url"],
                ThumbnailUrl = (string)x["thumbnailUrl"]
            }).ToList();

            return View(albums);
        }

    }
}
