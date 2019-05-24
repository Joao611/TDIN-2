using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WarehouseForm.WarehouseServiceReference;

namespace WarehouseForm {
    public partial class WarehouseClientForm : Form {
        WarehouseServiceClient proxy;
        List<Request> requests = new List<Request>();

        public WarehouseClientForm(WarehouseServiceClient proxy) {
            this.proxy = proxy;
            InitializeComponent();
        }

        private void selectRowEvent(object sender, DataGridViewRowStateChangedEventArgs e) {
            // For any other operation except, StateChanged, do nothing
            if (e.StateChanged != DataGridViewElementStates.Selected) return;


        }
    }


}
