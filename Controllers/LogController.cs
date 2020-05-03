using System;
using System.IO;
using Microsoft.AspNetCore.Mvc;

namespace Asp_Net_Docker.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LogController : ControllerBase
    {

        private const string LOG_PATH_BASE = "./logs/asp-net-docker";
        [HttpGet]
        public string Get()
        {
            return "log controller";
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Log1([FromBody] BodyData bodyData)
        {
            Console.WriteLine(bodyData.Data);
            var filename = RandomFileName();
            Directory.CreateDirectory(LOG_PATH_BASE);
            using (var textWriter = new FileInfo(Path.Combine(LOG_PATH_BASE, filename)).CreateText())
            {
                textWriter.Write(bodyData.Data);
            }
            return Ok();
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Log2([FromBody] BodyData bodyData)
        {
            Console.WriteLine(bodyData.Data);
            var randomStr = RandomString();
            var filename = $"{randomStr}.txt";
            var path = Path.Combine(LOG_PATH_BASE, randomStr);
            Directory.CreateDirectory(path);
            using (var textWriter = new FileInfo(Path.Combine(path, filename)).CreateText())
            {
                textWriter.Write(bodyData.Data);
            }
            return Ok();
        }


        private static string RandomFileName()
        {
            return $"{RandomString()}.txt";
        }

        private static string RandomString()
        {
            return DateTime.Now.ToString("yyyyMMdd-HHmmss-FFFFFFF");
        }
    }

}