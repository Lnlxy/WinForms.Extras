using System.Collections.Generic;
using System.Linq;

namespace System.Windows.Forms.Internals
{
    internal class SourceTypeDescriptor
    {
        private static readonly Dictionary<Type, List<SourceMemberDescriptor>> members = new Dictionary<Type, List<SourceMemberDescriptor>>();

        private static readonly object syncObj = new object();

        public static SourcePropertyDescriptor GetProperty(object source, string propertyName)
        {
            return GetProperty(source.GetType(), propertyName);
        }

        public static SourcePropertyDescriptor GetProperty(Type sourceType, string propertyName)
        {
            lock (syncObj)
            {
                if (!members.ContainsKey(sourceType))
                {
                    members[sourceType] = new List<SourceMemberDescriptor>();
                }
                var property = members[sourceType].SingleOrDefault(i => i.Name == propertyName && i is SourcePropertyDescriptor);
                if (property == null)
                {
                    property = new SourcePropertyDescriptor(sourceType.GetProperty(propertyName, Reflection.BindingFlags.Public | Reflection.BindingFlags.NonPublic | Reflection.BindingFlags.Instance | Reflection.BindingFlags.Static));
                    members[sourceType].Add(property);
                }
                return (SourcePropertyDescriptor)property;
            }
        }
    }
}
