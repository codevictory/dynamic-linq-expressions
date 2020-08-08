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
                choiceNumber = UI.Main.AskForChoiceNumber();

                switch (choiceNumber)
                {
                    case 1: // Name
                        var nameOfEmperor = UI.Main.AskForNameOfEmperor();

                        var name_member = Expression.Property(parameter, "Name");
                        var constant = Expression.Constant(nameOfEmperor);

                        var name_expression = Expression.Equal(name_member, constant);

                        UI.Main.PrintNewExpression(name_expression);

                        currentPredicate = appendPredicate(currentPredicate, name_expression, LogicalConjunction.And);
                        break;
                    case 2: // Start of reign (SOR)
                        var SOR_span = UI.Main.AskForTimeSpan();

                        var SOR_member = Expression.Property(parameter, "StartOfReign");

                        var SOR_expression = clampExpression(SOR_span.Item1, SOR_span.Item2, SOR_member);

                        UI.Main.PrintNewExpression(SOR_expression);

                        currentPredicate = appendPredicate(currentPredicate, SOR_expression, LogicalConjunction.And);
                        break;
                    case 3: // End of reign (EOR)
                        var EOR_span = UI.Main.AskForTimeSpan();
                        var EOR_member = Expression.Property(parameter, "EndOfReign");

                        var EOR_expression = clampExpression(EOR_span.Item1, EOR_span.Item2, EOR_member);

                        UI.Main.PrintNewExpression(EOR_expression);

                        currentPredicate = appendPredicate(currentPredicate, EOR_expression, LogicalConjunction.And);
                        break;
                    case 4: // Dynasty
                        var dynasty = UI.Main.AskForDynasty();

                        var dynasty_member = Expression.Property(parameter, "Dynasty");
                        var dynasty_constant = Expression.Constant(dynasty);
                        var dynasty_expression = Expression.Equal(dynasty_member, dynasty_constant);

                        UI.Main.PrintNewExpression(dynasty_expression);

                        currentPredicate = appendPredicate(currentPredicate, dynasty_expression, LogicalConjunction.And);
                        break;
                    case 5: // Run query
                        var lambda = Expression.Lambda<Func<Emperor, bool>>(currentPredicate, parameter);
                        var finalPredicate = lambda.Compile();

                        var emperors = Emperor.GetEmperorsList();

                        var results = emperors.Where(finalPredicate);
                        UI.Main.PrintResults(results);
                        break;
                    default:
                        UI.Main.PrintInvalidInputNotification();
                        break;
                }

                if (choiceNumber != 5)
                    UI.Main.PrintCurrentPredicate(currentPredicate);
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
