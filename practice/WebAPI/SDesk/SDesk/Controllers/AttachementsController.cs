using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Routing;
using System.Web.Mvc;
using SDesk.Models;

namespace SDesk.Controllers
{
    public class AttachementsController : ApiController
    {
        public static readonly List<Attachement> Attachements = new List<Attachement>
        {
            new Attachement()
            {
                FileExtention = "rar",
                FileName = "Test1",
                Id = 1,
                MailId = 1
            },
            new Attachement()
            {
                FileExtention = "zip",
                FileName = "Test2",
                Id = 2,
                MailId = 2
            }
        };

        
           //GET api/attachements
            public IEnumerable<Attachement> Get()
            {
                return Attachements;
            }

            // GET api/attachements/5
            //[Route("attachements/{attId}")]
            public Attachement Get(int attId)
            {
                return Attachements.FirstOrDefault(a => a.Id == attId);
            }


            [Route("api/mails/{id}/attachements/extention={ext}")]
            public Attachement Get(string ext)
            {
                return Attachements.FirstOrDefault(a => a.FileExtention == ext);
            }

            //[Route("api/mails/{id}/attachements/{attId}?extention={ext}?status={status}")]
            public Attachement Get(int attId, string ext, int status)
            {
                return Attachements.FirstOrDefault(attachement => attachement.FileExtention == ext && attachement.Id == attId && attachement.StatusId == status);
            }

            // POST api/attachements
            public void Post([FromBody]Attachement value)
            {
                Attachements.Add(value);
            }

            // PUT api/attachements/5
            public void Put(int attId, [FromBody]Attachement value)
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

