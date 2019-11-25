using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ClasesMarcacion
{
    public enum TipoUsuario
    {
        Empleado,
        Administrador
    }
    public class Usuari
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string NroDocumento { get; set; }
        public string CodigoHumano { get; set; }
        public Departamento departamento   { get; set; }
        public Cargo cargo  { get; set; }
        public DateTime FechaIngreso  { get; set; }
        public TipoUsuario tipoUsuario { get; set; }

        public static List<Usuari> listarUsuario  = new List<Usuari>();

        public Usuari() { }


        public static void AgregarUsuario(Usuari p)
        {
            
            using (SqlConnection con = new SqlConnection(SqlServer.CADENA_CONEXION))

            {
                con.Open(); 
                string textoCmd = "insert into Usuario (Nombre, Apellido, NroDocumento, CodigoHumano, departamento, cargo, FechaIngreso, tipoUsuario) VALUES (@Nombre, @Apellido, @NroDocumneto, @CodigoHumano, @departamento, @cargo, @FechaIngreso, @tipoUsuario)";
                SqlCommand cmd = new SqlCommand(textoCmd, con);

                SqlParameter p1 = new SqlParameter("@Nombre", p.Nombre);
                SqlParameter p2 = new SqlParameter("@Apellido", p.Apellido);
                SqlParameter p3 = new SqlParameter("@NroDocumneto", p.NroDocumento);
                SqlParameter p4 = new SqlParameter("@CodigoHumano", p.CodigoHumano);
                SqlParameter p5 = new SqlParameter("@departamento", p.departamento);
                SqlParameter p6 = new SqlParameter("@cargo", p.cargo);
                SqlParameter p7 = new SqlParameter("@FechaIngreso", p.FechaIngreso);
                SqlParameter p8 = new SqlParameter("@tipoUsuario", p.tipoUsuario);

                
                p1.SqlDbType = SqlDbType.VarChar;
                p2.SqlDbType = SqlDbType.VarChar;
                p3.SqlDbType = SqlDbType.VarChar;
                p4.SqlDbType = SqlDbType.VarChar;
                p5.SqlDbType = SqlDbType.Int;
                p6.SqlDbType = SqlDbType.Int;
                p7.SqlDbType = SqlDbType.DateTime;
                p8.SqlDbType = SqlDbType.Int;
                

                cmd.Parameters.Add(p1);
                cmd.Parameters.Add(p2);
                cmd.Parameters.Add(p3);
                cmd.Parameters.Add(p4);
                cmd.Parameters.Add(p5);
                cmd.Parameters.Add(p6);
                cmd.Parameters.Add(p7);
                cmd.Parameters.Add(p8);

                cmd.ExecuteNonQuery();

            }



        }
        public static void EditarUsuario(int index, Usuari p)
        {
            
            using (SqlConnection con = new SqlConnection(SqlServer.CADENA_CONEXION))
            {
                con.Open();
                string textoCMD = "UPDATE Usuario SET Nombre = @Nombre, Apellido = @Apellido, NroDocumento = @NroDocumneto, Departamento = @departamento, Cargo = @cargo, FechaIngreso = @FechaIngreso, tipoUsuario = @tipoUsuario where Id = @Id";

                SqlCommand cmd = new SqlCommand(textoCMD, con);

                SqlParameter p1 = new SqlParameter("@Nombre", p.Nombre);
                SqlParameter p2 = new SqlParameter("@Apellido", p.Apellido);
                SqlParameter p3 = new SqlParameter("@NroDocumneto", p.NroDocumento);
               
                SqlParameter p4 = new SqlParameter("@departamento", p.departamento);
                SqlParameter p5 = new SqlParameter("@cargo", p.cargo);
                SqlParameter p6 = new SqlParameter("@FechaIngreso", p.FechaIngreso);
                SqlParameter p7 = new SqlParameter("@tipoUsuario", p.tipoUsuario);
                SqlParameter p8 = new SqlParameter("@Id", p.Id);

                p1.SqlDbType = SqlDbType.VarChar;
                p2.SqlDbType = SqlDbType.VarChar;
                p3.SqlDbType = SqlDbType.VarChar;
               
                p4.SqlDbType = SqlDbType.Int;
                p5.SqlDbType = SqlDbType.Int;
                p6.SqlDbType = SqlDbType.DateTime;
                p7.SqlDbType = SqlDbType.Int;
                p8.SqlDbType = SqlDbType.Int;



                cmd.Parameters.Add(p1);
                cmd.Parameters.Add(p2);
                cmd.Parameters.Add(p3);
                cmd.Parameters.Add(p4);
                cmd.Parameters.Add(p5);
                cmd.Parameters.Add(p6);
                cmd.Parameters.Add(p7);
                cmd.Parameters.Add(p8);
             

                cmd.ExecuteNonQuery();
            }
        }


        public static void EliminarUsuario(Usuari p)
        {
           
            using (SqlConnection con = new SqlConnection(SqlServer.CADENA_CONEXION))

            {
                con.Open();
                string SENTENCIA_SQL = "delete from Usuario where Id = @Id";

                SqlCommand cmd = new SqlCommand(SENTENCIA_SQL, con);
                SqlParameter p9 = new SqlParameter("@Id", p.Id);
                p9.SqlDbType = SqlDbType.Int;
                cmd.Parameters.Add(p9);

                cmd.ExecuteNonQuery();
            }
        }

        public static List<Usuari> ObtenerUsuario()
        {


            Usuari usuario;
            listarUsuario.Clear();
            using (SqlConnection con = new SqlConnection(SqlServer.CADENA_CONEXION))

            {
                con.Open();
                string textoCMD = "Select * from Usuario";

                SqlCommand cmd = new SqlCommand(textoCMD, con);

                SqlDataReader elLectorDeDatos = cmd.ExecuteReader();

               

                while (elLectorDeDatos.Read())
                {
                    usuario = new Usuari();
                    usuario.Id = elLectorDeDatos.GetInt32(0);
                    usuario.Nombre = elLectorDeDatos.GetString(1);
                    usuario.Apellido = elLectorDeDatos.GetString(2);
                    usuario.NroDocumento = elLectorDeDatos.GetString(3);
                    usuario.departamento = Departamento.ObtenerDpto(elLectorDeDatos.GetInt32(4));
                    usuario.cargo = Cargo.ObtenerCar(elLectorDeDatos.GetInt32(5));
                    usuario.FechaIngreso = elLectorDeDatos.GetDateTime(6);
                    usuario.tipoUsuario = (TipoUsuario)elLectorDeDatos.GetInt32(7);

                    listarUsuario.Add(usuario);
                }

                return listarUsuario;

            }

        }

        public override string ToString()
        {
            return this.Nombre + " " + Apellido;
        }
    }
}
