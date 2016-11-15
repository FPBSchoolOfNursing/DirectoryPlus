using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CasAuthenticationMiddleware.Attributes;
using DirectoryPlus.DataContexts;
using System.Web;
using Microsoft.AspNet.Identity.Owin;
using DirectoryPlus.Services;
using DirectoryPlus.Models;

namespace DirectoryPlus.RestControllers
{

    //Route prefix dox: http://www.asp.net/web-api/overview/web-api-routing-and-actions/attribute-routing-in-web-api-2
    [RoutePrefix("directory")]
    //[ADAuthorize("ads.case.edu", "nurs-dept-it")]
    public class DirectoryAPIController : ApiController
    {
        private DirectoryContext db;
        private string adDomain = "ads.case.edu"; //todo: abstract this out to a better place.. Maybe web.config?
        #region ctor
        public DirectoryAPIController()
        {
            //throw new NotImplementedException("Please don't use the default contructor");
        }
        public DirectoryAPIController(DirectoryContext DBContext)
        {
            DirectoryDBContext = DBContext;
        }       
        public DirectoryContext DirectoryDBContext
        {
            get { return db ?? HttpContext.Current.GetOwinContext().Get<DirectoryContext>(); }
            private set { db = value; }
        }
        #endregion

        [Route("{aliasOrAdGroup}/{query?}")]
        public IEnumerable<DirectoryReturn> GetDirectory(string aliasOrAdGroup, string query = null)
        {
            /* Return directory information for an Alias (see GetAliases() ) or an Ad Group Eg staff@nursing.case.edu or nursing 
             * 
             * */
            var directory = (from p in DirectoryDBContext.People
                             join o in DirectoryDBContext.Offices on p.CaseUserId equals o.CaseUserId
                             select new DirectoryReturn
                             {
                                 Name = p.FirstName + " " + p.LastName,
                                 Email = p.CaseUserId + "@case.edu",
                                 Location = o.Building + " " + o.RoomNumber,
                                 PersonPhone = p.PhoneNumber,
                                 OfficePhone = o.PhoneNumber
                             });

            return directory.ToList();
        }

        [Route("Aliases")]
        public IEnumerable<string> GetAliases()
        {
            /*Returns a list of aliases 
             * 
             * An alias is a pointer to a group of adgroups E.g.
             * Nursing = faculty@nursing.case.edu, staff@nursing.case.edu
             * 
             * */

            return new string[] { "Nursing", "UTech", "Adalbert Hall" };
        }

        [Route("Sync/{aliasOrAdGroup}")]
        public IHttpActionResult GetSync(string aliasOrAdGroup)
        {
            try
            {
                var adservice = new ActiveDirectoryService(DirectoryDBContext);
                adservice.SyncLocalDbAsync(adDomain, aliasOrAdGroup).Wait();
                return Ok();
            }
            catch(Exception ex)
            {
                return new System.Web.Http.Results.ExceptionResult(ex, this);
            }           
        }



        /*
        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
        */
    }
}