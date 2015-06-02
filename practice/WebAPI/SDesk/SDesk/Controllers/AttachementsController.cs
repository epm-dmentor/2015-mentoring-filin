#region

using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using SDesk.Models;

#endregion

namespace SDesk.Controllers
{
    public class AttachementsController : ApiController
    {
        public static readonly List<Attachement> Attachements = new List<Attachement>
        {
            new Attachement
            {
                FileExtention = "rar",
                FileName = "Test1",
                Id = 1,
                MailId = 1
            },
            new Attachement
            {
                FileExtention = "zip",
                FileName = "Test2",
                Id = 2,
                MailId = 2
            }
        };


        public Attachement Get([FromUri] int attId, [FromUri] string ext, [FromUri] int status)
        {
            return Attachements.FirstOrDefault(attachement =>
                        attachement.FileExtention == ext && attachement.Id == attId && 
                        attachement.StatusId == status);
        }


        //// GET api/attachements
        public IEnumerable<Attachement> Get()
        {
            return Attachements;
        }


        //  // GET api/attachements/5
        [Route("api/mails/{id}/attachements/{attId}")]
        public Attachement Get(int attId)
        {
            return Attachements.FirstOrDefault(a => a.Id == attId);
        }


        [Route("api/mails/{id}/attachements/ext={ext}")]
        public Attachement Get(string ext)
        {
            return Attachements.FirstOrDefault(a => a.FileExtention == ext);
        }


        // POST api/attachements
        public void Post([FromBody] Attachement value)
        {
            Attachements.Add(value);
        }

        // PUT api/attachements/5
        public void Put(int attId, [FromBody] Attachement value)
        {
            Attachements.Add(value);
        }

        // DELETE api/attachements/5
        public void Delete(int attId)
        {
            Attachements.RemoveAt(attId);
        }
    }
}