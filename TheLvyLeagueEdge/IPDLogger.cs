namespace PahadiDukan.Service.interfaces
{
    public interface IPDLogger
    {
        string CreateDirectory(string ModuleFolder, string path);
        Task LogError(string Text, string filepath);
    }
}
