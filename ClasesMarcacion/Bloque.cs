using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

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
        public DateTime HoraEntrada  { get; set; }
        public DateTime HoraSalida { get; set; }
        public DateTime FechaEntrada { get; set; }
        public DateTime FechaSalida { get; set; }
        public TipoHora Tipo_Hora { get; set; }


        public static List<Bloque> listaBloque = new List<Bloque>();


        public static List<Bloque> ObtenerBloque()
        {
            return listaBloque; ;
        }

        public static void AgregarBloque(Bloque b)
        {
            using (SqlConnection con = new SqlConnection(SqlServer.CADENA_CONEXION))
            {
            }
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
