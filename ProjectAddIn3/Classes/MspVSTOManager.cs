using Microsoft.Office.Interop.MSProject;
using Mobideo.Integration.ProjectVSTOAddIn;
using ProjectAddIn3.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Task = System.Threading.Tasks.Task;

namespace ProjectAddIn3.Classes
{
    public class MspVSTOManager : IMspVSTOManager
    {
        public IMobideoImporter MobideoImporter { get; set; }
        public IEnumerable<SubProjectWrapper> SubProjects { get; set; }
        public Task Export()
        {
            throw new NotImplementedException();
        }

        public Task GetAllSubProjects(object subProjectsListBox)
        {
            var subProjectsList = subProjectsListBox as CheckedListBox;
            SubProjects = new List<SubProjectWrapper>();
            foreach (var subProject in Globals.ThisAddIn.Application.ActiveProject.Subprojects)
            {
                var currrentSubProject = subProject as Subproject;
                var newSubProjectWrapper = new SubProjectWrapper(currrentSubProject);
                subProjectsList.Items.Add(newSubProjectWrapper);
            }

            return Task.CompletedTask;
        }

        public async Task Import(object subProjectsListBox)
        {
            var subProjectsList = subProjectsListBox as CheckedListBox;
            var selectedMppFiles = subProjectsList.CheckedItems.Cast<SubProjectWrapper>().ToList();
            await MobideoImporter.ImportFilesToMobideo(selectedMppFiles);
        }

        public MspVSTOManager()
        {
            MobideoImporter= new MobideoImporter(); 
        }
    }
}
