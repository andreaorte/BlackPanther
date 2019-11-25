using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasesMarcacion
{

    public enum TipoHora
    {
        Normal,
        Extra,
        Guardia
    }
    public class Bloque
    {

        public Usuari NombreUsuario  { get; set; }
        public TipoHora Tipo_Hora { get; set; }
        public DateTime HoraEntrada  { get; set; }
        public DateTime HoraSalida { get; set; }
        public DateTime FechaEntrada { get; set; }
        public DateTime FechaSalida { get; set; }


        public static List<Bloque> listaBloque = new List<Bloque>();
        //Metodo para Obtener Proveedores
        public static List<Bloque> ObtenerBloque()
        {
            return listaBloque;
        }

        public Bloque() { }

        public Bloque(string codigoHumano, DateTime horaentrada, DateTime horasalida, DateTime fechaEntrada, DateTime fechaSalida)
        {
            
            this.HoraEntrada = horaentrada;
            this.HoraSalida = horasalida;
            this.FechaEntrada = fechaEntrada;
            this.FechaSalida = fechaSalida;

        }


        //Metodo para Agregar Proveedores

        public static void AgregarBloque(Bloque b)
        {
            listaBloque.Add(b);
        }
        public static void EliminarBloque(Bloque b)
        {
            listaBloque.Remove(b);
        }

        public static void EditarBloque(Bloque b, int indice)
        {
            Bloque.listaBloque[indice] = b;

        }



        public override string ToString()
        {
            return this.NombreUsuario.ToString();
        }



    }
}
