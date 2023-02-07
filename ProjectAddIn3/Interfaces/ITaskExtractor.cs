using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectAddIn3.Query;

namespace ProjectAddIn3.Interfaces
{
    public interface ITaskExtractor
    {
        IEnumerable<object> GetTasks(IEnumerable<string> tasksUniqueIdentifiers, int startIndex, int pageSize,string ExtendedPropertyName="Hash");
    }
}
