using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exceptions
{
    public delegate void MyDelegate();
    public class Bank
    {
        public event MyDelegate insufficientbalance;
        public event MyDelegate Zerobalance;
        public event MyDelegate LowBalance;
        public int balance = 10000;


        public void Credit(int amt)
        {
            balance = balance + amt;
            
        }
        public void  Debit(int amt)
        {
            if (amt > balance)
            {
                insufficientbalance();

            }
            else
            {
                balance -= amt;


                if (balance == 0)
                {
                    Zerobalance();
                }
                else if (balance < 3000)
                {
                    LowBalance();
                }
                else
                {

                    Console.WriteLine(balance);

                }
            }


        }
    }

    public class Events2
    {
        static void imsg()
        {
            Console.WriteLine(" you have insufficient balance");
        }
        static void zmsg()
        {
            Console.WriteLine(" you have zero balance");
        }
        static void lmsg()
        {
            Console.WriteLine(" you have low balance");
        }
        static void Main(string[] args)
        {
            Bank b = new Bank();
            b.insufficientbalance += new MyDelegate(imsg);
            b.Zerobalance +=new MyDelegate(zmsg);
            b.LowBalance +=new MyDelegate(lmsg);
            b.Credit(0);
            b.Debit(3000);
          
        }
    }
}
