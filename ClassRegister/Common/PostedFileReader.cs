using ClassRegister.Models;

namespace ClassRegister.Common
{
    public class PostedFileReader
    {
        public Stream FileStream { get; private set; }
        public string Type { get; set; }

        public PostedFileReader(Stream fileStream, string type)
        {
            FileStream = fileStream;
            Type = type;
        }

        public List<string>? GetLines()
        {
            return Type switch
            {
                Extensions.Text => ReadTxt(),
                Extensions.Xlsx => ReadXlsx(),
                _ => null,
            };
        }

        private List<string> ReadXlsx()
        {

            return null;
        }

        private List<string> ReadTxt()
        {
            using StreamReader sr = new(FileStream);

            List<string> text = new();
            string? line;

            while (!sr.EndOfStream)
            {
                line = sr.ReadLine();
                if (line is not null)
                    text.Add(line);
            }

            return text;
        }
    }
}
