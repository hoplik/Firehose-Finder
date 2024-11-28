using FirehoseFinder.Properties;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Globalization;
using System.Drawing;

namespace FirehoseFinder.Forms
{
    public partial class Rate : Form
    {
        readonly Func funcs = new Func();
        public Rate()
        {
            InitializeComponent();
            dataSet_rate.ReadXml("Users_Rate.xml", XmlReadMode.ReadSchema);
            List<Users_Rating> new_sort_rate = new List<Users_Rating>();
            foreach (DataRow rate_str in dataSet_rate.Tables[1].Rows)
            {
                string user_fullstr = $"{rate_str["UserFN"]} {rate_str["UserLN"]} ({rate_str["UserN"]})";
                int mess = Convert.ToInt32(rate_str["Posts"].ToString(), 10);
                int react = Convert.ToInt32(rate_str["Reactions"].ToString(), 10);
                DateTime dt = DateTime.Parse(rate_str["Last_date"].ToString());
                Users_Rating ur = new Users_Rating(user_fullstr, mess, react, dt);
                new_sort_rate.Add(ur);
            }
            List<Users_Rating> sort_rate = new List<Users_Rating>(funcs.SortingRate(new_sort_rate));
            string fulluser = $"{Settings.Default.userFN} {Settings.Default.userLN} ({Settings.Default.userN})";
            CustomLabel customLabel;
            for (int count_str = 0; count_str<sort_rate.Count; count_str++)
            {
                users_rating_chart.Series["s1"].Points.AddXY(count_str+1, sort_rate[count_str].User_mess);
                users_rating_chart.Series["s2"].Points.AddXY(count_str+1, sort_rate[count_str].User_reactions);
                if (sort_rate[count_str].User_fullname.Equals(fulluser)) customLabel = new CustomLabel()
                {
                    FromPosition = count_str + 0.5,
                    ToPosition = count_str + 1.5,
                    Text = $"{count_str+1}. {sort_rate[count_str].User_fullname} - ({sort_rate[count_str].User_mess + sort_rate[count_str].User_reactions})",
                    ForeColor = Color.Red
                };
                else customLabel = new CustomLabel()
                {
                    FromPosition = count_str+0.5,
                    ToPosition = count_str+1.5,
                    Text = $"{count_str+1}. {sort_rate[count_str].User_fullname} - ({sort_rate[count_str].User_mess + sort_rate[count_str].User_reactions})"
                };
                users_rating_chart.ChartAreas[0].AxisX.CustomLabels.Add(customLabel);
            }
        }
    }
}