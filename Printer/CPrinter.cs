using Printer.StoreServiceReference;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Printer {
    [CallbackBehavior(UseSynchronizationContext = false)]
    class CPrinter : IStoreDualServiceCallback {
        StoreDualServiceClient proxy;

        CPrinter() {
            proxy = new StoreDualServiceClient(new InstanceContext(this));
            proxy.Subscribe();

            // Register the exit handler
            SetConsoleCtrlHandler(Handler, true);
        }

        public void OrderCreated(Order order) {
            if (order.state.type == Order.State.Type.DISPATCHED_AT) {
                int[] arr = {
                    order.book.title.Length, order.client.name.Length,
                    order.client.address.Length, order.client.email.Length };
                int max = arr.Max();
                Console.WriteLine();
                Console.WriteLine(("").PadRight(15 + order.book.title.Length, '*'));
                Console.WriteLine("\nClient name: {0}", order.client.name);
                Console.WriteLine("E-mail: {0}", order.client.email);
                Console.WriteLine("Address: {0}\n", order.client.address);
                Console.WriteLine(("").PadRight(15 + order.book.title.Length, '-'));
                Console.WriteLine("\n  " + order.book.title + "\n");
                Console.WriteLine("\t{0,3}x {1,6:C2} {2,10:C2}\n", order.quantity, order.book.price, order.totalPrice);
                Console.WriteLine(("").PadRight(15 + order.book.title.Length, '*'));
                Console.WriteLine();
            }
        }

        static void Main(string[] args) {
            CPrinter printer = new CPrinter();
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-PT", false);

            Console.WriteLine("Press Return to terminate.");
            Console.ReadLine();
        }

        // Credits for the console exit code below: https://www.meziantou.net/2018/04/09/detecting-console-closing-in-net

        [System.Runtime.InteropServices.DllImport("Kernel32")]
        private static extern bool SetConsoleCtrlHandler(SetConsoleCtrlEventHandler handler, bool add);

        private delegate bool SetConsoleCtrlEventHandler(CtrlType sig);

        private enum CtrlType {
            CTRL_C_EVENT = 0,
            CTRL_BREAK_EVENT = 1,
            CTRL_CLOSE_EVENT = 2,
            CTRL_LOGOFF_EVENT = 5,
            CTRL_SHUTDOWN_EVENT = 6
        }

        private bool Handler(CtrlType signal) {
            switch (signal) {
                case CtrlType.CTRL_BREAK_EVENT:
                case CtrlType.CTRL_C_EVENT:
                case CtrlType.CTRL_LOGOFF_EVENT:
                case CtrlType.CTRL_SHUTDOWN_EVENT:
                case CtrlType.CTRL_CLOSE_EVENT:
                    Console.WriteLine("Closing");
                    proxy.Unsubscribe();
                    proxy.Close();
                    Environment.Exit(0);
                    return false;
                default:
                    return false;
            }
        }

        // Unused hooks.
        public void AddRequest(Request request) { }
        public void OrderStateUpdated(Order order) { }
    }
}
