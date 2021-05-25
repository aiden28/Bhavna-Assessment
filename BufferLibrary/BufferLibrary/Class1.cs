/***************************************************************************************
 * Author Mohammad Hasan Raza
 * Project Name Problem09
 * Purpose - store maximum 10 data in buffer if data is more than 10, then override it. This is a class library
 * Date 24 May 2021
 * Copyright @ {Bhavna Corp 2021}
 ***************************************************************************************/
using System;
using System.Collections;

namespace BufferLibrary
{
    public class Class1
    {
        public void MaxBuffer(int n)
        {
            var arlist = new ArrayList();
            string line, flag = " ";
            int count = 0, ind;
            Console.WriteLine("Inter data line by line to store in buffer and press '?' for print data stored in buffer and exit from program");

            //taking input unknown no. of input
            while ((line = Console.ReadLine()) != null)
            {

                // printing latest stored buffer data
                if (line == "?")
                {
                    foreach (var item in arlist)
                        Console.WriteLine(item);
                    break;
                }
                // if input is not ? then store it into buffer.
                else
                {
                    if (count > n - 1)
                    {
                        Console.WriteLine("Alert data is stored it's limit");
                        Console.WriteLine("Want to continue to store data then press 'y' otherwise press any key for exit");
                        flag = Console.ReadLine();

                        if (flag == "y")
                        {
                            flag = " ";
                            ind = count % n;
                            //overriding data

                            arlist[ind] = line;
                        }
                        else
                            break;
                    }
                    else
                    {
                        arlist.Add(line);
                        //condition - when buffer is full
                        if (count == n - 1)
                            Console.WriteLine("Alert Buffer is full");
                    }

                }

                count += 1;
        }   }
    }
}
