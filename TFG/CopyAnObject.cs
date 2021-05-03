using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace TFG
{
    [Serializable]
    internal static class CopyAnObject<T>
    {
        internal static T Copiar(T obj)
        {
            T objCopy;
            MemoryStream ms = new MemoryStream();
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(ms, obj);
            ms.Position = 0;
            objCopy = (T)bf.Deserialize(ms);
            ms.Close();
            return objCopy;
        }

    }
}
