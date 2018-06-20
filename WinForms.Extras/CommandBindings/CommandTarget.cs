// ***********************************************************************
// Author           : Hoze(hoze@live.cn)
// Created          : 06-20-2018
//
// ***********************************************************************
// <copyright file="CommandTarget.cs" company="Park Plus Inc.">
//     Copyright 2015 - 2018 (c) Park Plus Inc. All rights reserved.
// </copyright>
// ***********************************************************************

using System.ComponentModel;
using System.Linq;

namespace System.Windows.Forms
{
    /// <summary>
    /// 命令目标组件。
    /// </summary>
    internal sealed class CommandTarget
    {
        #region Fields

        private readonly Internals.SourceEventDescriptor _defaultEvent;

        private readonly Internals.SourcePropertyDescriptor _enabledProperty;

        #endregion

        #region Constructors

        internal CommandTarget(Component component)
        {
            Component = component;
            var eventName = GetDefaultEventName(component.GetType());
            _defaultEvent = Internals.SourceTypeDescriptor.GetEvent(component, eventName);
            _enabledProperty = Internals.SourceTypeDescriptor.GetProperty(component, "Enabled");
        }

        internal CommandTarget(Component component, string eventName)
        {
            Component = component;
            _defaultEvent = Internals.SourceTypeDescriptor.GetEvent(component, eventName);
            _enabledProperty = Internals.SourceTypeDescriptor.GetProperty(component, "Enabled");
        }

        #endregion

        #region Properties

        public Component Component { get; private set; }

        #endregion

        #region Methods

        public void DoEvent(EventHandler eventHandler)
        {
            _defaultEvent.AddEventHandler(Component, eventHandler);
        }

        public void UpdateState(bool state)
        {
            _enabledProperty.SetValue(Component, state);
        }

        private static string GetDefaultEventName(Type type)
        {
            var attribute = type.GetCustomAttributes(typeof(DefaultEventAttribute), true).FirstOrDefault() as DefaultEventAttribute;
            return attribute?.Name ?? string.Empty;
        }

        #endregion
    }
}
