using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Telerik.Windows.Controls.VirtualGrid;

namespace ReactiveUI.Samples.Routing.Views
{


    class Customer
    {
        public string FirstName { get; set; }
    }
    
    /// <summary>
    /// Interaction logic for SecondView.xaml
    /// </summary>
    public partial class SecondView
    {
        List<Customer> _customers;
        public SecondView()
        {
            InitializeComponent();
            _customers = new List<Customer>();
            _customers.Add(new Customer { FirstName = "Rodney" });
            _customers.Add(new Customer { FirstName = "Rodney" });
            _customers.Add(new Customer { FirstName = "Rodney" });
            _customers.Add(new Customer { FirstName = "Rodney" });
            _customers.Add(new Customer { FirstName = "Rodney" });
            _customers.Add(new Customer { FirstName = "Rodney" });
            _customers.Add(new Customer { FirstName = "Rodney" });
            _customers.Add(new Customer { FirstName = "Rodney" });
            _customers.Add(new Customer { FirstName = "Rodney" });
            _customers.Add(new Customer { FirstName = "Rodney" });
            _customers.Add(new Customer { FirstName = "Rodney" });
            _customers.Add(new Customer { FirstName = "Rodney" });
            _customers.Add(new Customer { FirstName = "Rodney" });
            _customers.Add(new Customer { FirstName = "Rodney" });
            _customers.Add(new Customer { FirstName = "Rodney" });
            _customers.Add(new Customer { FirstName = "Rodney" });
            _customers.Add(new Customer { FirstName = "Rodney" });
            _customers.Add(new Customer { FirstName = "Rodney" });
            _customers.Add(new Customer { FirstName = "Rodney" });
            _customers.Add(new Customer { FirstName = "Rodney" });
            _customers.Add(new Customer { FirstName = "Rodney" });
            _customers.Add(new Customer { FirstName = "Rodney" });
            var customers = _customers;

            this.VirtualGrid.DataProvider = new BaseDataProvider(customers);
            this.PinNameColumn();

            this.WhenActivated(d =>
            {
                d(this.BindCommand(ViewModel, vm => vm.Back, view => view.backButton));
            });
        }

        private void PinNameColumn()
        {
            var columnToPin = this.VirtualGrid.DataProvider.ItemProperties.Where(ip => ip.Name == "Contact_Name").FirstOrDefault();
            var columnToPinIndex = this.VirtualGrid.DataProvider.ItemProperties.IndexOf(columnToPin);
            this.VirtualGrid.PinColumnLeft(columnToPinIndex);
        }

        private void virtualGrid_CellValueNeeded(object sender,
        Telerik.Windows.Controls.VirtualGrid.CellValueEventArgs e)
        {
            e.Value = String.Format("{0}.{1}", e.RowIndex, e.ColumnIndex);
        }
    }

    internal class BaseDataProvider : DataProvider
    {
        public BaseDataProvider(IEnumerable source) : base(source)
        {
        }
    }
}
