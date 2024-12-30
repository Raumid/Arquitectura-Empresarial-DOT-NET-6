namespace Pacagroup.Ecommerce.Application.DTO
{
    public class CustomersDto
    {
        /**
         * En esta capa solo se exponen las propiedades necesarias
         * en esta caso como no se tiene RN se exponen todos los campos
         * Tambien se pueden renonbrar de forma distinta.
         */
        public string CustomerId { get; set; }
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string ContactTitle { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
    }
}