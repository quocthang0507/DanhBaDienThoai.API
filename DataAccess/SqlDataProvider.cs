using Microsoft.ApplicationBlocks.Data;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess
{
	public class SqlDataProvider : DataProvider
	{
		private string connectionString;

		public SqlDataProvider(string connectionStringName)
		{
			this.connectionString = ConfigurationManager.ConnectionStrings[connectionStringName].ConnectionString;
		}

		private void AssignParameterValues(SqlParameter[] commandParameters, object[] parameterValues)
		{
			if (commandParameters == null || parameterValues == null) return;
			if (commandParameters.Length != parameterValues.Length)
				throw new ArgumentException("Command parameters do not match parameter values!");
			for (int i = 0, j = commandParameters.Length; i < j; i++)
				commandParameters[i].Value = parameterValues[i];
		}

		public override DataSet ExecuteDataset(string spName, params object[] parameterValues)
		{
			return SqlHelper.ExecuteDataset(connectionString, spName, parameterValues);
		}

		public override int ExecuteNonQuery(string spName, params object[] parameterValues)
		{
			return SqlHelper.ExecuteNonQuery(connectionString, spName, parameterValues);
		}

		public override object ExecuteNonQueryWithOutput(string outputParam, string spName, params object[] parameterValues)
		{
			if (string.IsNullOrEmpty(outputParam))
				throw new ArgumentException("OutputParam can't be null or empty!");
			SqlParameter[] parameters = SqlHelperParameterCache.GetSpParameterSet(connectionString, spName);
			SqlParameter sqlParameter = null;
			foreach (var item in parameters)
			{
				if (string.Compare(item.ParameterName, outputParam, true) == 0)
				{
					sqlParameter = item;
					break;
				}
			}
			if (sqlParameter == null)
				throw new Exception("Parameter not found!");
			AssignParameterValues(parameters, parameterValues);
			int result = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, spName, parameters);
			if (result > 0)
				return sqlParameter.Value;
			return null;
		}

		public override IDataReader ExecuteReader(string spName, params object[] parameterValues)
		{
			return SqlHelper.ExecuteReader(connectionString, spName, parameterValues);
		}

		public override object ExecuteScalar(string spName, params object[] parameterValues)
		{
			return SqlHelper.ExecuteScalar(connectionString, spName, parameterValues);
		}
	}
}
