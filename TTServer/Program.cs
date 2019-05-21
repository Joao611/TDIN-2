using System;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace StoreHost {
    class Program {
        static void Main() {
            WebServiceHost host = new WebServiceHost(typeof(StoreService.StoreService));
            host.Open();
            Console.WriteLine("Store service running");
            Console.WriteLine("Press ENTER to stop the service");
            Console.ReadLine();
            host.Close();
        }
    }
}
