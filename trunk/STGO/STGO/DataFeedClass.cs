using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using fn = STGO.Functions;

namespace STGO
{

    /// <summary>
    /// Class for wdCalendar to view, add, edit and remove calendar events.
    /// This is the main class for wdCalendar
    /// </summary>
    public class DataFeedClass
    {

        public static Dictionary<string, object> addCalendar(string st, string et, string sub, string ade)
        {

            Dictionary<string, object> ret = new Dictionary<string, object>();

            string sStp = "proc_JQCalendar_addCalendar";
            int sqlReturn = 0;

            SqlConnection oSqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlServer"].ConnectionString);
            SqlCommand oSqlCmd = new SqlCommand(sStp, oSqlCon);

            try
            {

                oSqlCmd.CommandType = CommandType.StoredProcedure;
                oSqlCmd.CommandTimeout = 900;


                SqlParameter paramSubject = new SqlParameter("@subject", SqlDbType.VarChar, 1000);
                SqlParameter paramStartTime = new SqlParameter("@starttime", SqlDbType.DateTime);
                SqlParameter paramEndTime = new SqlParameter("@endtime", SqlDbType.DateTime);
                SqlParameter paramIsAllDayEvent = new SqlParameter("@IsAllDayEvent", SqlDbType.SmallInt);

                // Assign values to parameters
                paramSubject.Value = sub;
                paramStartTime.Value = st;
                paramEndTime.Value = et;
                paramIsAllDayEvent.Value = ade;

                // Add the parameters to oSqlCmd object
                oSqlCmd.Parameters.Add(paramSubject);
                oSqlCmd.Parameters.Add(paramStartTime);
                oSqlCmd.Parameters.Add(paramEndTime);
                oSqlCmd.Parameters.Add(paramIsAllDayEvent);

                // Open SQL connection and execute it
                oSqlCon.Open();
                sqlReturn = oSqlCmd.ExecuteNonQuery();

                ret.Add("IsSuccess", true);
                ret.Add("Msg", "add success");
                ret.Add("Data", sqlReturn.ToString());

            }
            catch (Exception)
            {
                ret.Add("IsSuccess", false);
                ret.Add("Msg", "add failed");
                ret.Add("Data", sqlReturn.ToString());
            }
            finally
            {
                if (oSqlCon.State == ConnectionState.Open)
                    oSqlCon.Close();
            }

            return ret;

        }

        public static Dictionary<string, object> addDetailedCalendar(string st, string et, string sub, string ade, string dscr, string loc, string color, string tz)
        {

            Dictionary<string, object> ret = new Dictionary<string, object>();

            string sStp = "proc_JQCalendar_addDetailedCalendar";
            int sqlReturn = 0;

            SqlConnection oSqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlServer"].ConnectionString);
            SqlCommand oSqlCmd = new SqlCommand(sStp, oSqlCon);

            try
            {

                oSqlCmd.CommandType = CommandType.StoredProcedure;
                oSqlCmd.CommandTimeout = 900;


                SqlParameter paramSubject = new SqlParameter("@subject", SqlDbType.VarChar, 255);
                SqlParameter paramStartTime = new SqlParameter("@starttime", SqlDbType.DateTime);
                SqlParameter paramEndTime = new SqlParameter("@endtime", SqlDbType.DateTime);
                SqlParameter paramIsAllDayEvent = new SqlParameter("@IsAllDayEvent", SqlDbType.SmallInt);
                SqlParameter paramDescription = new SqlParameter("@Description", SqlDbType.VarChar, 1000);
                SqlParameter paramLocation = new SqlParameter("@Location", SqlDbType.VarChar, 200);
                SqlParameter paramColor = new SqlParameter("@Color", SqlDbType.VarChar, 200);

                // Assign values to parameters
                paramSubject.Value = sub;
                paramStartTime.Value = st;
                paramEndTime.Value = et;
                paramIsAllDayEvent.Value = ade;
                paramDescription.Value = dscr;
                paramLocation.Value = loc;
                paramColor.Value = color;

                // Add the parameters to oSqlCmd object
                oSqlCmd.Parameters.Add(paramSubject);
                oSqlCmd.Parameters.Add(paramStartTime);
                oSqlCmd.Parameters.Add(paramEndTime);
                oSqlCmd.Parameters.Add(paramIsAllDayEvent);
                oSqlCmd.Parameters.Add(paramDescription);
                oSqlCmd.Parameters.Add(paramLocation);
                oSqlCmd.Parameters.Add(paramColor);

                // Open SQL connection and execute it
                oSqlCon.Open();
                sqlReturn = oSqlCmd.ExecuteNonQuery();

                ret.Add("IsSuccess", true);
                ret.Add("Msg", "add success");
                ret.Add("Data", sqlReturn.ToString());

            }
            catch (Exception)
            {
                ret.Add("IsSuccess", false);
                ret.Add("Msg", "add failed");
                ret.Add("Data", sqlReturn.ToString());
            }
            finally
            {
                if (oSqlCon.State == ConnectionState.Open)
                    oSqlCon.Close();
            }

            return ret;

        }

