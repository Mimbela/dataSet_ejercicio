using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace dataSet_ejercicio
{
    class Program
    {
        static void Main(string[] args)
        {
            string cadenaConexion = @"Data Source=DESKTOP-7KN5JV1\SQLEXPRESS;Initial Catalog=NORTHWND;Integrated Security=True";
            string query = "select * from products";

            try
            {
                using (SqlConnection objConexion = new SqlConnection(cadenaConexion)) 
                {
                    objConexion.Open();
                    SqlDataAdapter daProductos = new SqlDataAdapter(query ,objConexion);
                    DataSet ds = new DataSet("datosProductos");
                    daProductos.Fill(ds, "Productos");

                    DataTable tbProducts = ds.Tables["Productos"];
                    Console.WriteLine("Listado de productos");
                    Console.WriteLine();

                    foreach (DataRow fila in tbProducts.Rows)
                    {
                        Console.WriteLine("Código de producto:  {0}" , fila ["ProductID"].ToString());
                        Console.WriteLine("Nombre de producto : {0}" , fila ["ProductName"].ToString());
                        Console.WriteLine();
                    }

                    Console.ReadKey();

                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                Console.ReadKey();
            }
        }
    }
}
/*ejercicio: crea con DATASET  una consulta de los productos*/