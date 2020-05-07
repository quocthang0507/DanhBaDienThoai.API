using System;
using System.Collections.Generic;

namespace DataAccess.Classes
{
	public class DangNhap
	{
		public string username { get; set; }
		public string password { get; set; }

		private const string cacheKey = "dangnhap";

		public DangNhap()
		{

		}

		public DangNhap(string username, string password)
		{
			this.username = username;
			this.password = password;
		}

		public static List<DangNhap> GetAllAccounts()
		{
			List<DangNhap> data = DataCache.GetCache(cacheKey) as List<DangNhap>;
			if (data == null)
			{
				data = CBO.FillCollection<DangNhap>(DataProvider.Instance.ExecuteReader("GetAllAccounts"));
				if (data != null && data.Count > 0)
				{
					data.TrimExcess();
					DataCache.SetCache(cacheKey, data);
				}
			}
			return data;
		}

		public static bool CreateAccount(DangNhap dangNhap)
		{
			bool result = DataProvider.Instance.ExecuteNonQuery("CreateAccount", dangNhap.username, dangNhap.password) > 0;
			if (result)
				DataCache.RemoveCache(cacheKey);
			return result;
		}

		public static bool UpdateAccount(DangNhap dangNhap)
		{
			bool result = DataProvider.Instance.ExecuteNonQuery("UpdateAccount", dangNhap.username, dangNhap.password) > 0;
			if (result)
				DataCache.RemoveCache(cacheKey);
			return result;

		}

		public static bool DeleteAccount(string username)
		{
			bool result = DataProvider.Instance.ExecuteNonQuery("DeleteAccount", username) > 0;
			if (result)
				DataCache.RemoveCache(cacheKey);
			return result;
		}

	}
}
