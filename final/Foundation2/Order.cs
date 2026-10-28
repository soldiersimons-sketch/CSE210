using System;
using System.Collections.Generic;
using System.Text;

public class Order
{
    private List<Product> _products;
    private Customer _customer;

    public Order(Customer customer)
    {
        _customer = customer;
        _products = new List<Product>();
    }

    public void AddProduct(Product product) => _products.Add(product);

    public double CalculateTotal()
    {
        double total = 0;
        foreach (Product product in _products)
            total += product.GetTotalCost();
        return total + (_customer.IsInUSA() ? 5 : 35);
    }

    public string GetPackingLabel()
    {
        StringBuilder label = new StringBuilder();
        label.AppendLine("PACKING LABEL");
        foreach (Product product in _products)
            label.AppendLine(product.GetPackingInfo());
        return label.ToString();
    }

    public string GetShippingLabel()
    {
        return $"SHIPPING LABEL\n{_customer.GetName()}\n{_customer.GetAddress().GetFullAddress()}";
    }
}
