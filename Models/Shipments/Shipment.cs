using Assignment03OOP.Models.Relationships;

namespace Assignment03OOP.Models.Shipments
{
    public class Shipment
    {
        public string TrackingCode { get; set; }
        public string Description { get; set; }
        public double Weight { get; set; }
        public decimal DeliveryFee { get; set; }
        public DeliveryAddress Address { get; set; }

        public virtual decimal EstimatedCost => DeliveryFee + ((decimal)Weight * 5m);

        public Shipment(string trackingCode, string description, double weight, decimal deliveryFee, DeliveryAddress address)
        {
            TrackingCode = trackingCode;
            Description = description;
            Weight = weight;
            DeliveryFee = deliveryFee;
            Address = address;
        }

        public Shipment(string trackingCode, string description, double weight, decimal deliveryFee, string street = "Main St", string city = "Cairo", string postalCode = "11511")
            : this(trackingCode, description, weight, deliveryFee, new DeliveryAddress(street, city, postalCode))
        {
        }

        public void UpdateWeight(double newWeight)
        {
            Weight = newWeight;
            Console.WriteLine($"Weight updated to {Weight} KG.");
        }

        public void UpdateWeight(double newWeight, double extraPackingWeight)
        {
            Weight = newWeight + extraPackingWeight;
            Console.WriteLine($"Weight updated to {Weight} KG (Base: {newWeight} KG + Packing: {extraPackingWeight} KG).");
        }

        public virtual void PrintShipment()
        {
            Console.WriteLine($"Tracking Code   : {TrackingCode}");
            Console.WriteLine($"Description     : {Description}");
            Console.WriteLine($"Weight          : {Weight} KG");
            Console.WriteLine($"Delivery Fee    : {DeliveryFee} EGP");
            Console.WriteLine($"Estimated Cost: {EstimatedCost} EGP");
        }
    }
}
