// Copyright Amazon.com, Inc. or its affiliates. All Rights Reserved.
// SPDX-License-Identifier: MIT-0
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost host = null;
            try
            {
                Console.WriteLine("Client OS: {0}", Environment.OSVersion);
                host = new ServiceHost(typeof(CalculatorService));
                host.Open();
                foreach (var uri in host.BaseAddresses)
                {
                    Console.WriteLine("Started the service: {0}", uri);
                }

                // Leave the service running
                Console.WriteLine("The service is running in background...");
                Thread.Sleep(-1);
            }
            catch
            {
                host?.Close();
                Console.WriteLine("The service is closed");
            }
        }
    }
}