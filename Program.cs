using Assignment03OOP.Models.Centers;
using Assignment03OOP.Models.Helpers;
using Assignment03OOP.Models.Relationships;
using Assignment03OOP.Models.Shipments;

namespace Assignment03OOP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Part 01 - Theoretical Questions

            // Q1 a) What is the difference between Method Overloading and Method Overriding?
            // - Method Overloading: Multiple methods in the same class with the same name but different parameters (decided at compile time).
            // - Method Overriding: A derived class changes the implementation of a virtual method from the base class using the override keyword (decided at runtime).

            // Q1 b) What is the difference between Static Binding and Dynamic Binding?
            // - Static Binding (Early Binding): The compiler links the method call at compile time based on the reference type.
            // - Dynamic Binding (Late Binding): The CLR resolves the method call at runtime based on the actual object type.

            // Q2 a) What is the purpose of the sealed keyword when applied to a class?
            // - It stops inheritance so no other class can inherit from it.

            // Q2 b) What is the difference between a sealed class and a sealed method?
            // - Sealed Class: The entire class cannot be inherited by any class.
            // - Sealed Method: An overridden method that cannot be overridden again by any further derived classes.

            // Q2 c) Can a sealed method be overridden? Why?
            // - No, because the sealed keyword blocks overriding and will give a compile error if you try.

            #endregion

            #region Part 02 - Practical

            Driver driver = new Driver(101, "Ahmed Mohamed", "01012345678");
            DeliveryCenter center = new DeliveryCenter(10);
            center.Driver = driver;

            StandardShipment standard = new StandardShipment(
                trackingCode: "SH001",
                description: "Laptop",
                weight: 3.0,
                deliveryFee: 80m,
                street: "10 Tahrir St",
                city: "Cairo",
                postalCode: "11511"
            );

            ExpressShipment express = new ExpressShipment(
                trackingCode: "SH002",
                description: "Mobile Phone",
                weight: 2.0,
                deliveryFee: 60m,
                extraFee: 30m,
                street: "25 Corniche Ave",
                city: "Alexandria",
                postalCode: "21500"
            );

            InternationalShipment international = new InternationalShipment(
                trackingCode: "SH003",
                description: "Television",
                weight: 8.0,
                deliveryFee: 120m,
                destinationCountry: "Germany",
                customsFee: 100m,
                street: "Friedrichstrasse 45",
                city: "Berlin",
                postalCode: "10117"
            );

            center.AddShipment(standard);
            center.AddShipment(express);
            center.AddShipment(international);

            center.PrintAllShipments();

            Console.WriteLine("Printing Using DeliveryHelper...\n");
            DeliveryHelper.PrintShipmentDetails(standard);
            DeliveryHelper.PrintShipmentDetails(express);
            DeliveryHelper.PrintShipmentDetails(international);

            Console.WriteLine("=========================================\n");
            Console.WriteLine("Updating Weight...\n");

            Console.Write("Standard Shipment: ");
            standard.UpdateWeight(4.5);

            Console.Write("Express Shipment : ");
            express.UpdateWeight(2.0, 1.0);

            Console.WriteLine();

            Console.WriteLine("=========================================");
            Console.WriteLine("Mixed Shipment Collection (Polymorphism)");
            Console.WriteLine("=========================================\n");

            Shipment[] mixedFleet = new Shipment[]
            {
                standard,
                express,
                international,
                new CompletedShipment("SH004", "Documents", 0.5, 30m, "Al-Ahram St", "Giza", "12556"),
                new PriorityInternationalShipment("SH005", "Medical Equipment", 12.0, 300m, "France", 250m)
            };

            foreach (Shipment s in mixedFleet)
            {
                Console.WriteLine($"-> [{s.TrackingCode}] Type: {s.GetType().Name} | Estimated Cost: {s.EstimatedCost} EGP");
            }
            Console.WriteLine();

            Console.WriteLine("=========================================");
            Console.WriteLine("Demonstrating Sealed Class & Sealed Method");
            Console.WriteLine("=========================================\n");

            CompletedShipment completed = new CompletedShipment("SH004", "Medical Records", 1.0, 50m);
            Console.WriteLine($"[Sealed Class] CompletedShipment instantiated: {completed.TrackingCode}");

            PriorityInternationalShipment priority = new PriorityInternationalShipment("SH005", "Precision Tools", 5.0, 200m, "Japan", 180m);
            priority.GenerateCustomsReport();

            Console.WriteLine("\n=========================================");
            Console.WriteLine("Assignment 03 Executed Successfully!");
            Console.WriteLine("=========================================");

            #endregion
        }
    }
}
