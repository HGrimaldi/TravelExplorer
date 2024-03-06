using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Reservas
{
    public interface IReservaRepository
    {
        Task<List<Reserva>> GetAll();
        Task<Reserva?> GetByIdAsync(ReservaId id);
        Task<bool> ExistsAsync(ReservaId id);
        void Add(Reserva reserva);
        void Update(Reserva reserva);
        void Delete(Reserva reserva);
    }
}
