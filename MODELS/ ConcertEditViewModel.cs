public class ConcertEditViewModel
{
    public int ConcertId { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    public DateTime ConcertDate { get; set; }

    public string Address { get; set; }
    public string City { get; set; }

    public string TicketSalePassword { get; set; }

    [RegularExpression(@"[A-Z]{3}\d{3}")]
    public string PromoCode { get; set; }

    [Range(1, 150000)]
    public int Capacity { get; set; }
}
