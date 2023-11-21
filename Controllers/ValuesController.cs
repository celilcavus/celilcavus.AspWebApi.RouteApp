using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplication1.Controllers
{
    public class ValuesController : ApiController
    {
        static List<String> values = new List<String>()
        {
            "value 0","value 1","value 2"
        };
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return values.ToList();
        }
        [HttpGet]
        // GET api/values/5
        public string Get(int id)
        {
            return values[id];
        }
        [HttpPost]
        // POST api/values
        public void Post([FromBody] string value)
        {
            values.Add(value);
        }
        [HttpPut]
        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
            values[id] = value;
        }
        [HttpDelete]
        // DELETE api/values/5
        public void Delete(int id)
        {
            values.RemoveAt(id);
        }
    }
}
