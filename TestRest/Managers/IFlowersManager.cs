using TestRest.Models;

namespace TestRest.Managers
{
    public interface IFlowersManager
    {
        Flower Add(Flower newFlower);
        Flower? Delete(int Id);
        IEnumerable<Flower> GetAll(string? speciesFilter, string? colorFilter, int? amount);
        Flower? GetById(int Id);
        Flower? Update(int id, Flower updates);
    }
}