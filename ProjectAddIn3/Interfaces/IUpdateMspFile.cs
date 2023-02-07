using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task = Microsoft.Office.Interop.MSProject.Task;

namespace ProjectAddIn3.Interfaces
{
    public interface IUpdateMspFile
    {
        void updateByColumnName(Task syncline,string ColumnName,object value);
    }
}
