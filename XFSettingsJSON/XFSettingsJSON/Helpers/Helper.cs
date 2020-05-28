using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using XFSettingsJSON.Models;

namespace XFSettingsJSON.Helpers
{
    public class Helper
    {
        public static AppSettings GetAppSettings()
        {
            try
            {
                var appSettings = new AppSettings();
                var assembly = Assembly.GetExecutingAssembly();
                var resourceName = assembly.GetManifestResourceNames()
                    ?.FirstOrDefault(p => p.EndsWith("production.settings.json", StringComparison.OrdinalIgnoreCase));

                using (var file = assembly.GetManifestResourceStream(resourceName))
                using (var stream = new StreamReader(file))
                {
                    var strJson = stream.ReadToEnd();
                    appSettings = JsonConvert.DeserializeObject<AppSettings>(strJson);
                }

                return appSettings;
            }
            catch(Exception ex)
            {
                return null;
            }
        }
    }
}
