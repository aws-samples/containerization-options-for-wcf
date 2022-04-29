// Copyright Amazon.com, Inc. or its affiliates. All Rights Reserved.
// SPDX-License-Identifier: MIT-0
using CoreWCF.Configuration;
using System.Net;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;


namespace Server
{
	public class Program
	{
		public static void Main(string[] args)
		{
			//All Ports set are default.
			IWebHost host = CreateWebHostBuilder(args).Build();
			host.Run();
		}

	    public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
		    WebHost.CreateDefaultBuilder(args)
					 .UseKestrel(options =>
					 {
						 options.ListenAnyIP(80);
					 })
					 .UseNetTcp(808)				 
					 .UseStartup<Startup>();
	}
}
