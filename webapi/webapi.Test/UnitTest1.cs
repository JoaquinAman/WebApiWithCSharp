using System.Runtime.Intrinsics.X86;
using Microsoft.Win32.SafeHandles;
using webapi.Models;
using webapi.Exceptions;
using webapi.Controllers;
using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using webapi.Service;

namespace webapi.Test;

[TestClass]
public class UnitTest1
{
    DTORequest dTORequest = new DTORequest();

    [TestMethod]
    public void TestMethodEncode()
    {
        IEncodeService encodeService = new EncodeService();
        dTORequest.input = "hello world!";
        string result = encodeService.Encode(dTORequest);
        Assert.AreEqual("aGVsbG8gd29ybGQh", result);
    }
     [TestMethod]
    public void TestMethodEncodeFailsIfEmpty()
    {
        IEncodeService encodeService = new EncodeService();
        IDecodeService decodeService = new DecodeService();
        EncodingController encodingController = new EncodingController(decodeService, encodeService);

        dTORequest.input = "";
        var result = encodingController.PostEncode(dTORequest);

        {
            Assert.AreEqual(typeof(StatusCodeResult), result.GetType());
        }
    }

    [TestMethod]
    public void TestMethodDecode()
    {
        IDecodeService decodeService = new DecodeService();
        dTORequest.input = "aGVsbG8gd29ybGQh";
        string result = decodeService.Decode(dTORequest);
        Assert.AreEqual("hello world!", result);
    }

    //   [TestMethod]
    // public async void TestMethodEncodeFailsIfEmptyIntegrationTest()
    // {
    //     var webAppFactory = new WebApplicationFactory<Program>();
    //     var httpClient = webAppFactory.CreateDefaultClient();
        
    //     string url = "/api/v1/base64/encode";
    //     var httpContent = new StringContent(name);
    //     var response = await httpClient.PostAsync(url, httpContent);

    //     var stringResult = await response.Content.ReadAsStringAsync();
    //     IEncodeService encodeService = new EncodeService();
    //     IDecodeService decodeService = new DecodeService();
    //     EncodingController encodingController = new EncodingController(decodeService, encodeService);

    //     dTORequest.input = "";
    //     var result = encodingController.PostEncode(dTORequest);

    //     {
    //         Assert.AreEqual(typeof(StatusCodeResult), result.GetType());
    //     }
    // }

   
}