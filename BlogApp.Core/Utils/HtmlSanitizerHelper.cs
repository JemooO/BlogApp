using Ganss.XSS;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogApp.Core.Utils
{
    public class HtmlSanitizerHelper
    {
        private static HtmlSanitizer _sanitizer;
        private static readonly object _lock = new object();
        public static HtmlSanitizer Sanitizer
        {
            get
            {
                if (_sanitizer == null)
                    lock (_lock)
                    {
                        if (_sanitizer == null)
                            _sanitizer = new HtmlSanitizer();
                    }
                return _sanitizer;
            }
        }
    }
}
