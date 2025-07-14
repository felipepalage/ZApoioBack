using ZApoioBack.Models;
using ZApoioBack.Repository.Interfaces;
using ZApoioBack.Service.Interfaces;

namespace ZApoioBack.Service.Implementations
{
    public class ProgressoService : IProgressoService
    {
        private readonly IProgressoRepository _repository;

        public ProgressoService(IProgressoRepository repository)
        {
            _repository = repository;
        }

        public void Registrar(ProgressoZAcademy progresso)
        {
            _repository.Salvar(progresso);
        }

        public List<ProgressoZAcademy> BuscarPorUsuario(string usuario)
        {
            return _repository.ListarPorUsuario(usuario);
        }
    }
}