        public static Dictionary<string, object> listCalendarByRange(string sd, string ed)
        {

            // Convert unitx timestamp to DateTime
            DateTime dtSd = fn.ConvertFromUnixTimestamp(Convert.ToDouble(sd));
            DateTime dtEd = fn.ConvertFromUnixTimestamp(Convert.ToDouble(ed));

            Dictionary<string, object> ret = new Dictionary<string, object>();

            string sStp = "proc_JQCalendar_listCalendarByRange";
            int sqlReturn = 0;

            DataTable dtResults = new DataTable();
            SqlConnection oSqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlServer"].ConnectionString);
            SqlCommand oSqlCmd = new SqlCommand(sStp, oSqlCon);
            SqlDataAdapter oSqlDa = new SqlDataAdapter(oSqlCmd);

            try
            {

                oSqlCmd.CommandType = CommandType.StoredProcedure;
                oSqlCmd.CommandTimeout = 900;

                SqlParameter paramStartTime = new SqlParameter("@starttime", SqlDbType.DateTime);
                SqlParameter paramEndTime = new SqlParameter("@endtime", SqlDbType.DateTime);

                // Assign values to parameters
                paramStartTime.Value = dtSd;
                paramEndTime.Value = dtEd;

                // Add the parameters to oSqlCmd object
                oSqlCmd.Parameters.Add(paramStartTime);
                oSqlCmd.Parameters.Add(paramEndTime);

                // Open SQL connection and execute it
                oSqlCon.Open();
                sqlReturn = oSqlDa.Fill(dtResults);

                List<object> evtList = new List<object>();

                foreach (DataRow row in dtResults.Rows)
                {

                    DateTime dtST = DateTime.Parse(row["StartTime"].ToString());
                    DateTime dtET = DateTime.Parse(row["EndTime"].ToString());

                    string sAde = row["IsAllDayEvent"].ToString();

                    object[] EvtData = new object[11];

                    EvtData[0] = (int)row["id"];
                    EvtData[1] = row["Subject"].ToString();
                    EvtData[2] = dtST.ToString("MM/dd/yyyy HH:mm");
                    EvtData[3] = dtET.ToString("MM/dd/yyyy HH:mm");
                    EvtData[4] = Convert.ToInt16(sAde);
                    EvtData[5] = 0;
                    EvtData[6] = 0;
                    EvtData[7] = row["Color"].ToString();
                    EvtData[8] = 1;
                    EvtData[9] = row["Location"].ToString();
                    EvtData[10] = string.Empty;

                    evtList.Add(EvtData);

                }

                ret.Add("events", evtList);
                ret.Add("issort", true);
                ret.Add("start", dtSd.ToString("MM/dd/yyyy HH:mm"));
                ret.Add("end", dtEd.ToString("MM/dd/yyyy HH:mm"));
                ret.Add("error", null);

            }
            catch (Exception ex)
            {
                ret.Add("error", "list calendar by range failed: " + ex.Message);
                //ret["error"] = "list calendar by range failed: " + ex.Message;

            }
            finally
            {
                if (oSqlCon.State == ConnectionState.Open)
                    oSqlCon.Close();
            }


            return ret;

        }

