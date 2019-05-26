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
    [CallbackBehavior(UseSynchronizationContext = false)]
    public partial class WarehouseClientForm : Form, IWarehouseServiceCallback {
        readonly WarehouseServiceClient proxy;

        public WarehouseClientForm() {
            InitializeComponent();
            proxy = new WarehouseServiceClient(new InstanceContext(this));
        }

        public void RequestCreated(Request request) {
            BeginInvoke((Action)delegate () {
                requestsGrid.Rows.Add(request.orderGuid, request.bookTitle, request.quantity);
            });
        }

        public void RequestStateUpdated(Request request) {
            DataGridViewRow row = requestsGrid.Rows
                        .Cast<DataGridViewRow>()
                        .FirstOrDefault(r => (Guid)r.Cells["orderIdColumn"].Value == request.orderGuid);
            BeginInvoke((Action) delegate() {
                requestsGrid.Rows.Remove(row);
            });
        }

        private void WarehouseClientForm_Shown(object sender, EventArgs e) {
            List<Request> requests = new List<Request>(proxy.GetRequests());
            requests.ForEach(request => {
                RequestCreated(request);
            });
            proxy.Subscribe();
        }

        private void WarehouseClientForm_FormClosing(object sender, FormClosingEventArgs e) {
            proxy.Unsubscribe();
            proxy.Close();
        }

        private void RequestsGrid_CellClick(object sender, DataGridViewCellEventArgs e) {
            if (requestsGrid.SelectedRows.Count > 0) {
                DataGridViewRow row = requestsGrid.SelectedRows[0];
                proxy.SendBooks(
                    (string)row.Cells["bookColumn"].Value,
                    (int)row.Cells["quantityColumn"].Value,
                    (Guid)row.Cells["orderIdColumn"].Value
                );
            }
        }
    }
}
