using DanhBaDienThoai.API.Models;
using DataAccess.Classes;
using System.Web.Http;

namespace DanhBaDienThoai.API.Controllers
{
    [BasicAuthentication]
    public class DanhBaController : ApiController
    {
        /// <summary>
        /// GET api/DanhBa
        /// Gets all contacts in SQL Server
        /// </summary>
        /// <returns>Code: 200</returns>
        [Route("api/DanhBa")]
        public IHttpActionResult Get()
        {
            var list = ThongTinLienHe.GetAll();
            return Ok(list);
        }

        /// <summary>
        /// GET api/DanhBa/id
        /// Gets contact by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Code: 200 or 404</returns>
        [Route("api/DanhBa/{id}")]
        public IHttpActionResult Get(int id)
        {
            var entity = ThongTinLienHe.GetByID(id);
            if (entity == null)
                return NotFound();
            return Ok(entity);
        }

        /// <summary>
        /// GET api/DanhBa/GetByName/name
        /// Gets contacts whose name matches
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/DanhBa/GetByName/{name}")]
        public IHttpActionResult GetByName(string name)
        {
            var entities = ThongTinLienHe.GetByName(name);
            if (entities == null)
                return NotFound();
            return Ok(entities);
        }

        /// <summary>
        /// GET api/DanhBa/GetByNickname/name
        /// Gets contact whose nickname matches
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/DanhBa/GetByNickname/{name}")]
        public IHttpActionResult GetByNickname(string name)
        {
            var entities = ThongTinLienHe.GetByNickname(name);
            if (entities == null)
                return NotFound();
            return Ok(entities);
        }

        /// <summary>
        /// POST api/DanhBa
        /// Inserts a contact to server
        /// </summary>
        /// <param name="lienHe"></param>
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
        /// PUT api/DanhBa
        /// Updates a contact that exists in server
        /// </summary>
        /// <param name="dangNhap"></param>
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
        /// DELETE api/DanhBa/id
        /// Deletes a contact that exists in server
        /// </summary>
        /// <param name="id"></param>
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
