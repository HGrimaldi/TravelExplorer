using Domain.Reservas;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories
{
    public class ReservaRepository : IReservaRepository
    {
        private readonly ApplicationDbContext _context;

        public ReservaRepository(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void Add(Reserva reserva) => _context.Reservas.Add(reserva);
        public void Delete(Reserva reserva) => _context.Reservas.Remove(reserva);
        public void Update(Reserva reserva) => _context.Reservas.Update(reserva);
        public async Task<bool> ExistsAsync(Guid id) => await _context.Reservas.AnyAsync(r => r.Id == id);
        public async Task<Reserva?> GetByIdAsync(Guid id) => await _context.Reservas.SingleOrDefaultAsync(r => r.Id == id);
        public async Task<List<Reserva>> GetAll() => await _context.Reservas.ToListAsync();
    }
}
