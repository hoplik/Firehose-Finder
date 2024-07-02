using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FirehoseFinder.Forms
{
    public partial class Rate : Form
    {
        Guide guide = new Guide();
        public Rate()
        {
            InitializeComponent();
            int count_str = 1;
            foreach (Users_Rating users_Rating in guide.users_rate)
            {
                users_rating_chart.Series["Series1"].Points.AddXY(count_str, users_Rating.User_activities);
                users_rating_chart.ChartAreas[0].AxisX.CustomLabels.Add(count_str-0.5, count_str+0.5, $"{count_str}. {users_Rating.User_fullname}");
                count_str++;
            }
        }
    }
}