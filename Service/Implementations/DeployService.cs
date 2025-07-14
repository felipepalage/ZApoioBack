using ZApoioBack.Models;
using ZApoioBack.Repository.Interfaces;
using ZApoioBack.Service.Interfaces;

namespace ZApoioBack.Service.Implementations
{
    public class DeployService : IDeployService
    {
        private readonly IDeployRepository _deployRepository;

        public DeployService(IDeployRepository deployRepository)
        {
            _deployRepository = deployRepository;
        }

        public void RegistrarDeploy(Deploy deploy)
        {
            _deployRepository.Salvar(deploy);
        }

        public List<Deploy> ListarDeploys()
        {
            return _deployRepository.ObterTodos();
        }
    }
}
