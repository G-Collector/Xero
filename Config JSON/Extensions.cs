using System;
using System.Collections.Generic;
using System.Reflection;

namespace Xero.tinyJSON
{
	[Obfuscation(Exclude = true)]
	public static class Extensions
	{
		public static bool AnyOfType<TSource>(this IEnumerable<TSource> source, Type expectedType)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			if (expectedType == null)
			{
				throw new ArgumentNullException("expectedType");
			}
			foreach (TSource tsource in source)
			{
				if (expectedType.IsInstanceOfType(tsource))
				{
					return true;
				}
			}
			return false;
		}
	}
}
