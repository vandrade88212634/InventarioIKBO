namespace Dominio.Servicio.DTO.Identity
{
    public class RegistrationRequest
    {
        public string Name { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string Pasword { get; set; } = string.Empty;
    }
}