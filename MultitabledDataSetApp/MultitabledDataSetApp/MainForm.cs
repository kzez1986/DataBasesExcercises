using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.SqlClient;
using System.Configuration;

namespace MultitabledDataSetApp
{
    public partial class MainForm : Form
    {
        private DataSet _autoLotDs = new DataSet("AutoLot");

        private SqlCommandBuilder _sqlCbInventory;
        private SqlCommandBuilder _sqlCbCustomers;
        private SqlCommandBuilder _sqlCbOrders;

        private SqlDataAdapter _invTableAdapter;
        private SqlDataAdapter _custTableAdapter;
        private SqlDataAdapter _ordersTableAdapter;

        private string _connectionString;
        
        public MainForm()
        {
            InitializeComponent();

            _connectionString = ConfigurationManager.ConnectionStrings["AutoLotSqlProvider"].ConnectionString;

            _invTableAdapter = new SqlDataAdapter("Select * from Inventory", _connectionString);
            _custTableAdapter = new SqlDataAdapter("Select * from Customers", _connectionString);
            _ordersTableAdapter = new SqlDataAdapter("select * from Orders", _connectionString);

            _sqlCbInventory = new SqlCommandBuilder(_invTableAdapter);
            _sqlCbOrders = new SqlCommandBuilder(_ordersTableAdapter);
            _sqlCbCustomers = new SqlCommandBuilder(_custTableAdapter);

            _invTableAdapter.Fill(_autoLotDs, "Inventory");
            _custTableAdapter.Fill(_autoLotDs, "Customers");
            _ordersTableAdapter.Fill(_autoLotDs, "Orders");

            BuildTableRelationship();

            dataGridViewInventory.DataSource = _autoLotDs.Tables["Inventory"];
            dataGridViewCustomers.DataSource = _autoLotDs.Tables["Customers"];
            dataGridViewOrders.DataSource = _autoLotDs.Tables["Orders"];
        }

        private void BuildTableRelationship()
        {
            DataRelation dr = new DataRelation("CustomerOrder", _autoLotDs.Tables["Customers"].Columns["CustID"], _autoLotDs.Tables["Orders"].Columns["CustID"]);
            _autoLotDs.Relations.Add(dr);

            dr = new DataRelation("InventoryOrder", _autoLotDs.Tables["Inventory"].Columns["CarID"], _autoLotDs.Tables["Orders"].Columns["CarID"]);
            _autoLotDs.Relations.Add(dr);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}
