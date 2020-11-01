using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace DeclineAplay.Utils
{
    public class WebBrowserExtendedNavigatingEventArgs : CancelEventArgs
    {
        // Fields
        private string _Url;
        private string _Frame;

        // Methods
        public WebBrowserExtendedNavigatingEventArgs(string url, string frame)
        {
            this._Url = url;
            this._Frame = frame;
        }

        // Properties
        public string Url =>
            this._Url;

        public string Frame =>
            this._Frame;
    }
}
