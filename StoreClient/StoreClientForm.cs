﻿using StoreClient.StoreServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Windows.Forms;

namespace StoreClient {
    [CallbackBehavior(UseSynchronizationContext = false)]
    public partial class StoreClientForm : Form, IStoreDualServiceCallback {
        StoreDualServiceClient proxy;
        List<Book> books = new List<Book>();
        List<Client> clients = new List<Client>();
        List<Order> orders = new List<Order>();
        Book selectedBook = null;
        double totalPrice = 0;
        public StoreClientForm() {
            InitializeComponent();
            proxy = new StoreDualServiceClient(new InstanceContext(this));
            newOrderPanel.Parent = this;
            stockPanel.Parent = this;
            stockPanel.Location = newOrderPanel.Location;
            requestsPanel.Parent = this;
            requestsPanel.Location = newOrderPanel.Location;
            ordersPanel.Parent = this;
            ordersPanel.Location = newOrderPanel.Location;
            newClientPanel.Parent = newOrderPanel;
            regClientPanel.Parent = newOrderPanel;
            newClientPanel.Location = regClientPanel.Location;
            newClientPanel.Visible = false;
            setVisibility(0);
        }

        private void newOrderButton_Click(object sender, EventArgs e) {
            setVisibility(0);
            regClientPanel.Visible = true;
            newClientPanel.Visible = false;
        }

        private void stockButton_Click(object sender, EventArgs e) {
            setVisibility(1);
        }

        private void ordersButton_Click(object sender, EventArgs e) {
            setVisibility(2);
        }

        private void requestsButton_Click(object sender, EventArgs e) {
            setVisibility(3);
        }

        private void resClientButton_Click(object sender, EventArgs e) {
            regClientPanel.Visible = true;
            newClientPanel.Visible = false;
        }

        private void newClientButton_Click(object sender, EventArgs e) {
            regClientPanel.Visible = false;
            newClientPanel.Visible = true;
        }

        private void booksComboBox_SelectedIndexChanged(object sender, EventArgs e) {
            selectedBook = books.Find(book => book.title == booksComboBox.Text);
            updateTotalPrice();
        }

        private void quantityNumericUpDown_ValueChanged(object sender, EventArgs e) {
            updateTotalPrice();
        }

        public void updateTotalPrice() {
            if (selectedBook == null) {
                totalPrice = 0;
            } else {
                totalPrice = Convert.ToInt32(quantityNumericUpDown.Value) * selectedBook.price;
            }
            
            totalPriceLabel.Text = totalPrice.ToString();
        }

        private void StoreClientForm_Shown(object sender, EventArgs e) {
            proxy.Subscribe();
            addBooksToForm();
            addClientsToForm();
            addOrdersToForm();
            addRequestsToForm();
        }

        private void payButton_Click(object sender, EventArgs e) {
            if (booksComboBox.SelectedItem == null || 
                (nameTextBox.Text == "" && clientsComboBox.SelectedItem == null)) {
                return;
            }
            int clientId = 0;
            if (newClientPanel.Visible) {
                if (nameTextBox.Text != "" && emailTextBox.Text != "" && addressTextBox.Text != "") {
                    clientId = registerClient();
                } else {
                    return;
                }
            } else {
                string clientName = clientsComboBox.SelectedItem.ToString();
                clientsComboBox.SelectedItem = null;
                clientId = clients.Find(client => client.name == clientName).id;
            }
            string bookName = booksComboBox.SelectedItem.ToString();
            booksComboBox.SelectedItem = null;
            int bookId = books.Find(book => book.title == bookName).id;
            int quantity = Convert.ToInt32(quantityNumericUpDown.Value);
            quantityNumericUpDown.Value = 1;
            proxy.CreateOrder(clientId, bookId, quantity);
            // orders.Add(newOrder);
            // ordersGrid.Rows.Add(newOrder.guid, newOrder.book.title, newOrder.quantity, stateToString(newOrder.state));
            //updateBookStock(newOrder.book.title, newOrder.book.stock);
        }

        public void setVisibility(int index) {
            List<Panel> panels = new List<Panel>() { newOrderPanel, stockPanel, ordersPanel, requestsPanel };
            panels.ForEach(panel => panel.Visible = false);
            panels[index].Visible = true;
        }

        public void addBooksToForm() {
            books = new List<Book>(proxy.GetBooks());
            books.ForEach(book => {
                booksComboBox.Items.Add(book.title);
                stockGrid.Rows.Add(book.title, book.stock);
            });
        }

