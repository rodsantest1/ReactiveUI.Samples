using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ReactiveUI.Samples.Routing.ViewModels;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace ReactiveUI.Samples.Routing.Views
{
    /// <summary>
    /// Interaction logic for WelcomeView.xaml
    /// </summary>
    public partial class WelcomeView : IViewFor<IWelcomeViewModel>
    {
        public WelcomeView()
        {
            InitializeComponent();

            PopulateData(); 

            this.WhenActivated(d =>
            {
                d(this.WhenAnyValue(x => x.ViewModel).BindTo(this, x => x.DataContext));
                d(this.BindCommand(ViewModel, vm => vm.HelloWorld, view => view.helloWorldButton));
                d(this.BindCommand(ViewModel, vm => vm.NavigateToSecond, view => view.navigateButton));
            });
        }

        public IWelcomeViewModel ViewModel
        {
            get { return (IWelcomeViewModel)GetValue(ViewModelProperty); }
            set { SetValue(ViewModelProperty, value); }
        }
        public static readonly DependencyProperty ViewModelProperty =
            DependencyProperty.Register("ViewModel", typeof(IWelcomeViewModel), typeof(WelcomeView), new PropertyMetadata(null));

        object IViewFor.ViewModel
        {
            get { return ViewModel; }
            set { ViewModel = (IWelcomeViewModel)value; }
        }
        public void PopulateData()
        {
            ObservableCollection<Employee> employees = new();
            employees.Add(new Employee() { Name = "Rodney01", CompanyName = "Company01", Title = "Title01" });
            employees.Add(new Employee() { Name = "Rodney02", CompanyName = "Company02", Title = "Title02" });
            employees.Add(new Employee() { Name = "Rodney03", CompanyName = "Company03", Title = "Title03" });
            employees.Add(new Employee() { Name = "Rodney04", CompanyName = "Company04", Title = "Title04" });
            employees.Add(new Employee() { Name = "Rodney05", CompanyName = "Company05", Title = "Title05" });

            employees.Add(new Employee() { Name = "Rodney06", CompanyName = "Company06", Title = "Title06" });
            employees.Add(new Employee() { Name = "Rodney07", CompanyName = "Company07", Title = "Title07" });
            employees.Add(new Employee() { Name = "Rodney08", CompanyName = "Company08", Title = "Title08" });
            employees.Add(new Employee() { Name = "Rodney09", CompanyName = "Company09", Title = "Title09" });
            employees.Add(new Employee() { Name = "Rodney10", CompanyName = "Company10", Title = "Title10" });

            radDataPager1.Source = employees;
        }

        public Employee MyProperty { get; set; }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            PopulateData();

        }
    }

    public class Employee
    {
        public string Name { get; set; }
        public string CompanyName { get; set; }
        public string Title { get; set; }
    }
}
