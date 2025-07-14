using ZApoioBack.Models;

namespace ZApoioBack.Repository.Interfaces
{
    public interface IDeployRepository
    {
        void Salvar(Deploy deploy);
        List<Deploy> ObterTodos();
    }
}
