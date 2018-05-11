using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.IO;
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
        public async Task<ActionResult> Get()
        {
            string dataFilePath = Path.Combine(_hostingEnvironment.ContentRootPath, @"Data\books.json");
            return await Task.FromResult<ActionResult>(Ok(FileSystemFile.ReadAllTextAsync(dataFilePath)));
        }
    }
}
