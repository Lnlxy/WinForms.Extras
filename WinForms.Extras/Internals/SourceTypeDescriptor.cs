using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Concurrent;
namespace System.Windows.Forms.Internals
{
    internal class SourceTypeDescriptor
    {
        private static readonly object syncObj = new object();
        private static readonly Dictionary<Type, List<MemberDescriptor>> members = new Dictionary<Type, List<MemberDescriptor>>();

        public static PropertyDescriptor GetProperty(object source, string propertyName)
        {
            return GetProperty(source.GetType(), propertyName);
        }
        public static PropertyDescriptor GetProperty(Type sourceType, string propertyName)
        {
            lock (syncObj)
            {
                if (!members.ContainsKey(sourceType))
                {
                    members[sourceType] = new List<MemberDescriptor>();
                }
                var property = members[sourceType].SingleOrDefault(i => i.Name == propertyName && i is PropertyDescriptor);
                if (property == null)
                {
                    property = new PropertyDescriptor(sourceType.GetProperty(propertyName, Reflection.BindingFlags.Public | Reflection.BindingFlags.NonPublic | Reflection.BindingFlags.Instance | Reflection.BindingFlags.Static));
                    members[sourceType].Add(property);
                }
                return (PropertyDescriptor)property;
            }
        }
    }
}
