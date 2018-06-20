// ***********************************************************************
// Author           : Hoze(hoze@live.cn)
// Created          : 06-20-2018
//
// ***********************************************************************
// <copyright file="SourceMemberDescriptor.cs" company="Park Plus Inc.">
//     Copyright 2015 - 2018 (c) Park Plus Inc. All rights reserved.
// </copyright>
// ***********************************************************************

namespace System.Windows.Forms.Internals
{
    internal abstract class SourceMemberDescriptor
    {
        #region Constructors

        public SourceMemberDescriptor(string name)
        {
            Name = name;
        }

        #endregion

        #region Properties

        public string Name { get; private set; }

        #endregion
    }
}
