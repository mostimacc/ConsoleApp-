using System;
class Saving_card
{ 
    private int money;
    public string customer;
    public int Money
    {
        get 
        { 
            return money; 
        }
        set 
        { 
            money = value; 
        }
    }
}
class Credit_Card : Saving_card 
{
    private int time;
    Saving_card card;
    private int maxpayment = 10000;
    public Credit_Card(string u, int t, int m, Saving_card c)
    {
        customer = u; time = t; Money = m; card = c;
    }
    public int Time
    {
  
        get 
        {
            return time;
        }
        set 
        { 
            time = value;
        }
    }
    public void paymoney()
    {
        if (Money < maxpayment)
        {
            Console.WriteLine("您本月消费:{0}", Money);

            Console.WriteLine("用户{0}:信用卡待还:{1}，储蓄卡余额:{2}", customer, Money, card.Money);
            if (card.Money < Money)
            {
                Money -= card.Money;
                card.Money = 0;
                Console.WriteLine("已到还款日期,您的储蓄卡余额不足，信用卡待还:{0}，储蓄卡余额为0", Money - card.Money);
            }
            else
            {
                card.Money -= Money;
                Money = 0;
                Console.WriteLine("已到还款日期,还完欠款后，信用卡待还为0，储蓄卡余额:{0}", card.Money - Money);
            }
        }
        else
            Console.WriteLine("您没有那么多的额度");
    }
    public void notime()
    {
        Console.WriteLine("未到还款日期，储蓄卡余额:{0}，信用卡待还:{1}", Money, card.Money);
    }

}

class Paydelegate
{
    public delegate void paydelegate();
    public event paydelegate payevent;
    public void Notify()
    {
        if (payevent != null)
        {

            payevent();
        }
    }
}
class program
{
    static void Main(string[] args)
    {
        int paytime = 15;
        Saving_card sc = new Saving_card();
        sc.Money = 1000;
        Credit_Card C1 = new Credit_Card("张三",15, 3000, sc);
        Paydelegate pay = new Paydelegate();
        if (paytime == C1.Time)
        {
            pay.payevent += new Paydelegate.paydelegate(C1.paymoney);
        }
        else
            pay.payevent += new Paydelegate.paydelegate(C1.notime);
        pay.Notify();
    }
}
