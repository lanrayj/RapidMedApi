using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace RapidMedApi
{
    public class RapidMedApiRepository
    {
        private SqlConnection myConnection;
        private string connection;
        public string Connection
        {
            get
            {
                return connection;
            }
        }
        

        private string query;
        public string Query
        {
            get
            {
                return query;
            }
            set
            {
                query = value;
            }
        }

        private DataSet result;
        public DataSet Result
        {
            get
            {
                return result;
            }
            set
            {
                result = value;
            }
        }
        private int status;
        public int Status
        {
            get
            {
                return status;
            }
            set
            {
                status = value;
            }
        }
        private string message;
        public string Message
        {
            get
            {
                return message;
            }
            set
            {
                message = value;
            }
        }

        public RapidMedApiRepository(string RMAconnection)
        {
            connection = RMAconnection;
        }

        public void Insert(){
            try
            {
                myConnection = new SqlConnection(connection);
                myConnection.Open();
                SqlCommand cmd = new SqlCommand(query, myConnection);
                SqlDataReader myReader;
                myReader = cmd.ExecuteReader();      
                myConnection.Close();
                message = "successful";
                status = 1;
            }
            catch (Exception ex)
            {
                message = ex.Message;
                status = 0;
            }
        }

        public void Select()
        {
            try
            {
                myConnection = new SqlConnection(connection);
                myConnection.Open();
                SqlCommand cmd = new SqlCommand(query, myConnection);
                SqlDataAdapter MyAdapter = new SqlDataAdapter(cmd);

                result = new DataSet();
                MyAdapter.Fill(result);
                message = "successful";
                status = 1;
                myConnection.Close();
            }

            catch (Exception ex)
            {
                message = ex.Message;
                status = 0;
            }
        }

        public void Update()
        {

        }

        public void Delete()
        {

        }


    }
}