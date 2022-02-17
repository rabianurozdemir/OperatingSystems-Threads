
namespace Odev2
{
    partial class Form1
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chartPerformans = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.hesaplaButonu = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chartPerformans)).BeginInit();
            this.SuspendLayout();
            // 
            // chartPerformans
            // 
            this.chartPerformans.BackColor = System.Drawing.Color.Transparent;
            chartArea1.Name = "ChartArea1";
            this.chartPerformans.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartPerformans.Legends.Add(legend1);
            this.chartPerformans.Location = new System.Drawing.Point(46, 62);
            this.chartPerformans.Name = "chartPerformans";
            this.chartPerformans.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.EarthTones;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.LabelForeColor = System.Drawing.Color.Transparent;
            series1.Legend = "Legend1";
            series1.MarkerColor = System.Drawing.Color.Red;
            series1.MarkerSize = 8;
            series1.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
            series1.Name = "Series1";
            this.chartPerformans.Series.Add(series1);
            this.chartPerformans.Size = new System.Drawing.Size(764, 422);
            this.chartPerformans.TabIndex = 0;
            this.chartPerformans.Text = "chart1";
            // 
            // hesaplaButonu
            // 
            this.hesaplaButonu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.hesaplaButonu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.hesaplaButonu.Font = new System.Drawing.Font("Cooper Black", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hesaplaButonu.ForeColor = System.Drawing.Color.MidnightBlue;
            this.hesaplaButonu.Location = new System.Drawing.Point(332, 527);
            this.hesaplaButonu.Name = "hesaplaButonu";
            this.hesaplaButonu.Size = new System.Drawing.Size(141, 50);
            this.hesaplaButonu.TabIndex = 1;
            this.hesaplaButonu.Text = "Hesapla";
            this.hesaplaButonu.UseVisualStyleBackColor = false;
            this.hesaplaButonu.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(936, 645);
            this.Controls.Add(this.hesaplaButonu);
            this.Controls.Add(this.chartPerformans);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.chartPerformans)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartPerformans;
        private System.Windows.Forms.Button hesaplaButonu;
    }
}

