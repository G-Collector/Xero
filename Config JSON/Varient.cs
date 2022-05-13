using System;
using System.Globalization;
using System.Reflection;

namespace Xero.tinyJson
{
	[Obfuscation(Exclude = true)]
	public abstract class Variant : IConvertible
	{
		public void Make<T>(out T item)
		{
			JSON.MakeInto<T>(this, out item);
		}

		public T Make<T>()
		{
			T result;
			JSON.MakeInto<T>(this, out result);
			return result;
		}

		public string ToJSON()
		{
			return JSON.Dump(this);
		}

		public virtual TypeCode GetTypeCode()
		{
			return TypeCode.Object;
		}

		public virtual object ToType(Type conversionType, IFormatProvider provider)
		{
			string str = "Cannot convert ";
			Type type = base.GetType();
			throw new InvalidCastException(str + ((type != null) ? type.ToString() : null) + " to " + conversionType.Name);
		}


		public virtual DateTime ToDateTime(IFormatProvider provider)
		{
			string str = "Cannot convert ";
			Type type = base.GetType();
			throw new InvalidCastException(str + ((type != null) ? type.ToString() : null) + " to DateTime");
		}

		public virtual bool ToBoolean(IFormatProvider provider)
		{
			string str = "Cannot convert ";
			Type type = base.GetType();
			throw new InvalidCastException(str + ((type != null) ? type.ToString() : null) + " to Boolean");
		}

	
		public virtual byte ToByte(IFormatProvider provider)
		{
			string str = "Cannot convert ";
			Type type = base.GetType();
			throw new InvalidCastException(str + ((type != null) ? type.ToString() : null) + " to Byte");
		}

		
		public virtual char ToChar(IFormatProvider provider)
		{
			string str = "Cannot convert ";
			Type type = base.GetType();
			throw new InvalidCastException(str + ((type != null) ? type.ToString() : null) + " to Char");
		}

		
		public virtual decimal ToDecimal(IFormatProvider provider)
		{
			string str = "Cannot convert ";
			Type type = base.GetType();
			throw new InvalidCastException(str + ((type != null) ? type.ToString() : null) + " to Decimal");
		}

		
		public virtual double ToDouble(IFormatProvider provider)
		{
			string str = "Cannot convert ";
			Type type = base.GetType();
			throw new InvalidCastException(str + ((type != null) ? type.ToString() : null) + " to Double");
		}

		
		public virtual short ToInt16(IFormatProvider provider)
		{
			string str = "Cannot convert ";
			Type type = base.GetType();
			throw new InvalidCastException(str + ((type != null) ? type.ToString() : null) + " to Int16");
		}

	
		public virtual int ToInt32(IFormatProvider provider)
		{
			string str = "Cannot convert ";
			Type type = base.GetType();
			throw new InvalidCastException(str + ((type != null) ? type.ToString() : null) + " to Int32");
		}

		
		public virtual long ToInt64(IFormatProvider provider)
		{
			string str = "Cannot convert ";
			Type type = base.GetType();
			throw new InvalidCastException(str + ((type != null) ? type.ToString() : null) + " to Int64");
		}

		
		public virtual sbyte ToSByte(IFormatProvider provider)
		{
			string str = "Cannot convert ";
			Type type = base.GetType();
			throw new InvalidCastException(str + ((type != null) ? type.ToString() : null) + " to SByte");
		}


		public virtual float ToSingle(IFormatProvider provider)
		{
			string str = "Cannot convert ";
			Type type = base.GetType();
			throw new InvalidCastException(str + ((type != null) ? type.ToString() : null) + " to Single");
		}

		
		public virtual string ToString(IFormatProvider provider)
		{
			string str = "Cannot convert ";
			Type type = base.GetType();
			throw new InvalidCastException(str + ((type != null) ? type.ToString() : null) + " to String");
		}

		public virtual ushort ToUInt16(IFormatProvider provider)
		{
			string str = "Cannot convert ";
			Type type = base.GetType();
			throw new InvalidCastException(str + ((type != null) ? type.ToString() : null) + " to UInt16");
		}

	
		public virtual uint ToUInt32(IFormatProvider provider)
		{
			string str = "Cannot convert ";
			Type type = base.GetType();
			throw new InvalidCastException(str + ((type != null) ? type.ToString() : null) + " to UInt32");
		}

	
		public virtual ulong ToUInt64(IFormatProvider provider)
		{
			string str = "Cannot convert ";
			Type type = base.GetType();
			throw new InvalidCastException(str + ((type != null) ? type.ToString() : null) + " to UInt64");
		}

	
		public override string ToString()
		{
			return this.ToString(Variant.FormatProvider);
		}

	
		public virtual Variant this[string key]
		{
			get
			{
				throw new NotSupportedException();
			}
			set
			{
				throw new NotSupportedException();
			}
		}

	
		public virtual Variant this[int index]
		{
			get
			{
				throw new NotSupportedException();
			}
			set
			{
				throw new NotSupportedException();
			}
		}

		
		public static implicit operator bool(Variant variant)
		{
			return variant.ToBoolean(Variant.FormatProvider);
		}

		public static implicit operator float(Variant variant)
		{
			return variant.ToSingle(Variant.FormatProvider);
		}


		public static implicit operator double(Variant variant)
		{
			return variant.ToDouble(Variant.FormatProvider);
		}


		public static implicit operator ushort(Variant variant)
		{
			return variant.ToUInt16(Variant.FormatProvider);
		}


		public static implicit operator short(Variant variant)
		{
			return variant.ToInt16(Variant.FormatProvider);
		}

		public static implicit operator uint(Variant variant)
		{
			return variant.ToUInt32(Variant.FormatProvider);
		}

		public static implicit operator int(Variant variant)
		{
			return variant.ToInt32(Variant.FormatProvider);
		}

		public static implicit operator ulong(Variant variant)
		{
			return variant.ToUInt64(Variant.FormatProvider);
		}

		public static implicit operator long(Variant variant)
		{
			return variant.ToInt64(Variant.FormatProvider);
		}

		public static implicit operator decimal(Variant variant)
		{
			return variant.ToDecimal(Variant.FormatProvider);
		}
		public static implicit operator string(Variant variant)
		{
			return variant.ToString(Variant.FormatProvider);
		}
		public static implicit operator Guid(Variant variant)
		{
			return new Guid(variant.ToString(Variant.FormatProvider));
		}
		protected static readonly IFormatProvider FormatProvider = new NumberFormatInfo();
	}
}
