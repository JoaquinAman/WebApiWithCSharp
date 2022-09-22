using System.Text;
using webapi.Models;
using webapi.Exceptions;

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