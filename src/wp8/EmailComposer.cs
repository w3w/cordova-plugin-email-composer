using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Phone.Tasks;
using WPCordovaClassLib.Cordova;
using WPCordovaClassLib.Cordova.Commands;
using WPCordovaClassLib.Cordova.JSON;

namespace Cordova.Extension.Commands
{
    class EmailComposer : BaseCommand
    {
        public void open(string options)
        {
            string[] jsOptions = JsonHelper.Deserialize<string[]>(options);

            //epic hack to convert JS object to array which can be deserialized
            char[] charsToTrim = { '}' };
            string arrayString = jsOptions[0].Replace("{\"recipients\":[", "[").Replace("],\"subject\":", ",").Replace("\"body\":", "").TrimEnd(charsToTrim) + "]";

            string[] data = JsonHelper.Deserialize<string[]>(arrayString);
            string recipient = data[0];
            string subject = data[1];
            string text = data[2];

            EmailComposeTask emailComposeTask = new EmailComposeTask();

            emailComposeTask.To = recipient;
            emailComposeTask.Subject = subject;
            emailComposeTask.Body = text;

            emailComposeTask.Show();
        }

        public void isServiceAvailable(string options)
        {
            PluginResult result = new PluginResult(PluginResult.Status.OK, "{\"message\":\"ok\"}");
            result.KeepCallback = false;
            this.DispatchCommandResult(result);
        }
    }
}
