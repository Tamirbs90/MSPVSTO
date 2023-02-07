using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectAddIn3.Interfaces;
using Task = Microsoft.Office.Interop.MSProject.Task;
using Microsoft.Office.Interop.MSProject;
using System.Runtime.InteropServices;
using Mobideo.Integration.ProjectVSTOAddIn;


namespace ProjectAddIn3.Classes
{
    public class MspUpdater: IUpdateMspFile
    {
        public void updateByColumnName(Task syncline, string ColumnName, object value)
        {
            syncline.SetField(Globals.ThisAddIn.Application.FieldNameToFieldConstant(ColumnName), value.ToString());
        }
    }
}
