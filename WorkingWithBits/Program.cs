using System;
using System.Collections.Generic;

namespace WorkingWithBits
{
    class Program
    {
        static void Main(string[] args)
        {
            UIntBitOperations op = new UIntBitOperations();
            Console.WriteLine("10 to binary : " + op.ToBinary((uint)10));

            Console.WriteLine();
            Console.WriteLine("=============================");
            Console.WriteLine();

            Tokenizer tokenizer = new Tokenizer();

            string tweet = @"Speech balloon @
             ¡@thibautcourtois
             en zona mixta!
            #UCL
            ";
            List<string> mentions = tokenizer.ExtractMentions(tweet);
            List<string> hashtags = tokenizer.ExtractHashtags(tweet);

            if (mentions.Count > 0)
            {
                Console.WriteLine("Mentions count : " + mentions.Count);
                for (int i = 0; i < mentions.Count; i++)
                    Console.WriteLine("#{0} | {1}", i+1, mentions[i]);
            }
            else
            {
                Console.WriteLine("No mentions found in the tweet");
            }

            if (hashtags.Count > 0)
            {
                Console.WriteLine("Hashtags count : " + hashtags.Count);
                for (int i = 0; i < hashtags.Count; i++)
                    Console.WriteLine("#{0} | {1}", i+1,  hashtags[i]);
            }

            Console.WriteLine();
            Console.WriteLine("=============================");
            Console.WriteLine();

            string wordsAndNumsString = "_ali ==    2 5.5";

            List<string> tokens = tokenizer.ExtractSpecialWordsAndNumbers(wordsAndNumsString);
            if (tokens.Count > 0)
            {
                Console.WriteLine("Extracting tokens from -> [" + wordsAndNumsString + "]");
                for (int i = 0; i < tokens.Count; i++)
                    Console.WriteLine("#{0} | {1}", i+1, tokens[i]);
            }
            else
            {
                Console.WriteLine("No tokens found, string is empty or has whitespaces only");
            }

            Console.WriteLine();
            Console.WriteLine("=============================");
            Console.WriteLine();

            string stringWithColors = "#f This color is #32a852 #f #23C";
            List<string> colors = tokenizer.ExtractColors(stringWithColors);
            if(colors.Count > 0)
            {
                Console.WriteLine("Colors count : " + colors.Count);
                for (int i = 0; i < colors.Count; i++)
                {
                    Console.WriteLine(colors[i]);
                }
            }
            else
            {
                Console.WriteLine("No colors found");
            }    
        }
    }

}
