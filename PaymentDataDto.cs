using System;


public class PaymentDataDto
{
	[Key]
	public int CompId { get; set; }

	public bool Status { get; set; }

	public decimal Amount { get; set; } 
}
