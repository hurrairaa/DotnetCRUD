using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstProject.Models;

namespace FirstProject.Interface
{
    public interface IFamilyService
    {
        IEnumerable<Family> GetFamily();

        Family GetFamilyById(int famId);
        void AddFamily(Family fam);
        void EditFamily(Family fam);
        void DeleteFamily(Family fam);
    
    }
}
