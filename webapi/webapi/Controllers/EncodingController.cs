using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using webapi.Models;
using webapi.Exceptions;
using webapi.Service;

namespace webapi.Controllers;

[ApiController]
[Route("/api/v1/base64/")]
public class EncodingController : ControllerBase
{
    public EncodingController(IDecodeService decodeService, IEncodeService encodeService){
        this.encodeService = encodeService;
        this.decodeService = decodeService;
    }
    private IEncodeService encodeService = new EncodeService();
    private IDecodeService decodeService = new DecodeService();
    [HttpPost("encode")]
    public ActionResult<DTORequest> PostEncode(DTORequest dTORequest)
    {
        // integration test, el servicio devuelve una excepion, el controller
        // hace un try catch, el integration test evalua que el codigo de error es el correcto
        try
        {
            string myInput = encodeService.Encode(dTORequest);
            DTOResponse dTOResponse = new DTOResponse();
            dTOResponse.input = myInput;

            return Ok(dTOResponse);
        }
        catch (InvalidMsgException)
        {
            return new StatusCodeResult(StatusCodes.Status400BadRequest);
        }
    }
    [HttpPost("decode")]
    public ActionResult PostDecode(DTORequest dTORequest)
    {
        string myInput = decodeService.Decode(dTORequest);
        DTOResponse dTOResponse = new DTOResponse();
        dTOResponse.input = myInput;

        return Ok(dTOResponse);
    }
}
