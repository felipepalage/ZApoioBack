using ZApoioBack.Models;

namespace ZApoioBack.Repository.Interfaces
{
    public interface IProgressoRepository
    {
        void Salvar(ProgressoZAcademy progresso);
        List<ProgressoZAcademy> ListarPorUsuario(string usuario);
    }
}
