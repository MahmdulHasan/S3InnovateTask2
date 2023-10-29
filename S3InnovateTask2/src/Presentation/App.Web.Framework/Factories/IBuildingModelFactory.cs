﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Web.Framework.Factories
{
    public interface IBuildingModelFactory
    {
        Task<List<BuildingModel>> PrepareBuildingModelList();
    }
}
