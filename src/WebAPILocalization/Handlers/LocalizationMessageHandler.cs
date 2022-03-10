﻿using System.Collections.Generic;
using System.Net.Http;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;

namespace WebAPILocalization.Handlers
{
    public class LocalizationMessageHandler : DelegatingHandler
    {
        private readonly List<string> _supportedLanguages = new List<string>() { "tr-TR", "en-US" };

        protected override async Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request, CancellationToken cancellationToken)
        {
            SetCulture(request);

            var response = await base.SendAsync(request, cancellationToken);
            return response;
        }

        #region Private Methods
        private void SetCulture(HttpRequestMessage request)
        {
            foreach (var loopLanguage in request.Headers.AcceptLanguage)
            {
                // Desteklediğimiz dillerden biri var ise culture bilgisini o dile göre güncelliyoruz.
                if (_supportedLanguages.Contains(loopLanguage.Value))
                {
                    Thread.CurrentThread.CurrentCulture = new CultureInfo(loopLanguage.Value);
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo(loopLanguage.Value);

                    break;
                }
            }
        }
        #endregion
    }
}