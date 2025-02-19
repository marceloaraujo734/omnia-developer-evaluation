using Xunit.Abstractions;
using Xunit.Sdk;

namespace Ambev.DeveloperEvaluation.Integration.Abstractions;

public class SequentialOrderer : ITestCaseOrderer
{
    public IEnumerable<TTestCase> OrderTestCases<TTestCase>(IEnumerable<TTestCase> testCases) where TTestCase : ITestCase
    {
        return testCases.OrderBy(option =>
        {
            var orderAttribute = option.TestMethod.Method.GetCustomAttributes(typeof(OrderAttribute).AssemblyQualifiedName).FirstOrDefault();

            return orderAttribute is null ? int.MaxValue : orderAttribute.GetNamedArgument<int>("Order");
        });
    }
}
