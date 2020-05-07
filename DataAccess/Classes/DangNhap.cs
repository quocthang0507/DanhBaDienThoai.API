using System;
using System.Collections.Generic;

namespace DataAccess.Classes
{
	public class DangNhap
	{
		public string username { get; set; }
		public string password { get; set; }

		public DangNhap()
		{

		}

		public DangNhap(string username, string password)
		{
			this.username = username;
			this.password = password;
		}

		public static List<DangNhap> GetAllAccounts()
			=> CBO.FillCollection<DangNhap>(DataProvider.Instance.ExecuteReader("GetAllAccounts"));

		public static bool CreateAccount(DangNhap dangNhap)
		{
			return DataProvider.Instance.ExecuteNonQuery("CreateAccount", dangNhap.username, dangNhap.password) > 0;
		}

		public static bool UpdateAccount(DangNhap dangNhap)
		{
			return DataProvider.Instance.ExecuteNonQuery("UpdateAccount", dangNhap.username, dangNhap.password) > 0;
		}

		public static bool DeleteAccount(string username)
		{
			try
			{
				return DataProvider.Instance.ExecuteNonQuery("DeleteAccount", username) > 0;
			}
			catch (Exception)
			{
				return false;
			}
		}

	}
}
