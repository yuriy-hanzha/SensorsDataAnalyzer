using SensorsDataAnalyzer.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SensorsDataAnalyzer.Controllers
{
    [RoutePrefix("analyzer")]
    public class AnalysisController : ApiController
    {
        IGenericRepository<SensorsDataRecord> _repository;
        public AnalysisController()
        {
            _repository = new GenericRepository<SensorsDataRecord>();
        }

        [HttpPost]
        [Route("set")]
        public IHttpActionResult SetData(IEnumerable<SensorsDataRecord> data)
        {
            data.ToList().ForEach(record => _repository.Add(record));
            _repository.SaveChanges();

            return Ok();
        }
    }
}