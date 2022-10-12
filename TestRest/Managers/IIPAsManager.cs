using TestRest.Models;

namespace TestRest.Managers
{
    public interface IIPAsManager
    {
        IPA Add(IPA newIpa);
        IPA? Delete(int Id);
        IEnumerable<IPA> GetAll(double? minimumProof, double? maximumProof, int amount);
        IPA? GetById(int Id);
        IPA? Update(int Id, IPA updates);
    }
}