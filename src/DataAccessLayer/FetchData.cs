using System;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayerWithoutLogging
{
    public class FetchData
    {
        public DataTable GetStudentData()
        {
            var studentInfo = new DataTable();
            try
            {
                //Milestone 1 : put a message into pesistent storage that method execution has started
                var sqlConnection = GetDbConnection();
                sqlConnection.Open();

                //Milestone 2 : put a message into pesistent storage that Database connection was successfully established

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT * FROM Student", sqlConnection);
                sqlDataAdapter.Fill(studentInfo);
                //Milestone 3 : put a message into pesistent storage that query to the database was successful

                //Milestone 4 : put an informational note about the count of students that were fetched from the database.
            }
            catch (Exception ex)
            {
                //Exception flow Milestone : put a message into pesistent storage that an internal error occurred and the reason behind the error with line number of code etc.
            }
            //Milestone 5 : put a message into pesistent storage that method execution has finished
            return studentInfo;
        }

        private SqlConnection GetDbConnection()
        {
            var sqlConnection = new SqlConnection("Server=myServerAddress;Database=myDataBase;Trusted_Connection=True;");
            return sqlConnection;
        }
    }
}
