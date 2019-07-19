using System;
using System.Net.Http;
using System.IO;

private static readonly HttpClient client = new HttpClient();

public static async void GetStringAsync(ILogger log, string url, string path)
{
  var logText = String.Empty;
  var resStr = String.Empty;
  var response = await client.GetAsync(url);
  var logDir = @path;
  var logFile = "log.txt";
  var logPath = Path.Combine(logDir, logFile);

  if (response.IsSuccessStatusCode)
  {
    logText = "Response collected for " + url;
  }
  else
  {
    logText = "Error response: " + response;
  }

  resStr = DateTime.Now + " : " + logText;
  log.LogInformation(resStr);
  File.AppendAllText(logPath, resStr + Environment.NewLine);
}

public static void CheckFinn(ILogger log, ExecutionContext context)
{
   GetStringAsync(log, "https://finn-mining.azurewebsites.net/links?scan=yes", context.FunctionDirectory);
   GetStringAsync(log, "https://finn-mining.azurewebsites.net/price?scan=yes", context.FunctionDirectory);
}

public static void Run(TimerInfo myTimer, ILogger log, ExecutionContext context)
{
   log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");
   CheckFinn(log, context);
}
