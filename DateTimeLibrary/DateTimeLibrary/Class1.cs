/**************************************************************
 * Author Mohammad Hasan Raza
 * Project Name - Project06, This is a class library
 * Purpose - there is three subproblem
 *              1) total  no. of days b/w from date to todate
 *              2) total  no. of months, days b/w from date to todate
 *              3) total  no. of days, month and year b/w from date to todate
 * Date 18 May 2021
 * Copyright @ {Bhavna Corp 2021}
 ***************************************************************/


using System;
using System.Globalization;
namespace DateTimeLibrary
{
    public class Class1
    {
        //input fromdate and returning fromdate object

        public DateTime FromDateValidation1()
        {
            DateTime FromDate;

            Console.WriteLine("enter from date in Format dd/mm/yyyy");
            // taking date input untill a vild fromdate
            while (!(DateTime.TryParseExact(Console.ReadLine(), "dd'/'MM'/'yyyy",
                CultureInfo.InvariantCulture, DateTimeStyles.None, out FromDate) && FromDate < DateTime.Now))
            {
                if (FromDate >= DateTime.Now)
                {
                    Console.WriteLine("From Date should be less then today's date");
                }
                else
                    Console.WriteLine("Invalid Date");
                Console.WriteLine("enter from date again");
            }
            return FromDate;
        }


        //input todate and returning todate object
        public DateTime ToDateValidation(DateTime FromDate)
        {
            DateTime ToDate;
            var invaliDate = new DateTime(01, 01, 0001);

            Console.WriteLine("enter to date in Format dd/mm/yyyy");
            // taking date input untill a vild todate

            while (!(DateTime.TryParseExact(Console.ReadLine(), "dd'/'MM'/'yyyy",
                CultureInfo.InvariantCulture, DateTimeStyles.None, out ToDate) && ToDate >= FromDate))
            {
                if (ToDate.Equals(invaliDate))
                {
                    Console.WriteLine("Invalid Date");
                }
                else
                    Console.WriteLine("ToDate should be greater or equal to then from date");

                Console.WriteLine("enter todate again");
            }
            return ToDate;
        }

        //calculating date diffrences in form days, months and years

        public void DateDiff(DateTime FromDate, DateTime Todate)
        {
            DateTime StartTime = new DateTime(1, 1, 1);
            TimeSpan timeSpan = Todate - FromDate;
            int year = StartTime.Add(timeSpan).Year - 1;
            int month = StartTime.Add(timeSpan).Month - 1;
            int days = StartTime.Add(timeSpan).Day - 1;
            Console.WriteLine("total days = {0} and month = {1}", days, (month + year * 12));
            Console.WriteLine("total days = " + days + " , month = " + month + " and year = " + year);

        }
    }
}
