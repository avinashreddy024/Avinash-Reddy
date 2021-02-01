using System;
using System.Collections.Generic;
using System.Linq;

namespace Assignment1_Spring2021
{
    class Program
    {
        static void Main(string[] args)
        {   //Question 1      
            Console.WriteLine("Q1 : Enter the number of rows for the traingle:");
            int n = Convert.ToInt32(Console.ReadLine());
            printTriangle(n);
            Console.WriteLine();

            //Question 2:         
            Console.WriteLine("Q2 : Enter the number of terms in the Pell Series:");
            int n2 = Convert.ToInt32(Console.ReadLine());
            printPellSeries(n2);
            Console.WriteLine();

            //Question 3:           
            Console.WriteLine("Q3 : Enter the number to check if squareSums exist:");
            int n3 = Convert.ToInt32(Console.ReadLine());
            bool flag = squareSums(n3);
            if (flag)
            {
                Console.WriteLine("Yes, the number can be expressed as a sum of squares of 2 integers");
            }
            else
            {
                Console.WriteLine("No, the number cannot be expressed as a sum of squares of 2 integers");
            }

            //Question 4:      
            int[] arr = { 3, 1, 4, 1, 5 };
            Console.WriteLine("Q4: Enter the absolute difference to check");
            int k = Convert.ToInt32(Console.ReadLine());
            int n4 = diffPairs(arr, k);
            Console.WriteLine("There exists {0} pairs with the given difference", n4);

            //Question 5:          
            List<string> emails = new List<string>();
            emails.Add("dis.email + bull@usf.com");
            emails.Add("dis.e.mail+bob.cathy@usf.com");
            emails.Add("disemail+david@us.f.com");
            int ans5 = UniqueEmails(emails);
            Console.WriteLine("Q5");
            Console.WriteLine("The number of unique emails is " + ans5);

            //Quesiton 6:      
            string[,] paths = new string[,]
            {
                {
                    "London", "New York"
                },
                {
                    "New York", "Tampa"
                },
                {
                    "Delhi", "London"
                }
            };
            string destination = DestCity(paths);
            Console.WriteLine("Q6");
            Console.WriteLine("Destination city is " + destination);
        }

        private static void printTriangle(int n)
        {
            //the outer lopp goes till n (i.e fr each row)
            //The inner loops are responsible for printing stars and spaces 
            for (int i = 0; i < n; i++)
            {
                string l = "";
                for (int j = i; j < n - 1; j++)
                {
                    l += " ";
                }
                for (int k = 0; k < 2 * i + 1; k++)
                {
                    l += "*";
                }
                Console.WriteLine(l);
            }
        }
        private static void printPellSeries(int n2)
        {

            //we  follow the logic of PELL series i.e next number = 2*previous+ pell number before
            
            int m = 0;
            int n = 1;
            for (int i = 0; i <n2 ; i++)
            {
                //printing first two integers as 0 and 1 in the series
                if(i==0 || i==1)
                {
                    Console.Write(i + " ");
                }
                else
                {
                    int x = 2 * n + m;
                    //keep swapping the numbers to m,n accordingly.
                    m = n;
                    n = x;
                    Console.Write(x + " ");
                }             
            }
        }
        private static bool squareSums(int n3)
        {

            // Here we can iterate till sqrt(n) and check if there exists any two 
            //numbers such that there squares add up to given number.
            //typecasting float to integer
            int n = (int) Math.Sqrt(n3);
            bool flag = false;
            for(int i=0; i<=n; i++)
            {
                for(int j=i; j<=n; j++)
                {
                    //calculating sum of squares
                    if (i * i + j*j == n3)
                        flag = true;
                }
            }
            return flag;
        }
        private static int diffPairs(int[] nums, int k)
        {
            //we sort the array and check if there exists any two numbers  where the differene 
            // is K.
            //And to remove duplicates we initalize the array and check if those numbers 
            // are already counted for.

            int count = 0;
            int[] a = new int[100];
            Array.Sort(nums);
            //loop for first number in the difference
            for(int i=0; i<nums.Length; i++)
            {
                //loop for second number in the difference
                for (int j=i+1; j<nums.Length; j++)
                {
                    //finding difference and checking for difference k
                        if (Math.Abs(nums[i] - nums[j]) == k)
                    {
                        //puttiing 1's if we get that number in the difference
                        if (!(a[nums[i]] == 1 && a[nums[j]] == 1))
                        {
                            a[nums[i]] = 1;
                            a[nums[j]] = 1;
                            count++;
                        }

                    }
                }
            }
            return count;
        }
        private static int UniqueEmails(List<string> emails)
        {
            //Here we process the mails according to the given condions and store in the new list
            //And count the unique mails in the new list.
            int count;
            Dictionary<string, int> added = new Dictionary<string, int>();
            List<string> mails = new List<string>();
            //taking one mail at a time
            foreach(var name in emails)
            {
                string str = "";
                bool ignore = false;
                int j = 0;
                //taking one character at a time from mail
                foreach(var p in name)
                {
                    j += 1;
                    //checking for '@' and adding evrything after that.
                    if (p == '@')
                    {
                        for(int i=j-1; i<name.Length;i++)
                        {
                            str += name[i];
                        }
                        break;
                    }
                    //just ignoring if we get '.' and ' '
                    if (p=='.' || p==' ')
                    {
                        continue;
                    }
                    //ignoring text after '+' sign
                    if (p == '+')
                    {
                        ignore = true;
                    }
                    if(!ignore)
                        str += p;

                }
                //adding filtered mails into new list
                mails.Add(str);
            }
            foreach(var n in mails)

            {
                //adding every mail to dictionary(added)
                    added[n] = 1;
            }
            //count of dictionary
            return added.Count();
        }
        private static string DestCity(string[,] paths)
        {
            //comparing every second city in each row with the first city in each row other tha this.
            string result="";
            bool flag = true;
            //traversing through each row
            for(int i=0;i<paths.Length; i++)
            {
                flag = true;
                int j;
                //checking for first city in each row
                for(j=0; j<paths.Length/2;j++)
                {
                    if(paths[i,1]== paths[j,0])
                    {
                        flag = false;
                        break;
                    }
                }
                if (flag)
                {
                    result = paths[i, 1];
                    break;
                }
            }
            return result;
        }
    }
}