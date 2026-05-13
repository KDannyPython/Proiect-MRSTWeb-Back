using System;

private readonly IAccount _account;
public ActionResult VerifyOrderStatus()
{
	int CompId;
	var convert = int.TryParse(Id, out CompId);
	if (CompId)
	{
		PaymentData pData = _account.GetOrderPaymentStatus(CompId);
		bool status = pData.Status;
		decimal	amount = pData.Amount;
    }

	return View();
}
