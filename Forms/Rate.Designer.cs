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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Rate));
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.users_rating_chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.dataSet_rate = new System.Data.DataSet();
            ((System.ComponentModel.ISupportInitialize)(this.users_rating_chart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet_rate)).BeginInit();
            this.SuspendLayout();
            // 
            // users_rating_chart
            // 
            chartArea1.AxisX.IsReversed = true;
            chartArea1.CursorX.AxisType = System.Windows.Forms.DataVisualization.Charting.AxisType.Secondary;
            chartArea1.Name = "ChartArea1";
            this.users_rating_chart.ChartAreas.Add(chartArea1);
            resources.ApplyResources(this.users_rating_chart, "users_rating_chart");
            legend1.Enabled = false;
            legend1.Name = "Legend1";
            this.users_rating_chart.Legends.Add(legend1);
            this.users_rating_chart.Name = "users_rating_chart";
            this.users_rating_chart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Pastel;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedBar;
            series1.IsValueShownAsLabel = true;
            series1.Legend = "Legend1";
            series1.Name = "s1";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedBar;
            series2.IsValueShownAsLabel = true;
            series2.Legend = "Legend1";
            series2.Name = "s2";
            this.users_rating_chart.Series.Add(series1);
            this.users_rating_chart.Series.Add(series2);
            // 
            // dataSet_rate
            // 
            this.dataSet_rate.DataSetName = "NewDataSet";
            // 
            // Rate
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.users_rating_chart);
            this.Name = "Rate";
            ((System.ComponentModel.ISupportInitialize)(this.users_rating_chart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet_rate)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart users_rating_chart;
        private System.Data.DataSet dataSet_rate;
    }
}