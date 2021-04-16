using System;
using System.Collections.Generic;

namespace WorkingWithBits
{
    public class Tokenizer
    {
        // string starts with (letter | _)
        // number starts with (digit), it can be (int | float)
        // one equals sign
        // if whitespace then skip to the next char
        // any other char then throw an exception
        public List<string> ExtractSpecialWordsAndNumbers(string source)
        {
            int i = 0;
            string token = "";
            List<string> tokens = new List<string>();

            while (i < source.Length)
            {
                token = "";
                if (char.IsLetter(source[i]) || source[i] == '_')
                {
                    // string (\t \r \n)
                    while (
                        i < source.Length && !char.IsWhiteSpace(source[i]) 
                        && (char.IsLetterOrDigit(source[i]) || source[i] == '_'))
                    {
                        token = token + source[i++];
                    }
                    tokens.Add(token);
                    continue;
                }
                else if (char.IsDigit(source[i]))
                {
                    int flag = 0; // 0 int - 1 float
                                  // number
                                  //while (i < source.Length && !char.IsWhiteSpace(source[i]) && source[i] == '.' || char.IsDigit(source[i]))
                    while (i < source.Length && !char.IsWhiteSpace(source[i]))
                    {
                        if (char.IsDigit(source[i]))
                        {
                            token = token + source[i++];
                            continue;
                        }
                        
                        if (source[i] == '.')
                        {
                            if (flag == 1) // if already indicated as float then .. throw exception
                                throw new Exception("Float number with more than one decimal point");

                            flag = 1;
                            token = token + source[i++];
                            continue;
                        }

                        throw new Exception("Invalid float number");
                    }
                    tokens.Add(token);
                }
                else if (source[i] == '=')
                {
                    tokens.Add(source[i++].ToString());
                }
                else if (char.IsWhiteSpace(source[i]))
                {
                    i++;
                }
                else
                {
                    throw new Exception("Unexcpeted token");
                }
            }

            return tokens;
        }

        static bool IsHex(char source)
        {
            string hexChars = "0123456789abcdefABCDEF";

            for (int i = 0; i < hexChars.Length; i++)
                if (hexChars[i] == source)
                    return true;

            return true;
        }

        // extract hexdecimal from string #84aa83
        public List<string> ExtractColors(string source)
        {
            int i = 0;
            int hexIndex = 0;
            string token = "";
            List<string> tokens = new List<string>();
            int flag = 0;

            while (i < source.Length)
            {
                if (source[i] == '#')
                {
                    //i++;
                    hexIndex = 0;
                    token = "" + source[i++]; // add # then point to the next char

                    while(hexIndex < 6)
                    {
                        if (i < source.Length && !char.IsWhiteSpace(source[i]))
                        {
                            if (!IsHex(source[i]))
                                throw new Exception("Unexcepted token");

                            if (flag == 0) flag = 1;
                            token = token + source[i++];
                        }
                        else
                        {
                            if (flag == 0)
                                throw new Exception("Unexcpected token");
                            token = token + "0";
                        }
                        hexIndex++;
                    }
                    tokens.Add(token);
                }
                i++;
            }

            return tokens;
        }



        public List<string> ExtractMentions(string tweet)
        {
            int i = 0;
            List<string> tokens = new List<string>();
            string token = "";
            while (i < tweet.Length)
            {
                token = "";
                if (tweet[i++] == '@')
                {
                    while (i < tweet.Length && !char.IsWhiteSpace(tweet[i])
                            && (char.IsLetterOrDigit(tweet[i]) || tweet[i] == '_'))
                    {
                        token = token + tweet[i++];
                    }

                    if (token != string.Empty)
                    {
                        tokens.Add(token);
                    }
                }
            }
            return tokens;
        }

        // Same code for ExtractMentions but the identifier is different (# - @)
        public List<string> ExtractHashtags(string tweet)
        {
            int i = 0;
            List<string> tokens = new List<string>();
            string token = "";
            while (i < tweet.Length)
            {
                token = "";
                if (tweet[i++] == '#')
                {
                    while (i < tweet.Length && !char.IsWhiteSpace(tweet[i])
                            && (char.IsLetterOrDigit(tweet[i]) || tweet[i] == '_'))
                    {
                        token = token + tweet[i++];
                    }

                    if (token != string.Empty)
                    {
                        tokens.Add(token);
                    }
                }
            }
            return tokens;
        }

    }
}
