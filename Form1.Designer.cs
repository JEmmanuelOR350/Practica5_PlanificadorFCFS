namespace Practica5_PlanificadorFCFS
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.tablaProcesos = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.botonIniciar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.tablaProcesos)).BeginInit();
            this.SuspendLayout();
            // 
            // tablaProcesos
            // 
            chartArea1.Name = "ChartArea1";
            this.tablaProcesos.ChartAreas.Add(chartArea1);
            legend1.Enabled = false;
            legend1.Name = "Legend1";
            this.tablaProcesos.Legends.Add(legend1);
            this.tablaProcesos.Location = new System.Drawing.Point(76, 34);
            this.tablaProcesos.Name = "tablaProcesos";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Tiempo Ejeccuion";
            this.tablaProcesos.Series.Add(series1);
            this.tablaProcesos.Size = new System.Drawing.Size(993, 300);
            this.tablaProcesos.TabIndex = 0;
            this.tablaProcesos.Text = "chart1";
            // 
            // botonIniciar
            // 
            this.botonIniciar.Location = new System.Drawing.Point(76, 368);
            this.botonIniciar.Name = "botonIniciar";
            this.botonIniciar.Size = new System.Drawing.Size(233, 42);
            this.botonIniciar.TabIndex = 1;
            this.botonIniciar.Text = "Iniciar";
            this.botonIniciar.UseVisualStyleBackColor = true;
            this.botonIniciar.Click += new System.EventHandler(this.botonIniciar_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1095, 517);
            this.Controls.Add(this.botonIniciar);
            this.Controls.Add(this.tablaProcesos);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.tablaProcesos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart tablaProcesos;
        private System.Windows.Forms.Button botonIniciar;
    }
}

