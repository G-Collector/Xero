using System;
using System.Reflection;

namespace Xero.tinyJson
{ 
	[AttributeUsage(AttributeTargets.Method)]
	[Obfuscation(Exclude = true)]
	public class AfterDecode : Attribute
	{
	}
}
