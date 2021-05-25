/**************************************************************
 * Author - Mohammad Hasan Raza
 * Project Name - Project07, This is a class library
 * Purpose - capatilization of each word until a conjuction find
 * Date - 24 May 2021
 * Copyright @ {Bhavna Corp 2021}
 ***************************************************************/

using System;
using System.Collections.Generic;

namespace CaptilizationLibrary
{
    public class Class2
    {
        public void SentenceCaptilization(string sentence)
        {
            if (string.IsNullOrEmpty(sentence))
            {
                Console.WriteLine("Sorry for Empty string");
                return;
            }

            // breaking input sentence into words and store it into an array


            string[] str = sentence.Split();

            //making dictionary of conjuctions 

            Dictionary<string, string> dict = new Dictionary<string, string>
            {
                {"and","and"},{ "or","or"},{ "but","but"},{"nor","nor" },{ "yet","yet"},{ "so","so"},{ "for","for"},
                { "a","a"},{ "an","an"},{ "the","the"},{ "in","in"},{ "to","to"},{ "of","of"},{ "at","at"},{ "by","by"},
                { "up","up"},{ "on","on"}
            };

            // below logic is defined for capatilization of each word until a conjuction find.

            for (int i = 0; i < str.Length; i++)
            {
                if (!dict.ContainsKey(str[i]))
                    str[i] = char.ToUpper(str[i][0]) + str[i].Substring(1);
                //string builder

            }

            // printing element after captilization of sentence.

            Console.WriteLine("After captilization unless conjuction--->");

            for (int i = 0; i < str.Length; i++)
            {
                Console.Write(str[i] + " ");
            }
        }
    }
}
