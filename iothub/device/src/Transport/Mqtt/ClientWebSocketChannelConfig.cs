// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.Devices.Client.Transport.Mqtt
{
    using System;
    using System.Diagnostics.Contracts;
    using DotNetty.Buffers;
    using DotNetty.Transport.Channels;

    public class ClientWebSocketChannelConfig : IChannelConfiguration
    {
        public T GetOption<T>(ChannelOption<T> option)
        {
            Contract.Requires(option != null);

            if (ChannelOption.ConnectTimeout.Equals(option))
            {
                return (T)(object)this.ConnectTimeout; // no boxing will happen, compiler optimizes away such casts
            }
            if (ChannelOption.WriteSpinCount.Equals(option))
            {
                return (T)(object)this.WriteSpinCount;
            }
            if (ChannelOption.Allocator.Equals(option))
            {
                return (T)this.Allocator;
            }
            if (ChannelOption.RcvbufAllocator.Equals(option))
            {
                return (T)this.RecvByteBufAllocator;
            }
            if (ChannelOption.AutoRead.Equals(option))
            {
                return (T)(object)this.AutoRead;
            }
            if (ChannelOption.WriteBufferHighWaterMark.Equals(option))
            {
                return (T)(object)this.WriteBufferHighWaterMark;
            }
            if (ChannelOption.WriteBufferLowWaterMark.Equals(option))
            {
                return (T)(object)this.WriteBufferLowWaterMark;
            }
            if (ChannelOption.MessageSizeEstimator.Equals(option))
            {
                return (T)this.MessageSizeEstimator;
            }
            return default(T);
        }

        public bool SetOption(ChannelOption option, object value) => option.Set(this, value);

        public bool SetOption<T>(ChannelOption<T> option, T value)
        {
            // this.Validate(option, value);

            if (ChannelOption.ConnectTimeout.Equals(option))
            {
                this.ConnectTimeout = (TimeSpan)(object)value;
            }
            else if (ChannelOption.WriteSpinCount.Equals(option))
            {
                this.WriteSpinCount = (int)(object)value;
            }
            else if (ChannelOption.Allocator.Equals(option))
            {
                this.Allocator = (IByteBufferAllocator)value;
            }
            else if (ChannelOption.RcvbufAllocator.Equals(option))
            {
                this.RecvByteBufAllocator = (IRecvByteBufAllocator)value;
            }
            else if (ChannelOption.AutoRead.Equals(option))
            {
                this.AutoRead = (bool)(object)value;
            }
            else if (ChannelOption.WriteBufferHighWaterMark.Equals(option))
            {
                this.WriteBufferHighWaterMark = (int)(object)value;
            }
            else if (ChannelOption.WriteBufferLowWaterMark.Equals(option))
            {
                this.WriteBufferLowWaterMark = (int)(object)value;
            }
            else if (ChannelOption.MessageSizeEstimator.Equals(option))
            {
                this.MessageSizeEstimator = (IMessageSizeEstimator)value;
            }
            else
            {
                return false;
            }

            return true;
        }

        public TimeSpan ConnectTimeout { get; set; }

        public int WriteSpinCount { get; set; }

        public IByteBufferAllocator Allocator { get; set; }

        public IRecvByteBufAllocator RecvByteBufAllocator { get; set; }

        public bool AutoRead { get; set; }

        public int WriteBufferHighWaterMark { get; set; }

        public int WriteBufferLowWaterMark { get; set; }

        public IMessageSizeEstimator MessageSizeEstimator { get; set; }
    }
}