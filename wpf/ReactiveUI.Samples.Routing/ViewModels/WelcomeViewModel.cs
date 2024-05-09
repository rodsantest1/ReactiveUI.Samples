using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using ReactiveUI.Fody.Helpers;
using ReactiveUI.Samples.Routing.Interactions;
using ReactiveUI.Samples.Routing.Views;
using ReactiveUI.Samples.Routing101;

namespace ReactiveUI.Samples.Routing.ViewModels
{
    // It's usually a good idea to create an interface for every ViewModel and
    // reference that instead of the implementation. This makes creating fake
    // versions or design-time versions of ViewModels much easier.
    public interface IWelcomeViewModel : IRoutableViewModel
    {
        ReactiveCommand<Unit, Unit> HelloWorld { get; }
        ReactiveCommand<Unit, Unit> NavigateToSecond { get; }
    }

    public class WelcomeViewModel : ReactiveObject, IWelcomeViewModel
    {
        /* COOLSTUFF: What is UrlPathSegment
         * 
         * Imagine that the router state is like the path of the URL - what 
         * would the path look like for this particular page? Maybe it would be
         * the current user's name, or an "id". In this case, it's just a 
         * constant. You can get the whole path via 
         * IRoutingState.GetUrlForCurrentRoute.
         */
        public string UrlPathSegment
        {
            get { return "welcome"; }
        }

        [Reactive] public int PageIndex { get; set; }

        public IScreen HostScreen { get; protected set; }

        public ReactiveCommand<Unit, Unit> HelloWorld { get; protected set; }

        public ReactiveCommand<Unit, Unit> NavigateToSecond { get; }

        public ObservableCollection<Employee> Employees { get; set; }

        /* COOLSTUFF: Why the Screen here?
         *
         * Every RoutableViewModel has a pointer to its IScreen. This is really
         * useful in a unit test runner, because you can create a dummy screen,
         * invoke Commands / change Properties, then test to see if you navigated
         * to the correct new screen 
         */
        public WelcomeViewModel(IScreen screen)
        {
            HostScreen = screen;

            PopulateData();


            /* COOLSTUFF: Where's the Execute handler?
             * 
             * We want this command to display a MessageBox. However, 
             * displaying a MessageBox is a very View'y thing to do. Instead, 
             * the ViewModel is going to create the ReactiveCommand and the
             * *View* is going to Subscribe to it. That way, we can test in
             * the Unit Test runner that HelloWorld is Execute'd at the right
             * times, but still display the MessageBox when the code runs 
             * normally,
             */

            HelloWorld = ReactiveCommand.CreateFromObservable(() => MessageInteractions.ShowMessage.Handle("It works!!!"));
            NavigateToSecond = ReactiveCommand.CreateFromTask(async () => await HostScreen.Router.Navigate.Execute(new SecondViewModel(HostScreen)).Select(_ => Unit.Default));

            this.WhenNavigatedTo(() => Bar());
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

            Employees = employees;
        }

        private IDisposable Bar()
        {
            return Disposable.Create(() => Foo());
        }

        private void Foo()
        {
            if (true)
            { }
        }
    }
}
