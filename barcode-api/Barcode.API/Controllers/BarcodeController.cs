using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Barcode.DAL;
using Bogus;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Barcode.API.Controllers;

[ApiController]
[Route("[controller]")]
public class BarcodeController : ControllerBase
{
    private readonly ILogger<BarcodeController> logger;
    private readonly MyContext myContext;

    public BarcodeController(ILogger<BarcodeController> logger, MyContext myContext)
    {
        this.logger = logger;
        this.myContext = myContext;
    }

    //[HttpGet(Name = "GetBarcodes")]
    //public IEnumerable<DAL.Barcode> GetBarcodes()
    //{
    //    throw new NotImplementedException();
    //}

    [HttpPost]
    public async Task<DAL.Barcode> CreateBarcode([FromBody] BarcodeCreateDto barcode)
    {
        var createdBarcode = new DAL.Barcode { Code = barcode.Code, Type = barcode.Type };
        myContext.BarCodes.Add(createdBarcode);
        await myContext.SaveChangesAsync();
        return createdBarcode;
    }

    [HttpGet("fake/{count}")]
    public async Task FakeBarcodes(int count)
    {
        var faker = new Faker<DAL.Barcode>()
                .RuleFor(i => i.Code, b => b.Commerce.Ean13())
                .RuleFor(i => i.Type, "EAN_13")
            ;

        var codes = faker.Generate(count);
        await myContext.BarCodes.AddRangeAsync(codes);
        await myContext.SaveChangesAsync();
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