namespace FirehoseFinder.Forms
{
    partial class Rate
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Rate));
            this.users_rating_chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.users_rating_chart)).BeginInit();
            this.SuspendLayout();
            // 
            // users_rating_chart
            // 
            chartArea1.AxisX.IsReversed = true;
            chartArea1.CursorX.AxisType = System.Windows.Forms.DataVisualization.Charting.AxisType.Secondary;
            chartArea1.Name = "ChartArea1";
            this.users_rating_chart.ChartAreas.Add(chartArea1);
            this.users_rating_chart.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Enabled = false;
            legend1.Name = "Legend1";
            this.users_rating_chart.Legends.Add(legend1);
            this.users_rating_chart.Location = new System.Drawing.Point(0, 0);
            this.users_rating_chart.Name = "users_rating_chart";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedBar;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.users_rating_chart.Series.Add(series1);
            this.users_rating_chart.Size = new System.Drawing.Size(800, 450);
            this.users_rating_chart.TabIndex = 0;
            this.users_rating_chart.Text = "chart1";
            // 
            // Rate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.users_rating_chart);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Rate";
            this.Text = "Рейтинг неравнодушных пользователей";
            ((System.ComponentModel.ISupportInitialize)(this.users_rating_chart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart users_rating_chart;
    }
}