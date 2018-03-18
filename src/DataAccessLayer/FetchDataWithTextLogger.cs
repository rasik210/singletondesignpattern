using System;
using System.Data;
using System.Data.SqlClient;
using TextLogger;

namespace DataAccessLayerWithPlainTextLogger
{
    public class FetchData
    {
        public DataTable GetStudentData()
        {
            var empInfo = new DataTable();
            //logger class instantiation with new keyword
            var logger = new Logger();
            try
            {
                logger.Log("Method GetStudentData entered.", LogLevel.Trace);
                var sqlConnection = GetDbConnection();
                sqlConnection.Open();
                logger.Log("Connection established with database.", LogLevel.Trace);

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT * FROM Employee", sqlConnection);
                sqlDataAdapter.Fill(empInfo);
                // noob programming! someone initialized one more instance of Logger class again in the same method.
                var logger2 = new Logger(); 
                logger2.Log("Data obtained from database.", LogLevel.Trace);
                logger2.Log("Number of students fetched." + empInfo.Rows.Count, LogLevel.Information);
            }
            catch (Exception ex)
            {
                //anybody can instantiate Logger class at will.
                var logger3 = new Logger();
                logger3.Log("An error occured in GetStudentData method. Exception details are - " + ex.Message, LogLevel.Error);
            }
            logger.Log("Method GetStudentData Exited.", LogLevel.Trace);
            return empInfo;
        }

        private SqlConnection GetDbConnection()
        {
            //one more logger instance.
            var logger = new Logger();
            logger.Log("Method GetDbConnection entered.", LogLevel.Trace);
            var sqlConnection = new SqlConnection("Server=myServerAddress;Database=myDataBase;Trusted_Connection=True;");
            logger.Log("Method GetDbConnection exited.", LogLevel.Trace);
            return sqlConnection;
        }
    }

}
