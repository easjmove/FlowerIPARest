using TestRest.Models;

namespace TestRest.Managers
{
    public class IPAsManagerDB : IIPAsManager
    {
        private IpaContext _context;
        public IPAsManagerDB(IpaContext context)
        {
            _context = context;
        }

        public IPA Add(IPA newIpa)
        {
            newIpa.Id = 0;
            _context.IPAs.Add(newIpa);
            _context.SaveChanges();
            return newIpa;
        }

        public IPA? Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IPA> GetAll(double? minimumProof, double? maximumProof, int amount)
        {
            throw new NotImplementedException();
        }

        public IPA? GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public IPA? Update(int Id, IPA updates)
        {
            throw new NotImplementedException();
        }
    }
}
