/**************************************************************
    * Author - Mohammad Hasan Raza
    * Project Name - Problem10 ,this is a class library
    * Purpose - Exchange foreign country rupees into indian rupees
    * Date 24 May 2021
    * Copyright @ {Bhavna Corp 2021}
    ***************************************************************/

using System;
using System.Data;
using System.Data.SqlClient;
namespace CurrencyLibrary
{
    public class Class1
    {
        // creting table currency
        public void CreateTable()
        {
            SqlConnection con = null;
            try
            {
                //connection sql server
                con = new SqlConnection("data source=.; database=ForeignCurrency; integrated security=SSPI");
                SqlCommand cm = new SqlCommand("create table currency(name varchar(100), cost float)", con);
                con.Open();

                cm.ExecuteNonQuery();

                Console.WriteLine("Table created Successfully");
            }
            catch (Exception e)
            {
                Console.WriteLine("currency Table already exist ");
            }

            finally
            {
                con.Close();
            }
        }

        // inserting foreign currencies sign and their indian rupess value
        public void insertData()
        {
            string curr;
            int row;
            double value;
            SqlConnection con = null;
            try
            {

                Console.WriteLine("Ho many currency you want to insert atleast 5");
                row = Convert.ToInt32(Console.ReadLine());
                row = row < 5 ? 5 : row;
                // dispose  
                con = new SqlConnection("data source = . ; database = ForeignCurrency ; integrated security=SSPI");
                con.Open();
                Console.WriteLine("Enter  foreign currency and their values in indian rupees");
                SqlCommand cm;
                for (int i = 0; i < row; i++)
                {
                    curr = Console.ReadLine();
                    value = Convert.ToDouble(Console.ReadLine());
                    cm = new SqlCommand("insert into currency(name,cost) values(@curr , @value )", con);
                    cm.Parameters.AddWithValue("@curr", curr);
                    cm.Parameters.AddWithValue("@value", value);

                    cm.ExecuteNonQuery();
                    // returning no of rows

                }

            }
            catch (Exception e)
            {
                Console.WriteLine("Something Wrong");
            }
            finally
            {
                con.Close();
            }
        }


        // converting foriegn currency to indian currency
        public void fetchData()
        {
            SqlConnection con = null;
            double sdr1;
            try
            {
                con = new SqlConnection("data source = . ; database = ForeignCurrency ; integrated security=SSPI; MultipleActiveResultSets = true");

                SqlCommand cm = new SqlCommand("select * from currency", con);
                con.Open();
                SqlDataReader sdr = cm.ExecuteReader();
                Console.WriteLine("Available currencies are");
                Console.WriteLine("Foreign currency Sign" + "     " + "Indian rupee values");

                while (sdr.Read())
                {
                    Console.Write(sdr["name"] + "   " + sdr["cost"]);
                    Console.WriteLine();
                }
                Console.WriteLine("Do you want to delete current conversion list and add new conversion list? Yes or not");
                if (Console.ReadLine() == "Yes")
                {
                    new Class1().DeleteData();
                    new Class1().insertData();

                }
                int amt = 0;
                string value;
                Console.WriteLine("Enter currrency symbol");
                try
                {

                    value = Console.ReadLine();
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid Input");
                    return;

                }
                Console.WriteLine("Enter currrency amount");
                try
                {

                    amt = Convert.ToInt32(Console.ReadLine());

                }
                catch (Exception e)
                {
                    Console.WriteLine("Invalid Input");
                    return;

                }

                SqlCommand cm1 = new SqlCommand("select cost from currency where name = @value", con);
                cm1.Parameters.AddWithValue("@value", value);
                // obtaining currency value
                object sdr2 = cm1.ExecuteScalar();
                //currency value may be null when this not exixt in table
                if (sdr2 == null)
                {
                    Console.WriteLine("No such currency exist in database");
                    return;

                }



                if ((double)sdr2 != 0)
                {
                    Console.WriteLine("total Indian Rupees" + string.Format("{0:#.##}", (double)sdr2 * amt));
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("No such currency exist in database" + e);
            }
            finally
            {
                con.Close();
            }
        }

        //performing deletion operation of all currency
        public void DeleteData()
        {
            SqlConnection con = null;
            try
            {
                //sql connection
                con = new SqlConnection("data source = . ; database = ForeignCurrency ; integrated security=SSPI");
                //Sql command
                SqlCommand cm = new SqlCommand("delete  from currency", con);
                con.Open();
                int row = cm.ExecuteNonQuery();
                if (row > 0)
                    Console.WriteLine("Deleted successfully");
                else
                    Console.WriteLine("Deletion Failed");

            }
            catch (Exception e)
            {
                Console.WriteLine("Something Wrong");
            }
            finally
            {
                con.Close();
            }
        }
    }
}
