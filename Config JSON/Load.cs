using System;
using System.Reflection;

namespace Xero.tinyJson
{
	[Obsolete("Use the AfterDecode attribute instead.")]
	[Obfuscation(Exclude = true)]
	public sealed class Load : AfterDecode
	{
	}
}
