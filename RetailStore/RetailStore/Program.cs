using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace RetailStore
{
    class Program
    {
        static void Main(string[] args)
        {
            User user1 = new User();
            Bill bill = new Bill();
            string line;
            StreamWriter sw = new StreamWriter(Environment.CurrentDirectory + "/OutputFile.txt");
            StreamReader s = new StreamReader(Environment.CurrentDirectory + "/Bill_Details.txt");
            while ((line = s.ReadLine()) != null)
            {
                if (line.Contains("BillNo:"))
                {
                    string customer_id = s.ReadLine();
                    string[] date = s.ReadLine().Split();
                    float total = float.Parse(s.ReadLine());
                    float grocery = float.Parse(s.ReadLine());
                    DateTime d = new DateTime(int.Parse(date[2]), int.Parse(date[1]), int.Parse(date[0]));
                    bill.AddBill(line, d, customer_id, total, grocery);
                    break;
                }
            }
           //Get Customer Details from file for the correspoding customer
            StreamReader sr = new StreamReader(Environment.CurrentDirectory + "/Customer_Details.txt");
            while ((line = sr.ReadLine()) != null)
            {
                if (line.Equals(bill.GetCustomerID()))
                {
                    string name = sr.ReadLine();
                    string[] date = sr.ReadLine().Split();
                    int status = int.Parse(sr.ReadLine());
                    DateTime d = new DateTime(int.Parse(date[2]), int.Parse(date[1]), int.Parse(date[0]));
                    user1.AddCustomer(name,line, d, status);
                    break;
                }
            }
            if (line == null)
            {
                sw.WriteLine("Customer database not found");
            }
            else
            {
                int yr = user1.GetLoyaltyYears(bill.GetBillDate());
                Discount discount = new Discount();
                float discount_amount = discount.GetDiscountAmount(user1.GetCustomerStatus(), yr, bill.GetTotalCost(), bill.GetGroceryCost());
                float final_amount = bill.GetTotalCost() - discount_amount;
                sw.WriteLine("Bill Amount After Discount :");
                sw.WriteLine(final_amount);
            }
            sw.Dispose();
            s.Dispose();
            sr.Dispose();
        }
    }
    public class User
    {
        string user_name;
        string user_id;
        DateTime join_date;
        int user_status; //0-customer, 1-employee, 2-affliat
        public void AddCustomer(string name, string id, DateTime date, int status)
        {
            user_name = name;
            user_id = id;
            join_date = date;
            user_status = status;
        }

        public int GetCustomerStatus()
        {
            return user_status;
        }

        public int GetLoyaltyYears(DateTime bill_date)
        {
            TimeSpan dt = bill_date - join_date;
            return (dt.Days) / 365;
        }
    }

    public class Bill
    {
        string bill_id;
        DateTime bill_date;
        string user_id;
        float total_cost;
        float grocery_cost;
        public void AddBill(string id,DateTime d,string u_id, float total, float grocery)
        {
            bill_id = id;
            bill_date = d;
            user_id = u_id;
            total_cost = total;
            grocery_cost = grocery;
        }
        public string GetCustomerID()
        {
            return user_id;
        }

        public DateTime GetBillDate()
        {
            return bill_date;
        }
        public float GetTotalCost()
        {
            return total_cost;
        }
        public float GetGroceryCost()
        {
            return grocery_cost;
        }
    }

    public class Discount
    {
        public float GetDiscountAmount(int customer_status, int loyalty_years, float total_cost, float grocery_cost)
        {
            int DiscountPercent = 0;
            float Discount_BillAmount = 0;
            //Step1: Calculate discount based on customer status
            //Employee
            if (customer_status == 0)
                DiscountPercent = 30;
            //Affiliate
            else if (customer_status == 1)
                DiscountPercent = 10;
            //Normal user
            if (customer_status == 2 && loyalty_years >= 2)
            {
                if (loyalty_years > 2)
                    DiscountPercent = 5;
            }
            float DiscountAmount_Percent = (total_cost - grocery_cost) *DiscountPercent / 100;

            //Step2: Calculate Discount based on bill amount:5$ on every 100$
            Discount_BillAmount =((int) (total_cost/100)) * 5;

                        return (DiscountAmount_Percent + Discount_BillAmount);
        }

    }
}
