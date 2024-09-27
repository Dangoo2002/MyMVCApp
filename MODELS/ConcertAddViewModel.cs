using System;
using System.ComponentModel.DataAnnotations;

public class ConcertAddViewModel
{
    [Required]
    public string Name { get; set; }

    [Required]
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    public DateTime ConcertDate { get; set; } = DateTime.Now.AddDays(31);

    public string Address { get; set; }
    public string City { get; set; }
}
