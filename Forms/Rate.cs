using System.Windows.Forms;
using System.Collections.Generic;
using FirehoseFinder.Properties;
using System.Drawing;
using System.Windows.Forms.DataVisualization.Charting;

namespace FirehoseFinder.Forms
{
    public partial class Rate : Form
    {
        Guide guide = new Guide();
        Func funcs = new Func();
        public Rate()
        {
            InitializeComponent();
            List<Users_Rating> sort_rate = new List<Users_Rating>(funcs.SortingRate(guide.users_rate));
            string fulluser = $"{ Settings.Default.userFN } { Settings.Default.userLN} ({ Settings.Default.userN})";
            CustomLabel customLabel;
            for (int count_str = 0; count_str < sort_rate.Count; count_str++)
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