using Assignment03OOP.Models.Relationships;

namespace Assignment03OOP.Models.Shipments
{
    public class InternationalShipment : Shipment
    {
        public string DestinationCountry { get; set; }
        public decimal CustomsFee { get; set; }

        public override decimal EstimatedCost => base.EstimatedCost + CustomsFee;

        public InternationalShipment(string trackingCode, string description, double weight, decimal deliveryFee, string destinationCountry, decimal customsFee, DeliveryAddress address)
            : base(trackingCode, description, weight, deliveryFee, address)
        {
            DestinationCountry = destinationCountry;
            CustomsFee = customsFee;
        }

        public InternationalShipment(string trackingCode, string description, double weight, decimal deliveryFee, string destinationCountry, decimal customsFee, string street = "Airport Rd", string city = "Berlin", string postalCode = "10115")
            : base(trackingCode, description, weight, deliveryFee, street, city, postalCode)
        {
            DestinationCountry = destinationCountry;
            CustomsFee = customsFee;
        }

        public override void PrintShipment()
        {
            Console.WriteLine("International Shipment\n");
            Console.WriteLine($"Tracking Code       : {TrackingCode}");
            Console.WriteLine($"Description         : {Description}");
            Console.WriteLine($"Weight              : {Weight} KG");
            Console.WriteLine($"Delivery Fee        : {DeliveryFee} EGP");
            Console.WriteLine($"Destination Country : {DestinationCountry}");
            Console.WriteLine($"Customs Fee         : {CustomsFee} EGP");
            Console.WriteLine($"Estimated Cost      : {EstimatedCost} EGP");
        }

        public virtual void GenerateCustomsReport()
        {
            Console.WriteLine($"[Customs Report] Shipment {TrackingCode} destined for {DestinationCountry} | Customs Fee: {CustomsFee} EGP");
        }
    }
}
