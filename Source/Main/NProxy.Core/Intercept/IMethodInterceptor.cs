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

namespace NProxy.Core.Intercept
{
    /// <summary>
    /// Defines a method interceptor.
    /// </summary>
    public interface IMethodInterceptor : IInterceptor
    {
        /// <summary>
        /// Implement this method to perform extra treatments before and after the invocation.
        /// Polite implementations would certainly like to invoke <see cref="IJoinpoint.Proceed()"/>.
        /// </summary>
        /// <param name="invocation">The method invocation joinpoint.</param>
        /// <returns>The result of the call to <see cref="IJoinpoint.Proceed()"/>,
        /// might be intercepted by the interceptor.</returns>
        object Invoke(IMethodInvocation invocation);
    }
}