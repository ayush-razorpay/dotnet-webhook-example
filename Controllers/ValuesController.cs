using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;
using Newtonsoft.Json;

using System.Net;

namespace dotnet_example.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public string Post( Object value,[FromHeader(Name = "x-razorpay-signature")] string signature)
        {
        
   
      System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            string v = value.ToString();
     

      
      var hash = new HMACSHA256(Encoding.ASCII.GetBytes("test"));
      var t =  hash.ComputeHash(Encoding.ASCII.GetBytes(v));
     string generatedSignature =  BitConverter.ToString(t).Replace("-", "").ToLower();
        Console.WriteLine("x-razorpay-signature -  "+signature);
     Console.WriteLine("generatedSignature -    "+generatedSignature);

     if (String.Equals(generatedSignature, signature))  {

         return "signature matched";
     }else{

  return "signature does not match";
     }

        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }


    
}
