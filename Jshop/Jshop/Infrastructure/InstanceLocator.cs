namespace Jshop.Infrastructure
{
    using Jshop.ViewModel;

    public class InstanceLocator
    {
        public MainViewModel Main { get; set; }

        public InstanceLocator()
        {
            Main = new MainViewModel();
        }
    }
}
