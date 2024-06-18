using System.ComponentModel.DataAnnotations;

namespace API.Apps.AdminApi.DTOs
{
    public class BrandDto
    {
        [MaxLength(20)]
        public string Name { get; set; }
    }
}
