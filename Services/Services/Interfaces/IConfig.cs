using SQLite.Net.Interop;

namespace Services.Interfaces
{
    public interface IConfig
    {
        string DirectoryDB { get; }

        ISQLitePlatform Platform { get; }
    }

}
