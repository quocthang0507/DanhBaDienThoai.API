using System;
using System.Collections.Generic;

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
			=> CBO.FillCollection<ThongTinLienHe>(DataProvider.Instance.ExecuteReader("GetAll"));

		public static ThongTinLienHe GetByID(int id)
		{
			try
			{
				return CBO.FillObject<ThongTinLienHe>(DataProvider.Instance.ExecuteReader("GetByID", id));
			}
			catch (Exception)
			{
				return null;
			}
		}

		public static ThongTinLienHe GetByName(string name)
		{
			try
			{
				return CBO.FillObject<ThongTinLienHe>(DataProvider.Instance.ExecuteReader("GetByName", name));
			}
			catch (Exception)
			{
				return null;
			}
		}

		public static ThongTinLienHe GetByNickname(string nickname)
		{
			try
			{
				return CBO.FillObject<ThongTinLienHe>(DataProvider.Instance.ExecuteReader("GetByNickname", nickname));
			}
			catch (Exception)
			{
				return null;
			}
		}

		public static bool InsertContact(ThongTinLienHe lienHe)
		{
			return DataProvider.Instance.ExecuteNonQuery("InsertContact", lienHe.HoTen, lienHe.BietDanh, lienHe.NgaySinh, lienHe.SoDienThoai, lienHe.Email, lienHe.DiaChi) > 0;
		}

		public static bool UpdateContact(ThongTinLienHe lienHe)
		{
			return DataProvider.Instance.ExecuteNonQuery("UpdateContact", lienHe.ID, lienHe.HoTen, lienHe.BietDanh, lienHe.NgaySinh, lienHe.SoDienThoai, lienHe.Email, lienHe.DiaChi) > 0;
		}

		public static bool DeleteContact(int id)
		{
			try
			{
				return DataProvider.Instance.ExecuteNonQuery("DeleteContact", id) > 0;
			}
			catch (Exception)
			{
				return false;
			}
		}
	}
}