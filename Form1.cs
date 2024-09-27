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
        Queue<Proceso> Cola_procesos = new Queue<Proceso>();
        Proceso procesoE = null; // Proceso en ejecución
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
        }
        public void llenarCola()
        {
            Random random = new Random();
            for(int i=1; i<=10; ++i)
            {
                Cola_procesos.Enqueue(new Proceso(i,random.Next(3,10)));
            }
        }

        public void Ajustartabla()
        {
            // Limpia las series anteriores
            tablaProcesos.Series.Clear();

            // Crear la primera serie para el "Tiempo Trabajado"
            Series serieTiempoTrabajado = new Series("Tiempo Trabajado");
            serieTiempoTrabajado.ChartType = SeriesChartType.StackedColumn; // Tipo de gráfico apilado

            // Crear la segunda serie para el "Tiempo Restante"
            Series serieTiempoRestante = new Series("Tiempo Restante");
            serieTiempoRestante.ChartType = SeriesChartType.StackedColumn; // Tipo de gráfico apilado

            Random random = new Random();

            // Añadir los puntos a las series
            foreach (Proceso pTemp in Cola_procesos)
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

            while (Cola_procesos.Count > 0)
            {
                procesoE = Cola_procesos.Dequeue();
                await EjecutarProceso(); // Esperar a que el proceso actual termine
            }

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
            if(procesoE.tiempoTrabajado > procesoE.TME) procesoE.tiempoTrabajado = procesoE.TME;
            stopwatchProceso.Stop(); // Detener el cronómetro
            procesoE = null; // Indicar que no hay proceso en ejecución
        }
    }
}
