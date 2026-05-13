using System;

public class AccountLogic : AccountActions, IAccount
{
	public void GetOrderPaymentStatus(int compId)
	{
        GetOrderPaymentStatusAction(compId);
    }
}
