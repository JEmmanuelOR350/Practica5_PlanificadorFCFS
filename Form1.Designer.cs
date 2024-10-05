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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea8 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend8 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series8 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.tablaProcesos = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.botonIniciar = new System.Windows.Forms.Button();
            this.tablaProcesosListos = new System.Windows.Forms.DataGridView();
            this.TablaListosPID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TablaListosTiempoLlegada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TablaListosTiempoFinalizado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TablaListosTiempoEspera = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TablaListosTiempoEjecuccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TablaListosTiempoRetorno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tablaPromedios = new System.Windows.Forms.DataGridView();
            this.columnaPEspera = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnaTiempoEjecucion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnaTiempoRetorno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.tablaProcesos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablaProcesosListos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablaPromedios)).BeginInit();
            this.SuspendLayout();
            // 
            // tablaProcesos
            // 
            chartArea8.Name = "ChartArea1";
            this.tablaProcesos.ChartAreas.Add(chartArea8);
            legend8.Enabled = false;
            legend8.Name = "Legend1";
            this.tablaProcesos.Legends.Add(legend8);
            this.tablaProcesos.Location = new System.Drawing.Point(55, 32);
            this.tablaProcesos.Name = "tablaProcesos";
            series8.ChartArea = "ChartArea1";
            series8.Legend = "Legend1";
            series8.Name = "Tiempo Ejeccuion";
            this.tablaProcesos.Series.Add(series8);
            this.tablaProcesos.Size = new System.Drawing.Size(993, 300);
            this.tablaProcesos.TabIndex = 0;
            this.tablaProcesos.Text = "chart1";
            // 
            // botonIniciar
            // 
            this.botonIniciar.BackColor = System.Drawing.Color.LightGreen;
            this.botonIniciar.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonIniciar.ForeColor = System.Drawing.Color.DarkGreen;
            this.botonIniciar.Location = new System.Drawing.Point(67, 420);
            this.botonIniciar.Name = "botonIniciar";
            this.botonIniciar.Size = new System.Drawing.Size(160, 42);
            this.botonIniciar.TabIndex = 1;
            this.botonIniciar.Text = "Iniciar";
            this.botonIniciar.UseVisualStyleBackColor = false;
            this.botonIniciar.Click += new System.EventHandler(this.botonIniciar_Click);
            // 
            // tablaProcesosListos
            // 
            this.tablaProcesosListos.AllowUserToAddRows = false;
            this.tablaProcesosListos.AllowUserToDeleteRows = false;
            this.tablaProcesosListos.AllowUserToResizeColumns = false;
            this.tablaProcesosListos.AllowUserToResizeRows = false;
            this.tablaProcesosListos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.tablaProcesosListos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tablaProcesosListos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TablaListosPID,
            this.TablaListosTiempoLlegada,
            this.TablaListosTiempoFinalizado,
            this.TablaListosTiempoEspera,
            this.TablaListosTiempoEjecuccion,
            this.TablaListosTiempoRetorno});
            this.tablaProcesosListos.Location = new System.Drawing.Point(251, 356);
            this.tablaProcesosListos.MaximumSize = new System.Drawing.Size(700, 150);
            this.tablaProcesosListos.MinimumSize = new System.Drawing.Size(675, 150);
            this.tablaProcesosListos.MultiSelect = false;
            this.tablaProcesosListos.Name = "tablaProcesosListos";
            this.tablaProcesosListos.ReadOnly = true;
            this.tablaProcesosListos.RowHeadersVisible = false;
            this.tablaProcesosListos.RowHeadersWidth = 51;
            this.tablaProcesosListos.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.tablaProcesosListos.RowTemplate.Height = 24;
            this.tablaProcesosListos.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tablaProcesosListos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.tablaProcesosListos.Size = new System.Drawing.Size(692, 150);
            this.tablaProcesosListos.TabIndex = 2;
            // 
            // TablaListosPID
            // 
            this.TablaListosPID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.TablaListosPID.Frozen = true;
            this.TablaListosPID.HeaderText = "PID";
            this.TablaListosPID.MinimumWidth = 6;
            this.TablaListosPID.Name = "TablaListosPID";
            this.TablaListosPID.ReadOnly = true;
            this.TablaListosPID.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.TablaListosPID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.TablaListosPID.Width = 35;
            // 
            // TablaListosTiempoLlegada
            // 
            this.TablaListosTiempoLlegada.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.TablaListosTiempoLlegada.Frozen = true;
            this.TablaListosTiempoLlegada.HeaderText = "Tiempo de Llegada (s)";
            this.TablaListosTiempoLlegada.MinimumWidth = 6;
            this.TablaListosTiempoLlegada.Name = "TablaListosTiempoLlegada";
            this.TablaListosTiempoLlegada.ReadOnly = true;
            this.TablaListosTiempoLlegada.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.TablaListosTiempoLlegada.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.TablaListosTiempoLlegada.Width = 122;
            // 
            // TablaListosTiempoFinalizado
            // 
            this.TablaListosTiempoFinalizado.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.TablaListosTiempoFinalizado.Frozen = true;
            this.TablaListosTiempoFinalizado.HeaderText = "Tiempo Finalizado (s)";
            this.TablaListosTiempoFinalizado.MinimumWidth = 6;
            this.TablaListosTiempoFinalizado.Name = "TablaListosTiempoFinalizado";
            this.TablaListosTiempoFinalizado.ReadOnly = true;
            this.TablaListosTiempoFinalizado.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.TablaListosTiempoFinalizado.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.TablaListosTiempoFinalizado.Width = 115;
            // 
            // TablaListosTiempoEspera
            // 
            this.TablaListosTiempoEspera.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.TablaListosTiempoEspera.Frozen = true;
            this.TablaListosTiempoEspera.HeaderText = "Tiempo de Espera (s)";
            this.TablaListosTiempoEspera.MinimumWidth = 6;
            this.TablaListosTiempoEspera.Name = "TablaListosTiempoEspera";
            this.TablaListosTiempoEspera.ReadOnly = true;
            this.TablaListosTiempoEspera.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.TablaListosTiempoEspera.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.TablaListosTiempoEspera.Width = 116;
            // 
            // TablaListosTiempoEjecuccion
            // 
            this.TablaListosTiempoEjecuccion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.TablaListosTiempoEjecuccion.Frozen = true;
            this.TablaListosTiempoEjecuccion.HeaderText = "Tiempo en Ejecución (s)";
            this.TablaListosTiempoEjecuccion.MinimumWidth = 6;
            this.TablaListosTiempoEjecuccion.Name = "TablaListosTiempoEjecuccion";
            this.TablaListosTiempoEjecuccion.ReadOnly = true;
            this.TablaListosTiempoEjecuccion.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.TablaListosTiempoEjecuccion.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.TablaListosTiempoEjecuccion.Width = 126;
            // 
            // TablaListosTiempoRetorno
            // 
            this.TablaListosTiempoRetorno.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.TablaListosTiempoRetorno.Frozen = true;
            this.TablaListosTiempoRetorno.HeaderText = "Tiempo de Retorno - TurnAround (s)";
            this.TablaListosTiempoRetorno.MinimumWidth = 6;
            this.TablaListosTiempoRetorno.Name = "TablaListosTiempoRetorno";
            this.TablaListosTiempoRetorno.ReadOnly = true;
            this.TablaListosTiempoRetorno.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.TablaListosTiempoRetorno.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.TablaListosTiempoRetorno.Width = 205;
            // 
            // tablaPromedios
            // 
            this.tablaPromedios.AllowUserToAddRows = false;
            this.tablaPromedios.AllowUserToDeleteRows = false;
            this.tablaPromedios.AllowUserToResizeColumns = false;
            this.tablaPromedios.AllowUserToResizeRows = false;
            this.tablaPromedios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tablaPromedios.ColumnHeadersVisible = false;
            this.tablaPromedios.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.columnaPEspera,
            this.columnaTiempoEjecucion,
            this.columnaTiempoRetorno});
            this.tablaPromedios.Enabled = false;
            this.tablaPromedios.Location = new System.Drawing.Point(525, 540);
            this.tablaPromedios.MaximumSize = new System.Drawing.Size(418, 30);
            this.tablaPromedios.MinimumSize = new System.Drawing.Size(418, 30);
            this.tablaPromedios.Name = "tablaPromedios";
            this.tablaPromedios.ReadOnly = true;
            this.tablaPromedios.RowHeadersVisible = false;
            this.tablaPromedios.RowHeadersWidth = 51;
            this.tablaPromedios.RowTemplate.Height = 24;
            this.tablaPromedios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.tablaPromedios.Size = new System.Drawing.Size(418, 30);
            this.tablaPromedios.TabIndex = 3;
            // 
            // columnaPEspera
            // 
            this.columnaPEspera.Frozen = true;
            this.columnaPEspera.HeaderText = "Promedio Tiempo Espera";
            this.columnaPEspera.MinimumWidth = 6;
            this.columnaPEspera.Name = "columnaPEspera";
            this.columnaPEspera.ReadOnly = true;
            this.columnaPEspera.Width = 125;
            // 
            // columnaTiempoEjecucion
            // 
            this.columnaTiempoEjecucion.Frozen = true;
            this.columnaTiempoEjecucion.HeaderText = "Promedio Tiempo Ejecucion";
            this.columnaTiempoEjecucion.MinimumWidth = 6;
            this.columnaTiempoEjecucion.Name = "columnaTiempoEjecucion";
            this.columnaTiempoEjecucion.ReadOnly = true;
            this.columnaTiempoEjecucion.Width = 125;
            // 
            // columnaTiempoRetorno
            // 
            this.columnaTiempoRetorno.Frozen = true;
            this.columnaTiempoRetorno.HeaderText = "Promedio Tiempo de Retorno";
            this.columnaTiempoRetorno.MinimumWidth = 6;
            this.columnaTiempoRetorno.Name = "columnaTiempoRetorno";
            this.columnaTiempoRetorno.ReadOnly = true;
            this.columnaTiempoRetorno.Width = 125;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(372, 540);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 26);
            this.label1.TabIndex = 4;
            this.label1.Text = "Promedios:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1095, 588);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tablaPromedios);
            this.Controls.Add(this.tablaProcesosListos);
            this.Controls.Add(this.botonIniciar);
            this.Controls.Add(this.tablaProcesos);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.tablaProcesos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablaProcesosListos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablaPromedios)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart tablaProcesos;
        private System.Windows.Forms.Button botonIniciar;
        private System.Windows.Forms.DataGridView tablaProcesosListos;
        private System.Windows.Forms.DataGridViewTextBoxColumn TablaListosPID;
        private System.Windows.Forms.DataGridViewTextBoxColumn TablaListosTiempoLlegada;
        private System.Windows.Forms.DataGridViewTextBoxColumn TablaListosTiempoFinalizado;
        private System.Windows.Forms.DataGridViewTextBoxColumn TablaListosTiempoEspera;
        private System.Windows.Forms.DataGridViewTextBoxColumn TablaListosTiempoEjecuccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn TablaListosTiempoRetorno;
        private System.Windows.Forms.DataGridView tablaPromedios;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnaPEspera;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnaTiempoEjecucion;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnaTiempoRetorno;
        private System.Windows.Forms.Label label1;
    }
}

