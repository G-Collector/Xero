using System;
using System.Reflection;

namespace Xero.tinyJson
{
	[Obsolete("Use the Exclude attribute instead.")]
	[Obfuscation(Exclude = true)]
	public sealed class Skip : Exclude
	{
	}
}