        public void addClientsToForm() {
            clients = new List<Client>(proxy.GetClients());
            clients.ForEach(client => clientsComboBox.Items.Add(client.name));
        }

        public void addOrdersToForm() {
            orders = new List<Order>(proxy.GetOrders());
            orders.ForEach(order => {
                ordersGrid.Rows.Add(order.guid, order.book.title, order.quantity, stateToString(order.state));
            });
        }

        public void addRequestsToForm() {
            List<Request> requests = new List<Request>(proxy.GetRequests());
            requests.ForEach(request => {
                AddRequest(request);
            });
        }

        private string stateToString(Order.State state) {
            switch (state.type) {
                case Order.State.Type.WAITING:
                    return "Waiting Expedition";
                case Order.State.Type.DISPATCHED_AT:
                    return "Dispatched at " + state.dispatchDate.ToString("MM/dd/yyyy");
                case Order.State.Type.DISPATCH_OCCURS_AT:
                    return "Dispatch will occur at " + state.dispatchDate.ToString("MM/dd/yyyy");
                default:
                    return "";
            }
        }

        public int registerClient() {
            string name = nameTextBox.Text;
            nameTextBox.Text = "";
            string address = addressTextBox.Text;
            addressTextBox.Text = "";
            string email = emailTextBox.Text;
            emailTextBox.Text = "";
            Client newClient = proxy.CreateClient(name, address, email);
            return newClient.id;
        }

        private void updateBookStock(string bookTitle, int stock) {
            Book book = books.Find(b => b.title == bookTitle);
            if(book.stock != stock) {
                book.stock = stock;
                DataGridViewRow row = stockGrid.Rows
                            .Cast<DataGridViewRow>()
                            .FirstOrDefault(r => (string)r.Cells["bookNameColumn"].Value == bookTitle);
                row.Cells["bookStockColumn"].Value = stock;
            }
        }

        public void OrderCreated(Order order) {
            orders.Add(order);
            BeginInvoke((Action) (() => {
                ordersGrid.Rows.Add(order.guid, order.book.title, order.quantity, stateToString(order.state));
            }));
            updateBookStock(order.book.title, order.book.stock);
        }

        public void OrderStateUpdated(Order order) {
            Order o = orders.Find(or => or.guid == order.guid);
            o.state = order.state;
            DataGridViewRow row = ordersGrid.Rows
                            .Cast<DataGridViewRow>()
                            .FirstOrDefault(r => (Guid)r.Cells["orderIdColumn"].Value == order.guid);
            row.Cells["stateColumn"].Value = stateToString(order.state);
            if (order.state.type == Order.State.Type.DISPATCHED_AT) {
                Book book = books.Find(b => b.id == order.book.id);
                if(book.stock != order.book.stock) {
                    book.stock = order.book.stock;
                    row = stockGrid.Rows
                            .Cast<DataGridViewRow>()
                            .FirstOrDefault(r => (string)r.Cells["bookNameColumn"].Value == book.title);
                    row.Cells["bookStockColumn"].Value = book.stock;
                }
            }
        }

        public void AddRequest(Request request) {
            BeginInvoke((Action)(() => {
                requestsGrid.Rows.Add(request.orderGuid, request.bookTitle, request.quantity);
            }));
        }

        public void DeleteRequest(Request request) {
            DataGridViewRow row = requestsGrid.Rows
                        .Cast<DataGridViewRow>()
                        .FirstOrDefault(r => (Guid)r.Cells["requestOrderIdColumn"].Value == request.orderGuid);

            BeginInvoke((Action)delegate () {
                requestsGrid.Rows.Remove(row);
            });
        }

        public void ClientAdded(Client client) {
            clients.Add(client);
            BeginInvoke((Action)(() => {
                clientsComboBox.Items.Add(client.name);
            }));
        }

        private void StoreClientForm_FormClosing(object sender, FormClosingEventArgs e) {
            proxy.Unsubscribe();
            proxy.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e) {
            if (requestsGrid.SelectedRows.Count > 0) {
                DataGridViewRow row = requestsGrid.SelectedRows[0];
                proxy.SatisfyOrders((string)row.Cells["requestBookNameColumn"].Value,
                    (int)row.Cells["requestQuantityColumn"].Value,
                    (Guid)row.Cells["requestOrderIdColumn"].Value);
            }
        }
    }
}
