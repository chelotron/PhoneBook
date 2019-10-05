namespace appPhone.Models
{

    public enum TypeContact
    {
        PhoneNumber,
        EMail,
        Facebook,
        Twitter,
        LinkedIN
    }

    public class Phone
    {
        
        public int PhoneID { get; set; }
        
        public string Name { get; set; }
        
        public TypeContact Type { get; set; }
        
        public string Contact { get; set; }
    }
}