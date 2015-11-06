using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CefSharp;
using System.Threading;
using System.Threading.Tasks;

namespace CefSharp.MinimalExample.WinForms
{

    class CallbackResponseClass
    {
        public string Name;

        public CallbackResponseClass(string name)
        {
            Name = name;
        }
    }

    struct CallbackResponseStruct
    {
        public string Name;

        public CallbackResponseStruct(string name)
        {
            Name = name;
        }
    }


    class BoundObject
    {


        public BoundObject()
        {
        }

        public void TestCallbackString(IJavascriptCallback javascriptCallback)
        {
            const int taskDelay = 500;

            Task.Run(async () =>
            {
                await Task.Delay(taskDelay);

                using (javascriptCallback)
                {
                    await javascriptCallback.ExecuteAsync("This callback from C# was delayed " + taskDelay + "ms");
                }
            });
        }

        public void TestCallbackStruct(IJavascriptCallback javascriptCallback)
        {
            const int taskDelay = 500;

            Task.Run(async () =>
            {
                await Task.Delay(taskDelay);

                using (javascriptCallback)
                {
                    CallbackResponseStruct response = new CallbackResponseStruct("Test");
                    await javascriptCallback.ExecuteAsync(response);
                }
            });
        }

        public void TestCallbackClass(IJavascriptCallback javascriptCallback)
        {
            const int taskDelay = 500;

            Task.Run(async () =>
            {
                await Task.Delay(taskDelay);

                using (javascriptCallback)
                {
                    CallbackResponseClass response = new CallbackResponseClass("Test");
                    try
                    {
                        javascriptCallback.ExecuteAsync(response);
                    }
                    catch (Exception ex)
                    {
                        javascriptCallback.ExecuteAsync(string.Format("Error: {0}", ex.Message));
                    }
                }
            });
        }


    }
}
