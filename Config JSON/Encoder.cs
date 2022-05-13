using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Text;
using Xero.tinyJson;

namespace Xero.tinyJSON
{
	[Obfuscation(Exclude = true)]
	public sealed class Encoder
	{
		private Encoder(EncodeOptions options)
		{
			options = options;
			builder = new StringBuilder();
			indent = 0;
		}

		public static string Encode(object obj)
		{
			return Encoder.Encode(obj, EncodeOptions.None);
		}
		public static string Encode(object obj, EncodeOptions options)
		{
			Encoder encoder = new Encoder(options);
			encoder.EncodeValue(obj, false);
			return encoder.builder.ToString();
		}
		private bool PrettyPrintEnabled
		{
			get
			{
				return (options & EncodeOptions.PrettyPrint) == EncodeOptions.PrettyPrint;
			}
		}
		private bool TypeHintsEnabled
		{
			get
			{
				return (options & EncodeOptions.NoTypeHints) != EncodeOptions.NoTypeHints;
			}
		}
		private bool IncludePublicPropertiesEnabled
		{
			get
			{
				return (options & EncodeOptions.IncludePublicProperties) == EncodeOptions.IncludePublicProperties;
			}
		}
		private bool EnforceHierarchyOrderEnabled
		{
			get
			{
				return (options & EncodeOptions.EnforceHierarchyOrder) == EncodeOptions.EnforceHierarchyOrder;
			}
		}
		private void EncodeValue(object value, bool forceTypeHint)
		{
			if (value == null)
			{
				builder.Append("null");
				return;
			}
			if (value is string)
			{
				EncodeString((string)value);
				return;
			}
			if (value is ProxyString)
			{
				EncodeString(((ProxyString)value).ToString(CultureInfo.InvariantCulture));
				return;
			}
			if (value is char)
			{
				EncodeString(value.ToString());
				return;
			}
			if (value is bool)
			{
				builder.Append(((bool)value) ? "true" : "false");
				return;
			}
			if (value is Enum)
			{
				EncodeString(value.ToString());
				return;
			}
			if (value is Array)
			{
				EncodeArray((Array)value, forceTypeHint);
				return;
			}
			if (value is IList)
			{
				EncodeList((IList)value, forceTypeHint);
				return;
			}
			if (value is IDictionary)
			{
				EncodeDictionary((IDictionary)value, forceTypeHint);
				return;
			}
			if (value is Guid)
			{
				EncodeString(value.ToString());
				return;
			}
			if (value is ProxyArray)
			{
				EncodeProxyArray((ProxyArray)value);
				return;
			}
			if (value is ProxyObject)
			{
				EncodeProxyObject((ProxyObject)value);
				return;
			}
			if (value is float || value is double || value is int || value is uint || value is long || value is sbyte || value is byte || value is short || value is ushort || value is ulong || value is decimal || value is ProxyBoolean || value is ProxyNumber)
			{
				builder.Append(Convert.ToString(value, CultureInfo.InvariantCulture));
				return;
			}
			EncodeObject(value, forceTypeHint);
		}

		private IEnumerable<FieldInfo> GetFieldsForType(Type type)
		{
			if (EnforceHierarchyOrderEnabled)
			{
				Stack<Type> stack = new Stack<Type>();
				while (type != null)
				{
					stack.Push(type);
					type = type.BaseType;
				}
				List<FieldInfo> list = new List<FieldInfo>();
				while (stack.Count > 0)
				{
					list.AddRange(stack.Pop().GetFields(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic));
				}
				return list;
			}
			return type.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
		}

		private IEnumerable<PropertyInfo> GetPropertiesForType(Type type)
		{
			if (EnforceHierarchyOrderEnabled)
			{
				Stack<Type> stack = new Stack<Type>();
				while (type != null)
				{
					stack.Push(type);
					type = type.BaseType;
				}
				List<PropertyInfo> list = new List<PropertyInfo>();
				while (stack.Count > 0)
				{
					list.AddRange(stack.Pop().GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic));
				}
				return list;
			}
			return type.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
		}

