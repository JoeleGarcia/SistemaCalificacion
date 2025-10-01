using SistemaCalificacion.Application.DTOs;
using SistemaCalificacion.Domain.Entities;


namespace SistemaCalificacion.Application.Interfaces
{
    public interface ISessionManager
    {

        Task SignInAsync(User user);
        Task SignOutAsync();

    }
}
