using System;
using System.IO;
using Microsoft.AspNetCore.Mvc;

namespace Asp_Net_Docker.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LogController : ControllerBase
    {
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
            var path = "./logs/log1";
            var filename = RandomFileName();
            Directory.CreateDirectory(path);
            using (var textWriter = new FileInfo(Path.Combine(path, filename)).CreateText())
            {
                textWriter.Write(bodyData.Data);
            }
            return Ok();
        }

        private static string RandomFileName()
        {
            return $"{DateTime.Now.ToString("yyyyMMdd-HHmmss-FFFFFFF")}.txt";
        }
    }

}