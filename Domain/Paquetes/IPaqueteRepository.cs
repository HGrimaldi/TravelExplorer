using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Paquetes
{
    public interface IPaqueteRepository
    {
        Task<List<Paquete>> GetAll();
        Task<Paquete?> GetByIdAsync(PaqueteId id);
        Task<bool> ExistsAsync(PaqueteId id);
        void Add(Paquete paquete);
        void Update(Paquete paquete);
        void Delete(Paquete paquete);
    }
}
