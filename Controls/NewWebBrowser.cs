using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using DeclineAplay.Utils;

namespace DeclineAplay.Controls
{
    public partial class NewWebBrowser : WebBrowser
    {
        // Fields
        private AxHost.ConnectionPointCookie cookie;
        private WebBrowserExtendedEvents events;

        // Events
        public event EventHandler BeforeNavigate;

        public event EventHandler BeforeNewWindow;

        // Methods
        protected override void CreateSink()
        {
            base.CreateSink();
            this.events = new WebBrowserExtendedEvents(this);
            this.cookie = new AxHost.ConnectionPointCookie(base.ActiveXInstance, this.events, typeof(DWebBrowserEvents2));
        }

        protected override void DetachSink()
        {
            if (this.cookie != null)
            {
                this.cookie.Disconnect();
                this.cookie = null;
            }
            base.DetachSink();
        }

        protected void OnBeforeNavigate(string url, string frame, out bool cancel)
        {
            EventHandler beforeNavigate = this.BeforeNavigate;
            WebBrowserExtendedNavigatingEventArgs e = new WebBrowserExtendedNavigatingEventArgs(url, frame);
            if (beforeNavigate != null)
            {
                beforeNavigate(this, e);
            }
            cancel = e.Cancel;
        }

        protected void OnBeforeNewWindow(string url, out bool cancel)
        {
            EventHandler beforeNewWindow = this.BeforeNewWindow;
            WebBrowserExtendedNavigatingEventArgs e = new WebBrowserExtendedNavigatingEventArgs(url, null);
            if (beforeNewWindow != null)
            {
                beforeNewWindow(this, e);
            }
            cancel = e.Cancel;
        }

        // Nested Types
        [ComImport, Guid("34A715A0-6587-11D0-924A-0020AFC7AC4D"), InterfaceType(ComInterfaceType.InterfaceIsIDispatch), TypeLibType(TypeLibTypeFlags.FHidden)]
        public interface DWebBrowserEvents2
        {
            [DispId(250)]
            void BeforeNavigate2([In, MarshalAs(UnmanagedType.IDispatch)] object pDisp, [In] ref object URL, [In] ref object flags, [In] ref object targetFrameName, [In] ref object postData, [In] ref object headers, [In, Out] ref bool cancel);
            [DispId(0x111)]
            void NewWindow3([In, MarshalAs(UnmanagedType.IDispatch)] object pDisp, [In, Out] ref bool cancel, [In] ref object flags, [In] ref object URLContext, [In] ref object URL);
        }

        private class WebBrowserExtendedEvents : StandardOleMarshalObject, NewWebBrowser.DWebBrowserEvents2
        {
            // Fields
            private NewWebBrowser _Browser;

            // Methods
            public WebBrowserExtendedEvents(NewWebBrowser browser)
            {
                this._Browser = browser;
            }

            public void BeforeNavigate2(object pDisp, ref object URL, ref object flags, ref object targetFrameName, ref object postData, ref object headers, ref bool cancel)
            {
                this._Browser.OnBeforeNavigate((string)URL, (string)targetFrameName, out cancel);
            }

            public void NewWindow3(object pDisp, ref bool cancel, ref object flags, ref object URLContext, ref object URL)
            {
                this._Browser.OnBeforeNewWindow((string)URL, out cancel);
            }
        }
    }
}
