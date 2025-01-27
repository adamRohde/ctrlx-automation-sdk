﻿/*
MIT License

Copyright (c) 2021 Bosch Rexroth AG

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
*/

using Datalayer;
using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Threading;

namespace Samples.Datalayer.Provider.Alldata
{
    class Program
    {
        // !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        // !!! CHANGE THIS TO YOUR ENVIRONMENT !!!
        // !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        private static readonly IPAddress IpAddress = IPAddress.Parse("192.168.1.1"); // IPAddress.Loopback
        private static readonly string Username = "boschrexroth";
        private static readonly string Password = "boschrexroth";

        static void Main(string[] args)
        {
            //Add app exit handler to handle optional clean up
            AppDomain.CurrentDomain.ProcessExit += CurrentDomain_ProcessExit;

            // Check if the process is running inside a snap 
            var isSnapped = !string.IsNullOrEmpty(Environment.GetEnvironmentVariable("SNAP"));
            Console.WriteLine(value: $"Running inside snap: {isSnapped}");

            // Create a new ctrlX Data Layer system
            using var system = new DatalayerSystem();

            // Starts the ctrlX Data Layer system without a new broker (startBroker = false) because one broker is already running on ctrlX device
            system.Start(startBroker: false);
            Console.WriteLine("ctrlX Data Layer system started.");

            // Create the provider with inter-process communication (ipc) protocol if running in snap, otherwise tcp
            using var provider = isSnapped
                ? system.Factory.CreateIpcProvider()
                : system.Factory.CreateTcpProvider(IpAddress,
                    DatalayerSystem.DefaultProviderPort,
                    Username,
                    Password);
            Console.WriteLine("ctrlX Data Layer provider created.");

            // Register type with binary flatbuffers schema file: sampleSchema.bfbs (auto generated from sampleSchema.fbs by flatc compiler)
            var resultRegisterType = provider.RegisterType(MetadataProvider.TypesInertialValue, Path.Combine(AppContext.BaseDirectory, "sampleSchema.bfbs"));
            Console.WriteLine(value: $"Registering Type with address='{MetadataProvider.TypesInertialValue}', result='{resultRegisterType}'");

            // Create the static nodes
            var staticNodes = provider.CreateStaticNodes();

            // Create the dynamic nodes
            var dynamicNodes = provider.CreateDynamicNodes();

            // Start the Provider
            var startResult = provider.Start();

            // Check if provider is connected.
            Console.WriteLine(value: $"Provider connected: {provider.IsConnected}");
            if (!provider.IsConnected)
            {
                //if not we exit and retry after app daemon restart-delay (see snapcraft.yaml)
                Console.WriteLine($"Restarting app after restart-delay of 10 s ...");
                return;
            }

            // Check if provider is started.
            Console.WriteLine(value: $"Provider started: {startResult}");

            // Just keep the process running
            while (true)
            {
                if (provider.IsConnected)
                {

                    var sw = Stopwatch.StartNew();
                    sw.Start();
                    // Change dynamic nodes value every 1000 milliseconds.
                    foreach (var node in dynamicNodes)
                    {
                        node.ChangeValue();
                    };
                    sw.Stop();
                    Console.WriteLine($"Change value elapsed ms: {sw.Elapsed.TotalMilliseconds}");
                }
                else
                {
                    Console.WriteLine("Provider is disconnected: skip changing values of dynamic nodes.");
                }

                Thread.Sleep(millisecondsTimeout: 1000);
            }
        }

        private static void CurrentDomain_ProcessExit(object sender, EventArgs e)
        {
            Console.WriteLine("Application exit");

            //The EventHandler for this event can perform termination activities, such as closing files, releasing storage and so on, before the process ends.

            //Note:
            //In.NET Framework, the total execution time of all ProcessExit event handlers is limited,
            //just as the total execution time of all finalizers is limited at process shutdown.
            //The default is two seconds. An unmanaged host can change this execution time by calling the ICLRPolicyManager::SetTimeout method with the OPR_ProcessExit enumeration value.
            //This time limit does not exist in .NET Core.

            // Your optional clean up code goes here ... 
            //...
        }
    }
}
