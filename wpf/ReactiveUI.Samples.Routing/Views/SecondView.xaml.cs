using System;
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
    /// <summary>
    /// Interaction logic for SecondView.xaml
    /// </summary>
    public partial class SecondView
    {
        public SecondView()
        {
            InitializeComponent();

            this.VirtualGrid.DataProvider = new CustomDataProvider(GetSampleCustomers());


            this.WhenActivated(d =>
            {
                d(this.BindCommand(ViewModel, vm => vm.Back, view => view.backButton));
            });
        }

        private void VirtualGrid_CellValueNeeded(object sender, Telerik.Windows.Controls.VirtualGrid.CellValueEventArgs e)
        {
            // Example: Populate cell values with sample customer data
            var customers = GetSampleCustomers(); // Replace with your data retrieval logic
            var customer = customers.ElementAtOrDefault(e.RowIndex);
            if (customer != null)
            {
                switch (e.ColumnIndex)
                {
                    case 0:
                        e.Value = customer.FirstName;
                        break;
                    case 1:
                        e.Value = customer.LastName;
                        break;
                    case 2:
                        e.Value = customer.City;
                        break;
                }
            }
        }

        private IEnumerable<Customer> GetSampleCustomers()
        {
            // Replace with your actual data source (e.g., database query or API call)
            return new List<Customer>
                {
                    new Customer { FirstName = "John", LastName = "Doe", City = "New York" },
                    new Customer { FirstName = "Jane", LastName = "Smith", City = "Los Angeles" },
                    new Customer { FirstName = "Jane", LastName = "Smith", City = "Los Angeles" },
                    new Customer { FirstName = "Jane", LastName = "Smith", City = "Los Angeles" },
                    new Customer { FirstName = "Jane", LastName = "Smith", City = "Los Angeles" },
                    new Customer { FirstName = "Jane", LastName = "Smith", City = "Los Angeles" },
                    new Customer { FirstName = "Jane", LastName = "Smith", City = "Los Angeles" },
                    new Customer { FirstName = "Jane", LastName = "Smith", City = "Los Angeles" },
                    new Customer { FirstName = "Jane", LastName = "Smith", City = "Los Angeles" },
                    new Customer { FirstName = "Jane", LastName = "Smith", City = "Los Angeles" },
                    new Customer { FirstName = "Jane", LastName = "Smith", City = "Los Angeles" },
                    new Customer { FirstName = "Jane", LastName = "Smith", City = "Los Angeles" },
                    new Customer { FirstName = "Jane", LastName = "Smith", City = "Los Angeles" },
                    new Customer { FirstName = "Jane", LastName = "Smith", City = "Los Angeles" },
                    new Customer { FirstName = "Jane", LastName = "Smith", City = "Los Angeles" },
                    new Customer { FirstName = "Jane", LastName = "Smith", City = "Los Angeles" },
                    new Customer { FirstName = "Jane", LastName = "Smith", City = "Los Angeles" },
                    new Customer { FirstName = "Jane", LastName = "Smith", City = "Los Angeles" },
                    new Customer { FirstName = "Jane", LastName = "Smith", City = "Los Angeles" },
                    new Customer { FirstName = "Jane", LastName = "Smith", City = "Los Angeles" },
                    new Customer { FirstName = "Jane", LastName = "Smith", City = "Los Angeles" },
                    new Customer { FirstName = "Jane", LastName = "Smith", City = "Los Angeles" },
                    new Customer { FirstName = "Jane", LastName = "Smith", City = "Los Angeles" },
                    new Customer { FirstName = "Jane", LastName = "Smith", City = "Los Angeles" },
                    new Customer { FirstName = "Jane", LastName = "Smith", City = "Los Angeles" },
                    new Customer { FirstName = "Jane", LastName = "Smith", City = "Los Angeles" },
                    new Customer { FirstName = "Jane", LastName = "Smith", City = "Los Angeles" },
                    new Customer { FirstName = "Jane", LastName = "Smith", City = "Los Angeles" },
                    new Customer { FirstName = "Jane", LastName = "Smith", City = "Los Angeles" },
                    new Customer { FirstName = "Jane", LastName = "Smith", City = "Los Angeles" },
                    new Customer { FirstName = "Jane", LastName = "Smith", City = "Los Angeles" },
                    new Customer { FirstName = "Jane", LastName = "Smith", City = "Los Angeles" },
                    new Customer { FirstName = "Jane", LastName = "Smith", City = "Los Angeles" },
                    new Customer { FirstName = "Jane", LastName = "Smith", City = "Los Angeles" },
                    new Customer { FirstName = "Jane", LastName = "Smith", City = "Los Angeles" },
                    new Customer { FirstName = "Jane", LastName = "Smith", City = "Los Angeles" },
                    new Customer { FirstName = "Jane", LastName = "Smith", City = "Los Angeles" },
                    new Customer { FirstName = "Jane", LastName = "Smith", City = "Los Angeles" },
                    new Customer { FirstName = "Jane", LastName = "Smith", City = "Los Angeles" },
                    new Customer { FirstName = "Jane", LastName = "Smith", City = "Los Angeles" },
                    new Customer { FirstName = "Jane", LastName = "Smith", City = "Los Angeles" },
                    new Customer { FirstName = "Jane", LastName = "Smith", City = "Los Angeles" },
                    new Customer { FirstName = "Jane", LastName = "Smith", City = "Los Angeles" },
                    new Customer { FirstName = "Jane", LastName = "Smith", City = "Los Angeles" },
                    // Add more sample customers here
                };
        }

    }

    public class CustomDataProvider : DataProvider
    {
        public CustomDataProvider(IEnumerable<Customer> source) : base(source)
        {
        }
    }

}
