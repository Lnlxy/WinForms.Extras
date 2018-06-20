// ***********************************************************************
// Author           : Hoze(hoze@live.cn)
// Created          : 06-20-2018
//
// ***********************************************************************
// <copyright file="CommandBinding.cs" company="Park Plus Inc.">
//     Copyright 2015 - 2018 (c) Park Plus Inc. All rights reserved.
// </copyright>
// ***********************************************************************

namespace System.Windows.Forms
{
    /// <summary>
    /// 命令绑定。
    /// </summary>
    internal class CommandBinding
    {
        #region Fields

        private readonly ICommand _command;

        private readonly IValueObject _commandParameter;

        private readonly CommandTarget _target;

        #endregion

        #region Constructors

        internal CommandBinding(ICommand command, CommandTarget target) : this(command, target, null)
        {
        }

        internal CommandBinding(ICommand command, CommandTarget target, IValueObject commandParameter)
        {
            _target = target;
            _command = command;
            _commandParameter = commandParameter;
            target.DoEvent(OnTargetEventHandle);
            if (commandParameter != null)
            {
                commandParameter.ValueChanged += OnVlaueChanged;
            }
        }

        #endregion

        #region Methods

        private void OnTargetEventHandle(object sender, EventArgs e)
        {
            if (_command.CanExecute(_commandParameter?.Value))
            {
                _command.Execute(_commandParameter?.Value);
            }
        }

        private void OnVlaueChanged(object sender, EventArgs e)
        {
            _target.UpdateState(_command.CanExecute(_commandParameter?.Value));
        }

        #endregion
    }
}
