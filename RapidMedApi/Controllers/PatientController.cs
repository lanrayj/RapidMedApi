using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RapidMedApi.Controllers
{
    public class PatientController : ApiController
    {
        
        static string conn = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
        RapidMedApiRepository myRapidMedApiRepository = new RapidMedApiRepository(conn);

        // GET: api/Patient
        public DataTable GetPatientDetails()
        {
            myRapidMedApiRepository.Query = "SELECT pkid,hospital_no,surname,other_names, age, sex, FROM patient";
            myRapidMedApiRepository.Select();

            var ds = myRapidMedApiRepository.Result;
            DataTable patientTable = ds.Tables[0];
            return patientTable;

            
        }

        // GET: api/Patient/5
         
            public DataTable Get(string part1,string part2,string part3)
      
        {

            string  hospitalNumber = part1 + "/" + part2 + "/" + part3 ;
           
            myRapidMedApiRepository.Query = "SELECT pkid,hospital_no,surname,other_names,age,sex FROM patient WHERE hospital_no = '" + hospitalNumber + "'";
            myRapidMedApiRepository.Select();

            var ds = myRapidMedApiRepository.Result;
            DataTable patientTable = ds.Tables[0];
            return patientTable;
        }

        // POST: api/Patient
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Patient/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Patient/5
        public void Delete(int id)
        {
        }
    }
}
