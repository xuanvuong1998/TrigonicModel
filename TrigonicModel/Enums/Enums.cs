namespace TrigonicModel
{
    public enum ProjectStatus
    {
        Raising = 0,
        RaisedFailed = -1,
        RaisedSucessful = 1,
        Removed = -2
    }

    public enum Payment
    {
        VISA,
        MOMO,
        PAYPAL,
        ZALOPAY
    }

    public enum TransactionStatus
    {
        FAILED,
        SUCCESS,
        DEPRECATED,
    }

    public enum TransactionType
    {
        INVEST,
        REVENUE_RETURN,
        INVEST_PROFIT_RETURN
    }

    public enum UserRole
    {
        ADMIN = 0,
        ENTERPRISE = 1,
        INVESTOR = 2
    }


}