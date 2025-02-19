namespace Ambev.DeveloperEvaluation.Integration.Abstractions;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
public class OrderAttribute : Attribute
{
    public int Order { get; }
    public OrderAttribute(int order) => Order = order;
}
