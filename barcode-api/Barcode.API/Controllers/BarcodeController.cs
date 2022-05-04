using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Barcode.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Barcode.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BarcodeController : ControllerBase
    {
        private readonly ILogger<BarcodeController> logger;

        public BarcodeController(ILogger<BarcodeController> logger)
        {
            this.logger = logger;
        }

        [HttpGet(Name = "GetBarcodes")]
        public IEnumerable<DAL.Barcode> GetBarcodes()
        {

            throw new NotImplementedException();
        }

        [HttpPost]
        public Task<DAL.Barcode> CreateBarcode([FromBody] BarcodeCreateDto barcode)
        {

            throw new NotImplementedException();
        }


        public class BarcodeCreateDto
        {
            public string Code { get; set; }
            public string Type { get; set; }
        }

        public class BarcodeListDto
        {
            public Guid Id { get; set; }
            public string Code { get; set; }
            public string Type { get; set; }
        }
    }
}