        public static Dictionary<string, object> listCalendar(string day, string type)
        {

            DateTime dtDay = DateTime.Parse(day);


            string st = fn.ConvertToUnixTimeStamp(dtDay).ToString();
            string et = fn.ConvertToUnixTimeStamp(dtDay.AddDays(1).AddSeconds(-1)).ToString();

            switch (type)
            {
                case "month":

                    DateTime dtfirstDayofMonth = fn.GetFirstDayOfMonth(dtDay);
                    DateTime dtlastDayofMonth = fn.GetLastDayOfMonth(dtDay);

                    st = fn.ConvertToUnixTimeStamp(dtfirstDayofMonth).ToString();
                    et = fn.ConvertToUnixTimeStamp(dtlastDayofMonth.AddDays(1).AddSeconds(-1)).ToString();

                    break;

                case "week":

                    st = fn.ConvertToUnixTimeStamp(fn.GetFirstDayOfWeek(dtDay)).ToString();
                    et = fn.ConvertToUnixTimeStamp(fn.GetLastDayOfWeek(dtDay).AddDays(1).AddSeconds(-1)).ToString();

                    break;

                case "day":

                    st = fn.ConvertToUnixTimeStamp(dtDay).ToString();
                    et = fn.ConvertToUnixTimeStamp(dtDay.AddDays(1).AddSeconds(-1)).ToString();

                    break;
            }

            return listCalendarByRange(st, et);

        }

        public static Dictionary<string, object> updateCalendar(int id, string st, string et)
        {
            Dictionary<string, object> ret = new Dictionary<string, object>();

            string sStp = "proc_JQCalendar_updateCalendar";
            int sqlReturn = 0;

            SqlConnection oSqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlServer"].ConnectionString);
            SqlCommand oSqlCmd = new SqlCommand(sStp, oSqlCon);

            try
            {

                oSqlCmd.CommandType = CommandType.StoredProcedure;
                oSqlCmd.CommandTimeout = 900;

                SqlParameter paramID = new SqlParameter("@id", SqlDbType.Int);
                SqlParameter paramStartTime = new SqlParameter("@starttime", SqlDbType.DateTime);
                SqlParameter paramEndTime = new SqlParameter("@endtime", SqlDbType.DateTime);

                // Assign values to parameters
                paramID.Value = id;
                paramStartTime.Value = st;
                paramEndTime.Value = et;

                // Add the parameters to oSqlCmd object
                oSqlCmd.Parameters.Add(paramID);
                oSqlCmd.Parameters.Add(paramStartTime);
                oSqlCmd.Parameters.Add(paramEndTime);

                // Open SQL connection and execute it
                oSqlCon.Open();
                sqlReturn = oSqlCmd.ExecuteNonQuery();

                ret.Add("IsSuccess", true);
                ret.Add("Msg", "update success");
                ret.Add("Data", sqlReturn.ToString());

            }
            catch (Exception)
            {
                ret.Add("IsSuccess", false);
                ret.Add("Msg", "update failed");
                ret.Add("Data", sqlReturn.ToString());
            }
            finally
            {
                if (oSqlCon.State == ConnectionState.Open)
                    oSqlCon.Close();
            }

            return ret;

        }

