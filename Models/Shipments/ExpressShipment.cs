using Assignment03OOP.Models.Relationships;

namespace Assignment03OOP.Models.Shipments
{
    public class ExpressShipment : Shipment
    {
        public decimal ExtraFee { get; set; }

        public override decimal EstimatedCost => base.EstimatedCost + ExtraFee;

        public ExpressShipment(string trackingCode, string description, double weight, decimal deliveryFee, decimal extraFee, DeliveryAddress address)
            : base(trackingCode, description, weight, deliveryFee, address)
        {
            ExtraFee = extraFee;
        }

        public ExpressShipment(string trackingCode, string description, double weight, decimal deliveryFee, decimal extraFee, string street = "Express Way", string city = "Alexandria", string postalCode = "21500")
            : base(trackingCode, description, weight, deliveryFee, street, city, postalCode)
        {
            ExtraFee = extraFee;
        }

        public override void PrintShipment()
        {
            Console.WriteLine("Express Shipment\n");
            Console.WriteLine($"Tracking Code   : {TrackingCode}");
            Console.WriteLine($"Description     : {Description}");
            Console.WriteLine($"Weight          : {Weight} KG");
            Console.WriteLine($"Delivery Fee    : {DeliveryFee} EGP");
            Console.WriteLine($"Extra Fee       : {ExtraFee} EGP");
            Console.WriteLine($"Estimated Cost: {EstimatedCost} EGP");
        }
    }
}
