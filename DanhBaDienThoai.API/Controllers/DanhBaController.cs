using DanhBaDienThoai.API.Models;
using DataAccess.Classes;
using System.Net.Http;
using System.Web.Http;

namespace DanhBaDienThoai.API.Controllers
{
    [BasicAuthentication]
    public class DanhBaController : ApiController
    {
        /// <summary>
        /// GET api/DanhBa
        /// Get all contacts in SQL Server
        /// </summary>
        /// <returns>Code: 200</returns>
        public IHttpActionResult Get()
        {
            var list = ThongTinLienHe.GetAll();
            return Ok(list);
        }

        /// <summary>
        /// GET api/DanhBa/id
        /// Get contact by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Code: 200 or 404</returns>
        public IHttpActionResult Get(int id)
        {
            var entity = ThongTinLienHe.GetByID(id);
            if (entity == null)
                return NotFound();
            return Ok(entity);
        }

        public IHttpActionResult GetByName(string name)
        {
            var entities = ThongTinLienHe.GetByName(name);
            if (entities == null)
                return NotFound();
            return Ok(entities);
        }
    }
}
