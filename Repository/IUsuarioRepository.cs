using usuario.Model;

namespace usuario.Repository
{
    public interface IUsuarioRepository
    {
        Task<IEnumerable<Usuario>> BuscaUsuario();
        Task<Usuario> BuscaUsuario(int id);
        void AdicionaUsuario(Usuario usuario);
        void AtualizarUsuario(Usuario usuario);
        void DeletaUsuario(Usuario usuario);

        Task<bool> SaveChangeAsync();

    }
}