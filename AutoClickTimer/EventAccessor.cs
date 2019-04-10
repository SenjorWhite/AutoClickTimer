using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace AutoClickTimer
{
    class EventAccessor
    {
        public List<ClickEvent> ReadEventFile(string filePath)
        {
            List<ClickEvent> events = new List<ClickEvent>();

            using (StreamReader file = File.OpenText(filePath))
            {
                JsonSerializer serializer = new JsonSerializer();
                events = (List<ClickEvent>)serializer.Deserialize(file, typeof(List<ClickEvent>));
            }
            
            return events;
        }

        public void WriteEventFile(string filePath,List<ClickEvent> events)
        {
            using (StreamWriter file = File.CreateText(filePath))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, events);
            }
        }
    }
}
