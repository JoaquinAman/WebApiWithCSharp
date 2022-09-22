using webapi.Models;
namespace webapi.Service;
public interface IEncodeService
{
    string Encode(DTORequest dTORequest);
}