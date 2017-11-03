namespace System.Windows.Forms.Internals
{
    abstract class SourceMemberDescriptor
    {
        public SourceMemberDescriptor(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }
    }
}
