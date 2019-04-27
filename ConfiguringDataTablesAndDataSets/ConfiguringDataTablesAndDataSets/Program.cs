using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
namespace ConfiguringDataTablesAndDataSets
{
    class Program
    {
        static void Main(string[] args)
        {
            /* //CREANDO DataTable
             DataTable dt = new DataTable("Mi Tabla");

             //Creamos la 1ra columna
             DataColumn columna1 = dt.Columns.Add();
             columna1.ColumnName = "Primera";
             columna1.DataType = typeof(int);
             columna1.DefaultValue = 0;
             columna1.Unique = true;
             columna1.AllowDBNull = false;

             //Agregamos la 2da columna
             DataColumn columna2 = new DataColumn();
             columna2.ColumnName = "Sgunda";
             columna2.DataType = typeof(string);
             columna2.MaxLength = 25;
             dt.Columns.Add(columna2);

             //Agregamos la 3ra columna
             dt.Columns.Add("Tercera", typeof(string)).MaxLength = 40;

             //Creamos la 4ta y 5ta columna y las agregamos juntas
             DataColumn columna4 = new DataColumn("Cuarta");
             columna4.DataType = typeof(int);
             DataColumn columna5 = new DataColumn("Quinta", typeof(decimal));
             dt.Columns.AddRange(new DataColumn[] { columna4, columna5});

             //Mostramos nuestras columnas en el DataTable
             Console.WriteLine("El DataTable {0} tiene {1} columnas: ", dt.TableName, dt.Columns.Count);
             Console.WriteLine();
             foreach(DataColumn col in dt.Columns)
             {
                 Console.WriteLine("\t\t\t{0}", col.ColumnName);
             }
             Console.ReadKey();
             */


            /*//CREANDO UN OBJETO DataSet
            DataSet ds = new DataSet("Mi DataSet");
            DataTable tabla1 = ds.Tables.Add("Tabla_1");

            //Creamos la tabla 2 y la agregamos
            DataTable tabla2 = new DataTable("Tabla_2");
            ds.Tables.Add(tabla2);

            //Creamos tabla 3 y 4 y las agregamos
            DataTable tabla3 = new DataTable("Tabla_3");
            DataTable tabla4 = new DataTable("Tabla_4");
            ds.Tables.AddRange(new DataTable[] {tabla3, tabla4 });

            Console.WriteLine("El DataSet {0} tiene los siguientes {1} DataTables", ds.DataSetName, ds.Tables.Count);
            foreach(DataTable dt in ds.Tables)
            {
                Console.WriteLine("\t\t\t{0}",dt.TableName);
            }
            Console.ReadKey();
            **/


            
            // Cadena de conexion
            string sqlConn = "Data Source=localhost;" + "Integrated security=SSPI;Initial Catalog=MLC_NOM;";

            // Consulta Select
            string sqlSelect = "SELECT TOP 5 nombre, paterno, materno " + "FROM trabajador";

            // Se carga la conexion y la consulta al SqlDataAdapter
            SqlDataAdapter da = new SqlDataAdapter(sqlSelect, sqlConn);

            // Se crea el DataTableMapping y se instancia al SqlDataAdapter, estamos trayendo la tabla "trabajador"
            DataTableMapping dtm = da.TableMappings.Add("Table", "TRABAJADOR");

            // Creamos las columnas del mappings
            dtm.ColumnMappings.Add("Nombre", "nombre");
            dtm.ColumnMappings.Add("Apellidos Paterno", "paterno");
            dtm.ColumnMappings.Add("Apellido Mateno", "materno");

            // Create and fill the DataSet
            DataSet ds = new DataSet();
            da.Fill(ds);

            Console.WriteLine("Nombre del DataTable:{0}", ds.Tables[0].TableName);

            foreach (DataColumn col in ds.Tables["TRABAJADOR"].Columns)
            {
                Console.WriteLine("\tNombre del DataColumn {0} = {1}",
                    col.Ordinal, col.ColumnName);
            }

            foreach (DataRow row in ds.Tables["TRABAJADOR"].Rows)
            {
                Console.WriteLine("Nombre = {0}, Paterno = {1}, Materno = {2}",
                row["nombre"], row["paterno"], row["materno"]);
            }

            Console.WriteLine("\nPress any key to continue.");
            Console.ReadKey();



        }
    }
}
