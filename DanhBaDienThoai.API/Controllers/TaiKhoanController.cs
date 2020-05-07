using DanhBaDienThoai.API.Models;
using DataAccess.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http;

namespace DanhBaDienThoai.API.Controllers
{
	[BasicAuthentication]
	public class TaiKhoanController : ApiController
	{
		/// <summary>
		/// GET api/TaiKhoan
		/// </summary>
		/// <returns>Message from server</returns>
		public HttpResponseMessage Get()
		{
			var user = HttpContext.Current.User;
			return Response(new StringContent($"<h2>Xin chào {user.Identity.Name}</h2></br>Tại đây không có gì để bạn dùng."), "text/html");
		}

		private HttpResponseMessage Response(HttpContent content, string header)
		{
			var response = new HttpResponseMessage(HttpStatusCode.OK)
			{
				Content = content
			};
			response.Content.Headers.ContentType = new MediaTypeHeaderValue(header);
			return response;
		}

		/// <summary>
		/// POST api/TaiKhoan
		/// Creates an account in server
		/// </summary>
		/// <param name="dangNhap">Your login info</param>
		/// <returns>Code: 200 or 400</returns>
		public IHttpActionResult Post(DangNhap dangNhap)
		{
			if (!ModelState.IsValid)
				return BadRequest("Invalid request");
			if (DangNhap.CreateAccount(dangNhap))
				return Ok();
			return BadRequest();
		}

		/// <summary>
		/// PUT api/TaiKhoan
		/// Updates an account that exists in server
		/// </summary>
		/// <param name="dangNhap"></param>
		/// <returns>Code: 200 or 400 or 404</returns>
		public IHttpActionResult Put(DangNhap dangNhap)
		{
			if (!ModelState.IsValid)
				return BadRequest("Invalid request");
			if (DangNhap.UpdateAccount(dangNhap))
				return Ok();
			return NotFound();
		}

		/// <summary>
		/// DELETE api/TaiKhoan
		/// Deletes an account that exists in server
		/// </summary>
		/// <param name="username"></param>
		/// <returns>Code: 200 or 400 or 404</returns>
		public IHttpActionResult Delete(string username)
		{
			if (!ModelState.IsValid || !HttpContext.Current.User.Identity.Name.Equals(username, StringComparison.OrdinalIgnoreCase))
				return BadRequest("Invalid request");
			if (DangNhap.DeleteAccount(username))
				return Ok();
			return NotFound();
		}
	}
}
