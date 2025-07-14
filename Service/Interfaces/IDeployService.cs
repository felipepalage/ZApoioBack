using ZApoioBack.Models;

namespace ZApoioBack.Service.Interfaces
{
    public interface IDeployService
    {
        void RegistrarDeploy(Deploy deploy);
        List<Deploy> ListarDeploys();
    }
}
