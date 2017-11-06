using System.Collections.Generic;
using System.Linq;

namespace System.Windows.Forms.Internals
{
    internal class SourceTypeDescriptor
    {
        private static readonly Dictionary<Type, List<SourceMemberDescriptor>> members = new Dictionary<Type, List<SourceMemberDescriptor>>();

        private static readonly object syncObj = new object();

        public static SourceEventDescriptor GetEvent(object source, string eventName)
        {
            return GetEvent(source.GetType(), eventName);
        }

        public static SourceEventDescriptor GetEvent(Type sourceType, string eventName)
        {
            return GetOrCreateMember(sourceType, eventName, (type, evn) =>
            {
                var property = new SourceEventDescriptor(type.GetEvent(evn, Reflection.BindingFlags.Public | Reflection.BindingFlags.NonPublic | Reflection.BindingFlags.Instance | Reflection.BindingFlags.Static));
                return property;
            });
        }

        public static SourcePropertyDescriptor GetProperty(object source, string propertyName)
        {
            return GetProperty(source.GetType(), propertyName);
        }

        public static SourcePropertyDescriptor GetProperty(Type sourceType, string propertyName)
        {
            return GetOrCreateMember(sourceType, propertyName, (type, pro) =>
            {
                var property = new SourcePropertyDescriptor(type.GetProperty(pro, Reflection.BindingFlags.Public | Reflection.BindingFlags.NonPublic | Reflection.BindingFlags.Instance | Reflection.BindingFlags.Static));
                return property;
            });
        }

        private static TDescriptor GetOrCreateMember<TDescriptor>(Type sourceType, string memberName, Func<Type, string, TDescriptor> createFunc) where TDescriptor : SourceMemberDescriptor
        {
            lock (syncObj)
            {
                if (!members.ContainsKey(sourceType))
                {
                    members[sourceType] = new List<SourceMemberDescriptor>();
                }
                var member = members[sourceType].SingleOrDefault(i => i.Name == memberName && i is TDescriptor);
                if (member == null)
                {
                    member = createFunc(sourceType, memberName);
                    if (member != null)
                    {
                        members[sourceType].Add(member);
                    }
                }
                return (TDescriptor)member;
            }
        }
    }
}
