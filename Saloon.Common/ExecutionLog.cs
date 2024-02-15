using Newtonsoft.Json;

namespace Saloon.Common
{
    public class ExecutionLog
  {
    public void LogException(dynamic log, string path)
    {
      var exString = JsonConvert.SerializeObject(log, Formatting.Indented,
                    new JsonSerializerSettings()
                    {
                      ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                    });
      var mk = new MakeLog();
      mk.ErrorLog(path, "routeexectionlogs/logs.txt", exString);
    }

    public void LogExceptionDumm(dynamic log, string path)
    {
      var exString = JsonConvert.SerializeObject(log, Formatting.Indented,
                    new JsonSerializerSettings()
                    {
                      ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                    });
      var mk = new MakeLog();
      mk.ErrorLog(path, "routeexectionlogs/logsnoterror.txt", exString);
    }
  }
}
