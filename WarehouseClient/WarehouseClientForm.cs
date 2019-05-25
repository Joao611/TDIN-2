using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WarehouseForm.WarehouseServiceReference;

namespace WarehouseForm {
    public partial class WarehouseClientForm : Form, IWarehouseServiceCallback {
        readonly WarehouseServiceClient proxy;

        public WarehouseClientForm() {
            InitializeComponent();
            proxy = new WarehouseServiceClient(new InstanceContext(this));
            List<Request> requests = new List<Request>(proxy.GetRequests());
            requests.ForEach(request => {
                requestsGrid.Rows.Add(request.orderGuid, request.bookTitle, request.quantity);
            });
        }

        public void RequestCreated(Request request) {
            return;
            //throw new NotImplementedException();
        }

        public void RequestStateUpdated(Request request) {
            throw new NotImplementedException();
        }

        private void selectRowEvent(object sender, DataGridViewRowStateChangedEventArgs e) {
            // For any other operation except, StateChanged, do nothing
            if (e.StateChanged != DataGridViewElementStates.Selected) return;


        }

        private void WarehouseClientForm_Shown(object sender, EventArgs e) {
            proxy.Subscribe();
        }

        private void WarehouseClientForm_FormClosing(object sender, FormClosingEventArgs e) {
            proxy.Unsubscribe();
            proxy.Close();
        }
    }
}
