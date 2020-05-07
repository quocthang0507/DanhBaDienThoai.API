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
        /// <returns></returns>
        public IHttpActionResult Get()
        {
            var list = ThongTinLienHe.GetAll();
            return Ok(list);
        }
    }
}
