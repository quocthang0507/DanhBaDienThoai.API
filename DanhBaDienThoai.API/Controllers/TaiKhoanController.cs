using DanhBaDienThoai.API.Models;
using DataAccess.Classes;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;

namespace DanhBaDienThoai.API.Controllers
{
	[BasicAuthentication]
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
	public class TaiKhoanController : ApiController
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
	{
		/// <summary>
		/// GET api/TaiKhoan
		/// </summary>
		/// <returns>Message from server</returns>
		public HttpResponseMessage Get()
		{
			var user = HttpContext.Current.User;
			return Response($"Hello {user.Identity.Name}", "text/html");
		}

		private HttpResponseMessage Response(string content, string header)
		{
			var response = new HttpResponseMessage(HttpStatusCode.OK)
			{
				Content = new StringContent(content, Encoding.UTF8)
			};
			response.Content.Headers.ContentType = new MediaTypeHeaderValue(header);
			return response;
		}

		/// <summary>
		/// POST api/TaiKhoan<br/>
		/// Creates an login account in server
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
		/// PUT api/TaiKhoan<br/>
		/// Updates an account that exists in server
		/// </summary>
		/// <param name="dangNhap">A json string that is defined as a DangNhap object</param>
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
		/// DELETE api/TaiKhoan<br/>
		/// Deletes an account that exists in server, you only delete your account
		/// </summary>
		/// <param name="name">Username</param>
		/// <returns>Code: 200 or 400 or 404</returns>
		public IHttpActionResult Delete(string name)
		{
			if (!ModelState.IsValid || !HttpContext.Current.User.Identity.Name.Equals(name, StringComparison.OrdinalIgnoreCase))
				return BadRequest("Invalid request");
			if (DangNhap.DeleteAccount(name))
				return Ok();
			return NotFound();
		}
	}
}
