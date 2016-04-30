using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;


namespace practicaFinal
{
    class Conexion
    {

        string cadena = variablesGlobales.cadena;
        int i = 0;      


        public DataSet regresaTabla(string SP, string[] nombreParametros, string[] Parametros)
        {
            SqlConnection connection;
            SqlDataAdapter adapter;
            SqlCommand command = new SqlCommand();
            SqlParameter param;
            DataSet ds = new DataSet();
            connection = new SqlConnection(cadena);

            connection.Open();
            command.Connection = connection;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = SP;
            while (i < nombreParametros.Length)
            {
                if (nombreParametros[i] != null)
                {
                    param = new SqlParameter(nombreParametros[i], Parametros[i]);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    command.Parameters.Add(param);
                }
                i++;
            }

            adapter = new SqlDataAdapter(command);
            adapter.Fill(ds);
            connection.Close();
            i = 0;
            return ds;
        }

        public DataSet regresaTabla(string consulta)
        {
            SqlConnection conectar = new SqlConnection(cadena);
            SqlCommand comando = new SqlCommand(consulta, conectar);
            SqlDataAdapter da = new SqlDataAdapter(comando);
            DataSet ds = new DataSet();
            conectar.Open();
            comando.ExecuteNonQuery();
            da.Fill(ds, "Tabla");
            conectar.Close();
            return ds;
        }

        public bool ejecutaSP(string SP, string[] nombreParametros, string[] Parametros, int tipo)
        {
            i = 0;
            variablesGlobales.ds = null;
            try
            {
                //SqlConnection connection;
                SqlConnection connection = new SqlConnection(cadena);
                SqlCommand command = new SqlCommand();
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                SqlParameter param;
                DataSet ds = new DataSet();


                connection.Open();
                command.Connection = connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = SP;
                while (i != nombreParametros.Length)
                {
                    if (nombreParametros[i] != null)
                    {
                        param = new SqlParameter(nombreParametros[i], Parametros[i]);
                        param.Direction = ParameterDirection.Input;
                        param.DbType = DbType.String;
                        command.Parameters.Add(param);
                    }
                    i++;
                }

                if (tipo == 1)
                {
                    adapter.Fill(ds, "Tabla");
                    variablesGlobales.ds = ds;
                }
                else
                {
                    command.ExecuteNonQuery();
                }
                connection.Close();

                return true;
            }
            catch (Exception e)
            {
                variablesGlobales.mensajeErrorSQL = e.Message;
                return false;
            }
        }      

        public bool consulta(string consulta)
        {
            SqlConnection conectar = new SqlConnection(cadena);
            SqlCommand comando = new SqlCommand(consulta, conectar);
            SqlDataAdapter da = new SqlDataAdapter(comando);
            DataSet ds = new DataSet();
            conectar.Open();
            try
            {
                comando.ExecuteNonQuery();
                conectar.Close();

                return true;
            }
            catch(Exception e)
            {
                conectar.Close();
                variablesGlobales.mensajeErrorSQL = e.Message;

                return false;
            }
           // da.Fill(ds, "Tabla");
          
        }
        public string obtenerValorUnico(string consulta, int pocision)
        {
            string valor = "";
            SqlConnection conectar = new SqlConnection(cadena);
            SqlCommand comando  = new SqlCommand(consulta, conectar);
            SqlDataAdapter da = new SqlDataAdapter(comando);
           
            conectar.Open();

             SqlDataReader sqlDR = comando.ExecuteReader();
             while (sqlDR.Read())
            {
                try
                {
                    valor = sqlDR.GetString(pocision);
                }
                catch
                {
                    valor = sqlDR.GetSqlInt32(pocision).ToString();
                }
            }

             conectar.Close();
            return valor;

        }


    }
}
