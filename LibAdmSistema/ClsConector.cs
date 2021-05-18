using System;
using System.Data;
using System.Linq;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections.Specialized;
using System.Data.Sql;

namespace LibAdmSistema
{
	public class ClsConector
	{
		private SqlConnection conexion;
		private LibAdmSistema.ClsUtilidades clsUtiles = new LibAdmSistema.ClsUtilidades();
		//private SqlConnection conexion;

		private void Conectar()
		{
			string bd = "qbz4h7qjqnqSjENx4B27ugzP8WL2RI9VHfd/l56YcLkmIh9Uvox9JOk1DSagQtDL4h4EPWVkA543Pays15jQmJINFUIAe7aRhB8CSIm5+laiVatmvADwWL5dJ6Rx6eYZnZ6GlbhcqWa6vQJjhPxaQQ==";
            //**********************
            conexion = new SqlConnection(clsUtiles.DecryptTripleDES(bd));
			conexion.Open();
		}

		private void Cerrar()
		{
			conexion.Close();
		}

		public DataSet Listar(String strPublicacion, SqlCommand cmd)
		{
			Conectar();
			DataSet dt = new DataSet();
			cmd.Connection = conexion;
			SqlDataAdapter reader = new SqlDataAdapter(cmd);
			reader.Fill(dt);
			Cerrar();
			return dt;
		}

		public void AgregarModificarEliminar(String strPublicacion, SqlCommand cmd)
		{
			Conectar();

			cmd.Connection = conexion;

			cmd.ExecuteNonQuery();


			Cerrar();

		}

	}
}
