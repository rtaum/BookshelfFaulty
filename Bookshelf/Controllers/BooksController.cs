using Bookshelf.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

using FileSystemFile = System.IO.File;

namespace Bookshelf.Controllers
{
    [Route("api/[controller]")]
    public class BooksController : Controller
    {
        private readonly IHostingEnvironment _hostingEnvironment;

        public BooksController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        [HttpGet]
        public async Task<ActionResult> Get([FromQuery] string title)
        {
            var rand = new Random();
            if (rand.Next() % 2 == 0)
            {
                return BadRequest();
            }

            string dataFilePath = Path.Combine(
                _hostingEnvironment.ContentRootPath,
                @"Data\books.json");

            var jsonData = await FileSystemFile.ReadAllTextAsync(dataFilePath);
            var books = JsonConvert.DeserializeObject<Book[]>(jsonData);
            var filteredBooks = books.Where(b => string.IsNullOrEmpty(title) || b.Title.Contains(title));

            return await Task.FromResult<ActionResult>(Ok(filteredBooks));
        }
    }
}
