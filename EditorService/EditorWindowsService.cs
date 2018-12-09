using System;
using System.ServiceModel;
using System.ServiceProcess;
using KMA.APZRPMJ2018.TextEditor.Tools;

namespace KMA.APZRPMJ2018.TextEditor.EditorService
{
    public class EditorWindowsService : ServiceBase
    {
        internal const string CurrentServiceName = "TextEditorService1";
        internal const string CurrentServiceDisplayName = "Text Editor Service1";
        internal const string CurrentServiceSource = "TextEditorServiceSource1";
        internal const string CurrentServiceLogName = "TextEditorServiceLogName1";
        internal const string CurrentServiceDescription = "Text Editor for learning purposes1.";
        private ServiceHost _serviceHost = null;

        public EditorWindowsService()
        {
            ServiceName = CurrentServiceName;
            try
            {
                AppDomain.CurrentDomain.UnhandledException += UnhandledException;
                Logger.Log("Initialization");
            }
            catch (Exception ex)
            {
                Logger.Log("Initialization", ex);
            }
        }

        protected override void OnStart(string[] args)
        {
            Logger.Log("OnStart");
            RequestAdditionalTime(120 * 1000);

            try
            {
                if (_serviceHost != null)
                {
                    _serviceHost.Close();
                }
            }
            catch
            {
            }
            try
            {
                _serviceHost = new ServiceHost(typeof(TextEditorService));
                _serviceHost.Open();
            }
            catch (Exception ex)
            {
                Logger.Log("OnStart", ex);
                throw;
            }
            Logger.Log("Service Started");
        }

        protected override void OnStop()
        {
            Logger.Log("OnStop");
            RequestAdditionalTime(120 * 1000);
            try
            {
                _serviceHost.Close();
            }
            catch (Exception ex)
            {
                Logger.Log("Trying To Stop The Host Listener", ex);
            }
            Logger.Log("Service Stopped");
        }

        private void UnhandledException(object sender, UnhandledExceptionEventArgs args)
        {
            var ex = (Exception)args.ExceptionObject;
            
            Logger.Log("UnhandledException", ex);
        }
    }
}
