using hybr.Shared.Services;

namespace hybr
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            GlobalData.GetAllData();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new MainPage()) { Title = "hybr" };
        }
    }
}
