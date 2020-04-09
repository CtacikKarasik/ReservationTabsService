using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Reservation1.Model;
using Reservation1.Service;

namespace Reservation1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReservedController : ControllerBase
    {
        private readonly ILogger<ReservedController> _logger;
        private readonly TableReservation _tableReservation;

        public ReservedController(ILogger<ReservedController> logger, TableReservation tableReservation)
        {
            _logger = logger;
            _tableReservation = tableReservation;
        }

        [HttpGet]
        public ActionResult<IEnumerable<TableInfo>> Get()
        {
            return _tableReservation.GetListInfoTables();
        }

        [HttpGet("{id}")]
        public ActionResult<TableInfo> Get(int id)
        {
            if (_tableReservation.GetInfoTable(id) != null)
            {
                return _tableReservation.GetInfoTable(id);
            }
            return StatusCode(400);
        }

        [HttpPost]
        public ActionResult Post([FromBody]TableInfo tableInfo)
        {
            if (!_tableReservation.AddReservedTable(tableInfo))
            {
                return this.StatusCode((int)HttpStatusCode.Conflict);
            }
            return Ok();
        }
    }
}
