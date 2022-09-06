using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;
using System.Web.Http.Cors;
using second_api_project.Models;
namespace second_api_project.Controllers
{//enable cross domain for all class
  [EnableCorsAttribute("*","*","*")]
  //enable https for all class
  //enable this if u want https enabled
  //[RequiredHttps]
    public class archiveController : ApiController
    {
        [HttpGet]
        //[DisableCors]
        //[RequiredHttps]
        [BasicAthuntication]
        public HttpResponseMessage basicAuth(/*string  papertype="all"*/)
        {
            string username = Thread.CurrentPrincipal.Identity.Name;
            //authorazation part
            //create instance of class that inhret from dbcontext 
            using (ArchiveSystemEntities1 entities = new ArchiveSystemEntities1())
            {
//k                return Request.CreateResponse(HttpStatusCode.OK,displayName);

                switch (username.ToLower())
                {

                    case "user":
                        return Request.CreateResponse(HttpStatusCode.OK, entities.ArchiveBooks_TBL.Where(e => e.BookPaperType.ToLower() == "استنساخ").ToList());
                    case "admin":
                        return Request.CreateResponse(HttpStatusCode.OK, entities.ArchiveBooks_TBL.ToList());
                    default:
                        return Request.CreateResponse(HttpStatusCode.BadRequest);


                }
                //switch (papertype.ToLower())
                //{ 
                //case "all":
                //    return Request.CreateResponse(HttpStatusCode.OK,entities.ArchiveBooks_TBL.ToList());
                //    case "copy":
                //        return Request.CreateResponse(HttpStatusCode.OK, entities.ArchiveBooks_TBL.Where(e=>e.BookPaperType.ToLower()=="استنساخ").ToList());
                //    case "origion":
                //        return Request.CreateResponse(HttpStatusCode.OK, entities.ArchiveBooks_TBL.Where(e => e.BookPaperType.ToLower() == "اصلي").ToList());
                //    default  :
                //        return Request.CreateErrorResponse(HttpStatusCode.BadRequest,
                //           "value of type must be all or copy or origin" + papertype + "in invalid");

                //}


            }

        }
        [HttpGet]
        public HttpResponseMessage LoadArhive(int id )
        {
            //create instance of class that inhret from dbcontext 
            using (ArchiveSystemEntities1 entities = new ArchiveSystemEntities1())
            {

                var entity = entities.ArchiveBooks_TBL.ToList();

                if (entity != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, entity);
                }
                else
                {
                    //404 not found
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound,  "not found ");
                }

            }

        }
        //this post work fine but will return 204 no content in post man coz it void
        //public void Post([FromBody] ArchiveBooks_TBL archive)
        //{
        //    using (ArchiveSystemEntities entities = new ArchiveSystemEntities())
        //    {

        //        entities.ArchiveBooks_TBL.Add(archive);
        //        entities.SaveChanges();

        //    }

        //}

        //retrun message after posting
        public HttpResponseMessage Post([FromBody] ArchiveBooks_TBL archive)
        {
            try
            {
                using (ArchiveSystemEntities1 entities = new ArchiveSystemEntities1())
                {

                    entities.ArchiveBooks_TBL.Add(archive);
                    entities.SaveChanges();

                    //return a message instade of void, content status code 201 created +the object inserted as json in body of response instade of 1 

                    var message = Request.CreateResponse(HttpStatusCode.Created, archive);

                    //also return the uri we requested +id of new inserted item so we can GET it 
                    //you can ind it in response header as name "location"

                    message.Headers.Location = new Uri(Request.RequestUri + "/" + archive.ArchiveBookID.ToString());
                    return message;
                }
            }
            catch (Exception ex)
            {

                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }


        }


        public HttpResponseMessage Delete(int id)
        {
            try
            {
                using (ArchiveSystemEntities1 entities = new ArchiveSystemEntities1())
                {
                    var entity = entities.ArchiveBooks_TBL.FirstOrDefault(e => e.ArchiveBookID == id);
                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound,
                        "archive with id =" + id.ToString() + "not found");
                    }
                    else
                    {
                        entities.ArchiveBooks_TBL.Remove(entity);
                        entities.SaveChanges();
                        return Request.CreateResponse(HttpStatusCode.OK);
                    }

                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);

            }

        }


        public HttpResponseMessage Put([FromBody]int id,[FromUri]ArchiveBooks_TBL archiveobj)
        {
            try
            {
                using (ArchiveSystemEntities1 entities = new ArchiveSystemEntities1())
                {
                    var entity = entities.ArchiveBooks_TBL.FirstOrDefault(e => e.ArchiveBookID == id);
                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound,
                        "archive with id =" + id.ToString() + " not found");
                    }  
                    else
                    {

                        entity.BookCode=archiveobj.BookCode;
                        entity.BookNumber = archiveobj.BookNumber;
                        //etc

                        entities.SaveChanges();
                        return Request.CreateResponse(HttpStatusCode.OK,entity);
                    }

                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);

            }

        }

    }
}
