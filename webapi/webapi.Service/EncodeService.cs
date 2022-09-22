using System.Text;
using webapi;
using webapi.Exceptions;

namespace webapi.Service;
public class EncodeService : IEncodeService
{
    public string Encode(DTORequest dTORequest)
    {
        try
        {
            string result = Convert.ToBase64String(Encoding.UTF8.GetBytes(dTORequest.input));
            return result;
        }
        catch (InvalidMsgException)
        {
            throw new InvalidMsgException("Invalid input");
        }
    }
}