using System;
using System.Reflection;

namespace Xero.tinyJson
{

	[Obfuscation(Exclude = true)]
	public sealed class ProxyBoolean : Variant
	{

		public ProxyBoolean(bool value)
		{
			this.value = value;
		}

		public override bool ToBoolean(IFormatProvider provider)
		{
			return this.value;
		}

		public override string ToString(IFormatProvider provider)
		{
			if (!this.value)
			{
				return "false";
			}
			return "true";
		}

		private readonly bool value;
	}
}
