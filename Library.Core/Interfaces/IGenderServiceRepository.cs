using System.Collections.Generic;
using System.Threading.Tasks;

namespace Library.Core.Interfaces
{
    public interface IGenderRepository
    {
         Task<IEnumerable<Gender>> GetGenders();
         Task<Gender> GetGender(int id);
         Task InsertGender(Gender genero);
         Task<bool> UpdateGender(Gender genero);
         Task<bool> DeleteGender(int id);
    }
}