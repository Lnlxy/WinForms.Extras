// ***********************************************************************
// Author           : Hoze(hoze@live.cn)
// Created          : 06-20-2018
//
// ***********************************************************************
// <copyright file="ComponentEventExtensions.cs" company="Park Plus Inc.">
//     Copyright 2015 - 2018 (c) Park Plus Inc. All rights reserved.
// </copyright>
// ***********************************************************************

using System.ComponentModel;
using System.Linq;

namespace System.Windows.Forms
{
    /// <summary>
    /// 对组件的拓展。
    /// </summary>
    public static class ComponentEventExtensions
    {
        #region Methods

        /// <summary>
        /// 创建组件的默认事件信息。
        /// </summary>
        /// <param name="component">组件。</param>
        /// <returns></returns>
        public static ComponentEvent Event(this Component component)
        {
            var attribute = component.GetType().GetCustomAttributes(typeof(DefaultEventAttribute), true).FirstOrDefault() as DefaultEventAttribute;
            return Event(component, attribute.Name);
        }

        /// <summary>
        /// 创建组件指定名称的事件信息。
        /// </summary>
        /// <param name="component">组件。</param>
        /// <param name="eventName">事件名称。</param>
        /// <returns></returns>
        public static ComponentEvent Event(this Component component, string eventName)
        {
            return new ComponentEvent(component, eventName);
        }

        #endregion
    }
}
