// Here is a basic clientside function for the example plugin 

public async Task Plugintest(string usr) {
   await _sem.WaitAsync(); // We higly recommend you use our semaphore in any client side action/request you make to keep compatibility with internally built commands
   try  {

    // here you see the method is OSender, just like the serversided, now in the sense it doesnt matter what you name the method, we are just using this to simplify internal commands
    // you can change this for your custom commands and handle it on your plugin to make your calls diffrent if you wish
    await RSY.FSender(_wri, "OSender", "/hello", new Dictionary<string, string> {
       { "AppID", Appid }, // Appid is a public string that is set when you create the client 
       { "Username", usr }, // This currently for testing is just being passed a param but will be made like the Appid later
    });

    // Just like on the server you pull header data out the same way
    var rq = await RequestData.Read(_rea);

    Logger.Log("TEST", $"{rq.Headers.GetValueOrDefault("Message")}");
  } finally {
    _sem.Release();
  }
}