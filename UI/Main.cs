using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using Model;

namespace UI
{
    public class Main
    {
        public static int AskForChoiceNumber()
        {
            System.Console.WriteLine("Which features you would like to query:" +
                "\n[1] Emperor's name" +
                "\n[2] Start of emperor's reign" +
                "\n[3] End of emperor's reign" +
                "\n[4] Dynasty emperor belonged to" +
                "\n[5] Run query");

            return Convert.ToInt32(System.Console.ReadLine());
        }

        public static string AskForNameOfEmperor()
        {
            System.Console.WriteLine("\nInsert name of emperor you want query with.");
            return System.Console.ReadLine();
        }

        public static void PrintNewExpression(Expression newExpression)
        {
            System.Console.WriteLine("\nNew expression added: {0} \n", newExpression);
        }

        public static (int, int) AskForTimeSpan()
        {

            System.Console.WriteLine("\nInsert the year to begin with.");
            var earliest = Convert.ToInt32(System.Console.ReadLine());
            System.Console.WriteLine("\nInsert the year to finish with.");
            var latest = Convert.ToInt32(System.Console.ReadLine());

            return (earliest, latest);
        }

        public static Dynasty AskForDynasty()
        {
            System.Console.WriteLine("Choose dynasty:" +
                        "\n[1] Julio-Claudian Dynasty" +
                        "\n[2] Flavian Dynasty" +
                        "\n[3] Nerva-Antinine Dynasty" +
                        "\n[4] Severan Dynasty" +
                        "\n[5] Gordian Dynasty" +
                        "\n[6] Constantian Dynasty" +
                        "\n[7] Valentinian Dynasty" +
                        "\n[8] Theodosian Dynasty" +
                        "\n");

            var dynastyStr = System.Console.ReadLine();
            return (Dynasty)Enum.Parse(typeof(Dynasty), dynastyStr);
        }

        public static void PrintResults(IEnumerable<Emperor> results)
        {
            System.Console.WriteLine("\nResulting emprerors:");
            foreach (var result in results)
            {
                System.Console.WriteLine(result.Name + "(" + result.Dynasty + ")");
            }
        }

        public static void PrintInvalidInputNotification()
        {
            System.Console.WriteLine("Invalid input. Use numbers 1-5.\n");
        }

        public static void PrintCurrentPredicate(Expression currentPredicate)
        {
            System.Console.WriteLine("Current predicate is: {0} \n", currentPredicate);
        }
    }
}