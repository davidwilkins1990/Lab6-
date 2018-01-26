/*
 David Wilkins
 Lab 6 - Pig Latin
 01/26/2018

 this program asks a user for a word or sentence then translates it to pig latin
 and displays the result back to the user.

 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6._2
{

    //TODO:need to check for 0 vowels, and just add "ay" ie. rhythym -> rhythymay
    //need to figure out how to exclude punctuation - try indexOf and string.skip

    /* TESTING CLASSES - DECIDED NOT TO GO THIS ROUTE YET
    public class Word
    {
        string userInput = "";
        string pigWord = "";
        string vowels = "";
        public string getUserInput()
        {
            return userInput;
        }

        public void setUserInput(string userInput)
        {
            this.userInput = userInput;
        }

        public string getPigWord()
        {
            return pigWord;
        }

        public void setPigWord(string pigWord)
        {
            this.pigWord = pigWord;
        }



    }

    
    */


    class Program
    {
        //METHOD TO DETERMINE WHETHER THE SENTENCE HAS ANYTHING OTHER THAN LETTERS IN IT
        //TODO: from here, if it does, determine where and how to ignore them //.skip? 
        public static bool noSymbols(string sentence)
        {
            bool sTest = false;

            char[] letters = sentence.ToCharArray();

            foreach (char c in letters)
            {
                if (char.IsLetter(c) == true)
                {
                    sTest = true;
                    Console.WriteLine("NO symbols");

                }
                else
                {
                    sTest = false;
                    Console.WriteLine("YES symbols");
                }
            }

            return sTest;
        }

       

        //FIND WHERE PUNCTUATION OCCURS AND MAKE A LIST CONTAINING THOSE INDEX NUMBERS
        //TODO: from here use the index list to skip over punctuation when building the new word.
        public static List<int> punctuationTest(string sentence)
        {
            List<int> pList = new List<int>();

            char[] letters = sentence.ToCharArray();
            foreach (char c in letters)
            {

                if (c == '?' || c == '!' || c == '.')
                {
                    pList.Add(sentence.IndexOf(c));
                }
            }
            return pList;
        }

        //GET INPUT , TRANSLATE, AND DISPLAY BACK TO USER 
        public static string translate()
        {
            string translation = "";


            Console.WriteLine("*** English to Pig Latin Translation ***");

            Console.Write("Please type in a word to translate: ");

            string inputSentence = Console.ReadLine();



            //IF THE INPUT STRING IS EMPTY, START OVER AND ASK FOR A WORD
            if (inputSentence == "")
            {
                Console.WriteLine("You must enter a word to translate.");
                translate();
            }


            Console.WriteLine();
            //TAKE THE INPUT SENTENCE AND SPLIT IT INTO WORDS USING A WHITESPACE OR COMMA DELIMETER
            //AND STORE THOSE WORDS INTO A STRING[]
            string[] words = inputSentence.Split(' ', ',');


            //LOOP THROUGH THE CHARS IN EACH WORD AND TRANSLATE TO PIG LATIN
            //BY FINDING THE STARTING INDEX OF THE FIRST VOWEL IN THE WORD, THEN
            //TAKE A SUBSTRING OF ALL THE LETTERS UP TO THAT POINT, AND A SECOND
            //SUBSTRING OF THE REMAINING LETTERS, CONCATONATING THEM TOGETHER, 
            //AND ADD 'AY' OR 'WAY' WHERE APPROPRIATE TO TRANSLATE CORRECTLY

            foreach (string s in words)
            {
                string input = s;
                char[] vowels = { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U' };
                char[] punct = { '.', '?', '!' };

                int start = 0;
                char z = input[0];
                if (z == 'a' || z == 'e' || z == 'i' || z == 'o' || z == 'u' || z == 'A' || z == 'E' || z == 'I' || z == 'O' || z == 'U')
                {
                    Console.Write(input + "way" + " ");

                }
                else
                {
                    foreach (char v in input)
                    {
                        if (v != 'a' && v != 'e' && v != 'i' && v != 'o' && v != 'u' && v != 'A' && v != 'E' && v != 'I' && v != 'O' && v != 'U')
                        {
                            start++;
                        }
                        else
                        {
                            break;
                        }
                    }

                    //SUB1 IS THE START INDEX (FIRST VOWEL) -> END OF THE WORD
                    string sub1 = input.Substring(start);

                    //SUB2 IS THE FIRST LETTER -> LETTER BEFORE THE FIRST VOWEL
                    string sub2 = input.Substring(0, start);

                    //ADD SUB1, SUB2, AND 'AY' TO TRANSLATE
                    Console.Write(sub1 + sub2 + "ay" + " ");



                }
            }

            //LETS USER TRANSLATE AGAIN IF THEY PRESS 'Y' OR EXIT ON ANY OTHER KEY
            Console.WriteLine();
            Console.WriteLine("press 'y' to continue or any other key to quit");
            string again = Console.ReadLine();
            again = again.ToLower();
            if (again == "y")
            {
                translate();
            }
            return translation;
        }

        static void Main(string[] args)
        {
            // || int.TryParse(input, out int x) != false - keep for future use


            //INDEX OF ANY TEST, WORKS AWESOME - WILL USE IN THE FUTURE
            /*
            Console.Write("input: ");
            string input = Console.ReadLine();
            char[] conditions = { 'a', 'e', 'i', 'o', 'u' };
            string indexes = "";
            indexes =indexes + " & " + input.IndexOfAny(conditions).ToString();
            Console.WriteLine();
            Console.WriteLine(indexes);
            */

            translate();
            Console.ReadLine();

        }
    }
}
