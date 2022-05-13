using System;
using System.Reflection;

namespace Xero.tinyJson
{
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
	[Obfuscation(Exclude = true)]
	public class TypeHint : Attribute
	{
	}
}
