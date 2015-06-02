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
                Cc = "<Aleksandr.Filin@barclayscapital.com>",
                Id = 1,
            },
            new Mail
            {
                AttachementId = 2,
                Body = "Test Message 2",
                Cc = "<Olexandr_Filin@epam.com>",
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
        public void Post([FromBody] Mail value)
        {
            Mails.Add(value);
        }

        // PUT api/mails/5
        public void Put(int id, [FromBody] Mail value)
        {
            Mails.Add(value);
        }

        // DELETE api/mails/5
        public void Delete(int id)
        {
            Mails.RemoveAt(id);
        }
    }
}