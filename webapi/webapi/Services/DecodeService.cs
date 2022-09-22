using System.Text;
using webapi.Models;
public class DecodeService : IDecodeService
{
    public string Decode(DTORequest dTORequest)
    {
        string myString = dTORequest.input;
        var result = System.Convert.FromBase64String(myString);
        return System.Text.Encoding.UTF8.GetString(result);
    }
}