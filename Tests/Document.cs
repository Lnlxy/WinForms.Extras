using System.ComponentModel;
using System.IO;
using System.Windows.Forms;

namespace Tests
{
    class Document : INotifyPropertyChanged
    {
        private string path, title, content;
        private bool saved = true;

        public event PropertyChangedEventHandler PropertyChanged;

        public bool IsSaved
        {
            get => saved; private set
            {
                if (value != saved)
                {
                    saved = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("IsSaved"));
                }
            }
        }

        public string Content
        {
            get => content;
            set
            {
                if (!string.Equals(content, value))
                {
                    content = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Content"));
                    IsSaved = false;
                }
            }
        }

        public string Path
        {
            get => path;
            set
            {
                if (!string.Equals(path, value))
                {
                    path = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Path"));
                }
            }
        }

        public string Title
        {
            get => title;
            set
            {
                if (!string.Equals(title, value))
                {
                    title = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Title"));
                }
            }
        }

        public Document()
        {
            title = "无标题";
            saved = true;
        }

        public void Save()
        {
            if (!File.Exists(path))
            {
                using (SaveFileDialog dialog = new SaveFileDialog())
                {
                    dialog.Filter = "文本文件(*.txt)|*.txt";
                    dialog.AutoUpgradeEnabled = true;
                    dialog.DefaultExt = ".txt";
                    if (dialog.ShowDialog() != DialogResult.OK)
                    {
                        return;
                    }
                    path = dialog.FileName;
                }
            }
            File.WriteAllText(path, content);
            IsSaved = true;
        }

        public void SaveAs(string path)
        {

        }

        public static Document Open(string path)
        {

            var content = File.ReadAllText(path);
            return new Document()
            {
                content = content,
                path = path,
                saved = true,
                title = System.IO.Path.GetFileName(path)
            };
        }
    }
}
