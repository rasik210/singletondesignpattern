using System;
using DataAccessLayerWithPlainTextLogger;

namespace StudentInfo
{
    public partial class StudentPortal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnStudentInfo_Click(object sender, EventArgs e)
        {
            var fetchData = new FetchData();
            var studentData = fetchData.GetStudentData();
            //UI logic to bind the student data obtained above with UI elements.
            //I've skipped it as UI binding logic isn't of much relevance here.
        }
    }
}