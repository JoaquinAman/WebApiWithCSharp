using webapi.Models;
namespace webapi.Service;
public interface IDecodeService
{
    string Decode(DTORequest dTORequest);
}