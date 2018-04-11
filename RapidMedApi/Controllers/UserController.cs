using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Collections;
using RapidMedApi.Models;

namespace RapidMedApi.Controllers
{

    public class UserController : ApiController
    {
       static string conn = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
        RapidMedApiRepository myRapidMedApiRepository = new RapidMedApiRepository(conn);

        // GET: api/User
        public DataTable GetUserDetails()
        {
            myRapidMedApiRepository.Query = "SELECT * FROM admin_user";
            myRapidMedApiRepository.Select();

            var ds = myRapidMedApiRepository.Result;
            DataTable userTable = ds.Tables[0];
            return userTable;
        }

        // GET: api/User/5
        public DataTable GetUserDetails(int id)
        { 
            myRapidMedApiRepository.Query = "SELECT * FROM admin_user WHERE pkid = '"+ id +"'";
            myRapidMedApiRepository.Select();

            var ds = myRapidMedApiRepository.Result;
            DataTable firstTable = ds.Tables[0];
            return firstTable;       
        }

        // POST: api/User
        public DataTable PostDetails([FromBody] LoginDetails details)
        {
           
            string username = details.username;
            string password = details.password;

            myRapidMedApiRepository.Query = "SELECT pkid, name, doctors, nursing FROM admin_user WHERE username = '" + username + "' AND password = '" + password + "'";
            myRapidMedApiRepository.Select();
            var ds = myRapidMedApiRepository.Result;

            if (ds.Tables.Count != 0)
            {
                float id = Int32.Parse(ds.Tables[0].Rows[0]["pkid"].ToString());
                DataTable firstTable = ds.Tables[0];
                var data = firstTable;
                return data;
            }

            else
            {
                return null;
            }
           
        }

        // PUT: api/User/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/User/5
        public void Delete(int id)
        {
        }
    }
}
