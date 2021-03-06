﻿// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using NuGet.Protocol.Core.Types;
using Newtonsoft.Json;
#if !DNXCORE50
using System.Net.Cache;

#endif

namespace NuGet.Protocol.Core.v3.Data
{
    /// <summary>
    /// A NuGet http client with support for authentication, proxies, and caching.
    /// </summary>
    public sealed class DataClient : HttpClient
    {
        private bool _disposed;
        private readonly INuGetMessageHandlerProvider[] _modifiers;

        /// <summary>
        /// Raw constructor that allows full overriding of all caching and default DataClient behavior.
        /// </summary>
        public DataClient(HttpMessageHandler handler)
            : base(handler)
        {
            if (handler == null)
            {
                throw new ArgumentNullException("handler");
            }

            // Set user agent
            var userAgent = UserAgent.CreateUserAgentStringForVisualStudio(UserAgent.NuGetClientName);
            UserAgent.SetUserAgent(this, userAgent);
        }

        /// <summary>
        /// DataClient with the default options and caching support
        /// </summary>
        public DataClient()
            : this(CachingHandler)
        {
        }

        /// <summary>
        /// Internal constructor for building the final handler
        /// </summary>
        internal DataClient(HttpClientHandler handler, IEnumerable<INuGetMessageHandlerProvider> modifiers)
            : this(AssembleHandlers(handler, modifiers))
        {
            _modifiers = modifiers.ToArray();
        }

        /// <summary>
        /// Default caching handler used by the data client
        /// </summary>
        public static HttpClientHandler DefaultHandler
        {
            get { return AssembleHandlers(CachingHandler, Enumerable.Empty<INuGetMessageHandlerProvider>()); }
        }

        /// <summary>
        /// Chain the handlers together
        /// </summary>
        private static HttpClientHandler AssembleHandlers(HttpClientHandler handler, IEnumerable<INuGetMessageHandlerProvider> modifiers)
        {
            // final retry logic
            // RetryHandler retryHandler = new RetryHandler(handler, 5);

            // auth & proxy
            //RequestModifierHandler modHandler = new RequestModifierHandler(handler, modifiers);

            //return modHandler;

            return handler;
        }

        /// <summary>
        /// Retrieve a json file
        /// </summary>
        public JObject GetJObject(Uri address)
        {
            var task = GetJObjectAsync(address, CancellationToken.None);
            task.Wait();

            return task.Result;
        }

        /// <summary>
        /// Retrieve a json file
        /// </summary>
        public async Task<JObject> GetJObjectAsync(Uri address)
        {
            return await GetJObjectAsync(address, CancellationToken.None);
        }

        /// <summary>
        /// Retrieve a json file with caching
        /// </summary>
        public async Task<JObject> GetJObjectAsync(Uri address, CancellationToken token)
        {
            var response = await GetAsync(address, token);
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();

            return await Task.Run(() =>
                {
                    return JObject.Parse(json);
                });
        }

        private static HttpClientHandler CachingHandler
        {
            get
            {
#if !DNXCORE50
                return new WebRequestHandler()
                    {
                        CachePolicy = new RequestCachePolicy(RequestCacheLevel.Default)
                    };
#else
                return new HttpClientHandler();
#endif
            }
        }

        private static HttpMessageHandler NoCacheHandler
        {
            get
            {
#if !DNXCORE50
                return new WebRequestHandler()
                    {
                        CachePolicy = new RequestCachePolicy(RequestCacheLevel.BypassCache)
                    };
#else
                return new HttpClientHandler();
#endif
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && !_disposed)
            {
                _disposed = true;
            }

            base.Dispose(disposing);
        }
    }
}
