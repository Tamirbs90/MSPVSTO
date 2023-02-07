using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectAddIn3.Interfaces;
using ProjectAddIn3.Query;

namespace ProjectAddIn3.Classes
{
    public class GetTasksByReferenceIds: ITaskExtractor
    {
        public IEnumerable<object> GetTasks(IEnumerable<string> tasksReferenceIds, int startIndex, int pageSize,string ExtendedPropertyName="Hash")
        {
            var queryServicesClient = new GuideServicesQueryApiWebServiceClient("GuideServicesQueryApiWebService");
            var mobideoUser = "IntegrationUser"; //Move to config / user from login
            var userPassword = "123456";//Move to config / password from login
            var userCredentials = new UserCredentials() { UserName = mobideoUser, Password = userPassword };
            var tasksQuery = new TasksQuery { StartIndex = startIndex, PageSize = pageSize, ExtendedPropertyName = ExtendedPropertyName, ReferenceIds = tasksReferenceIds.ToArray(), ReturnPrecondition = false };
            var getTasksExtendedPropertyResponse = queryServicesClient.GetTasksExtendedProperty(new TokenCredentials(), userCredentials, tasksQuery);

            return getTasksExtendedPropertyResponse.Items;
        }
    }
}
