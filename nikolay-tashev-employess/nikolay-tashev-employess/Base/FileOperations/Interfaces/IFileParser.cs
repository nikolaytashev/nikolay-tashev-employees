using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nikolay_tashev_employess.Base.FileOperations.Interfaces
{
    public interface IFileParser<DataModel>
    {
        DataModel ParseData(string data, int currentRow);
    }
}
