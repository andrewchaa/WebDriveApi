using System;
using System.Collections.Generic;
using System.Web.Http;
using WebDriveApi.Domain;

namespace WebDriveApi.Controllers
{
    public class MetaDataController : ApiController
    {
        private readonly IMetaDataRepository _repository;

        public MetaDataController(IMetaDataRepository repository)
        {
            _repository = repository;
        }

        // GET api/metadata
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/metadata/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/metadata
        public void Post(Document document)
        {
            _repository.Save(document);
        }

        // PUT api/metadata/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/metadata/5
        public void Delete(int id)
        {
        }
    }
}
