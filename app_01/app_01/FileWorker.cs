
using System.IO;

namespace app_01
{
    class FileWorker
    {
        public string FilePath { get; private set; }
        public string FileContent { get; private set; }
        private static int lineNumber;//number of current line

        //Singleton realization
        private static FileWorker instance;
        private FileWorker(string filePath)
        {
            this.FilePath = filePath;
            ReadToEnd();
            lineNumber = 0;
        }
        public static FileWorker getInstance(string filePath)
        {
            if (instance == null)
                instance = new FileWorker(filePath);
            return instance;
        }

        //Setting FileContent
        private void ReadToEnd()
        {
            using (StreamReader str = new StreamReader(FilePath))
            {
                FileContent = str.ReadToEnd();
            }
        }
        //Reading next line
        public string ReadNextLine()
        {
            lineNumber++;
            return FileContent.Split('\n')[lineNumber-1];
        }
    }
}
