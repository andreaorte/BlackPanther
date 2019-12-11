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

        public int Id { get; set; }
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
                
                    con.Open(); 
                    string textoCmd = "insert into Bloque (Usuario, Tipo_Hora, HoraEntrada, HoraSalida, FechaEntrada, FechaSalida) VALUES (@Usuario, @Tipo_Hora, @HoraEntrada, @HoraSalida, @FechaEntrada, @FechaSalida)";
                    SqlCommand cmd = new SqlCommand(textoCmd, con);
                cmd = b.ObtenerParametros(cmd);
                cmd.ExecuteNonQuery();


            }
        }

        private SqlCommand ObtenerParametros(SqlCommand cmd, Boolean id = false)
        {
            SqlParameter p1 = new SqlParameter("@Usuario", this.NombreUsuario.Id);
            SqlParameter p2 = new SqlParameter("@Tipo_Hora", this.Tipo_Hora);
            SqlParameter p3 = new SqlParameter("@HoraEntrada", this.HoraEntrada);
            SqlParameter p4 = new SqlParameter("@HoraSalida", this.HoraSalida);
            SqlParameter p5 = new SqlParameter("@Cargo", this.FechaEntrada);
            SqlParameter p6 = new SqlParameter("@tipoUsuario", this.FechaSalida);


            p1.SqlDbType = SqlDbType.Int;
            p2.SqlDbType = SqlDbType.Int;
            p3.SqlDbType = SqlDbType.DateTime;
            p4.SqlDbType = SqlDbType.DateTime;
            p5.SqlDbType = SqlDbType.Date;
            p6.SqlDbType = SqlDbType.Date;
  


            cmd.Parameters.Add(p1);
            cmd.Parameters.Add(p2);
            cmd.Parameters.Add(p3);
            cmd.Parameters.Add(p4);
            cmd.Parameters.Add(p5);
            cmd.Parameters.Add(p6);
         

            if (id == true)
            {
                cmd = ObtenerParametrosId(cmd);
            }
            return cmd;
        }

        private SqlCommand ObtenerParametrosId(SqlCommand cmd)
        {
            SqlParameter p7 = new SqlParameter("@Id", this.Id);
            p7.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(7);
            return cmd;
        }

        public static void EliminarBloque(Bloque b)
        {
            using (SqlConnection con = new SqlConnection(SqlServer.CADENA_CONEXION))

            {
                con.Open();
                string SENTENCIA_SQL = "delete from Bloque where Id = @Id";

                SqlCommand cmd = new SqlCommand(SENTENCIA_SQL, con);
                SqlParameter p1 = new SqlParameter("@Id", b.Id);
                p1.SqlDbType = SqlDbType.Int;
                cmd.Parameters.Add(p1);

                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public static void EditarBloque(Bloque b, int indice)
        {
            using (SqlConnection con = new SqlConnection(SqlServer.CADENA_CONEXION))
            {
                con.Open();
                string textoCMD = "UPDATE Bloque SET Usuario=@Usuario, Tipo_Hora =@Tipo_Hora, HoraEntrada=@HoraEntrada, HoraSalida=@HoraSalida, FechaEntrada=@FechaEntrada,FechaSalida=@FechaSalida where Id = @Id";

                SqlCommand cmd = new SqlCommand(textoCMD, con);
                cmd = b.ObtenerParametros(cmd, true);

                cmd.ExecuteNonQuery();
            }

        }

        public static List<Bloque> ObtenerBloques()
        {
            Bloque b;

            listaBloque.Clear();

            using (SqlConnection con = new SqlConnection(SqlServer.CADENA_CONEXION))
            {
                con.Open();
                string textoCMD = "select * from Bloque";
                SqlCommand cmd = new SqlCommand(textoCMD, con);

                SqlDataReader elLectorDeDatos = cmd.ExecuteReader();

                while (elLectorDeDatos.Read())
                {
                    b = new Bloque();
                    b.Id = elLectorDeDatos.GetInt32(0);
                    b.NombreUsuario = Usuari.ObtenerUsuario(elLectorDeDatos.GetInt32(1));
                    b.Tipo_Hora = (TipoHora)elLectorDeDatos.GetInt32(2);
                    b.HoraEntrada = elLectorDeDatos.GetDateTime(3);
                    b.HoraSalida = elLectorDeDatos.GetDateTime(4);
                    b.FechaEntrada = elLectorDeDatos.GetDateTime(5);
                    b.FechaSalida = elLectorDeDatos.GetDateTime(6);
                    


                    listaBloque.Add(b);

                }
            }

            return listaBloque;
        }



        public override string ToString()
        {
            return this.NombreUsuario.ToString();
        }



    }
}
