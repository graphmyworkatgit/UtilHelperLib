using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters;

namespace UtilHelper.Serialization
{
    /*/
     * https://www.newtonsoft.com/json/help/html/DeserializeObject.htm
     * https://www.newtonsoft.com/json/help/html/SerializingJSONFragments.htm
     * https://www.thecodebuzz.com/newtonsoft-jsonreaderexception-could-not-convert-string-to-boolean/
     */
    class Serializer
    {
        //https://www.c-sharpcorner.com/blogs/serialize-and-deserialize-xml-file-into-c-sharp-object-and-vise-versa

    }

    class DeSerializer
    {

        public void DeSerializeLastState()
        {

        }
    }

    [Serializable()]
    public class LastRun:ISerializable
    {
        public string AppName { get; set; }
        public DateTime RunDate { get; set; }
        public DateTime RunTime { get; set; }

        public double weight { get; set; }
        public double height { get; set; }

        public void GetLastRunTime()
        {

        }
        public void SaveCurrentAppState(LastRun RunState,string FileNameWithPath)
        {

        }

        public void GetObjectData(SerializationInfo info, 
            StreamingContext context)
        {
            info.AddValue("Name", "TestSerial");
            info.AddValue("RunDate", "4/23/2021");
            info.AddValue("RunTime", "18:41");
            info.AddValue("weight", "80");
            info.AddValue("height", "5.8");
        }

        public LastRun(SerializationInfo info, StreamingContext context)
        {
            AppName = (string)info.GetValue("Name", typeof(string));
            weight = (double)info.GetValue("weight", typeof(double));
            height = (double)info.GetValue("height", typeof(double));

            Console.WriteLine($"{AppName} - {weight} - {height}");
        }
        public LastRun(string n, double w, double h)
        {
            AppName = n;
            weight = w;
            height = h;
        }

        public LastRun()
        {
            
        }

    }

}
