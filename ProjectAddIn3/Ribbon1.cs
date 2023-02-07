using Microsoft.Office.Tools.Ribbon;
using MSP_POC;
using ProjectAddIn3.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mobideo.Integration.ProjectVSTOAddIn
{
    public partial class Ribbon1
    {
        
        private void Ribbon1_Load(object sender, RibbonUIEventArgs e)
        {

        }

        private void RunBtn_Click(object sender, RibbonControlEventArgs e)
        {
            var form = new Form1();
            form.ShowDialog();
        }

    }
}
