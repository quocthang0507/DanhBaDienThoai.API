using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
