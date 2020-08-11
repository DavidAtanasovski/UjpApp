using Core;
using System.Collections.Generic;

namespace Data.Interface
{
    public interface IDDVRepository
    {
        List<DDV> GetAll();
        DDV Get(int id);
    }
}