		private void EncodeObject(object value, bool forceTypeHint)
		{
			Type type = value.GetType();
			AppendOpenBrace();
			forceTypeHint = (forceTypeHint || TypeHintsEnabled);
			bool includePublicPropertiesEnabled = IncludePublicPropertiesEnabled;
			bool firstItem = !forceTypeHint;
			if (forceTypeHint)
			{
				if (PrettyPrintEnabled)
				{
					AppendIndent();
				}
				EncodeString("@type");
				AppendColon();
				EncodeString(type.FullName);
				firstItem = false;
			}
			foreach (FieldInfo fieldInfo in GetFieldsForType(type))
			{
				bool forceTypeHint2 = false;
				bool flag = fieldInfo.IsPublic;
				foreach (object o in fieldInfo.GetCustomAttributes(true))
				{
					if (Encoder.excludeAttrType.IsInstanceOfType(o))
					{
						flag = false;
					}
					if (Encoder.includeAttrType.IsInstanceOfType(o))
					{
						flag = true;
					}
					if (Encoder.typeHintAttrType.IsInstanceOfType(o))
					{
						forceTypeHint2 = true;
					}
				}
				if (flag)
				{
					AppendComma(firstItem);
					EncodeString(fieldInfo.Name);
					AppendColon();
					EncodeValue(fieldInfo.GetValue(value), forceTypeHint2);
					firstItem = false;
				}
			}
			foreach (PropertyInfo propertyInfo in GetPropertiesForType(type))
			{
				if (propertyInfo.CanRead)
				{
					bool forceTypeHint3 = false;
					bool flag2 = includePublicPropertiesEnabled;
					foreach (object o2 in propertyInfo.GetCustomAttributes(true))
					{
						if (Encoder.excludeAttrType.IsInstanceOfType(o2))
						{
							flag2 = false;
						}
						if (Encoder.includeAttrType.IsInstanceOfType(o2))
						{
							flag2 = true;
						}
						if (Encoder.typeHintAttrType.IsInstanceOfType(o2))
						{
							forceTypeHint3 = true;
						}
					}
					if (flag2)
					{
						AppendComma(firstItem);
						EncodeString(propertyInfo.Name);
						AppendColon();
						EncodeValue(propertyInfo.GetValue(value, null), forceTypeHint3);
						firstItem = false;
					}
				}
			}
			AppendCloseBrace();
		}

		private void EncodeProxyArray(ProxyArray value)
		{
			if (value.Count == 0)
			{
				builder.Append("[]");
				return;
			}
			AppendOpenBracket();
			bool firstItem = true;
			foreach (Variant value2 in ((IEnumerable<Variant>)value))
			{
				AppendComma(firstItem);
				EncodeValue(value2, false);
				firstItem = false;
			}
			AppendCloseBracket();
		}

		private void EncodeProxyObject(ProxyObject value)
		{
			if (value.Count == 0)
			{
				builder.Append("{}");
				return;
			}
			AppendOpenBrace();
			bool firstItem = true;
			foreach (string text in value.Keys)
			{
				AppendComma(firstItem);
				EncodeString(text);
				AppendColon();
				EncodeValue(value[text], false);
				firstItem = false;
			}
			AppendCloseBrace();
		}

		private void EncodeDictionary(IDictionary value, bool forceTypeHint)
		{
			if (value.Count == 0)
			{
				builder.Append("{}");
				return;
			}
			AppendOpenBrace();
			bool firstItem = true;
			foreach (object obj in value.Keys)
			{
				AppendComma(firstItem);
				EncodeString(obj.ToString());
				AppendColon();
				EncodeValue(value[obj], forceTypeHint);
				firstItem = false;
			}
			AppendCloseBrace();
		}

		private void EncodeList(IList value, bool forceTypeHint)
		{
			if (value.Count == 0)
			{
				builder.Append("[]");
				return;
			}
			AppendOpenBracket();
			bool firstItem = true;
			foreach (object value2 in value)
			{
				AppendComma(firstItem);
				EncodeValue(value2, forceTypeHint);
				firstItem = false;
			}
			AppendCloseBracket();
		}

