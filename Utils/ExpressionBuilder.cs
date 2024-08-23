using System;
using System.Linq.Expressions;
using test_dotnet_app.DTO;
using test_dotnet_app.Entities;

namespace test_dotnet_app.Utils;

public static class ExpressionBuilder
{
    public static Expression<Func<T, bool>>? buildExpression<T>(this List<SearchParam>? searchParams)
    where T : BaseEntity
    {
        Expression<Func<T, bool>>? search = null;
        if (searchParams is null)
        {
            throw new CustomErrorException((int)CustomErroCodes.ExceptionBuilderException, "No search parameters specified");
        }
        // Extract search parameters from expression tree

        if (searchParams is not null && searchParams.Count > 0)
        {
            // check if search parameters exist in T
            var properties = typeof(T).GetProperties().Select(p => p.Name).ToList();

            foreach (var searchParam in searchParams)
            {
                if (!properties.Contains(searchParam.SearchField ?? ""))
                {
                    throw new CustomErrorException((int)CustomErroCodes.ExceptionBuilderException, $"Search parameter '{searchParam.SearchField ?? ""}' does not exist in entity {typeof(T).Name}");
                }
            }

            // check if search value is provided
            foreach (var searchParam in searchParams)
            {
                if (string.IsNullOrWhiteSpace(searchParam.SearchValue))
                {
                    throw new CustomErrorException((int)CustomErroCodes.ExceptionBuilderException, $"Search value for parameter '{searchParam.SearchField ?? ""}' is required");
                }
            }

            // Implement search logic here, depending on your requirements.
            // construct dynamic expression tree with search field and search value
            var parameter = Expression.Parameter(typeof(T), "e");

            var binaryExpressions = new List<BinaryExpression>();

            foreach (var param in searchParams)
            {
                // get the type depending upon the value of param.FieldType
                var propertyType = typeof(T).GetProperty(param.SearchField?? "")?.PropertyType;
                var value = Convert.ChangeType(param.SearchValue, propertyType!);
                
                binaryExpressions.Add(Expression.Equal(Expression.Property(parameter, param.SearchField ?? ""), Expression.Constant(value, propertyType!)));
            }
            if (binaryExpressions.Count == 1)
            {
                search = Expression.Lambda<Func<T, bool>>(binaryExpressions.First(), parameter);
            }
            else
            {
                BinaryExpression? combinedExpression = null;
                for (int i = 0; i < binaryExpressions.Count; i++)
                {
                    if (i == binaryExpressions.Count - 1)
                    {
                        break;
                    }
                    if (i == 0)
                    {
                        combinedExpression = Expression.AndAlso(binaryExpressions[i], binaryExpressions[i + 1]);
                    }
                    else
                    {
                        combinedExpression = Expression.AndAlso(combinedExpression!, binaryExpressions[i + 1]);
                        if (i + 1 == binaryExpressions.Count - 1)
                        {
                            break;
                        }
                    }
                }
                search = Expression.Lambda<Func<T, bool>>(combinedExpression!, parameter);
            }

            // search = Expression.Lambda<Func<T, bool>>(
            //     Expression.AndAlso(
            //         Expression.Equal(Expression.Property(parameter, "FirstName"), Expression.Constant(searchValue, typeof(string))),
            //         Expression.Equal(Expression.Property(parameter, "LastName"), Expression.Constant(searchValue, typeof(string)))
            //     ),
            //     parameter
            // );

            // Employees.Where(x=>x.FirstName=="value" && x.LastName=="value")
        }
        return search;
    }
}