        public static Dictionary<string, object> updateDetailedCalendar(int id, string st, string et, string sub, string ade, string dscr, string loc, string color, string tz)
        {

            Dictionary<string, object> ret = new Dictionary<string, object>();

            string sStp = "proc_JQCalendar_updateDetailedCalendar";
            int sqlReturn = 0;

            SqlConnection oSqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlServer"].ConnectionString);
            SqlCommand oSqlCmd = new SqlCommand(sStp, oSqlCon);

            try
            {

                oSqlCmd.CommandType = CommandType.StoredProcedure;
                oSqlCmd.CommandTimeout = 900;

                SqlParameter paramID = new SqlParameter("@id", SqlDbType.Int);
                SqlParameter paramStartTime = new SqlParameter("@starttime", SqlDbType.DateTime);
                SqlParameter paramEndTime = new SqlParameter("@endtime", SqlDbType.DateTime);
                SqlParameter paramSubject = new SqlParameter("@subject", SqlDbType.VarChar, 255);
                SqlParameter paramIsAllDayEvent = new SqlParameter("@IsAllDayEvent", SqlDbType.SmallInt);
                SqlParameter paramDescription = new SqlParameter("@Description", SqlDbType.VarChar, 1000);
                SqlParameter paramLocation = new SqlParameter("@Location", SqlDbType.VarChar, 200);
                SqlParameter paramColor = new SqlParameter("@Color", SqlDbType.VarChar, 200);


                // Assign values to parameters
                paramID.Value = id;
                paramStartTime.Value = st;
                paramEndTime.Value = et;
                paramSubject.Value = sub;
                paramIsAllDayEvent.Value = ade;
                paramDescription.Value = dscr;
                paramLocation.Value = loc;
                paramColor.Value = color;

                // Add the parameters to oSqlCmd object
                oSqlCmd.Parameters.Add(paramID);
                oSqlCmd.Parameters.Add(paramStartTime);
                oSqlCmd.Parameters.Add(paramEndTime);
                oSqlCmd.Parameters.Add(paramSubject);
                oSqlCmd.Parameters.Add(paramIsAllDayEvent);
                oSqlCmd.Parameters.Add(paramDescription);
                oSqlCmd.Parameters.Add(paramLocation);
                oSqlCmd.Parameters.Add(paramColor);

                // Open SQL connection and execute it
                oSqlCon.Open();
                sqlReturn = oSqlCmd.ExecuteNonQuery();

                ret.Add("IsSuccess", true);
                ret.Add("Msg", "update success");
                ret.Add("Data", sqlReturn.ToString());

            }
            catch (Exception)
            {
                ret.Add("IsSuccess", false);
                ret.Add("Msg", "update failed");
                ret.Add("Data", sqlReturn.ToString());
            }
            finally
            {
                if (oSqlCon.State == ConnectionState.Open)
                    oSqlCon.Close();
            }

            return ret;

        }

        public static Dictionary<string, object> removeCalendar(int id)
        {

            Dictionary<string, object> ret = new Dictionary<string, object>();

            string sStp = "proc_JQCalendar_removeCalendar";
            int sqlReturn = 0;

            SqlConnection oSqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlServer"].ConnectionString);
            SqlCommand oSqlCmd = new SqlCommand(sStp, oSqlCon);

            try
            {

                oSqlCmd.CommandType = CommandType.StoredProcedure;
                oSqlCmd.CommandTimeout = 900;

                SqlParameter paramID = new SqlParameter("@id", SqlDbType.Int);

                // Assign values to parameters
                paramID.Value = id;

                // Add the parameters to oSqlCmd object
                oSqlCmd.Parameters.Add(paramID);

                // Open SQL connection and execute it
                oSqlCon.Open();
                sqlReturn = oSqlCmd.ExecuteNonQuery();

                ret.Add("IsSuccess", true);
                ret.Add("Msg", "remove success");
                ret.Add("Data", sqlReturn.ToString());

            }
            catch (Exception)
            {
                ret.Add("IsSuccess", false);
                ret.Add("Msg", "remove failed");
                ret.Add("Data", sqlReturn.ToString());
            }
            finally
            {
                if (oSqlCon.State == ConnectionState.Open)
                    oSqlCon.Close();
            }

            return ret;

        }

    } // End class DataFeedClass

