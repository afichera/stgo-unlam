using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class Add : System.Web.UI.Page
{

    public DataTable dtEvents = new DataTable();
    public DataRow dtRow;
    public string sST = "00:00";
    public string sET = "23:59";
    public string sSD = DateTime.Now.ToShortDateString();
    public string sED = DateTime.Now.ToShortDateString();

    protected void Page_Load(object sender, EventArgs e)
    {
        // Load Events from database and save to public Data Table
        if (!Page.IsPostBack)
        {
            DateTime dtToday = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 7, 0, 0);

            sST = dtToday.ToString("HH:mm");
            sET = dtToday.AddHours(1).ToString("HH:mm");
            sSD = dtToday.ToString("M/dd/yyyy");
            sED = dtToday.ToString("M/dd/yyyy");

        }

    }

}
