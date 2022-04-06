using System;
using Microsoft.AspNetCore.Mvc;

namespace SpeedTest.API.Controllers
{
    public class SpeedTestController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return Ok();
        }

        [HttpGet("ping")]
        public IActionResult Ping()
        {
            return Ok();
        }

        [HttpGet("upload")]
        public IActionResult Upload(string r)
        {
            return Ok();
        }

        [HttpGet("download")]
        public IActionResult Download(int? ckSize)
        {
            var rnd = new Random();
            var data = new byte[1048576];
            rnd.NextBytes(data);

            var chunks = ckSize is not null ? ckSize : 4;
            if(chunks is null) chunks = 4;
            if(chunks>100) chunks = 100;
            for(var i=0; i<chunks; i++) {
                return Ok(data);
               
            }
            return Ok();
        }
    }
}