		private void EncodeArray(Array value, bool forceTypeHint)
		{
			if (value.Rank == 1)
			{
				EncodeList(value, forceTypeHint);
				return;
			}
			int[] indices = new int[value.Rank];
			EncodeArrayRank(value, 0, indices, forceTypeHint);
		}

		private void EncodeArrayRank(Array value, int rank, int[] indices, bool forceTypeHint)
		{
			AppendOpenBracket();
			int lowerBound = value.GetLowerBound(rank);
			int upperBound = value.GetUpperBound(rank);
			if (rank == value.Rank - 1)
			{
				for (int i = lowerBound; i <= upperBound; i++)
				{
					indices[rank] = i;
					AppendComma(i == lowerBound);
					EncodeValue(value.GetValue(indices), forceTypeHint);
				}
			}
			else
			{
				for (int j = lowerBound; j <= upperBound; j++)
				{
					indices[rank] = j;
					AppendComma(j == lowerBound);
					EncodeArrayRank(value, rank + 1, indices, forceTypeHint);
				}
			}
			AppendCloseBracket();
		}

		private void EncodeString(string value)
		{
			builder.Append('"');
			char[] array = value.ToCharArray();
			int i = 0;
			while (i < array.Length)
			{
				char c = array[i];
				switch (c)
				{
					case '\b':
						builder.Append("\\b");
						break;
					case '\t':
						builder.Append("\\t");
						break;
					case '\n':
						builder.Append("\\n");
						break;
					case '\v':
						goto IL_DD;
					case '\f':
						builder.Append("\\f");
						break;
					case '\r':
						builder.Append("\\r");
						break;
					default:
						if (c != '"')
						{
							if (c != '\\')
							{
								goto IL_DD;
							}
							builder.Append("\\\\");
						}
						else
						{
							builder.Append("\\\"");
						}
						break;
				}
			IL_123:
				i++;
				continue;
			IL_DD:
				int num = Convert.ToInt32(c);
				if (num >= 32 && num <= 126)
				{
					builder.Append(c);
					goto IL_123;
				}
				builder.Append("\\u" + Convert.ToString(num, 16).PadLeft(4, '0'));
				goto IL_123;
			}
			builder.Append('"');
		}
		private void AppendIndent()
		{
			for (int i = 0; i < indent; i++)
			{
				builder.Append('\t');
			}
		}

		private void AppendOpenBrace()
		{
			builder.Append('{');
			if (PrettyPrintEnabled)
			{
				builder.Append('\n');
				indent++;
			}
		}


		private void AppendCloseBrace()
		{
			if (PrettyPrintEnabled)
			{
				builder.Append('\n');
				indent--;
				AppendIndent();
			}
			builder.Append('}');
		}


		private void AppendOpenBracket()
		{
			builder.Append('[');
			if (PrettyPrintEnabled)
			{
				builder.Append('\n');
				indent++;
			}
		}


		private void AppendCloseBracket()
		{
			if (PrettyPrintEnabled)
			{
				builder.Append('\n');
				indent--;
				AppendIndent();
			}
			builder.Append(']');
		}
		private void AppendComma(bool firstItem)
		{
			if (!firstItem)
			{
				builder.Append(',');
				if (PrettyPrintEnabled)
				{
					builder.Append('\n');
				}
			}
			if (PrettyPrintEnabled)
			{
				AppendIndent();
			}
		}


		private void AppendColon()
		{
			builder.Append(':');
			if (PrettyPrintEnabled)
			{
				builder.Append(' ');
			}
		}


		private static readonly Type includeAttrType = typeof(Include);


		private static readonly Type excludeAttrType = typeof(Exclude);


		private static readonly Type typeHintAttrType = typeof(TypeHint);


		private readonly StringBuilder builder;

		private readonly EncodeOptions options;

		private int indent;
	}
}
