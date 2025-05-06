using System.IO;
using System.Threading.Tasks;
using System.Collections.Generic;

using KIT_Plugin_Manger;

namespace KIT_Plugin_test {
    public class OnLoad : IHandler {
        public string Endpoint => "/hello";

        public async Task IModule(RequestData rq, StreamWriter wri, IClientContext cli) {
            Logger.Log("EXAMPLE PLUGIN", "Hello, im a built in logger for cool console stuff :D");

            await RSY.FSender(wri, "OSender", "/hello", new Dictionary<string, string> {
               { "Message", "HI, im a example plugin p-p" }
            });
        }
    }
}