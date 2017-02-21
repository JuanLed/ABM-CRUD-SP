using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Entity;

namespace CapaDatos
{
    public class Connection
    {
               
        public void Insert (Empleado empleado)
        {
            using (SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-33PGAQ0\SQLEXPRESS;Initial Catalog=empleados;Integrated Security=True"))
            {
                conn.Open();
                const string sqlSP = "insertEmp";
                SqlCommand cmd = new SqlCommand(sqlSP, conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                //Cargar parametros para Stock Procedure
                cmd.Parameters.AddWithValue("@primerNombre", empleado.primerNombre);
                cmd.Parameters.AddWithValue("@segundoNombre", empleado.segundoNombre);
                cmd.Parameters.AddWithValue("@sueldo", empleado.sueldo);
                cmd.Parameters.AddWithValue("@antiguedad", empleado.antiguedad);
                cmd.Parameters.AddWithValue("@puesto", empleado.puesto);

                cmd.ExecuteNonQuery();              
            }
        }       //Insertar entrada

        public List<Empleado> ShowAll()
        {
            using (SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-33PGAQ0\SQLEXPRESS;Initial Catalog=empleados;Integrated Security=True"))
            {
                conn.Open();
                //Se genera instancia tipo lista de objetos empleado, para guardar resultado del Reader.
                List<Empleado> listaEmpleados = new List<Empleado>();  
                //Se define variable string con nombre de procedimiento guardado en SQL Server. El mismo proceso se repite en los demas metodos con mismo fin. 
                const string sqlSP = "getAllEmp";   
                //Se cargan parametros en variable tipo Command de SQL.
                SqlCommand cmd = new SqlCommand(sqlSP, conn);
                //Luego se indica al objeto SqlCommand que el procedimiento que se ejecuta desde la string provista es un Stored Procedure.
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader rdr = null;

                try
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        Empleado empleado = new Empleado
                        {
                            primerNombre = Convert.ToString(rdr["primerNombre"]),
                            segundoNombre = Convert.ToString(rdr["segundoNombre"]),
                            sueldo = Convert.ToInt32(rdr["sueldo"]),
                            antiguedad = Convert.ToInt32(rdr["antiguedad"]),
                            puesto = Convert.ToString(rdr["puesto"]),
                            id = Convert.ToInt32(rdr["id"])
                        };


                        listaEmpleados.Add(empleado);
                    }

                    //Se devuelve lista de empleados, luego de ser obtenida en ciclo anterior desde el rdr.
                    return listaEmpleados;
                }

                finally
                {
                    if (rdr != null)
                    {
                        rdr.Close();
                    }
                }

              }
            }              //Mostrar toda la tabla

        public Empleado GetByID(int idEmpleado)         //Leer empleado por ID
        {
            using (SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-33PGAQ0\SQLEXPRESS;Initial Catalog=empleados;Integrated Security=True"))
            {
                conn.Open();
                string sqlSP = "returnByID";
                SqlCommand cmd = new SqlCommand(sqlSP, conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                //Se cargan parametros solicitados por procedimiento stock
                cmd.Parameters.AddWithValue("@id", idEmpleado);
                SqlDataReader rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    Empleado empleado = new Empleado
                    {
                        primerNombre = Convert.ToString(rdr["primerNombre"]),
                        segundoNombre = Convert.ToString(rdr["segundoNombre"]),
                        sueldo = Convert.ToInt32(rdr["sueldo"]),
                        antiguedad = Convert.ToInt32(rdr["antiguedad"]),
                        puesto = Convert.ToString(rdr["puesto"]),
                        id = Convert.ToInt32(rdr["id"])
                    };

                    rdr.Close();
                    return empleado;

                }

                return null;
            }
        }

        public void Update(Empleado empleado)
        {
            using (SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-33PGAQ0\SQLEXPRESS;Initial Catalog=empleados;Integrated Security=True"))
            {
                conn.Open();
                string sqlSP = "updateByID";

                SqlCommand cmd = new SqlCommand(sqlSP, conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                //Cargar parametros para Stock Procedure
                cmd.Parameters.AddWithValue("@primerNombre", empleado.primerNombre);
                cmd.Parameters.AddWithValue("@segundoNombre", empleado.segundoNombre);
                cmd.Parameters.AddWithValue("@sueldo", empleado.sueldo);
                cmd.Parameters.AddWithValue("@antiguedad", empleado.antiguedad);
                cmd.Parameters.AddWithValue("@puesto", empleado.puesto);
                cmd.Parameters.AddWithValue("@id", empleado.id);

                cmd.ExecuteNonQuery();

            }
        }        //Actualizar entrada por ID
 
        public void Delete(int idEmpleado)
        {
            using (SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-33PGAQ0\SQLEXPRESS;Initial Catalog=empleados;Integrated Security=True"))
            {
                conn.Open();
                string sqlSP = "deleteByID";

                SqlCommand cmd = new SqlCommand(sqlSP, conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id", idEmpleado);

                cmd.ExecuteNonQuery();                
            }
        }           //Borrar entrada


    }
}
