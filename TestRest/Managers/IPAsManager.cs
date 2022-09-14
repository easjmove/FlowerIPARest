using TestRest.Models;

namespace TestRest.Managers
{
    public class IPAsManager
    {
        private static int _nextID = 1;
        private static List<IPA> _data = new List<IPA>()
        {
            new IPA(){Id = _nextID++, Name="Nr1", Proof=10.5, Brand= "Carlsberg", Grain="Corn" },
            new IPA(){Id = _nextID++, Name="Standard", Proof=5.5, Brand= "Tuborg", Grain="Wheat" },
            new IPA(){Id = _nextID++, Name="Nr44", Proof=6, Brand= "Carlsberg", Grain="Corn" }
        };

        public List<IPA> GetAll(double? minimumProof, double? maximumProof)
        {
            List<IPA> list = new List<IPA>(_data);
            if (minimumProof != null)
            {
                list = list.FindAll(ipa => ipa.Proof >= minimumProof);
            }
            if (maximumProof != null)
            {
                list = list.FindAll(ipa => ipa.Proof <= maximumProof);
            }
            return list;
        }
        public IPA? GetById(int Id)
        {
            return _data.Find(ipa => ipa.Id == Id);
        }

        public IPA Add(IPA newIpa)
        {
            newIpa.Id = _nextID++;
            _data.Add(newIpa);
            return newIpa;
        }

        public IPA? Update(int Id, IPA updates)
        {
            IPA? oldIpa = GetById(Id);
            if (oldIpa == null) return null;
            oldIpa.Name = updates.Name;
            oldIpa.Proof = updates.Proof;
            oldIpa.Brand = updates.Brand;
            oldIpa.Grain = updates.Grain;
            return oldIpa;
        }

        public IPA? Delete(int Id)
        {
            IPA? toBeDeleted = GetById(Id);
            if (toBeDeleted == null) return null;
            _data.Remove(toBeDeleted);
            return toBeDeleted;
        }
    }
}
