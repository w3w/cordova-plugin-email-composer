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
            string subject = jsOptions[0];
            string text = jsOptions[1];

            EmailComposeTask emailComposeTask = new EmailComposeTask();

            emailComposeTask.Subject = subject;
            emailComposeTask.Body = text;

            emailComposeTask.Show();
        }
    }
}
