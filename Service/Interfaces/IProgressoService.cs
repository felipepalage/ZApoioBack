using ZApoioBack.Models;

namespace ZApoioBack.Service.Interfaces
{
    public interface IProgressoService
    {
        void Registrar(ProgressoZAcademy progresso);
        List<ProgressoZAcademy> BuscarPorUsuario(string usuario);
    }
}
