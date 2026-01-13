using Microsoft.AspNetCore.Components.Forms;

namespace RealtyWeb_Server.Utils.IService
{
    public interface IFileWork
    {
        Task<string> UploadFile(IBrowserFile file);
        bool DeleteFile(string falePath);
        string RenameFile(string falePath);
        bool CrearTemp();
    }
}
