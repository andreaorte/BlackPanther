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
        public string NroDocumento { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public Departamento departamento { get; set; }
        public Cargo cargo { get; set; }
        public TipoUsuario tipoUsuario { get; set; }
        public DateTime FechaIngreso { get; set; }
        public string Usuario { get; set; }
        public string Password { get; set; }
        public string Correo { get; set; }

        public static List<Usuari> listarUsuario = new List<Usuari>();



        public override string ToString()
        {
            return this.Nombre + " " + Apellido;
        }


        public static void AgregarUsuario(Usuari u)
        {
            using (SqlConnection con = new SqlConnection(SqlServer.CADENA_CONEXION))

            {
                con.Open();
                string textoCmd = "INSERT INTO Usuario (NroDocumento, Nombre, Apellido, Departamento, Cargo, tipoUsuario, FechaIngreso, Usuario, Password, Correo)VALUES (@NroDocumento, @Nombre, @Apellido, @Departamento, @Cargo, @tipoUsuario, @FechaIngreso,@Usuario, @Password, @Correo)";
                SqlCommand cmd = new SqlCommand(textoCmd, con);
                cmd = u.ObtenerParametros(cmd);
                cmd.ExecuteNonQuery();
            }
        }

        public static void EliminarUsuario(Usuari u)
        {
            using (SqlConnection con = new SqlConnection(SqlServer.CADENA_CONEXION))

            {
                con.Open();
                string SENTENCIA_SQL = "delete from Usuario where Id = @Id";

                SqlCommand cmd = new SqlCommand(SENTENCIA_SQL, con);
                SqlParameter p1 = new SqlParameter("@Id", u.Id);
                p1.SqlDbType = SqlDbType.Int;
                cmd.Parameters.Add(p1);

                cmd.ExecuteNonQuery();
                con.Close();
            }
        }


        public static void EditarUsuario(int index, Usuari u)
        {

            using (SqlConnection con = new SqlConnection(SqlServer.CADENA_CONEXION))
            {
                con.Open();
                string textoCMD = "UPDATE Usuario SET NroDocumento=@NroDocumento, Nombre =@Nombre, Apellido=@Apellido, Departamento=@Departamento, Cargo=@Cargo,tipoUsuario=@tipoUsuario, FechaIngreso=@FechaIngreso, Usuario=@Usuario, Password=@Password, Correo=@Correo where Id = @Id";

                SqlCommand cmd = new SqlCommand(textoCMD, con);
                cmd = u.ObtenerParametros(cmd, true);

                cmd.ExecuteNonQuery();
            }
        }


        public static List<Usuari> ObtenerUsuarios()
        {
            Usuari u;

            listarUsuario.Clear();

            using (SqlConnection con = new SqlConnection(SqlServer.CADENA_CONEXION))
            {
                con.Open();
                string textoCMD = "select * from Usuario";
                SqlCommand cmd = new SqlCommand(textoCMD, con);

                SqlDataReader elLectorDeDatos = cmd.ExecuteReader();

                while (elLectorDeDatos.Read())
                {
                    u = new Usuari();
                    u.Id = elLectorDeDatos.GetInt32(0);
                    u.NroDocumento = elLectorDeDatos.GetString(1);
                    u.Nombre = elLectorDeDatos.GetString(2);
                    u.Apellido = elLectorDeDatos.GetString(3);
                    u.departamento = Departamento.ObtenerDpto(elLectorDeDatos.GetInt32(4));
                    u.cargo = Cargo.ObtenerCar(elLectorDeDatos.GetInt32(5));
                    u.tipoUsuario = (TipoUsuario)elLectorDeDatos.GetInt32(6);
                    u.FechaIngreso = elLectorDeDatos.GetDateTime(7);
                    u.Usuario = elLectorDeDatos.GetString(8);
                    u.Password = elLectorDeDatos.GetString(9);
                    u.Correo = elLectorDeDatos.GetString(10);




                    listarUsuario.Add(u);

                }
            }

            return listarUsuario;
        }


        private SqlCommand ObtenerParametros(SqlCommand cmd, Boolean id = false)
        {
            SqlParameter p1 = new SqlParameter("@NroDocumento", this.NroDocumento);
            SqlParameter p2 = new SqlParameter("@Nombre", this.Nombre);
            SqlParameter p3 = new SqlParameter("@Apellido", this.Apellido);
            SqlParameter p4 = new SqlParameter("@Departamento", this.departamento.Id);
            SqlParameter p5 = new SqlParameter("@Cargo", this.cargo.idCargo);
            SqlParameter p6 = new SqlParameter("@tipoUsuario", this.tipoUsuario);
            SqlParameter p7 = new SqlParameter("@FechaIngreso", this.FechaIngreso);
            SqlParameter p8 = new SqlParameter("@Usuario", this.Usuario);
            SqlParameter p9 = new SqlParameter("@Password", this.Password);
            SqlParameter p10 = new SqlParameter("@Correo", this.Correo);



            p1.SqlDbType = SqlDbType.VarChar;
            p2.SqlDbType = SqlDbType.VarChar;
            p3.SqlDbType = SqlDbType.VarChar;
            p4.SqlDbType = SqlDbType.Int;
            p5.SqlDbType = SqlDbType.Int;
            p6.SqlDbType = SqlDbType.Int;
            p7.SqlDbType = SqlDbType.DateTime;
            p8.SqlDbType = SqlDbType.VarChar;
            p9.SqlDbType = SqlDbType.VarChar;
            p10.SqlDbType = SqlDbType.VarChar;


            cmd.Parameters.Add(p1);
            cmd.Parameters.Add(p2);
            cmd.Parameters.Add(p3);
            cmd.Parameters.Add(p4);
            cmd.Parameters.Add(p5);
            cmd.Parameters.Add(p6);
            cmd.Parameters.Add(p7);
            cmd.Parameters.Add(p8);
            cmd.Parameters.Add(p9);
            cmd.Parameters.Add(p10);

            if (id == true)
            {
                cmd = ObtenerParametrosId(cmd);
            }
            return cmd;
        }

        private SqlCommand ObtenerParametrosId(SqlCommand cmd)
        {
            SqlParameter p11 = new SqlParameter("@Id", this.Id);
            p11.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(p11);
            return cmd;
        }
    }
}