using XFSettingsJSON.Helpers;
using XFSettingsJSON.ViewModel;

namespace XFSettingsJSON.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        public MainPageViewModel()
        {
            GetAppSettings();
        }

        private string _environment;
        public string Environment
        {
            get { return _environment; }
            set { SetProperty(ref _environment, value); }
        }

        private string _apiUrlBase;
        public string ApiUrlBase
        {
            get { return _apiUrlBase; }
            set { SetProperty(ref _apiUrlBase, value); }
        }

        private string _apiKey;
        public string ApiKey
        {
            get { return _apiKey; }
            set { SetProperty(ref _apiKey, value); }
        }

        void GetAppSettings()
        {
            var appSettings = Helper.GetAppSettings();
            if (appSettings != null)
            {
                Environment = appSettings.environment;
                ApiUrlBase = appSettings.apiUrlBase;
                ApiKey = appSettings.apiKey;
            }
        }
    }
}
