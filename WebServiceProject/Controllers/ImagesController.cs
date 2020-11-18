using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebServiceProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAsync(string name)
        {
            Byte[] img = null;
            try
            {
                img = await System.IO.File.ReadAllBytesAsync("c:\\users\\lenovo\\source\\repos\\WpfProject\\WebServiceProject\\Images\\" + name);
            }
            catch (Exception e)
            {
                return Content(e.ToString());
            }
            return File(img, "image/jpeg");
        }
    }
}