using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResultTest
{
    class ServiceResolver
    {
        public static IDialogService GetDialogService()
        {
            if (App.WindowServiceOverride == null)
                return new InteractiveWindowService();
            else
                return App.WindowServiceOverride;
        }

        public static ITestService GetTestService()
        {
            if (App.TestServiceOverride == null)
                return new InteractiveTestService();
            else
                return App.TestServiceOverride;
        }

    }
}
