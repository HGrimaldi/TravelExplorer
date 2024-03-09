using Domain.Customers;
using Domain.Paquetes;
using Domain.Primitives;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Repositories
{
    public class PaqueteRepository : IPaqueteRepository
    {
        private readonly ApplicationDbContext _context;

        public PaqueteRepository(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void Add(Paquete paquete)
        {
            // Agregar la nueva reserva al paquete
            foreach (var reserva in paquete.Reservas)
            {
                reserva.Paquete = paquete;
            }

            _context.Paquetes.Add(paquete);
        }

        public void Delete(Paquete paquete) => _context.Paquetes.Remove(paquete);
        public void Update(Paquete paquete) => _context.Paquetes.Update(paquete);
        public async Task<bool> ExistsAsync(PaqueteId id) => await _context.Paquetes.AnyAsync(p => p.Id == id);
        public async Task<Paquete?> GetByIdAsync(PaqueteId id) => await _context.Paquetes.SingleOrDefaultAsync(p => p.Id == id);
        public async Task<List<Paquete>> GetAll() => await _context.Paquetes.ToListAsync();
    }
}
