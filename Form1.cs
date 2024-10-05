using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Practica5_PlanificadorFCFS
{
    public partial class Form1 : Form
    {
        Queue<Proceso> Cola_procesos_nuevos = new Queue<Proceso>();
        Queue<Proceso> Cola_procesos_listos = new Queue<Proceso>();
        List<Proceso> Lista_Procesos_listos = new List<Proceso>();
        Proceso procesoE = null; // Proceso en ejecución
        Stopwatch stopwatchGlobal = new Stopwatch();
        Stopwatch stopwatchProceso = new Stopwatch();
        CancellationTokenSource cts = new CancellationTokenSource();
        List<String> ListaPID = new List<string>();
        List<double> ListaTiempoMaximo = new List<double>();
        List<double> ListaTiempoTrabajado = new List<double>();

        public Form1()
        {
            InitializeComponent();
            llenarCola();
            Ajustartabla();
            AjustartablaPromedios();
        }
        public void llenarCola()
        {
            Random random = new Random();
            for(int i=1; i<=10; ++i)
            {
                Cola_procesos_nuevos.Enqueue(new Proceso(i,random.Next(3,10)));
            }
        }
        private void LlenarTablaProcesosListos()
        {
            // Limpia la tabla antes de llenarla con nuevos datos
            tablaProcesosListos.Rows.Clear();

            // Recorre la lista de procesos completados
            foreach (Proceso proceso in Lista_Procesos_listos)
            {
                tablaProcesosListos.Rows.Add(
                    proceso.PID,                           // Columna PID
                    Math.Round(proceso.tiempoLlegada, 2),  // Columna Tiempo de llegada
                    Math.Round(proceso.tiempoFinalizado, 2), // Columna Tiempo finalizado
                    Math.Round(proceso.getEspera(), 2),    // Columna Tiempo de espera
                    Math.Round(proceso.getEjecuccion(), 2), // Columna Tiempo de ejecución
                    Math.Round(proceso.getRetorno(), 2)    // Columna Tiempo de retorno
                );
            }
            // Calcular y actualizar los promedios
            CalcularPromedios();
        }
        private void AjustartablaPromedios()
        {
            // Definir el ancho total de la tabla
            int anchoPorColumna = tablaPromedios.ClientSize.Width / 3; // Obtener el ancho disponible del DataGridView

            // Asignar los anchos calculados a las columnas
            tablaPromedios.Columns[0].Width = anchoPorColumna;
            tablaPromedios.Columns[1].Width = anchoPorColumna;
            tablaPromedios.Columns[2].Width = anchoPorColumna;

            //Inicializar los promedios en 0
            tablaPromedios.Rows.Add(0,0,0);
            tablaPromedios.Rows[0].Height = 20;

            tablaPromedios.DefaultCellStyle.SelectionBackColor = tablaPromedios.DefaultCellStyle.BackColor; // Hacer que el color de fondo sea el mismo en la selección
            tablaPromedios.DefaultCellStyle.SelectionForeColor = tablaPromedios.DefaultCellStyle.ForeColor; // Mantener el color del texto igual
        }
        private void CalcularPromedios()
        {
            double totalEspera = 0;
            double totalEjecuccion = 0;
            double totalRetorno = 0;
            int totalProcesos = Lista_Procesos_listos.Count;  // Número total de procesos en la lista

            // Recorremos la lista para sumar los tiempos de espera, ejecución y retorno
            foreach (Proceso proceso in Lista_Procesos_listos)
            {
                totalEspera += proceso.getEspera();
                totalEjecuccion += proceso.getEjecuccion();
                totalRetorno += proceso.getRetorno();
            }

            // Calcular los promedios
            double promedioEspera = totalProcesos > 0 ? totalEspera / totalProcesos : 0;
            double promedioEjecuccion = totalProcesos > 0 ? totalEjecuccion / totalProcesos : 0;
            double promedioRetorno = totalProcesos > 0 ? totalRetorno / totalProcesos : 0;

            // Redondear los resultados a 2 decimales
            promedioEspera = Math.Round(promedioEspera, 2);
            promedioEjecuccion = Math.Round(promedioEjecuccion, 2);
            promedioRetorno = Math.Round(promedioRetorno, 2);

            // Actualizar la tabla o crear una fila para mostrar estos promedios
            ActualizarTablaPromedios(promedioEspera, promedioEjecuccion, promedioRetorno);
        }
        private void ActualizarTablaPromedios(double promedioEspera, double promedioEjecuccion, double promedioRetorno)
        {
            // Limpia la tabla de promedios
            tablaPromedios.Rows.Clear();

            // Añadir una nueva fila con los promedios calculados
            tablaPromedios.Rows.Add(
                promedioEspera,            // Columna Promedio Tiempo de Espera
                promedioEjecuccion,        // Columna Promedio Tiempo de Ejecución
                promedioRetorno            // Columna Promedio Tiempo de Retorno
            );
        }

        public void Ajustartabla()
        {
            // Limpia las series anteriores
            tablaProcesos.Series.Clear();

            // Definir el ancho total de la tabla
            int anchoTotalTabla = 675;

            // Desactivar el ajuste automático de columnas
            tablaProcesosListos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            tablaProcesosListos.AllowUserToResizeColumns = false;

            // Definir los tamaños de las columnas restando un poco para márgenes y scrollbars
            int anchoPID = 50;
            int anchoRestante = (anchoTotalTabla - anchoPID) - 20; // Reservar espacio para bordes y scrollbar (aproximadamente 20 píxeles)
            int anchoColumnas = anchoRestante / 5; // Distribuir entre las otras 5 columnas

            // Configurar los anchos de las columnas
            tablaProcesosListos.Columns[0].Width = anchoPID;       // Columna PID
            tablaProcesosListos.Columns[1].Width = anchoColumnas;  // Columna Tiempo de llegada
            tablaProcesosListos.Columns[2].Width = anchoColumnas;  // Columna Tiempo finalizado
            tablaProcesosListos.Columns[3].Width = anchoColumnas;  // Columna Tiempo de espera
            tablaProcesosListos.Columns[4].Width = anchoColumnas;  // Columna Tiempo de ejecución
            tablaProcesosListos.Columns[5].Width = anchoColumnas;  // Columna Tiempo de retorno

            // Establecer el ancho del DataGridView
            tablaProcesosListos.Width = anchoTotalTabla;

            // Ajuste correcto de tamaño máximo
            tablaProcesosListos.MaximumSize = new Size(anchoTotalTabla + 20, tablaProcesosListos.Height);

            // Evitar la fila vacía al final
            tablaProcesosListos.AllowUserToAddRows = false;

            // Asegurarse de que no haya scroll horizontal
            tablaProcesosListos.ScrollBars = ScrollBars.Vertical;  // Solo barra de scroll vertical

            // Crear la primera serie para el "Tiempo Trabajado"
            Series serieTiempoTrabajado = new Series("Tiempo Trabajado");
            serieTiempoTrabajado.ChartType = SeriesChartType.StackedColumn; // Tipo de gráfico apilado

            // Crear la segunda serie para el "Tiempo Restante"
            Series serieTiempoRestante = new Series("Tiempo Restante");
            serieTiempoRestante.ChartType = SeriesChartType.StackedColumn; // Tipo de gráfico apilado

            Random random = new Random();

            // Añadir los puntos a las series
            foreach (Proceso pTemp in Cola_procesos_nuevos)
            {
                // Calcular el tiempo restante
                double tiempoRestante = pTemp.TME - pTemp.tiempoTrabajado;

                // Crear un color aleatorio para el "Tiempo Trabajado"
                Color colorAleatorio = Color.FromArgb(random.Next(256), random.Next(256), random.Next(256));

                // Añadir el "Tiempo Trabajado" a la primera serie, usando el PID como etiqueta en el eje X
                int indexTrabajado = serieTiempoTrabajado.Points.AddXY(pTemp.PID.ToString(), pTemp.tiempoTrabajado);
                DataPoint puntoTrabajado = serieTiempoTrabajado.Points[indexTrabajado];
                puntoTrabajado.Color = colorAleatorio;  // Asignar color aleatorio

                // Añadir el "Tiempo Restante" a la segunda serie, usando el PID como etiqueta en el eje X
                int indexRestante = serieTiempoRestante.Points.AddXY(pTemp.PID.ToString(), tiempoRestante);
                DataPoint puntoRestante = serieTiempoRestante.Points[indexRestante];
                puntoRestante.Color = Color.Gray;  // Color para el tiempo restante
            }

            // Agregar ambas series al gráfico
            tablaProcesos.Series.Add(serieTiempoTrabajado);
            tablaProcesos.Series.Add(serieTiempoRestante);

            // Configurar el eje X para tratar los valores como etiquetas de texto
            var chartArea = tablaProcesos.ChartAreas[0];
            chartArea.AxisX.IsLabelAutoFit = false;  // Deshabilitar el ajuste automático de las etiquetas
            chartArea.AxisX.Interval = 1;  // Mostrar cada proceso como una etiqueta separada
            chartArea.AxisX.LabelStyle.Angle = -45;  // Opcional: Inclinar las etiquetas del eje X para mayor legibilidad
            chartArea.AxisX.MajorGrid.Enabled = false;  // Desactivar las líneas de la cuadrícula en el eje X
            chartArea.AxisX.LabelStyle.IsEndLabelVisible = false;  // Evitar mostrar etiquetas innecesarias en los bordes
            chartArea.AxisX.IntervalAutoMode = IntervalAutoMode.VariableCount;
        }


        public async Task ActualizarTabla()
        {
            while (!cts.IsCancellationRequested)
            {
                if (procesoE != null)
                {
                    // Asegurarse de que las actualizaciones de UI se realicen en el hilo principal
                    this.Invoke((MethodInvoker)delegate
                    {
                        // Actualizar el tiempo trabajado en la serie "Tiempo Trabajado"
                        foreach (DataPoint proceso in tablaProcesos.Series["Tiempo Trabajado"].Points)
                        {
                            if (int.Parse(proceso.AxisLabel) == procesoE.PID)
                            {
                                proceso.YValues[0] = Math.Round(procesoE.tiempoTrabajado, 2);  // Redondear para mejor visualización
                                break;
                            }
                        }
                        // Actualizar el tiempo restante en la serie "Tiempo Restante"
                        foreach (DataPoint proceso in tablaProcesos.Series["Tiempo Restante"].Points)
                        {
                            if (int.Parse(proceso.AxisLabel) == procesoE.PID)
                            {
                                double tiempoRestante = Math.Round(procesoE.getRestante(), 2);
                                proceso.YValues[0] = tiempoRestante <= 0 ? 0 : tiempoRestante;  // Establecer el nuevo tiempo restante
                                break;
                            }
                        }
                        // Refrescar el gráfico para mostrar los cambios
                        tablaProcesos.Invalidate();
                    });
                }
                await Task.Delay(10); // Actualizar cada 100 ms para una visualización fluida
            }
        }
        private async void botonIniciar_Click(object sender, EventArgs e)
        {
            // Iniciar la tarea de actualización del gráfico en segundo plano
            Task actualizacionTablas = ActualizarTabla();

            stopwatchGlobal.Start();
            while(Cola_procesos_nuevos.Count>0)
            {
                Proceso Ptemp = Cola_procesos_nuevos.Dequeue();
                Ptemp.tiempoLlegada = stopwatchGlobal.Elapsed.TotalSeconds;
                Cola_procesos_listos.Enqueue(Ptemp);
            }

            while (Cola_procesos_listos.Count > 0)
            {
                procesoE = Cola_procesos_listos.Dequeue();
                procesoE.tiempoInicio = stopwatchGlobal.Elapsed.TotalSeconds;
                await EjecutarProceso(); // Esperar a que el proceso actual termine
            }
            stopwatchGlobal.Stop();

            // Cancelar la actualización del gráfico una vez que todos los procesos hayan terminado
            cts.Cancel();
            MessageBox.Show("Todos los procesos han terminado.");
        }
        private async Task EjecutarProceso()
        {
            stopwatchProceso.Restart();
            while(procesoE.tiempoTrabajado < procesoE.TME)
            {
                await Task.Delay(10); // Espera de 10 ms
                procesoE.tiempoTrabajado = stopwatchProceso.Elapsed.TotalSeconds; // Convertir a segundos
            }
            if (procesoE.tiempoTrabajado < procesoE.TME) procesoE.tiempoTrabajado = procesoE.TME;
            else procesoE.tiempoTrabajado = stopwatchProceso.Elapsed.TotalSeconds;
            stopwatchProceso.Stop(); // Detener el cronómetro
            procesoE.tiempoFinalizado = stopwatchGlobal.Elapsed.TotalSeconds;

            Lista_Procesos_listos.Add(procesoE);
            LlenarTablaProcesosListos();
            procesoE = null;// Indicar que no hay proceso en ejecución
        }
    }
}
