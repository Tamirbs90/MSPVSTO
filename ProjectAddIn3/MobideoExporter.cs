using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectAddIn3.Query;

namespace MSP_POC
{
    public class MobideoExporter
    {

        public TaskExtendedPropertiesResult[] GetTasksByReferenceId(IEnumerable<string> tasksReferenceIds)
        {
            var queryServicesClient = new GuideServicesQueryApiWebServiceClient("GuideServicesQueryApiWebService");
            var pageSize = 50;
            var mobideoUser = "IntegrationUser";
            var userPassword = "123456";
            var userCredentials = new UserCredentials() { UserName = mobideoUser, Password = userPassword };
            var tasksQuery = new TasksQuery { StartIndex = 0, PageSize = pageSize, ExtendedPropertyName = "Hash", ReferenceIds = tasksReferenceIds.ToArray(), ReturnPrecondition = false };
            var getTasksExtendedPropertyResponse = queryServicesClient.GetTasksExtendedProperty(new TokenCredentials(), userCredentials, tasksQuery);

            return getTasksExtendedPropertyResponse.Items;
        }
    }
}
