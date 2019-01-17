using System;
using System.Collections.Generic;
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
                "this is a test question?","Which OS does .NET core NOT support, while being self stable?","?","?","Of the following, Wich are True?","?","?","?","?","?"
            };

            string[ , ] quizOptions = // multi dimensonal array that holds quiz questions
            {
                { "A.) Apple","B.) Bannana","C.) Strawberry","D.) Orange"},
                { "A.) MacOS ","B.) SkyOS ","C.) Windows ","D.) Linux "},
                { "A.) ","B.) ","C.) ","D.) "},
                { "A.) ","B.) ","C.) ","D.) "},
                { "A.) Free ","B.) Open source ","C.) Is a software framework ","D.) All the above"},
                { "A.) ","B.) ","C.) ","D.) "},
                { "A.) ","B.) ","C.) ","D.) "},
                { "A.) ","B.) ","C.) ","D.) "},
                { "A.) ","B.) ","C.) ","D.) "},
                { "A.) ","B.) ","C.) ","D.) "}

            };
            string[] questionNum = {"1. ","2. ","3. ","4. ","5. ","6. ","7. ","8. ","9. ","10. "}; // use this as guide for the program
            List<int> Scores = new List<int>();

            Console.WriteLine("\tWelcome, this program will assess your knowledge of .NET Core");
            Console.WriteLine("To get started, please enter a number other than -1 to start program");
            string stringStart = Console.ReadLine();
            int attempt = 2;
            int maxAttempt = 0;
            int Exit = -1;
            int Score = 0;
            const int maxScore = 10;
            int Error = 0;
            int Start = Convert.ToInt16(stringStart);
            List<string> correct = new List<string>();
            List<string> wrong = new List<string>();
            Console.Clear();

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
                        Console.WriteLine("\tYou have not anwsered all the questions for this attempt!\n");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\tYou failed this attempt.\n");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                }

                Console.WriteLine("\nThank you for taking this small quiz");
            }

            while (Start != Exit)
            {
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine(questionNum[i] + questions[i]);
                    for (int j = 0; j < quizOptions.GetLength(1); j++)
                    {
                        Console.WriteLine(quizOptions[i,j]);
                    }

                    Console.WriteLine("Please enter an option");
                    string userSelection= Console.ReadLine();
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
                        Console.WriteLine("Error, no option given!");
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
                Console.WriteLine("Would you like to attempt again? You can attempt " + Convert.ToString(attempt) + " more times!\nHitting N will Exit and show your scores and attempts (Y/N)");
                string tryAgain = Console.ReadLine();
                maxAttempt++;
                

                if (tryAgain == "N")
                {
                    //exit
                    Start = -1; 
                    ScoreBoard();
                }
                else
                {
                    Console.Clear();
                    attempt--;
                    if (attempt < 0)
                    {
                        Console.WriteLine("You are out of attempts");
                        Console.WriteLine("Press Enter to continue...");
                        Console.ReadKey();
                        Console.Clear();
                        ScoreBoard();
                        Start = -1;
                    }
                    //play again
                }
            }

        }
    }
}
