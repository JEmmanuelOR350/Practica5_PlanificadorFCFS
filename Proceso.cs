using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Practica5_PlanificadorFCFS
{
    internal class Proceso
    {
        public int PID { get; set; }          // Identificador del proceso
        public int TME { get; set; }          // Tiempo máximo estimado en segundos
        public double tiempoTrabajado { get; set; }  // Tiempo trabajado hasta ahora en milisegundos

        // Constructor para inicializar un proceso con su PID y su TME
        public Proceso(int pid, int TimeE)
        {
            PID = pid;
            TME = TimeE;
            tiempoTrabajado = 0.0;  // Inicialmente no se ha trabajado nada
        }

        // Método para calcular y devolver el tiempo restante del proceso
        public double getRestante()
        {
            return TME - tiempoTrabajado;  // Retorna la diferencia entre TME y tiempo trabajado
        }
    }
}