    public static class Functions
    {

        /// <summary>
        /// Get the first day of the month for
        /// any full date submitted
        /// </summary>
        /// <param name="dtDate"></param>
        /// <returns></returns>
        public static DateTime GetFirstDayOfMonth(DateTime dtDate)
        {

            // set return value to the first day of the month
            // for any date passed in to the method
            // create a datetime variable set to the passed in date
            DateTime dtFrom = dtDate;

            // remove all of the days in the month
            // except the first day and set the
            // variable to hold that date
            dtFrom = dtFrom.AddDays(-(dtFrom.Day - 1));

            // return the first day of the month
            return dtFrom;

        }

        /// <summary>
        /// Get the first day of the month for a
        /// month passed by it's integer value
        /// </summary>
        /// <param name="iMonth"></param>
        /// <returns></returns>
        public static DateTime GetFirstDayOfMonth(int iMonth)
        {

            // set return value to the last day of the month
            // for any date passed in to the method
            // create a datetime variable set to the passed in date
            DateTime dtFrom = new DateTime(DateTime.Now.Year, iMonth, 1);

            // remove all of the days in the month
            // except the first day and set the
            // variable to hold that date
            dtFrom = dtFrom.AddDays(-(dtFrom.Day - 1));

            // return the first day of the month
            return dtFrom;

        }

        /// <summary>
        /// Get the last day of the month for any
        /// full date
        /// </summary>
        /// <param name="dtDate"></param>
        /// <returns></returns>
        public static DateTime GetLastDayOfMonth(DateTime dtDate)
        {

            // set return value to the last day of the month
            // for any date passed in to the method
            // create a datetime variable set to the passed in date
            DateTime dtTo = dtDate;

            // overshoot the date by a month
            dtTo = dtTo.AddMonths(1);

            // remove all of the days in the next month
            // to get bumped down to the last day of the
            // previous month
            dtTo = dtTo.AddDays(-(dtTo.Day));

            // return the last day of the month
            return dtTo;

        }

        /// <summary>
        /// Get the last day of a month expressed by it's
        /// integer value
        /// </summary>
        /// <param name="iMonth"></param>
        /// <returns></returns>
        public static DateTime GetLastDayOfMonth(int iMonth)
        {

            // set return value to the last day of the month
            // for any date passed in to the method
            // create a datetime variable set to the passed in date
            DateTime dtTo = new DateTime(DateTime.Now.Year, iMonth, 1);

            // overshoot the date by a month
            dtTo = dtTo.AddMonths(1);


            // remove all of the days in the next month
            // to get bumped down to the last day of the
            // previous month
            dtTo = dtTo.AddDays(-(dtTo.Day));

            // return the last day of the month
            return dtTo;

        }

        /// <summary>
        /// Get the first day of the week for any full date
        /// </summary>
        /// <param name="dtDate"></param>
        /// <returns></returns>
        public static DateTime GetFirstDayOfWeek(DateTime dtDate)
        {
            return dtDate.AddDays(1 - Convert.ToInt16(dtDate.DayOfWeek));
        }

        /// <summary>
        /// Get the last day of the week for any full date
        /// </summary>
        /// <param name="dtDate"></param>
        /// <returns></returns>
        public static DateTime GetLastDayOfWeek(DateTime dtDate)
        {
            return dtDate.AddDays(7 - Convert.ToInt16(dtDate.DayOfWeek));
        }

        /// <summary>
        /// Converts a date into unix timestamp
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static int ConvertToUnixTimeStamp(DateTime date)
        {
            DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            TimeSpan diff = date - origin;
            return (int)diff.TotalSeconds;
        }

        public static DateTime ConvertFromUnixTimestamp(double timestamp)
        {
            DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return origin.AddSeconds(timestamp);
        }


    } // End class Functions

}