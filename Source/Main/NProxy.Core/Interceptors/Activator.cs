﻿//
// NProxy is a library for the .NET framework to create lightweight dynamic proxies.
// Copyright © Martin Tamme
//
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU Lesser General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
// GNU Lesser General Public License for more details.
//
// You should have received a copy of the GNU Lesser General Public License
// along with this program. If not, see <http://www.gnu.org/licenses/>.
//

using System;
using NProxy.Core.Interceptors.Language;

namespace NProxy.Core.Interceptors
{
    /// <summary>
    /// Represents an activator.
    /// </summary>
    /// <typeparam name="T">The declaring type.</typeparam>
    internal sealed class Activator<T> : IActivator<T> where T : class
    {
        /// <summary>
        /// The proxy.
        /// </summary>
        private readonly IProxy<T> _proxy;

        /// <summary>
        /// The invocation handler.
        /// </summary>
        private readonly IInvocationHandler _invocationHandler;

        /// <summary>
        /// The arguments.
        /// </summary>
        private readonly object[] _arguments;

        /// <summary>
        /// Initializes a new instance of the <see cref="Activator{T}"/> class.
        /// </summary>
        /// <param name="proxy">The proxy.</param>
        /// <param name="invocationHandler">The invocation handler.</param>
        /// <param name="arguments">The arguments.</param>
        public Activator(IProxy<T> proxy, IInvocationHandler invocationHandler, object[] arguments)
        {
            if (proxy == null)
                throw new ArgumentNullException("proxy");

            if (invocationHandler == null)
                throw new ArgumentNullException("invocationHandler");

            if (arguments == null)
                throw new ArgumentNullException("proxy");

            _proxy = proxy;
            _invocationHandler = invocationHandler;
            _arguments = arguments;
        }

        #region IActivator<T> Members

        /// <inheritdoc/>
        public TInterface AdaptInstance<TInterface>(object instance) where TInterface : class
        {
            return _proxy.AdaptInstance<TInterface>(instance);
        }

        /// <inheritdoc/>
        public T CreateInstance()
        {
            return _proxy.CreateInstance(_invocationHandler, _arguments);
        }

        #endregion
    }
}