using System.Collections.Generic;

namespace DataAccess.Classes
{
	public class Accounts
	{
		public static List<DangNhap> GetAccounts()
		{
			return DangNhap.GetAllAccounts();
		}
	}
}
