public enum MemoView :int
{
    InboundMemos             = 1,   //     0000 0001
    InboundMemosForMyOrders  = 3,   //     0000 0011
    SentMemosAll             = 16,  //     0001 0000
    SentMemosNotReceived     = 48,  //     0011
    SentMemosReceivedNotRead = 80,  //     0101
    SentMemosRead            = 144, //     1001
    Outbox                   = 272, //0001 0001 0000
    OutBoxErrors             = 784  //0011 0001 0000
}

private string GetFilterForView (MemoView view, DefaultableBoolean readOnly)
{
    string filter = string.Empty;
    if ((view & MemoView.InboundMemos) == MemoView.InboundMemos)
    {
        filter = "<inbox filter conditions>";

        if ((view & MemoView.InboundMemosForMyOrders) == 
            MemoView.InboundMemosForMyOrders)
        {
            filter += "<my memo filter conditions>";
        }
    }
    else if ((view & MemoView.SentMemosAll) == MemoView.SentMemosAll)
    {
        //all sent items have originating system = to local
        filter = "<memos leaving current system>";

        if ((view & MemoView.Outbox) == MemoView.Outbox)
        {
            ...
        }
        else
        {
            //sent sub folders
            filter += "<all sent items>";

            if ((view & MemoView.SentMemosNotReceived) == 
                MemoView.SentMemosNotReceived)
            {
                if ((view & MemoView.SentMemosReceivedNotRead) == 
                    MemoView.SentMemosReceivedNotRead)
                {
                    filter += "<not received and not read conditions>";
                }
                else
                    filter += "<received and not read conditions>";
            }
        }
    }

    return filter;
}