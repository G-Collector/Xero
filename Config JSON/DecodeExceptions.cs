using System;
using System.Reflection;

namespace Xero.tinyJSON
{
	[Obfuscation(Exclude = true)]
	public sealed class DecodeException : Exception
	{
		public DecodeException(string message) : base(message)
		{
		}
		public DecodeException(string message, Exception innerException) : base(message, innerException)
		{
		}
	}
}
