using System;
using System.Linq;
using System.Linq.Expressions;

using Model;

namespace dynamic_linq_expressions
{
    class Program
    {
        static void Main(string[] args)
        {
            // PARAMETER
            var parameter = Expression.Parameter(typeof(Emperor));

            // INITIAL EMPTY PREDICATE
            Expression currentPredicate = null;

            var choiceNumber = 0;
            while (choiceNumber != 5)
            {
                System.Console.WriteLine("Which features you would like to query:" +
                    "\n[1] Emperor's name" +
                    "\n[2] Start of emperor's reign" +
                    "\n[3] End of emperor's reign" +
                    "\n[4] Dynasty emperor belonged to" +
                    "\n[5] Run query");

                choiceNumber = Convert.ToInt32(System.Console.ReadLine());

                switch (choiceNumber)
                {
                    case 1: // Name
                        System.Console.WriteLine("\nInsert name of emperor you want query with.");
                        var nameOfEmperor = System.Console.ReadLine();

                        var name_member = Expression.Property(parameter, "Name");
                        var constant = Expression.Constant(nameOfEmperor);

                        var name_expression = Expression.Equal(name_member, constant);

                        System.Console.WriteLine("\nNew expression added: {0} \n", name_expression);

                        currentPredicate = appendPredicate(currentPredicate, name_expression, LogicalConjunction.And);
                        break;
                    case 2: // Start of reign (SOR)
                        System.Console.WriteLine("\nInsert the year to begin with.");
                        var SOR_Earliest = Convert.ToInt32(System.Console.ReadLine());
                        System.Console.WriteLine("\nInsert the year to finish with.");
                        var SOR_Latest = Convert.ToInt32(System.Console.ReadLine());

                        var SOR_member = Expression.Property(parameter, "StartOfReign");

                        var SOR_expression = clampExpression(SOR_Earliest, SOR_Latest, SOR_member);

                        System.Console.WriteLine("\nNew expression added: {0} \n", SOR_expression);

                        currentPredicate = appendPredicate(currentPredicate, SOR_expression, LogicalConjunction.And);
                        break;
                    case 3: // End of reign (EOR)
                        System.Console.WriteLine("\nInsert the year to begin with.");
                        var EOR_Earliest = Convert.ToInt32(System.Console.ReadLine());
                        System.Console.WriteLine("\nInsert the year to finish with.");
                        var EOR_Latest = Convert.ToInt32(System.Console.ReadLine());

                        var EOR_member = Expression.Property(parameter, "EndOfReign");

                        var EOR_expression = clampExpression(EOR_Earliest, EOR_Latest, EOR_member);

                        System.Console.WriteLine("\nNew expression added: {0} \n", EOR_expression);

                        currentPredicate = appendPredicate(currentPredicate, EOR_expression, LogicalConjunction.And);
                        break;
                    case 4: // Dynasty
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
                        var dynasty = (Dynasty)Enum.Parse(typeof(Dynasty), dynastyStr);

                        var dynasty_member = Expression.Property(parameter, "Dynasty");
                        var dynasty_constant = Expression.Constant(dynasty);
                        var dynasty_expression = Expression.Equal(dynasty_member, dynasty_constant);

                        System.Console.WriteLine("\nNew expression added: {0} \n", dynasty_expression);

                        currentPredicate = appendPredicate(currentPredicate, dynasty_expression, LogicalConjunction.And);
                        break;
                    case 5: // Run query
                        var lambda = Expression.Lambda<Func<Emperor, bool>>(currentPredicate, parameter);
                        var finalPredicate = lambda.Compile();

                        var emperors = Emperor.GetEmperorsList();

                        var results = emperors.Where(finalPredicate);
                        System.Console.WriteLine("\nResulting emprerors:");
                        foreach (var result in results)
                        {
                            System.Console.WriteLine(result.Name);
                        }
                        break;
                    default:
                        System.Console.WriteLine("Invalid input. Use numbers 1-5.\n");
                        break;
                }

                if (choiceNumber != 5)
                    System.Console.WriteLine("Current predicate is: {0} \n", currentPredicate);
            }
        }

        private static Expression appendPredicate(Expression left, Expression rigth, LogicalConjunction lc)
        {
            if (left != null)
            {
                switch (lc)
                {
                    case LogicalConjunction.And:
                        return Expression.And(left, rigth);
                    case LogicalConjunction.Or:
                        return Expression.Or(left, rigth);
                    default:
                        throw new ArgumentException("Logical conjunctio not configured.");
                }
            }
            else // Meaning this is the first expression in the predicate.
            {
                return rigth;
            }
        }

        private static Expression clampExpression(int lessThan, int greaterThan, MemberExpression member)
        {
            var constantLessThan = Expression.Constant(lessThan);
            var constantGreaterThan = Expression.Constant(greaterThan);

            var expressionLessThan = Expression.LessThan(constantLessThan, member);
            var expressionGreaterThan = Expression.GreaterThan(constantGreaterThan, member);

            return Expression.And(expressionLessThan, expressionGreaterThan);
        }
    }
}
