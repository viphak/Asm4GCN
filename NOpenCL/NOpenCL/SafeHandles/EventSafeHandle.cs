﻿/*
 * Copyright (c) Tunnel Vision Laboratories, LLC. All rights reserved.
 * Licensed under the MIT license. See LICENSE file in the project root for full license information.
 * Modified for use in Asm4GCN. See https://github.com/tunnelvisionlabs/NOpenCL for original.*/

namespace NOpenCL.SafeHandles
{
    using Microsoft.Win32.SafeHandles;

    public sealed class EventSafeHandle : SafeHandleZeroOrMinusOneIsInvalid
    {
        public EventSafeHandle()
            : base(true)
        {
        }

        protected override bool ReleaseHandle()
        {
            ErrorCode result = UnsafeNativeMethods.clReleaseEvent(handle);
            return result == ErrorCode.Success;
        }
    }
}
