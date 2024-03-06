using Domain.Destinos;
using Microsoft.EntityFrameworkCore;
<<<<<<< HEAD
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
=======
>>>>>>> 445520db14f862bd97211cc643700f05f88eeb5b

namespace Infrastructure.Persistence.Repositories
{
    public class DestinoRepository : IDestinoRepository
    {
        private readonly ApplicationDbContext _context;

        public DestinoRepository(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void Add(Destino destino) => _context.Destinos.Add(destino);
        public void Delete(Destino destino) => _context.Destinos.Remove(destino);
        public void Update(Destino destino) => _context.Destinos.Update(destino);
<<<<<<< HEAD
        public async Task<bool> ExistsAsync(DestinoId id) => await _context.Destinos.AnyAsync(d => d.Id.Equals(id));
        public async Task<Destino?> GetByIdAsync(DestinoId id) => await _context.Destinos.SingleOrDefaultAsync(d => d.Id.Equals(id));
=======
        public async Task<bool> ExistsAsync(DestinoId id) => await _context.Destinos.AnyAsync(d => d.Id == id);
        public async Task<Destino?> GetByIdAsync(DestinoId id) => await _context.Destinos.SingleOrDefaultAsync(d => d.Id == id);
>>>>>>> 445520db14f862bd97211cc643700f05f88eeb5b
        public async Task<List<Destino>> GetAll() => await _context.Destinos.ToListAsync();
    }
}
