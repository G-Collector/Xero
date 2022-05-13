using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Il2CppSystem;
using Il2CppSystem.IO;
using Il2CppSystem.Runtime.Serialization.Formatters.Binary;

namespace XeroLag
{
	internal static class Serialization
	{
		public static byte[] ToByteArray(Il2CppSystem.Object obj)
		{
			if (obj == null)
			{
				return null;
			}
			Il2CppSystem.Runtime.Serialization.Formatters.Binary.BinaryFormatter binaryFormatter = new Il2CppSystem.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
			Il2CppSystem.IO.MemoryStream memoryStream = new Il2CppSystem.IO.MemoryStream();
			binaryFormatter.Serialize(memoryStream, obj);
			return memoryStream.ToArray();
		}

		public static byte[] ToByteArray(object obj)
		{
			if (obj == null)
			{
				return null;
			}
			System.Runtime.Serialization.Formatters.Binary.BinaryFormatter binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
			System.IO.MemoryStream memoryStream = new System.IO.MemoryStream();
			binaryFormatter.Serialize(memoryStream, obj);
			return memoryStream.ToArray();
		}

		public static T FromByteArray<T>(byte[] data)
		{
			T result;
			if (data == null)
			{
				result = default(T);
				return result;
			}
			System.Runtime.Serialization.Formatters.Binary.BinaryFormatter binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
			using (System.IO.MemoryStream memoryStream = new System.IO.MemoryStream(data))
			{
				result = (T)((object)binaryFormatter.Deserialize(memoryStream));
			}
			return result;
		}

		public static T IL2CPPFromByteArray<T>(byte[] data)
		{
			if (data == null)
			{
				return default(T);
			}
			Il2CppSystem.Runtime.Serialization.Formatters.Binary.BinaryFormatter binaryFormatter = new Il2CppSystem.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
			Il2CppSystem.IO.MemoryStream serializationStream = new Il2CppSystem.IO.MemoryStream(data);
			return (T)((object)binaryFormatter.Deserialize(serializationStream));
		}

		public static T FromIL2CPPToManaged<T>(Il2CppSystem.Object obj)
		{
			return Serialization.FromByteArray<T>(Serialization.ToByteArray(obj));
		}

		public static T FromManagedToIL2CPP<T>(object obj)
		{
			return Serialization.IL2CPPFromByteArray<T>(Serialization.ToByteArray(obj));
		}
	}
}
