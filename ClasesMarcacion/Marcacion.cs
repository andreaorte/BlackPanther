using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ClasesMarcacion
{
    
    public class Marcacion

    {

        public int Id { get; set; }
        public Usuari empleado { get; set; }
        public string MarcacionEntrada { get; set; }
        public string MarcacionSalida { get; set; }
        public string HorasTrabajadas { get; set; }
        public DateTime FechaMarcacion { get; set; }
        
        //public DateTime Hora { get; set; }

        public static List<Marcacion> listaMarcacion = new List<Marcacion>();

        public Marcacion() { }


        public static void AgregarMarcacion(Marcacion m)
        {
            using (SqlConnection con = new SqlConnection(SqlServer.CADENA_CONEXION))

            {
                con.Open();
                string textoCmd = "INSERT INTO Marcacion (Usuario,MarcacionEntrada, MarcacionSalida,HorasTrabajadas, FechaMarcacion)VALUES (@Usuario, @MarcacionEntrada, @MarcacionSalida, @HorasTrabajadas, @FechaMarcacion)";
                SqlCommand cmd = new SqlCommand(textoCmd, con);
                cmd = m.ObtenerParametros(cmd);
                cmd.ExecuteNonQuery();
            }
        }

        private SqlCommand ObtenerParametros(SqlCommand cmd, Boolean id = false)
        {
            SqlParameter p1 = new SqlParameter("@Usuario", this.empleado.Id);
            SqlParameter p2 = new SqlParameter("@MarcacionEntrada", this.MarcacionEntrada);
            SqlParameter p3 = new SqlParameter("@MarcacionSalida", this.MarcacionSalida);
            SqlParameter p4 = new SqlParameter("@HorasTrabajadas", this.HorasTrabajadas);
            SqlParameter p5 = new SqlParameter("@FechaMarcacion", this.FechaMarcacion);



            p1.SqlDbType = SqlDbType.Int;
            p2.SqlDbType = SqlDbType.VarChar;
            p3.SqlDbType = SqlDbType.VarChar;
            p4.SqlDbType = SqlDbType.VarChar;
            p5.SqlDbType = SqlDbType.Date;



            cmd.Parameters.Add(p1);
            cmd.Parameters.Add(p2);
            cmd.Parameters.Add(p3);
            cmd.Parameters.Add(p4);
            cmd.Parameters.Add(p5);


            if (id == true)
            {
                cmd = ObtenerParametrosId(cmd);
            }
            return cmd;

        }

        private SqlCommand ObtenerParametrosId(SqlCommand cmd)
        {
            SqlParameter p6 = new SqlParameter("@Id", this.Id);
            p6.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(p6);
            return cmd;
        }

        public static List<Marcacion> ObtenerMarcaciones()
        {
            Marcacion m;
            listaMarcacion.Clear();

            using (SqlConnection con = new SqlConnection(SqlServer.CADENA_CONEXION))

            {
                con.Open();
                string textoCMD = "Select * from Marcacion";

                SqlCommand cmd = new SqlCommand(textoCMD, con);

                SqlDataReader elLectorDeDatos = cmd.ExecuteReader();

                while (elLectorDeDatos.Read())
                {
                    m = new Marcacion();
                    m.Id = elLectorDeDatos.GetInt32(0);
                    m.empleado = Usuari.ObtenerUsuario(elLectorDeDatos.GetInt32(1));
                    m.MarcacionEntrada = elLectorDeDatos.GetString(2);
                    m.MarcacionSalida = elLectorDeDatos.GetString(3);
                    m.HorasTrabajadas = elLectorDeDatos.GetString(4);
                    m.FechaMarcacion = elLectorDeDatos.GetDateTime(5);


                    listaMarcacion.Add(m);


          


                }


                return listaMarcacion;
            }
        }

        public override string ToString()
        {
            return this.empleado.ToString();
        }


        public static void ActualizarMarcacion(int index, Marcacion m)
        {

            using (SqlConnection con = new SqlConnection(SqlServer.CADENA_CONEXION))
            {
                con.Open();
                string textoCMD = "UPDATE Marcacion SET Usuario=@Usuario,  MarcacionEntrada=@MarcacionEntrada, MarcacionSalida=@MarcacionSalida,HorasTrabajadas=@HorasTrabajadas,  FechaMarcacion=@FechaMarcacion where Id = @Id";

                SqlCommand cmd = new SqlCommand(textoCMD, con);
                cmd = m.ObtenerParametros(cmd, true);

                cmd.ExecuteNonQuery();
            }
        }



      

    }
}