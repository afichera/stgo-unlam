using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;



public partial class Edit : System.Web.UI.Page
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
            GetEventDetail();
        }

    }

    protected void GetEventDetail()
    {

        //if (Request["isallday"] != null && Request["isallday"] == "1")
            //IsAllDayEvent.Attributes.Add("checked", "");

        string sStp = "proc_JQCalendar_GetEventDetail";

        SqlConnection oSqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlServer"].ConnectionString);
        SqlCommand oSqlCmd = new SqlCommand(sStp, oSqlCon);
        SqlDataAdapter oSqlDa = new SqlDataAdapter(oSqlCmd);

        try
        {

            oSqlCmd.CommandType = CommandType.StoredProcedure;
            oSqlCmd.CommandTimeout = 900;

            SqlParameter paramID = new SqlParameter("@id", SqlDbType.Int);

            // Assign values to parameters
            paramID.Value = Request["id"];

            // Add the parameters to oSqlCmd object
            oSqlCmd.Parameters.Add(paramID);

            // Open SQL connection and execute it
            oSqlCon.Open();
            oSqlDa.Fill(dtEvents);

            if (dtEvents.Rows.Count > 0)
            {

                dtRow = dtEvents.Rows[0];

            }
            else
            {

                DateTime dtToday = DateTime.Parse(Request["start"]);

                dtRow = dtEvents.NewRow();
                dtRow["StartTime"] = dtToday;
                dtRow["EndTime"] = dtToday.AddHours(1);
                dtRow["Subject"] = "New Event";
                dtRow["Color"] = "6";

            }

            sST = DateTime.Parse(dtRow["StartTime"].ToString()).ToString("HH:mm");
            sET = DateTime.Parse(dtRow["EndTime"].ToString()).ToString("HH:mm");
            sSD = DateTime.Parse(dtRow["StartTime"].ToString()).ToString("M/dd/yyyy");
            sED = DateTime.Parse(dtRow["EndTime"].ToString()).ToString("M/dd/yyyy");


        }
        catch (Exception)
        {
            // Run error notification code here
        }
        finally
        {
            if (oSqlCon.State == ConnectionState.Open)
                oSqlCon.Close();
        }

    }
}
