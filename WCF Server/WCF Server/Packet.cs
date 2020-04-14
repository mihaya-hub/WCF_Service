using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace WCF_Server
{
    class DataPacket
    {
        public static byte[] Serialize(object data)
        {
            try
            {
                MemoryStream ms = new MemoryStream(1024);
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(ms, data);

                return ms.ToArray();
            }
            catch
            {
                return null;
            }
        }

        public static object Deserialize(byte[] data)
        {
            try
            {
                MemoryStream ms = new MemoryStream(1024);
                ms.Write(data, 0, data.Length);

                ms.Position = 0;
                BinaryFormatter bf = new BinaryFormatter();

                object obj = bf.Deserialize(ms);
                ms.Close();

                return obj;
            }
            catch
            {
                return null;
            }
        }
    }
}