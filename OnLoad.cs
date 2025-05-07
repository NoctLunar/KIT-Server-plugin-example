using System.IO;
using System.Threading.Tasks;
using System.Collections.Generic;

using KIT_Plugin_Manger;

// you can pull data out of the headers sent from the client
// example here checking if the ApplicationID sennt in the header is allowed to use this plugin
// Do note we already have internal checks to prevent clients that arent logged in for your application from using your plugin :D
// this is just a plugin example

namespace KIT_Plugin_test {
    public class OnLoad : IHandler {
        public string Endpoint => "/hello";

        public async Task IModule(RequestData rq, StreamWriter wri, IClientContext cli) {
            if (rq.Headers.GetValueOrDefault("AppID") != "1") {
                Logger.Log("EXAMPLE PLUGIN", "Someone called plugins endpoint, but this plugin inst allowed for this app");

                await RSY.FSender(wri, "OSender", Endpoint, new Dictionary<string, string> {
                   { "Message", "Unauthorised" }
                });
            } else {
                Logger.Log("EXAMPLE PLUGIN", "Hello, im a built in logger for cool console stuff :D");

                await RSY.FSender(wri, "OSender", Endpoint, new Dictionary<string, string> {
                   { "Message", $"Hello {rq.Headers.GetValueOrDefault("Username")}, this is a example plugin" }
                });
            }
        }
    }
}
