using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Presentation.Data;

public class EventEntity
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string EventName { get; set; } = null!;
    public string? EventDescription { get; set; }
    public string? EventImage { get; set; }
    public string Location { get; set; } = null!;
    public string City { get; set; } = null!;
    public string? State { get; set; }
    public DateTime EventStartDate { get; set; }
    public DateTime EventEndDate { get; set; }
    public DateTime TicketStartDate { get; set; }
    public int TicketAmount { get; set; }

    [Column(TypeName = "decimal(6,2)")]
    public decimal Price { get; set; }

}
