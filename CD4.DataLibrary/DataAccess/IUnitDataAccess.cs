﻿using CD4.DataLibrary.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CD4.DataLibrary.DataAccess
{
    public interface IUnitDataAccess
    {
        Task<List<UnitModel>> GetAllUnitsAsync();
    }
}