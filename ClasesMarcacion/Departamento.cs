using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasesMarcacion
{
    public class Departamento
    {
        public int Id { get; set; }
        public String descripcion { get; set; }

        public static List<Departamento> listaDepartamento = new List<Departamento>();
   
     

        public override string ToString()
        {
            return descripcion;
        }
        public static List<Departamento> listaDepartamentos = new List<Departamento>();

        public static List<Departamento> ObtenerDepartamentos()
        {
            return listaDepartamentos;
        }

        public static void AgregarDepartamento(Departamento d)
        {
            //listaProveedores.Add(p);
            using (SqlConnection con = new SqlConnection(SqlServer.CADENA_CONEXION))

            {
                con.Open(); //Abrimos la conex con la BD
                string textoCmd = "insert into Departamento (Descripcion) VALUES (@Descripcion)";
                SqlCommand cmd = new SqlCommand(textoCmd, con);

                //PARAMETROS
                SqlParameter p1 = new SqlParameter("@Descripcion", d.descripcion);


                //Le decimos a los parametros de que tipo de datos son
                p1.SqlDbType = SqlDbType.VarChar;


                //Agragamos los parametros al command
                cmd.Parameters.Add(p1);
                cmd.ExecuteNonQuery();

            }

        }

        public static void EliminarDepartamento(Departamento d)
        {

            using (SqlConnection con = new SqlConnection(SqlServer.CADENA_CONEXION))

            {
                con.Open();
                string SENTENCIA_SQL = "delete from Departamento where Id = @Id";

                SqlCommand cmd = new SqlCommand(SENTENCIA_SQL, con);
                SqlParameter p2 = new SqlParameter("@Id", d.Id);
                p2.SqlDbType = SqlDbType.Int;
                cmd.Parameters.Add(p2);

                cmd.ExecuteNonQuery();
            }
        }

        public static void EditarDepartamento(Departamento d, int indice)
        {
            //listaProveedores[index] = p;
            using (SqlConnection con = new SqlConnection(SqlServer.CADENA_CONEXION))
            {
                con.Open();
                string textoCMD = "UPDATE Departamento SET Descripcion = @Descripcion where Id = @Id";

                SqlCommand cmd = new SqlCommand(textoCMD, con);

                //DEFINICION DE PARAMETROS
                SqlParameter p1 = new SqlParameter("@Descripcion", d.descripcion);
                SqlParameter p2 = new SqlParameter("@Id", d.Id);


                //Le decimos a los parametros de que tipo de datos son
                p1.SqlDbType = SqlDbType.VarChar;
                p2.SqlDbType = SqlDbType.Int;

                cmd.Parameters.Add(p1);
                cmd.Parameters.Add(p2);


                cmd.ExecuteNonQuery();
            }
        }

        public static List<Departamento> ObtenerDepartamento()
        {

            Departamento departamento;
            listaDepartamento.Clear();

            using (SqlConnection con = new SqlConnection(SqlServer.CADENA_CONEXION))

            {
                con.Open();
                string textoCMD = "Select * from Departamento";

                SqlCommand cmd = new SqlCommand(textoCMD, con);

                SqlDataReader elLectorDeDatos = cmd.ExecuteReader();

                while (elLectorDeDatos.Read())
                {
                    departamento = new Departamento();
                    departamento.Id = elLectorDeDatos.GetInt32(0);
                    departamento.descripcion = elLectorDeDatos.GetString(1);

                    listaDepartamento.Add(departamento);
                }


                return listaDepartamento;
            }
        }

        public static Departamento ObtenerDpto(int id)
        {
            Departamento departamento = null;

            if (listaDepartamento.Count == 0)
            {
                Departamento.ObtenerDepartamento();
            }

            foreach (Departamento p in listaDepartamento)
            {
                if (p.Id == id)
                {
                    departamento = p;
                    break;
                }
            }

            return departamento;
        }
    }
}
