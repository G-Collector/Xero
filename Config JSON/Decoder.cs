using System;
using System.IO;
using System.Text;

namespace Xero.tinyJson
{

	public sealed class Decoder : IDisposable
	{

		private Decoder(string jsonString)
		{
			json = new StringReader(jsonString);
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
			json.Dispose();
			json = null;
		}


		private ProxyObject DecodeObject()
		{
			ProxyObject proxyObject = new ProxyObject();
			json.Read();
			for (; ; )
			{
				Decoder.Token nextToken = NextToken;
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
					string text = DecodeString();
					if (text == null)
					{
						goto Block_4;
					}
					if (NextToken != Decoder.Token.Colon)
					{
						goto Block_5;
					}
					json.Read();
					proxyObject.Add(text, DecodeValue());
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
			json.Read();
			bool flag = true;
			while (flag)
			{
				Decoder.Token nextToken = NextToken;
				if (nextToken == Decoder.Token.None)
				{
					return null;
				}
				if (nextToken != Decoder.Token.CloseBracket)
				{
					if (nextToken != Decoder.Token.Comma)
					{
						proxyArray.Add(DecodeByToken(nextToken));
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
			Decoder.Token nextToken = NextToken;
			return DecodeByToken(nextToken);
		}
		private Variant DecodeByToken(Decoder.Token token)
		{
			switch (token)
			{
				case Decoder.Token.OpenBrace:
					return DecodeObject();
				case Decoder.Token.OpenBracket:
					return DecodeArray();
				case Decoder.Token.String:
					return DecodeString();
				case Decoder.Token.Number:
					return DecodeNumber();
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
			json.Read();
			bool flag = true;
			while (flag)
			{
				if (json.Peek() == -1)
				{
					break;
				}
				char nextChar = NextChar;
				if (nextChar != '"')
				{
					if (nextChar != '\\')
					{
						stringBuilder.Append(nextChar);
					}
					else if (json.Peek() == -1)
					{
						flag = false;
					}
					else
					{
						nextChar = NextChar;
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
											stringBuilder2.Append(NextChar);
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
			return new ProxyNumber(NextWord);
		}
		private void ConsumeWhiteSpace()
		{
			while (" \t\n\r".IndexOf(PeekChar) != -1)
			{
				json.Read();
				if (json.Peek() == -1)
				{
					break;
				}
			}
		}

		private char PeekChar
		{
			get
			{
				int num = json.Peek();
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
				return Convert.ToChar(json.Read());
			}
		}
		private string NextWord
		{
			get
			{
				StringBuilder stringBuilder = new StringBuilder();
				while (" \t\n\r{}[],:\"".IndexOf(PeekChar) == -1)
				{
					stringBuilder.Append(NextChar);
					if (json.Peek() == -1)
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
				ConsumeWhiteSpace();
				if (json.Peek() == -1)
				{
					return Decoder.Token.None;
				}
				char peekChar = PeekChar;
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
							json.Read();
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
						json.Read();
						return Decoder.Token.CloseBracket;
					}
					if (peekChar == '{')
					{
						return Decoder.Token.OpenBrace;
					}
					if (peekChar == '}')
					{
						json.Read();
						return Decoder.Token.CloseBrace;
					}
				}
				string nextWord = NextWord;
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
