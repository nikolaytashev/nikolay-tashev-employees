using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nikolay_tashev_employess.Base.Common.Interfaces
{
    public interface IDataLoader<DataModel>
    {
       List<DataModel> LoadData();
    }
}
