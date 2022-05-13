
using System;
using System.IO;
using System.Text;
using Xero.tinyJson;

namespace TinyJson.Xero
{
	public sealed class Decoder : IDisposable
	{
		private Decoder(string jsonString)
		{
			this.json = new StringReader(jsonString);
		}

		public static Variant Decode(string jsonString)
		{
			Variant result;
			using (Decoder decoder = new Decoder(jsonString))
			{
				result = decoder.DecodeValue();
			}
			return result;
		}

		public void Dispose()
		{
			this.json.Dispose();
			this.json = null;
		}
		private ProxyObject DecodeObject()
		{
			ProxyObject proxyObject = new ProxyObject();
			this.json.Read();
			for (; ; )
			{
				Decoder.Token nextToken = this.NextToken;
				if (nextToken == Decoder.Token.None)
				{
					break;
				}
				if (nextToken == Decoder.Token.CloseBrace)
				{
					return proxyObject;
				}
				if (nextToken != Decoder.Token.Comma)
				{
					string text = this.DecodeString();
					if (text == null)
					{
						goto Block_4;
					}
					if (this.NextToken != Decoder.Token.Colon)
					{
						goto Block_5;
					}
					this.json.Read();
					proxyObject.Add(text, this.DecodeValue());
				}
			}
			return null;
		Block_4:
			return null;
		Block_5:
			return null;
		}

		private ProxyArray DecodeArray()
		{
			ProxyArray proxyArray = new ProxyArray();
			this.json.Read();
			bool flag = true;
			while (flag)
			{
				Decoder.Token nextToken = this.NextToken;
				if (nextToken == Decoder.Token.None)
				{
					return null;
				}
				if (nextToken != Decoder.Token.CloseBracket)
				{
					if (nextToken != Decoder.Token.Comma)
					{
						proxyArray.Add(this.DecodeByToken(nextToken));
					}
				}
				else
				{
					flag = false;
				}
			}
			return proxyArray;
		}

		private Variant DecodeValue()
		{
			Decoder.Token nextToken = this.NextToken;
			return this.DecodeByToken(nextToken);
		}
		private Variant DecodeByToken(Decoder.Token token)
		{
			switch (token)
			{
				case Decoder.Token.OpenBrace:
					return this.DecodeObject();
				case Decoder.Token.OpenBracket:
					return this.DecodeArray();
				case Decoder.Token.String:
					return this.DecodeString();
				case Decoder.Token.Number:
					return this.DecodeNumber();
				case Decoder.Token.True:
					return new ProxyBoolean(true);
				case Decoder.Token.False:
					return new ProxyBoolean(false);
				case Decoder.Token.Null:
					return null;
			}
			return null;
		}

		private Variant DecodeString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			this.json.Read();
			bool flag = true;
			while (flag)
			{
				if (this.json.Peek() == -1)
				{
					break;
				}
				char nextChar = this.NextChar;
				if (nextChar != '"')
				{
					if (nextChar != '\\')
					{
						stringBuilder.Append(nextChar);
					}
					else if (this.json.Peek() == -1)
					{
						flag = false;
					}
					else
					{
						nextChar = this.NextChar;
						if (nextChar <= '\\')
						{
							if (nextChar == '"' || nextChar == '/' || nextChar == '\\')
							{
								stringBuilder.Append(nextChar);
							}
						}
						else if (nextChar <= 'f')
						{
							if (nextChar != 'b')
							{
								if (nextChar == 'f')
								{
									stringBuilder.Append('\f');
								}
							}
							else
							{
								stringBuilder.Append('\b');
							}
						}
						else if (nextChar != 'n')
						{
							switch (nextChar)
							{
								case 'r':
									stringBuilder.Append('\r');
									break;
								case 't':
									stringBuilder.Append('\t');
									break;
								case 'u':
									{
										StringBuilder stringBuilder2 = new StringBuilder();
										for (int i = 0; i < 4; i++)
										{
											stringBuilder2.Append(this.NextChar);
										}
										stringBuilder.Append((char)Convert.ToInt32(stringBuilder2.ToString(), 16));
										break;
									}
							}
						}
						else
						{
							stringBuilder.Append('\n');
						}
					}
				}
				else
				{
					flag = false;
				}
			}
			return new ProxyString(stringBuilder.ToString());
		}
		private Variant DecodeNumber()
		{
			return new ProxyNumber(this.NextWord);
		}
		private void ConsumeWhiteSpace()
		{
			while (" \t\n\r".IndexOf(this.PeekChar) != -1)
			{
				this.json.Read();
				if (this.json.Peek() == -1)
				{
					break;
				}
			}
		}
		private char PeekChar
		{
			get
			{
				int num = this.json.Peek();
				if (num != -1)
				{
					return Convert.ToChar(num);
				}
				return '\0';
			}
		}

		private char NextChar
		{
			get
			{
				return Convert.ToChar(this.json.Read());
			}
		}
		private string NextWord
		{
			get
			{
				StringBuilder stringBuilder = new StringBuilder();
				while (" \t\n\r{}[],:\"".IndexOf(this.PeekChar) == -1)
				{
					stringBuilder.Append(this.NextChar);
					if (this.json.Peek() == -1)
					{
						break;
					}
				}
				return stringBuilder.ToString();
			}
		}
		private Decoder.Token NextToken
		{
			get
			{
				this.ConsumeWhiteSpace();
				if (this.json.Peek() == -1)
				{
					return Decoder.Token.None;
				}
				char peekChar = this.PeekChar;
				if (peekChar <= '[')
				{
					switch (peekChar)
					{
						case '"':
							return Decoder.Token.String;
						case '#':
						case '$':
						case '%':
						case '&':
						case '\'':
						case '(':
						case ')':
						case '*':
						case '+':
						case '.':
						case '/':
							break;
						case ',':
							this.json.Read();
							return Decoder.Token.Comma;
						case '-':
						case '0':
						case '1':
						case '2':
						case '3':
						case '4':
						case '5':
						case '6':
						case '7':
						case '8':
						case '9':
							return Decoder.Token.Number;
						case ':':
							return Decoder.Token.Colon;
						default:
							if (peekChar == '[')
							{
								return Decoder.Token.OpenBracket;
							}
							break;
					}
				}
				else
				{
					if (peekChar == ']')
					{
						this.json.Read();
						return Decoder.Token.CloseBracket;
					}
					if (peekChar == '{')
					{
						return Decoder.Token.OpenBrace;
					}
					if (peekChar == '}')
					{
						this.json.Read();
						return Decoder.Token.CloseBrace;
					}
				}
				string nextWord = this.NextWord;
				if (nextWord == "false")
				{
					return Decoder.Token.False;
				}
				if (nextWord == "true")
				{
					return Decoder.Token.True;
				}
				if (!(nextWord == "null"))
				{
					return Decoder.Token.None;
				}
				return Decoder.Token.Null;
			}
		}
		private const string whiteSpace = " \t\n\r";
		private const string wordBreak = " \t\n\r{}[],:\"";
		private StringReader json;

		private enum Token
		{
			None,
			OpenBrace,
			CloseBrace,
			OpenBracket,
			CloseBracket,
			Colon,
			Comma,
			String,
			Number,
			True,
			False,
			Null
		}
	}
}
