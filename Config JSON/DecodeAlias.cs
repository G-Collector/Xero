using System;
using System.Reflection;

namespace Xero.tinyJson
{
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = true)]
	[Obfuscation(Exclude = true)]
	public class DecodeAlias : Attribute
	{
		public string[] Names { get; private set; }

		public DecodeAlias(params string[] names)
		{
			Names = names;
		}

		public bool Contains(string name)
		{
			return Array.IndexOf<string>(Names, name) > -1;
		}
	}
}
