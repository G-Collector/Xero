using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;

namespace Xero.tinyJson
{

	[Obfuscation(Exclude = true)]
	public sealed class ProxyObject : Variant, IEnumerable<KeyValuePair<string, Variant>>, IEnumerable
	{
	
		public ProxyObject()
		{
			this.dict = new Dictionary<string, Variant>();
		}

		IEnumerator<KeyValuePair<string, Variant>> IEnumerable<KeyValuePair<string, Variant>>.GetEnumerator()
		{
			return this.dict.GetEnumerator();
		}


		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.dict.GetEnumerator();
		}


		public void Add(string key, Variant item)
		{
			this.dict.Add(key, item);
		}

	
		public bool TryGetValue(string key, out Variant item)
		{
			return this.dict.TryGetValue(key, out item);
		}


		public string TypeHint
		{
			get
			{
				Variant variant;
				if (this.TryGetValue("@type", out variant))
				{
					return variant.ToString(CultureInfo.InvariantCulture);
				}
				return null;
			}
		}


		public override Variant this[string key]
		{
			get
			{
				return this.dict[key];
			}
			set
			{
				this.dict[key] = value;
			}
		}


		public int Count
		{
			get
			{
				return this.dict.Count;
			}
		}


		public Dictionary<string, Variant>.KeyCollection Keys
		{
			get
			{
				return this.dict.Keys;
			}
		}


		public Dictionary<string, Variant>.ValueCollection Values
		{
			get
			{
				return this.dict.Values;
			}
		}

		public const string TypeHintKey = "@type";

		private readonly Dictionary<string, Variant> dict;
	}
}
