using JSONDemo.Models;
using JSONDemo.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace JSONDemo.Controllers
{
    [ApiController]
    public class HomeController : Controller
    {
        string url = "https://my-json-server.typicode.com/elfosena/csharp/posts";
        IPostService _postService;

        public HomeController(IPostService postService)
        {
            _postService = postService;
        }

        [HttpGet("read")]
        public async Task<IActionResult> Read()
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var httpResponseMessage = await httpClient.GetAsync(url);
                string jsonResponse = await httpResponseMessage.Content.ReadAsStringAsync();

                return Ok(jsonResponse);
            }
        }

        [HttpGet("saveposts")]
        public async Task<IActionResult> SavePosts()
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var httpResponseMessage = await httpClient.GetAsync(url);
                string jsonResponse = await httpResponseMessage.Content.ReadAsStringAsync();

                //Desirialize the JSON response into a C# array of Posts
                var posts = JsonConvert.DeserializeObject<Post[]>(jsonResponse);

                foreach (var post in posts)
                {
                    _postService.Create(post);
                }

                return Ok("Posts saved.");
            }
        }

        [HttpGet("getpost")]
        public IActionResult GetPost(int id)
        {
            Post post = _postService.Get(id);
            if (post == null)
            {
                return BadRequest("Post doesn't exist.");
            }
            else
            {
                return Ok(post);
            }
        }

    }
}
