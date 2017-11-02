namespace System.Windows.Forms.Internals
{
    abstract class MemberDescriptor
    {
        public MemberDescriptor(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }
    }
}
