// ***********************************************************************
// Author           : Hoze(hoze@live.cn)
// Created          : 06-20-2018
//
// ***********************************************************************
// <copyright file="SourceEventDescriptor.cs" company="Park Plus Inc.">
//     Copyright 2015 - 2018 (c) Park Plus Inc. All rights reserved.
// </copyright>
// ***********************************************************************

using System.Reflection;

namespace System.Windows.Forms.Internals
{
    internal class SourceEventDescriptor : SourceMemberDescriptor
    {
        #region Fields

        private readonly EventInfo _event;

        #endregion

        #region Constructors

        public SourceEventDescriptor(EventInfo eventInfo) : base(eventInfo.Name)
        {
            _event = eventInfo;
        }

        #endregion

        #region Methods

        public void AddEventHandler(object target, EventHandler handler)
        {
            _event.AddEventHandler(target, handler);
        }

        public void RemoveEventHandler(object target, EventHandler handler)
        {
            _event.RemoveEventHandler(target, handler);
        }

        #endregion
    }
}
