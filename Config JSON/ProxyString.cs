using System;
using System.Reflection;

namespace Xero.tinyJson
{
	[Obfuscation(Exclude = true)]
	public sealed class ProxyString : Variant
	{
		public ProxyString(string value)
		{
			this.value = value;
		}
		public override string ToString(IFormatProvider provider)
		{
			return this.value;
		}

		private readonly string value;
	}
}
