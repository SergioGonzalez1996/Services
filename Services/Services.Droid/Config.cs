using SQLite.Net.Interop;
using Xamarin.Forms;
using Services.Interfaces;

[assembly: Dependency(typeof(Services.Droid.Config))]

namespace Services.Droid
{
    public class Config : IConfig
    {
        private string directoryDB;
        private ISQLitePlatform platform;

        public string DirectoryDB
        {
            get
            {
                if (string.IsNullOrEmpty(directoryDB))
                {
                    directoryDB = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                }

                return directoryDB;
            }
        }

        public ISQLitePlatform Platform
        {
            get
            {
                if (platform == null)
                {
                    platform = new SQLite.Net.Platform.XamarinAndroid.SQLitePlatformAndroid();
                }

                return platform;

            }
        }
    }
}
