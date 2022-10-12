using TestRest.Models;

namespace TestRest.Managers
{
    public class FlowerManagerDB : IFlowersManager
    {
        private FlowerContext _context;

        public FlowerManagerDB(FlowerContext context)
        {
            _context = context;
        }

        public Flower Add(Flower newFlower)
        {
            newFlower.Id = 0;
            _context.Flowers.Add(newFlower);
            _context.SaveChanges();
            return newFlower;
        }

        public Flower? Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Flower> GetAll(string? speciesFilter, string? colorFilter, int? amount)
        {
            return _context.Flowers.ToList();
        }

        public Flower? GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public Flower? Update(int id, Flower updates)
        {
            throw new NotImplementedException();
        }
    }
}
