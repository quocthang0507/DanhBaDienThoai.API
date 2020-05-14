using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace DataAccess.Classes
{
	public class ThongTinLienHe
	{
		public int ID { get; set; }
		public string HoTen { get; set; }
		public string BietDanh { get; set; }
		public DateTime? NgaySinh { get; set; }
		public string SoDienThoai { get; set; }
		public string Email { get; set; }
		public string DiaChi { get; set; }

		private const string cacheKey = "thongtinlienhe";

		public ThongTinLienHe()
		{

		}

		public ThongTinLienHe(int iD, string hoTen, string bietDanh, DateTime? ngaySinh, string soDienThoai, string email, string diaChi)
		{
			ID = iD;
			HoTen = hoTen;
			BietDanh = bietDanh;
			NgaySinh = ngaySinh;
			SoDienThoai = soDienThoai;
			Email = email;
			DiaChi = diaChi;
		}

		public static List<ThongTinLienHe> GetAll()
		{
			List<ThongTinLienHe> data = DataCache.GetCache(cacheKey) as List<ThongTinLienHe>;
			if (data == null)
			{
				data = SortByName(CBO.FillCollection<ThongTinLienHe>(DataProvider.Instance.ExecuteReader("GetAll")));
				if (data != null && data.Count > 0)
				{
					data.TrimExcess();
					DataCache.SetCache(cacheKey, data);
				}
			}
			return data;
		}

		public static ThongTinLienHe GetByID(int id)
		{
			try
			{
				return GetAll().FindLast(t => t.ID == id);
			}
			catch (Exception)
			{
				return null;
			}
		}

		public static List<ThongTinLienHe> GetByName(string name)
		{
			try
			{
				return GetAll().Where(t => t.HoTen.IndexOf(name, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
			}
			catch (Exception)
			{
				return null;
			}
		}

		public static List<ThongTinLienHe> GetByNickname(string nickname)
		{
			try
			{
				return GetAll().Where(t => t.BietDanh.IndexOf(nickname, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
			}
			catch (Exception)
			{
				return null;
			}
		}

		public static bool InsertContact(ThongTinLienHe lienHe)
		{
			bool result = DataProvider.Instance.ExecuteNonQuery("InsertContact", lienHe.HoTen, lienHe.BietDanh, lienHe.NgaySinh, lienHe.SoDienThoai, lienHe.Email, lienHe.DiaChi) > 0;
			if (result)
				DataCache.RemoveCache(cacheKey);
			return result;
		}

		public static bool UpdateContact(ThongTinLienHe lienHe)
		{
			bool result = DataProvider.Instance.ExecuteNonQuery("UpdateContact", lienHe.ID, lienHe.HoTen, lienHe.BietDanh, lienHe.NgaySinh, lienHe.SoDienThoai, lienHe.Email, lienHe.DiaChi) > 0;
			if (result)
				DataCache.RemoveCache(cacheKey);
			return result;
		}

		public static bool DeleteContact(int id)
		{
			bool result = DataProvider.Instance.ExecuteNonQuery("DeleteContact", id) > 0;
			if (result)
				DataCache.RemoveCache(cacheKey);
			return result;
		}

		public static List<ThongTinLienHe> SortByName(List<ThongTinLienHe> lienHe)
		{
			lienHe.Sort(delegate (ThongTinLienHe lienHe1, ThongTinLienHe lienHe2)
			{
				string hoTen1 = lienHe1.HoTen;
				string hoTen2 = lienHe2.HoTen;
				string ten1 = hoTen1.Split(' ').Last();
				string ten2 = hoTen2.Split(' ').Last();
				if (ten1.Equals(ten2, StringComparison.OrdinalIgnoreCase))
					return hoTen1.CompareTo(hoTen2);
				else
					return ten1.CompareTo(ten2);
			});
			return lienHe;
		}

	}
}