﻿namespace Jshop.Droid
{
    using Android.App;
    using Android.OS;
    using Android.Runtime;
    using Plugin.CurrentActivity;
    using System;

    #if DEBUG
        [Application(Debuggable = true)]
    #else
        [Application(Debuggable = false)]
    #endif
    public partial class MainApplication : Application, Application.IActivityLifecycleCallbacks
    {
        public MainApplication(IntPtr handle, JniHandleOwnership transer) : base(handle, transer) { }

        public override void OnCreate()
        {
            base.OnCreate();
            CrossCurrentActivity.Current.Init(this);
            RegisterActivityLifecycleCallbacks(this);
        }

        public override void OnTerminate()
        {
            base.OnTerminate();
            UnregisterActivityLifecycleCallbacks(this);
        }

        public void OnActivityCreated(Activity activity, Bundle savedInstanceState) => CrossCurrentActivity.Current.Activity = activity;

        public void OnActivityDestroyed(Activity activity) { }

        public void OnActivityPaused(Activity activity) { }

        public void OnActivityResumed(Activity activity) => CrossCurrentActivity.Current.Activity = activity;

        public void OnActivitySaveInstanceState(Activity activity, Bundle outState) { }

        public void OnActivityStarted(Activity activity) => CrossCurrentActivity.Current.Activity = activity;

        public void OnActivityStopped(Activity activity) { }
    }
}