using DataAccess.Classes;
using System;
using System.Linq;

namespace DanhBaDienThoai.API.Models
{
	public class UserValidate
	{
		public static bool Login(string username, string password)
		{
			Accounts accounts = new Accounts();
			var list = accounts.GetAccounts();
			return list.Any(acc => acc.username.Equals(username, StringComparison.OrdinalIgnoreCase) && acc.password == password)
		}
	}
}