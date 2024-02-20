using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPIDemo.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        static List<string> strlist = new List<string>() { "Hello", "World" };
        public IEnumerable<string> Get()//Find/Show All records
        {
            return strlist;
        }

        // GET api/values/5
        public string Get(int id)//Find by ID
        {
            string s = null;
            if (id == 1)
            {
                s = "Hello";
            }
            else if (id == 2)
            {
                s = "World";
            }
            else
            {
                s = null;
            }
            return s;
        }

        // POST api/values
        public void Post([FromBody] string value)//Add/Create
        {
            strlist.Add(value);
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)//Update
        {
            if (id == 1)
            {
                strlist[id] = value;
            }
            else
            {
                strlist[id] = value;
            }

        }

        // DELETE api/values/5
        public void Delete(int id)
        {
            if (id != 0)
            {


                strlist.RemoveAt(id);

            }

        }
    }
}
