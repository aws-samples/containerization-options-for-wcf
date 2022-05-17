// Copyright Amazon.com, Inc. or its affiliates. All Rights Reserved.
// SPDX-License-Identifier: MIT-0
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class Program
    {
        private static string host;

        static void Main(string[] args)
        {
            Console.WriteLine("Starting ...");
            host = args.Length > 0 ? args[0] : "localhost";
            Console.WriteLine("Server DNS is: " + host);
            

            while (true)
            {
                Console.WriteLine("Pick up a protocol: Http or NetTcp");
                Console.WriteLine("Type \"exit\" to quit");
                var input = Console.ReadLine();
                if(input == "exit")
                    break;

                if (string.IsNullOrEmpty(input) || string.IsNullOrWhiteSpace(input))
                    continue;

                input = input.ToLower();
                if(!"http".Equals(input) && !"nettcp".Equals(input)) 
                    continue;

                
                Console.WriteLine("Enter the 1st Integer: ");
                var firstNumber = Int32.Parse(Console.ReadLine());
                Console.WriteLine("Enter the 2nd Integer: ");
                var secondNumber = Int32.Parse(Console.ReadLine());
                try
                {
                    switch (input)
                    {
                        case "http":
                            AddViaHttp(firstNumber, secondNumber);
                            break;
                        case "nettcp":
                            AddViaNetTcp(firstNumber, secondNumber);
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Oops I cannot call the service, error = " + e.Message);
                }
                

                
            }

        }

        static void AddViaHttp(int firstNumber, int secondNumber)
        {
            var address = string.Format("http://{0}:80/CalculatorService", host);
            var binding = new BasicHttpBinding();
            var factory = new ChannelFactory<ICalculator>(binding, address);
            var channel = factory.CreateChannel();

            Console.WriteLine($"{firstNumber} + {secondNumber} is " + channel.Add(firstNumber, secondNumber));
        }

        static void AddViaNetTcp(int firstNumber, int secondNumber)
        {
            var address = string.Format("net.tcp://{0}:808/CalculatorService", host);
            var binding = new NetTcpBinding(SecurityMode.None);
            var factory = new ChannelFactory<ICalculator>(binding, address);
            var channel = factory.CreateChannel();

            Console.WriteLine($"{firstNumber} + {secondNumber} is " + channel.Add(firstNumber, secondNumber));
        }
    }
}
