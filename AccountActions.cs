using System;

public class AccountActions
{
    private readonly AppDbContext _context;

    public AccountActions()
    {
        _context = new AppDbContext();
    }

    public PaymentData GetOrderPaymentStatusAction(int compId)
    {
        var pData = _account.PaymentData.Find(compId);
        if (pData == null)
        {
            return null;
        }

        return new PaymentDataDto
        {
            CompId = CompId,
            Status = pData.PaymentStatus,
            Amount = pData.Amount
        };
    }
}
