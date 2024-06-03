using System;
using System.Collections.Generic;

#region Address Class
// Represents an address with street, city, state, and country
public class Address
{
    private string _street;
    private string _city;
    private string _state;
    private string _country;

    public Address(string street, string city, string state, string country)
    {
        _street = street;
        _city = city;
        _state = state;
        _country = country;
    }

    // Checks if the address is in the USA
    public bool IsInUSA() => _country.ToLower() == "usa";

    // Provides a string representation of the address
    public override string ToString() => $"{_street}\n{_city}, {_state}\n{_country}";
}
#endregion

#region Customer Class
// Represents a customer with a name and address
public class Customer
{
    private string _name;
    private Address _address;

    public Customer(string name, Address address)
    {
        _name = name;
        _address = address;
    }

    // Returns the customer's name
    public string GetName() => _name;

    // Returns the customer's address
    public Address GetAddress() => _address;

    // Checks if the customer is in the USA
    public bool IsInUSA() => _address.IsInUSA();
}
#endregion

#region Product Class
// Represents a product with a name, product ID, price, and quantity
public class Product
{
    private string _name;
    private string _productId;
    private decimal _price;
    private int _quantity;

    public Product(string name, string productId, decimal price, int quantity)
    {
        _name = name;
        _productId = productId;
        _price = price;
        _quantity = quantity;
    }

    // Returns the product's name
    public string GetName() => _name;

    // Returns the product's ID
    public string GetProductId() => _productId;

    // Returns the product's price
    public decimal GetPrice() => _price;

    // Returns the product's quantity
    public int GetQuantity() => _quantity;

    // Calculates the total cost of the product
    public decimal GetTotalCost() => _price * _quantity;
}
#endregion

#region Order Class
// Represents an order containing products and a customer
public class Order
{
    private List<Product> _products;
    private Customer _customer;

    public Order(Customer customer)
    {
        _customer = customer;
        _products = new List<Product>();
    }

    // Adds a product to the order
    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    // Calculates the total cost of the order including shipping
    public decimal GetTotalCost()
    {
        decimal total = 0;
        foreach (var product in _products)
        {
            total += product.GetTotalCost();
        }

        // Adds shipping cost based on customer's location
        total += _customer.IsInUSA() ? 5 : 35;
        return total;
    }

    // Generates the packing label for the order
    public string GetPackingLabel()
    {
        string label = "Packing Label:\n";
        foreach (var product in _products)
        {
            label += $"{product.GetName()} (ID: {product.GetProductId()})\n";
        }
        return label;
    }

    // Generates the shipping label for the order
    public string GetShippingLabel()
    {
        return $"Shipping Label:\n{_customer.GetName()}\n{_customer.GetAddress()}";
    }
}
#endregion

#region Program Class
// Main program to create and display orders
public class Program
{
    public static void Main(string[] args)
    {
        // Creating addresses for customers
        Address address1 = new Address("123 Main St", "New York", "NY", "USA");
        Address address2 = new Address("456 Elm St", "Toronto", "ON", "Canada");

        // Creating customers with their respective addresses
        Customer customer1 = new Customer("John Doe", address1);
        Customer customer2 = new Customer("Jane Smith", address2);

        // Creating products
        Product product1 = new Product("Laptop", "A123", 999.99m, 1);
        Product product2 = new Product("Mouse", "B456", 25.50m, 2);
        Product product3 = new Product("Keyboard", "C789", 45.75m, 1);

        // Creating orders and adding products to them
        Order order1 = new Order(customer1);
        order1.AddProduct(product1);
        order1.AddProduct(product2);

        Order order2 = new Order(customer2);
        order2.AddProduct(product2);
        order2.AddProduct(product3);

        // Displaying packing labels, shipping labels, and total costs for each order
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Cost: {order1.GetTotalCost():C}\n");

        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Cost: {order2.GetTotalCost():C}");
    }
}
#endregion
