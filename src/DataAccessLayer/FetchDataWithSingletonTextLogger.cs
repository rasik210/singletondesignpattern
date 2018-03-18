using System;
using System.Data;
using System.Data.SqlClient;
using SingletonTextLogger;
//comment the above namespace and uncomment any of the below lines to use the desired implementation
//using StaticClassTextLogger;
//using SingletonTextLogger;
//using SingletonWithLockingTextLogger;
//using SingletonWithDoubleCheckedLockingTextLogger;
//using SingletonWithStaticInitialization;
//using SingletonWithStaticConstructor;
//using SingletonWithLazyType;

namespace DataAccessLayer
{
    public class FetchDataWithSingletonTextLogger
    {
        public DataTable GetStudentData()
        {
            var empInfo = new DataTable();
            //logger class instantiation with GetInstance
            var logger = Logger.GetInstance();

            try
            {
                logger.Log("Method GetStudentData entered.", LogLevel.Trace);
                var sqlConnection = GetDbConnection();
                sqlConnection.Open();
                logger.Log("Connection established with database.", LogLevel.Trace);

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT * FROM Employee", sqlConnection);
                sqlDataAdapter.Fill(empInfo);
                //no worries any more. It is the same instance.
                //logger2 is just a reference to the same singleton object
                var logger2 = Logger.GetInstance(); 
                logger2.Log("Data obtained from database.", LogLevel.Trace);
                logger2.Log("Number of students fetched." + empInfo.Rows.Count, LogLevel.Information);
            }
            catch (Exception ex)
            {
                //logger3 is again just a reference to the same singleton object
                var logger3 = Logger.GetInstance();
                logger3.Log("An error occured in GetStudentData method. Exception details are - " + ex.Message, LogLevel.Error);
            }
            logger.Log("Method GetStudentData Exited.", LogLevel.Trace);
            return empInfo;
        }

        private SqlConnection GetDbConnection()
        {
            //Gets you the reference to same singleton instance in place of creating a new object altogether
            var logger = Logger.GetInstance();
            logger.Log("Method GetDbConnection entered.", LogLevel.Trace);
            var sqlConnection = new SqlConnection("Server=myServerAddress;Database=myDataBase;Trusted_Connection=True;");
            logger.Log("Method GetDbConnection exited.", LogLevel.Trace);
            return sqlConnection;
        }

    }
}
