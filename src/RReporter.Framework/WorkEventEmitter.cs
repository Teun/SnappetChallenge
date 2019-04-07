using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RReporter.Application.StoreWorkEvent;

namespace RReporter.Framework
{

    public class WorkEventEmitter
    {
        private readonly IWorkEventHandler workEventHandler;

        public WorkEventEmitter (IWorkEventHandler workEventHandler)
        {
            this.workEventHandler = workEventHandler;
        }

        public async Task EmitEventsUntilAsync (DateTime untilTime)
        {
            IEnumerable<WorkEventDto> events = EnumerateAllWorkEvents ();

            foreach (var e in events)
            {
                if (e.SubmitDateTime > untilTime)
                    return;
                await workEventHandler.HandleAsync (e);
            }
        }

        public async Task EmitAllEventsAsync (DateTime nowTime)
        {
            var offset = DateTime.UtcNow - nowTime;
            IEnumerable<WorkEventDto> events = EnumerateAllWorkEvents ();
            foreach (var e in events)
            {
                while (e.SubmitDateTime > (DateTime.UtcNow - offset))
                    await Task.Delay (e.SubmitDateTime - (DateTime.UtcNow - offset));
                await workEventHandler.HandleAsync (e);
            }
        }

        private IEnumerable<WorkEventDto> EnumerateAllWorkEvents ()
        {
            // register code pages to let win-1252 encoding work
            string myDirectory = Path.GetDirectoryName (typeof (WorkEventEmitter).Assembly.Location);
            string pathToWorkJson = Path.Combine (myDirectory, "Data", "work.json");
            var serializer = new JsonSerializer () {DateTimeZoneHandling = DateTimeZoneHandling.Utc};
            

            using (Stream file = File.OpenRead (pathToWorkJson))
            using (TextReader rdr = new StreamReader (file, Encoding.UTF8))
            using (JsonReader jrdr = new JsonTextReader (rdr))
            {
                return serializer.Deserialize<IEnumerable<WorkEventDto>> (jrdr);
            }
        }
    }
}