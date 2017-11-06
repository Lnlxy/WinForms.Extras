using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace System.Windows.Forms.Internals
{
    class SourceEventDescriptor : SourceMemberDescriptor
    {
        private readonly EventInfo _event;
        public SourceEventDescriptor(EventInfo eventInfo) : base(eventInfo.Name)
        {
            _event = eventInfo;
        }

        public void AddEventHandler(object target, EventHandler handler)
        {
            _event.AddEventHandler(target, handler);
        }

        public void RemoveEventHandler(object target, EventHandler handler)
        {
            _event.RemoveEventHandler(target, handler);
        }
    }
}
