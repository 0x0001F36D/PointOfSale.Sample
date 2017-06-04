using PointOfSale.Contents.Common;

namespace PointOfSale.Contents.Service.Infrastructure
{
    public class Guest
    {
        public readonly static Guest Undefined = new Guest(null, null, null);

        public bool IsUndefined()
            => this.GetHashCode().Equals(Undefined);

        public Guest(string name, string phoneNumber, string address)
        {
            this.Name = name;
            this.Address = address;
            this.PhoneNumber = phoneNumber;
        }
    
        public string Name
        {
            get => name ?? "Guest";
            private set => name = value;
        }
        private string name;

        public string Address
        {
            get => address ?? "<Unnecessary>";
            private set => address = value;
        }
        private string address;

        public string PhoneNumber
        {
            get => phoneNumber ?? "<Unnecessary>";
            private set => phoneNumber = value;
        }
        private string phoneNumber;

        public void Modify(string itemName, string value)
        {
            switch (itemName)
            {
                case nameof(Name): this.Name = value; break;
                case nameof(Address): this.Address = value; break;
                case nameof(PhoneNumber): this.PhoneNumber = value; break;
                default:
                    throw new PosException("Field undefined : " + itemName);
            }
        }

        public override bool Equals(object obj)
            => this.GetHashCode().Equals(obj.GetHashCode());

        public override int GetHashCode()
            => (this.Name.GetHashCode() + this.Address.GetHashCode()) ^ this.PhoneNumber.GetHashCode();

        public override string ToString() 
            => $"Guest: {this.Name}, Phone: {this.PhoneNumber}, Address: {this.Address}";
    }
}
