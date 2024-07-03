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
                users_rating_chart.Series["s1"].Points.AddXY(count_str, users_Rating.User_mess);
                users_rating_chart.Series["s2"].Points.AddXY(count_str, users_Rating.User_reactions);
                users_rating_chart.ChartAreas[0].AxisX.CustomLabels.Add(count_str-0.5, count_str+0.5, $"{count_str}. {users_Rating.User_fullname} - ({users_Rating.User_mess + users_Rating.User_reactions})");
                count_str++;
            }
        }
    }
}