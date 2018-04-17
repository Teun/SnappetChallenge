namespace MigrationTool
{
    using System;
    using EFGetStarted.AspNetCore.NewDb.Models;
    using SnappetChallenge.Core;

    /// <summary>
    /// This is main class for console application - MigrationTool
    /// </summary>
    class Program
    {
        /// <summary>
        /// Defines the entry point of the application.
        /// </summary>
        /// <param name="args">The arguments.</param>
        static void Main(string[] args)
        {
            string ss = string.Empty;
            ss +=
            @"   _____  .__                     __  .__                ___________           .__   " + Environment.NewLine +
            @"  /     \ |__| ________________ _/  |_|__| ____   ____   \__    ___/___   ____ |  |  " + Environment.NewLine +
            @" /  \ /  \|  |/ ___\_  __ \__  \\   __\  |/  _ \ /    \    |    | /  _ \ /  _ \|  |  " + Environment.NewLine +
            @"/    Y    \  / /_/  >  | \// __ \|  | |  (  <_> )   |  \   |    |(  <_> |  <_> )  |__" + Environment.NewLine +
            @"\____|__  /__\___  /|__|  (____  /__| |__|\____/|___|  /   |____| \____/ \____/|____/" + Environment.NewLine +
            @"        \/  /_____/            \/                    \/                              ";
            Console.WriteLine(ss);
            Console.WriteLine("Press any key");
            Console.ReadKey();

            var tsk = new ReportFileReader().ReadBigJson<ReportItem>();
            tsk.Wait();

            Console.WriteLine("Migration is done");
            Console.ReadKey();
        }
    }
}
