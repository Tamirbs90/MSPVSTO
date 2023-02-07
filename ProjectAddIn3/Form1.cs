using MSP_POC;
using ProjectAddIn3.Query;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using Aspose.Tasks.Connectivity;
using Project = Microsoft.Office.Interop.MSProject.Project;
using Task = Microsoft.Office.Interop.MSProject.Task;
using Microsoft.Office.Interop.MSProject;
using ProjectAddIn3.Interfaces;
using ProjectAddIn3.Classes;

namespace Mobideo.Integration.ProjectVSTOAddIn
{
    public partial class Form1 : Form
    {
        public IMspVSTOManager MspVSTOManager { get; set; }

        public Form1()
        {
            InitializeComponent();
            //MSP_Project = new Aspose.Tasks.Project(string.Format("{0}\\{1}",Globals.ThisAddIn.Application.ActiveProject.Path, Globals.ThisAddIn.Application.ActiveProject.Name));
            MspVSTOManager = new MspVSTOManager();
            MspVSTOManager.GetAllSubProjects(SubProjectsList);
            //AppSettings = new Dictionary<string, string>();
            //initAppSettings();
        }

        //private void initAppSettings()
        //{
        //    var appSettings = ConfigurationManager.GetSection("Configs");
        //    ConfigurationManager.AppSettings.g
        //    foreach (var key in ConfigurationManager.AppSettings.AllKeys)
        //    {
        //        AppSettings.Add(key.Trim().ToUpper(), ConfigurationManager.AppSettings[key]);
        //    }
        //}
        private void label_UpdateMobideoToMsp_Click(object sender, EventArgs e)
        {
            Project currentProject;

            for (int i = 1; i <= Globals.ThisAddIn.Application.ActiveProject.Subprojects.Count; i++)
            {
                currentProject = Globals.ThisAddIn.Application.ActiveProject.Subprojects[i].SourceProject;
                foreach (Task syncline in currentProject.Tasks)
                {
                    //syncline.Text1 = "Test2.1.23";
                    string value= "Test2.1.23aa";
                    syncline.SetField(Globals.ThisAddIn.Application.FieldNameToFieldConstant("Text1"), value.ToString());
                }
            }

            //string[] TasksReferenceIds = new string[] { "151222-104-2022 TYR Turnaround" };
            //WriteTasksInformationToFile(mobideoImporter.GetTasksByReferenceId(TasksReferenceIds));
        }

        private void WriteTasksInformationToFile(TaskExtendedPropertiesResult[] taskExtendedPropertiesResults)
        {
            for (int i = 0; i < taskExtendedPropertiesResults.Length; i++)
            {
                Globals.ThisAddIn.Application.ActiveProject.OutlineChildren[i + 1].Start = taskExtendedPropertiesResults[i].TaskInformation.StartDate;
                Globals.ThisAddIn.Application.ActiveProject.OutlineChildren[i + 1].Finish = taskExtendedPropertiesResults[i].TaskInformation.DueDate;
                Globals.ThisAddIn.Application.ActiveProject.OutlineChildren[i + 1].Text1 = taskExtendedPropertiesResults[i].TaskInformation.EquipmentId;
                Globals.ThisAddIn.Application.ActiveProject.OutlineChildren[i + 1].Text2 = taskExtendedPropertiesResults[i].TaskInformation.EmployeeRefrenceId;
                Globals.ThisAddIn.Application.ActiveProject.OutlineChildren[i + 1].Text3 = taskExtendedPropertiesResults[i].TaskInformation.Summary;
                Globals.ThisAddIn.Application.ActiveProject.OutlineChildren[i + 1].Text4 = taskExtendedPropertiesResults[i].TaskInformation.TaskProgressStatus;
                Globals.ThisAddIn.Application.ActiveProject.OutlineChildren[i + 1].Text5 = taskExtendedPropertiesResults[i].TaskInformation.ReferenceId;
            }
           
        }

        //private void CreateSubProjectsFiles()
        //{

        //    //foreach (Task ProjectTask in Globals.ThisAddIn.Application.ActiveProject.OutlineChildren)
        //    //{
        //    //    using (FileStream fs = new FileStream(ProjectTask.Subproject, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
        //    //    {
        //    //        using (var fileStream = File.Create(string.Format("{0}\\{1}.mpp", Globals.ThisAddIn.Application.ActiveProject.Path, ProjectTask.Name)))
        //    //        {
        //    //            fs.Seek(0, SeekOrigin.Begin);
        //    //            fs.CopyTo(fileStream);
        //    //        }
        //    //    }
        //    //}


        //    foreach (var subProject in  Globals.ThisAddIn.Application.ActiveProject.Subprojects)
        //    {
        //        var currrentSubProject = subProject as Subproject;
        //        using (FileStream fs = new FileStream(currrentSubProject.Path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
        //        {
        //            using (var fileStream = File.Create(string.Format("{0}\\{1}.mpp", Globals.ThisAddIn.Application.ActiveProject.Path, "test1")))
        //            {
        //                fs.Seek(0, SeekOrigin.Begin);
        //                fs.CopyTo(fileStream);
        //            }
        //        }
        //    }
        //}

        private void label_UpdateMspToMobideo_Click(object sender, EventArgs e)
        {
            MspVSTOManager.Import(SubProjectsList);
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }
    }
}
