using System.Windows.Forms;
using System.Collections.Generic;

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
            for (int count_str = 0; count_str < sort_rate.Count; count_str++)
            {
                users_rating_chart.Series["s1"].Points.AddXY(count_str+1, sort_rate[count_str].User_mess);
                users_rating_chart.Series["s2"].Points.AddXY(count_str+1, sort_rate[count_str].User_reactions);
                users_rating_chart.ChartAreas[0].AxisX.CustomLabels.Add(count_str+0.5, count_str+1.5, $"{count_str+1}. {sort_rate[count_str].User_fullname} - ({sort_rate[count_str].User_mess + sort_rate[count_str].User_reactions})");
            }
        }
    }
}