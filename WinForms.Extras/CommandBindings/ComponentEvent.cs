// ***********************************************************************
// Author           : Hoze(hoze@live.cn)
// Created          : 06-20-2018
//
// ***********************************************************************
// <copyright file="ComponentEvent.cs" company="Park Plus Inc.">
//     Copyright 2015 - 2018 (c) Park Plus Inc. All rights reserved.
// </copyright>
// ***********************************************************************

using System.ComponentModel;
using System.Linq.Expressions;

namespace System.Windows.Forms
{
    public sealed class ComponentEvent
    {
        #region Fields

        private readonly CommandTarget commandTarget;

        #endregion

        #region Constructors

        public ComponentEvent(Component component, string eventName)
        {
            commandTarget = new CommandTarget(component, eventName);
        }

        #endregion

        #region Methods

        /// <summary>
        /// 添加命令。
        /// </summary>
        /// <param name="command">命令。</param>
        /// <returns>返回 <see cref="CommandBinding"/> 新实例。</returns>
        public void Command(ICommand command)
        {
            new CommandBinding(command, commandTarget);
        }

        /// <summary>
        /// 添加命令。
        /// </summary>
        /// <param name="command">命令。</param>
        /// <param name="commandParameter">命令执行参数。</param>
        /// <returns>返回 <see cref="CommandBinding"/> 新实例。</returns>
        public void Command(ICommand command, IValueObject commandParameter)
        {
            new CommandBinding(command, commandTarget, commandParameter);
        }

        /// <summary>
        /// 添加命令。
        /// </summary>
        /// <typeparam name="TSource">数据源类型。</typeparam>
        /// <typeparam name="TParameter">数据源成员。</typeparam>
        /// <param name="command">命令。</param>
        /// <param name="source">数据源。</param>
        /// <param name="expression">参数表达式。</param>
        /// <returns>返回 <see cref="CommandBinding"/> 新实例。</returns>
        public void Command<TSource, TParameter>(ICommand command, TSource source, Expression<Func<TSource, TParameter>> expression)
        {
            var member = expression.Body as MemberExpression;
            if (member.Member.MemberType != Reflection.MemberTypes.Property)
            {
                throw new InvalidOperationException($"{member.Member.Name} is not a property.");
            }
            Command(command, source.CreateBindableValue(expression));
        }

        /// <summary>
        /// 添加命令。
        /// </summary>
        /// <param name="command">命令。</param>
        /// <param name="commandParameter">命令执行参数。</param>
        /// <returns>返回 <see cref="CommandBinding"/> 新实例。</returns>
        public void Command(ICommand command, ValueObject commandParameter)
        {
            new CommandBinding(command, commandTarget, commandParameter);
        }

        #endregion
    }
}
