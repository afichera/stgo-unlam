using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using df = STGO.DataFeedClass;
using fn = STGO.Functions;
using Newtonsoft.Json;

public partial class DataFeed : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        string method = Page.Request["method"];
        string json = string.Empty;

        Response.Clear();
        Response.ContentType = "text/javascript;charset=UTF-8";

        switch (method)
        {
            case "add":
                json = JsonConvert.SerializeObject(df.addCalendar(Request["CalendarStartTime"], Request["CalendarEndTime"], Request["CalendarTitle"], Request["IsAllDayEvent"]), Formatting.None);
                break;

            case "list":
                json = JsonConvert.SerializeObject(df.listCalendar(Request["showdate"], Request["viewtype"]), Formatting.None);
                break;

            case "update":
                json = JsonConvert.SerializeObject(df.updateCalendar(Convert.ToInt32(Request["calendarID"]), Request["CalendarStartTime"], Request["CalendarEndTime"]), Formatting.None);
                break;

            case "remove":
                json = JsonConvert.SerializeObject(df.removeCalendar(Convert.ToInt32(Request["calendarID"])), Formatting.None);
                break;

            case "adddetails":

                string st = Request["stpartdate"] + " " + Request["stparttime"];
                string et = Request["etpartdate"] + " " + Request["etparttime"];
                string ade = (Request["IsAllDayEvent"] == null ? "0" : "1");

                if (Request["id"] != null)
                {
                    json = JsonConvert.SerializeObject(df.updateDetailedCalendar(Convert.ToInt32(Request["id"]), st, et, Request["Subject"], ade, Request["Description"], Request["Location"], Request["colorvalue"], Request["timezone"]), Formatting.None);
                }
                else
                {
                    json = JsonConvert.SerializeObject(df.addDetailedCalendar(st, et, Request["Subject"], ade, Request["Description"], Request["Location"], Request["colorvalue"], Request["timezone"]), Formatting.None);
                }

                break;
        }

        Response.Write(json);
        Response.End();

    }
}
