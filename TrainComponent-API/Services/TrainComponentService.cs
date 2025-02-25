using Microsoft.EntityFrameworkCore;
using TrainComponent.Data;

namespace TrainComponent.Services
{
    public class TrainComponentService
    {
        private readonly TrainComponentDbContext _context;
        private const int PAGE_SIZE = 10;

        public TrainComponentService(TrainComponentDbContext context)
        {
            _context = context;
        }

        public async Task<List<Models.TrainComponent>> GetAllAsync(int page, string? search)
        {
            var query = _context.TrainComponents.AsQueryable();

            if (!string.IsNullOrEmpty(search))
                query = query.Where(i => i.Name.Contains(search) || i.UniqueNumber.Contains(search));

            return await query.OrderBy(i => i.Id)
                              .Skip((page - 1) * PAGE_SIZE)
                              .Take(PAGE_SIZE)
                              .ToListAsync();
        }

        public async Task<bool> AddAsync(Models.TrainComponent component)
        {
            if (component.CanAssignQuantity && (component.Quantity == null || component.Quantity < 1))
                return false;

            _context.TrainComponents.Add(component);

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateAsync(int id, Models.TrainComponent component)
        {
            if (id != component.Id) return false;

            if (component.CanAssignQuantity && (component.Quantity == null || component.Quantity < 1))
                return false;

            _context.Entry(component).State = EntityState.Modified;

            try
            {
                return await _context.SaveChangesAsync() > 0;
            }
            catch (DbUpdateConcurrencyException)
            {
                return _context.TrainComponents.Any(e => e.Id == id);
            }
        }

        public async Task<bool> UpdateQuantityAsync(int id, int newQuantity)
        {
            var component = await _context.TrainComponents.FindAsync(id);
            if (component == null || !component.CanAssignQuantity) return false;
            component.Quantity = newQuantity;

            return await _context.SaveChangesAsync() > 0;
        }
    }
}
