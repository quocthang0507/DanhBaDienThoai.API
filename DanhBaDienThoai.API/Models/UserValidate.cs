using DataAccess.Classes;
using System;
using System.Linq;

namespace DanhBaDienThoai.API.Models
{
	public class UserValidate
	{
		public static bool Login(string username, string password)
		{
			var list = Accounts.GetAccounts();
			return list.Any(acc => acc.username.Equals(username, StringComparison.OrdinalIgnoreCase) && acc.password == password);
		}
	}
}