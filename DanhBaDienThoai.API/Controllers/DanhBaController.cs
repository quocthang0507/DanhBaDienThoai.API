using DanhBaDienThoai.API.Models;
using DataAccess.Classes;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace DanhBaDienThoai.API.Controllers
{
	[BasicAuthentication]
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
	public class DanhBaController : ApiController
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
	{
		/// <summary>
		/// GET api/DanhBa<br/>
		/// Gets all contacts in SQL Server
		/// </summary>
		/// <returns>Code: 200</returns>
		[Route("api/DanhBa")]
		[ResponseType(typeof(List<ThongTinLienHe>))]
		public IHttpActionResult Get()
		{
			var list = ThongTinLienHe.GetAll();
			return Ok(list);
		}

		/// <summary>
		/// GET api/DanhBa/{id}<br/>
		/// Finds a contact by id
		/// </summary>
		/// <param name="id">ID</param>
		/// <returns>Code: 200 or 404</returns>
		[Route("api/DanhBa/{id}")]
		[ResponseType(typeof(ThongTinLienHe))]
		public IHttpActionResult Get(int id)
		{
			var entity = ThongTinLienHe.GetByID(id);
			if (entity == null)
				return NotFound();
			return Ok(entity);
		}

		/// <summary>
		/// GET api/DanhBa/GetByName/{name}<br/>
		/// Finds all contacts whose name matches
		/// </summary>
		/// <param name="name">The string is a part of name</param>
		/// <returns>List of matched contacts</returns>
		[HttpGet]
		[Route("api/DanhBa/GetByName/{name}")]
		[ResponseType(typeof(List<ThongTinLienHe>))]
		public IHttpActionResult GetByName(string name)
		{
			var entities = ThongTinLienHe.GetByName(name);
			if (entities == null)
				return NotFound();
			return Ok(entities);
		}

		/// <summary>
		/// GET api/DanhBa/GetByNickname/{name}<br/>
		/// Gets contact whose nickname matches
		/// </summary>
		/// <param name="name">The string is a part of nickname</param>
		/// <returns>List of matched contacts</returns>
		[HttpGet]
		[Route("api/DanhBa/GetByNickname/{name}")]
		[ResponseType(typeof(List<ThongTinLienHe>))]
		public IHttpActionResult GetByNickname(string name)
		{
			var entities = ThongTinLienHe.GetByNickname(name);
			if (entities == null)
				return NotFound();
			return Ok(entities);
		}

		/// <summary>
		/// POST api/DanhBa<br/>
		/// Inserts a contact to server
		/// </summary>
		/// <param name="lienHe">A json string that is defined as a ThongTinLienHe object</param>
		/// <returns>Code: 400 or 200</returns>
		[Route("api/DanhBa")]
		public IHttpActionResult Post(ThongTinLienHe lienHe)
		{
			if (!ModelState.IsValid)
				return BadRequest("Invalid request");
			if (ThongTinLienHe.InsertContact(lienHe))
				return Ok();
			return BadRequest();
		}

		/// <summary>
		/// PUT api/DanhBa<br/>
		/// Updates a contact that exists in server
		/// </summary>
		/// <param name="lienHe">A json string that is defined as a ThongTinLienHe object</param>
		/// <returns>Code: 200 or 400 or 404</returns>
		[Route("api/DanhBa")]
		public IHttpActionResult Put(ThongTinLienHe lienHe)
		{
			if (!ModelState.IsValid)
				return BadRequest("Invalid request");
			if (ThongTinLienHe.UpdateContact(lienHe))
				return Ok();
			return NotFound();
		}

		/// <summary>
		/// DELETE api/DanhBa/{id}
		/// Deletes a contact that exists in server
		/// </summary>
		/// <param name="id">ID</param>
		/// <returns>Code: 200 or 400 or 404</returns>
		[Route("api/DanhBa/{id}")]
		public IHttpActionResult Delete(int id)
		{
			if (!ModelState.IsValid)
				return BadRequest("Invalid request");
			if (ThongTinLienHe.DeleteContact(id))
				return Ok();
			return NotFound();
		}
	}
}
