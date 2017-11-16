namespace Tests
{
    using System;
    using System.ComponentModel;
    using System.Windows.Forms;

    partial class NotePad : Form, INotifyPropertyChanged
    {
        private bool canUndo = true, selecion = true, canPaste = true;

        private Document document = new Document();

        private bool loaded;

        public NotePad()
        {
            InitializeComponent();
            Settings = new NotePadSettings() { Font = txtContent.Font, WordWrap = true };
        }

        public NotePad(string path) : this()
        {
            Document = Document.Open(path);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public bool CanPaste
        {
            get => canPaste;
            private set
            {
                if (canPaste != value)
                {
                    canPaste = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CanPaste"));
                }
            }
        }

        public bool CanUndo
        {
            get => canUndo;
            private set
            {
                if (canUndo != value)
                {
                    canUndo = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CanUndo"));
                }
            }
        }

        public Document Document
        {
            get => document;
            set
            {
                if (document != value)
                {
                    document = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Document"));
                }
            }
        }

        public bool SelectionChanged
        {
            get => selecion;
            private set
            {
                if (selecion != value)
                {
                    selecion = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SelectionChanged"));
                }
            }
        }

        public NotePadSettings Settings { get; private set; }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            //设置标题。
            this.Property(i => i.Text)
                .Binding(new MultiBindableValue(new BindableValue(this, "Document.Title"), new BindableValue(this, "Document.IsSaved")), new TitleConverter())
                .SetDataSourceUpdateMode(DataSourceUpdateMode.Never);
            //设置文本区信息
            txtContent.Property().Binding(new BindableValue(this, "Document.Content"));
            txtContent.Property(i => i.WordWrap).Binding(Settings, i => i.WordWrap);
            txtContent.Property(i => i.Font).Binding(Settings, i => i.Font);
            var statusBarBindingValue = new MultiBindableValue(new BindableValue(Settings, "WordWrap"), new BindableValue(Settings, "ShowStatusBar"));
            //设置状态栏信息。 
            sspStatus.Property(i => i.Visible).Binding(statusBarBindingValue, new ShowStatusConverter());
            tsmiStatusBar.Property(x => x.Checked).Binding(statusBarBindingValue, new ShowStatusConverter()).SetDataSourceUpdateMode(DataSourceUpdateMode.Never);
            tsmiStatusBar.Property(x => x.Enabled).Binding(Settings, x => x.WordWrap, new OppositeBooleanConverter());
            txtContent.Event("TextChanged").Command(new RelayCommand(x =>
            {
                if (txtContent.WordWrap)
                {
                    return;
                }
                tsslMessage.Text = $"总行数:{txtContent.Lines.Length}, 共{txtContent.TextLength}字";
            }));

            //设置换行信息。
            tsmiWordWrap.Property(i => i.Checked).Binding(Settings, i => i.WordWrap);
            tsmiWordWrap.Command(new RelayCommand(i => Settings.WordWrap = !Settings.WordWrap));

            //命令执行。
            tsmiStatusBar.Command(new RelayCommand(x => Settings.ShowStatusBar = !Settings.ShowStatusBar));
            tsmiFont.Command(new ChangeFontCommand(), this, x => x.Settings);
            tsmiNew.Command(new NewFileCommnd(), new ValueObject(this));
            tsmiOpen.Command(new OpenFileCommand(), new ValueObject(this));
            tsmiSave.Command(new SaveFileCommand(), new MultiBindableValue(new BindableValue(this, "Document"), new BindableValue(this, "Document.IsSaved")));
            tsmiUndo.Command(new RelayCommand(x => txtContent.Undo(), x => (bool)x), this, x => x.CanUndo);
            tsmiCopy.Command(new RelayCommand(x => txtContent.Copy(), x => (bool)x), this, x => x.SelectionChanged);
            tsmiCut.Command(new RelayCommand(x => txtContent.Cut(), x => (bool)x), this, x => x.SelectionChanged);
            tsmiPaste.Command(new RelayCommand(x => txtContent.Paste(), x => (bool)x), this, x => x.CanPaste);
            tsmiDelete.Command(new RelayCommand(x =>
            {
                var selecionIndex = txtContent.SelectionStart;
                txtContent.Text = txtContent.Text.Remove(selecionIndex, txtContent.SelectionLength);
                if (txtContent.TextLength > selecionIndex)
                {
                    txtContent.SelectionStart = selecionIndex;
                }
            }, x => (bool)x), this, x => x.SelectionChanged);
            loaded = true;
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (loaded)
            {
                CanUndo = txtContent.CanUndo;
                SelectionChanged = txtContent.SelectedText.Length > 0;
                CanPaste = Clipboard.GetText().Length > 0;
            }
        }
    }
}
