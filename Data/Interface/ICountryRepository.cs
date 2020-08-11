using Core;
using System;
using System.Collections.Generic;

namespace Data.Interface
{
    public interface ICountryRepository
    {
        List<Country> GetAll();
    }
}
