using System;
using ClasesMarcacion;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasesMarcacion
{
    public class Cargo
    {
        public int idCargo { get; set; }
        public String descripcion { get; set; }

        public static List<Cargo> listaCargo = new List<Cargo>();
        public Cargo() { }
        public Cargo(int idCargo, String decripcion)
        {
            this.idCargo = idCargo;
            this.descripcion = descripcion;

        }
        public override string ToString()
        {
            return descripcion;
        }
        public static List<Cargo> listaCargos = new List<Cargo>();

        public static List<Cargo> ObtenerCargos()
        {


            Cargo cargo;
            listaCargos.Clear();
            using (SqlConnection con = new SqlConnection(SqlServer.CADENA_CONEXION))

            {
                con.Open();
                string textoCMD = "Select * from Cargo";

                SqlCommand cmd = new SqlCommand(textoCMD, con);

                SqlDataReader elLectorDeDatos = cmd.ExecuteReader();

                while (elLectorDeDatos.Read())
                {
                    cargo = new Cargo();
                    cargo.idCargo = elLectorDeDatos.GetInt32(0);
                    cargo.descripcion = elLectorDeDatos.GetString(1);


                    listaCargos.Add(cargo);
                }

                return listaCargos;

            }

        }


        public static void AgregarCargo(Cargo c)
        {
            //listaProveedores.Add(p);
            using (SqlConnection con = new SqlConnection(SqlServer.CADENA_CONEXION))

            {
                con.Open(); //Abrimos la conex con la BD
                string textoCmd = "insert into Cargo (Descripcion) VALUES (@Descripcion)";
                SqlCommand cmd = new SqlCommand(textoCmd, con);

                //PARAMETROS
                SqlParameter p1 = new SqlParameter("@Descripcion", c.descripcion);


                //Le decimos a los parametros de que tipo de datos son
                p1.SqlDbType = SqlDbType.VarChar;


                //Agragamos los parametros al command
                cmd.Parameters.Add(p1);


                cmd.ExecuteNonQuery();

            }

        }

        public static void EliminarCargo(Cargo c)
        {
            //listaProveedores.Remove(p);
            //listaProveedores.Add(p);
            using (SqlConnection con = new SqlConnection(SqlServer.CADENA_CONEXION))

            {
                con.Open();
                string SENTENCIA_SQL = "delete from Cargo where Id = @Id";

                SqlCommand cmd = new SqlCommand(SENTENCIA_SQL, con);
                SqlParameter p2 = new SqlParameter("@Id", c.idCargo);
                p2.SqlDbType = SqlDbType.Int;
                cmd.Parameters.Add(p2);

                cmd.ExecuteNonQuery();
            }
        }

        public static void EditarCargo(Cargo c, int indice)
        {
            //listaProveedores[index] = p;
            using (SqlConnection con = new SqlConnection(SqlServer.CADENA_CONEXION))
            {
                con.Open();
                string textoCMD = "UPDATE Cargo SET Descripcion = @Descripcion where Id = @Id";

                SqlCommand cmd = new SqlCommand(textoCMD, con);

                //DEFINICION DE PARAMETROS
                SqlParameter p1 = new SqlParameter("@Descripcion", c.descripcion);
                SqlParameter p2 = new SqlParameter("@Id", c.idCargo);


                //Le decimos a los parametros de que tipo de datos son
                p1.SqlDbType = SqlDbType.VarChar;
                p2.SqlDbType = SqlDbType.Int;

                cmd.Parameters.Add(p1);
                cmd.Parameters.Add(p2);


                cmd.ExecuteNonQuery();
            }
        }
        public static List<Cargo> ObtenerCargo()
        {


            Cargo cargo;
            listaCargo.Clear();

            using (SqlConnection con = new SqlConnection(SqlServer.CADENA_CONEXION))

            {
                con.Open();
                string textoCMD = "Select * from Cargo";

                SqlCommand cmd = new SqlCommand(textoCMD, con);

                SqlDataReader elLectorDeDatos = cmd.ExecuteReader();

                while (elLectorDeDatos.Read())
                {
                    cargo = new Cargo();
                    cargo.idCargo = elLectorDeDatos.GetInt32(0);
                    cargo.descripcion = elLectorDeDatos.GetString(1);
                  
                    listaCargo.Add(cargo);
                }

                return listaCargo;

            }

        }
        public static Cargo ObtenerCar(int id)
        {
            Cargo cargo = null;

            if (listaCargo.Count == 0)
            {
                Cargo.ObtenerCargo();
            }

            foreach (Cargo p in listaCargo)
            {
                if (p.idCargo == id)
                {
                    cargo = p;
                    break;
                }
            }

            return cargo;
        }
    }
}
