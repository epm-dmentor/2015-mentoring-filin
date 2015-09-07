#region

using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using SDesk.Models;

#endregion

namespace SDesk.Controllers
{
    public class MailsController : ApiController
    {
        public static readonly List<Mail> Mails = new List<Mail>
        {
            new Mail
            {
                AttachementId = 1,
                Body = "Test Message",
                Cc = "<Aleksandr@barclayscapital.com>",
                Id = 1,
            },
            new Mail
            {
                AttachementId = 2,
                Body = "Test Message 2",
                Cc = "<Olexandr@epam.com>",
                Id = 2,
            }
        };

        // GET api/mails
        public IEnumerable<Mail> Get()
        {
            return Mails;
        }

        // GET api/mails/5
        public Mail Get(int id)
        {
            return Mails.FirstOrDefault(mail => mail.Id == id);
        }

        // POST api/mails
        [HttpPost]
        public void Post([FromBody] Mail value)
        {
            Mails.Add(value);
        }

        // PUT api/mails/5
        [HttpPut]
        public void Put(int id, [FromBody] Mail value)
        {
            Mails.Add(value);
        }

        // DELETE api/mails/5
        [HttpDelete]
        public void Delete(int id)
        {
            Mails.RemoveAt(id);
        }
    }
}