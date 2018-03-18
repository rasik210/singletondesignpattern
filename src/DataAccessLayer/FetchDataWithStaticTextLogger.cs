using System;
using System.Data;
using System.Data.SqlClient;
using StaticClassTextLogger;

namespace DataAccessLayerWithStaticTextLogger
{
    public class FetchData
    {
        public DataTable GetStudentData()
        {
            var empInfo = new DataTable();
            //explicit instantiation not required anymore
            //var logger = new Logger();

            try
            {
                //access methods of a static class using <ClassName>.<MethodName> syntax
                Logger.Log("Method GetStudentData entered.", LogLevel.Trace);
                var sqlConnection = GetDbConnection();
                sqlConnection.Open();
                Logger.Log("Connection established with database.", LogLevel.Trace);

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT * FROM Employee", sqlConnection);
                sqlDataAdapter.Fill(empInfo);
                //Compiler stop you from doing bad programming any more
                //var logger2 = Logger.GetInstance(); 
                Logger.Log("Data obtained from database.", LogLevel.Trace);
                Logger.Log("Number of students fetched." + empInfo.Rows.Count, LogLevel.Information);
            }
            catch (Exception ex)
            {
                Logger.Log("An error occured in GetStudentData method. Exception details are - " + ex.Message, LogLevel.Error);
            }
            Logger.Log("Method GetStudentData Exited.", LogLevel.Trace);
            return empInfo;
        }

        private SqlConnection GetDbConnection()
        {
            //even in a different method you use the same static class
            //var logger = Logger.GetInstance();
            Logger.Log("Method GetDbConnection entered.", LogLevel.Trace);
            var sqlConnection = new SqlConnection("Server=myServerAddress;Database=myDataBase;Trusted_Connection=True;");
            Logger.Log("Method GetDbConnection exited.", LogLevel.Trace);
            return sqlConnection;
        }

    }
}
