using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectAddIn3.Interfaces
{
    public  interface IMspVSTOManager
    {
        Task GetAllSubProjects(object subProjectsListBox);
        Task Import(object subProjectsListBox);
        Task Export();


    }
}
