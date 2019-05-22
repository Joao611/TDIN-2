using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StoreClient {
    public partial class StoreClientForm : Form {
        public StoreClientForm() {
            InitializeComponent();
            newOrderPanel.Parent = this;
            stockPanel.Parent = this;
            stockPanel.Location = newOrderPanel.Location;
            requestsPanel.Parent = this;
            requestsPanel.Location = newOrderPanel.Location;
            newMemberPanel.Parent = newOrderPanel;
            regMemberPanel.Parent = newOrderPanel;
            newMemberPanel.Location = regMemberPanel.Location;
            newMemberPanel.Visible = false;
            setVisibility(0);
        }

        public void setVisibility(int index) {
            List<Panel> panels = new List<Panel>() { newOrderPanel, stockPanel, requestsPanel };
            panels.ForEach(panel => panel.Visible = false);
            panels[index].Visible = true;
        }

        private void newOrderButton_Click(object sender, EventArgs e) {
            setVisibility(0);
            regMemberPanel.Visible = true;
        }

        private void stockButton_Click(object sender, EventArgs e) {
            setVisibility(1);
        }

        private void requestsButton_Click(object sender, EventArgs e) {
            setVisibility(2);
        }

        private void resMemberButton_Click(object sender, EventArgs e) {
            regMemberPanel.Visible = true;
            newMemberPanel.Visible = false;
        }

        private void newMemberButton_Click(object sender, EventArgs e) {
            regMemberPanel.Visible = false;
            newMemberPanel.Visible = true;
        }
    }
}
