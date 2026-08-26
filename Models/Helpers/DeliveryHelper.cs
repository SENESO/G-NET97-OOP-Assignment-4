using Assignment03OOP.Models.Shipments;

namespace Assignment03OOP.Models.Helpers
{
    public static class DeliveryHelper
    {
        public static void PrintShipmentDetails(Shipment shipment)
        {
            if (shipment == null) return;

            string shipmentType = shipment switch
            {
                StandardShipment => "Standard Shipment",
                ExpressShipment => "Express Shipment",
                PriorityInternationalShipment => "Priority International Shipment",
                InternationalShipment => "International Shipment",
                CompletedShipment => "Completed Shipment",
                _ => "Shipment"
            };

            Console.WriteLine($"{shipmentType} Printed Successfully.\n");
        }
    }
}
