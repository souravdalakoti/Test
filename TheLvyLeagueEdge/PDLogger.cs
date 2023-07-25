
using PahadiDukan.Service.interfaces;

namespace PahadiDukan.Services
{
    public class PDLogger:IPDLogger
    {
       
        private readonly string _rootPath;
        public PDLogger(IConfiguration configuration)
        {
            _rootPath = configuration.GetSection("pdlog").Value;
        }

        //TODO: get current path, will create log dasboard category api , so there can check path on server.
        public string CreateDirectory(string ModuleFolder, string path)
        {
            string pathString = Path.Combine(_rootPath,ModuleFolder,path);
            if (!Directory.Exists(pathString))
            {
                Directory.CreateDirectory(pathString);
            }
            return pathString;
        }

        public async Task WriteInFile(string path, string Text)
        {
            path = System.IO.Path.Combine(_rootPath, path);

            if (!Directory.Exists(Path.GetDirectoryName(path)))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(path));
            }
            if (!File.Exists(path))
            {
                File.Create(path).Dispose();

                using (TextWriter tw = new StreamWriter(path))
                {
                    await tw.WriteLineAsync(Text);
                }

            }
            else if (File.Exists(path))
            {
                using (TextWriter tw = new StreamWriter(path,true))
                {
                    await tw.WriteLineAsync(Text);
                }
            }
        }

        public async Task LogError(string Text, string filepath)
        {
            await WriteInFile(filepath, Text);
        }
    }
}
