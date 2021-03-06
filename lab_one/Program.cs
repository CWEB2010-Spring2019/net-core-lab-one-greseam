﻿using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;

namespace lab_one
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] cheatSheet =
            {
                "B","B","C","A","D"
                ,"A","A","C","D","A"
            };

            string[] questions = //aray that holds questions 
            {
                ".Net Core originated from which of the following companies?","Which OS does .NET core NOT support, while being self stable?"," When was .NET core 1.0 released?"," What is .Net Core written in?","Of the following, Wich are True about .Net Core?",
                " What is the next big version of .Net Core to be released?"," Which of the following, is the True about .Net Core but NOT Framework?","Of the following which IDEs works best with .NET Core?"," which of the following is not an architecture?","Which of the following is .NET core not compatible?"
            };

            string[ , ] quizOptions = // multi dimensonal array that holds quiz questions
            {
                { "A.) Apple","B.) Microsoft","C.) Google","D.) Orange"},
                { "A.) MacOS ","B.) SkyOS ","C.) Windows ","D.) Linux "},
                { "A.) Jan 13, 1998","B.) Jan 2, 2007","C.) June 27, 2016","D.) Apr 27, 2017"},
                { "A.) Both C# and C++","B.) C++ only","C.) C# only","D.) Python"},
                { "A.) Free ","B.) Open source ","C.) Is a software framework ","D.) All the above"},
                { "A.) 3.0","B.) 1.3","C.) 2.2","D.) 4.0"},
                { "A.) Cross-Platform","B.) .NET Core was made by Apple","C.) .Net Core runs worse than Framework","D.) .Net Core is unstable"},
                { "A.) MonoDevelop","B.) Notepad++","C.) Visual Studio 2017","D.) Microsoft Word"},
                { "A.) x86","B.) x32","C.) ARM","D.) False"},
                { "A.) .Org","B.) Xamarin","C.) Mono","D.) .NET Framework"} //.NET Framework, Xamarin and Mono

            };
            string[] questionNum = {"1. ","2. ","3. ","4. ","5. ","6. ","7. ","8. ","9. ","10. "}; // use this as guide for the program
            List<int> Scores = new List<int>();

            int attempt = 2;
            int maxAttempt = 0;
            int Exit = -1;
            int broke = -1;
            int Score = 0;
            const int maxScore = 10;
            int Error = 0;
            List<string> correct = new List<string>();
            List<string> wrong = new List<string>();
            int Start = -2;

            while (Start == -2) //begining of Console app
            {
                Console.WriteLine("\tWelcome, this program will assess your knowledge of .NET Core");
                Console.WriteLine("To get started, please press the SACE key to start program");
                ConsoleKey Input = Console.ReadKey().Key;
                if (Input == ConsoleKey.Spacebar)
                {
                    Start = 0;
                    Console.Clear();
                    play();
                }
                else
                {
                    Console.Clear();
                }
            }

            void ScoreBoard()
            {
                Console.Clear();
                Console.WriteLine("You attempted the Quiz " + Convert.ToString(maxAttempt) + " Time(s)!");
                for (int i = 0; i < maxAttempt; i++)
                {
                    Console.WriteLine("\tYou scored " + Scores[i] + " out of " + Convert.ToString(maxScore) + "!");
                    //add an acual scoreboard for each attempt
                    if (Scores[i] > 6)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\tYou passed this attempt.\n");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else if (Error > 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("\tYou did not anwser all the questions for this attempt!\n");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\tYou failed this attempt.\n");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                }

                Console.WriteLine("\nThank you for taking this small quiz\n\tHave a great day!!!\n");
                Start = -1;
                

            }
            
            void play() //begining of quiz
            {
                while (Start != Exit)
                {
                    for (int i = 0; i < 10; i++)
                    {
                        Console.WriteLine(questionNum[i] + questions[i]);
                        for (int j = 0; j < quizOptions.GetLength(1); j++)
                        {
                            Console.WriteLine(quizOptions[i, j]);
                        }

                        Console.WriteLine("Please enter an option");
                        string userSelection = Console.ReadLine();
                        Console.Clear();

                        //need to determine if the users selection is the correct answer 
                        if (userSelection == cheatSheet[i])
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            correct.Add(userSelection);
                            Console.WriteLine("Correct");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("Press Enter to continue...");
                            Console.ReadKey();
                            Console.Clear();
                            Score++;
                        }
                        else if (userSelection == "")
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            correct.Add(userSelection);
                            Console.WriteLine("Error, invalid option given!");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("Press Enter to continue...");
                            Console.ReadKey();
                            Console.Clear();
                            Error++;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            wrong.Add(userSelection);
                            Console.WriteLine("Incorect");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("Press Enter to continue...");
                            Console.ReadKey();
                            Console.Clear();

                        }

                    }

                    Scores.Add(Score);
                    Score = 0;
                    Console.WriteLine("Would you like to attempt again? You can attempt " + Convert.ToString(attempt) +
                                      " more times!\nHitting N will Exit and show your scores and attempts (Y/N)");

                    maxAttempt++;
                    while (broke == -1) //Change this to work with three attempts
                    {
                        ConsoleKey tryAgain = Console.ReadKey().Key;
                        if (tryAgain == ConsoleKey.N)
                        {
                            Console.Clear();
                            Start = -1;
                            broke = 1;
                            ScoreBoard();
                        }
                        else if (tryAgain == ConsoleKey.Y)
                        {
                            Console.Clear();
                            attempt--;
                            if (attempt < 0)
                            {
                                Console.WriteLine("You are out of attempts");
                                Console.WriteLine("Press Enter to continue...");
                                Console.ReadKey();
                                broke = 1;
                                Start = -1;
                                Console.Clear();
                                ScoreBoard();
                            }
                            play();
                        }
                        else
                        {
                            if (attempt < 0)
                            {
                                Console.ReadKey();
                                Console.Clear();
                                Start = -1;
                            }
                        }
                        
                    }

                    
                }
            }
        }
    }
}
