namespace autotaz
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}


/*
scaffold:
dotnet ef dbcontext scaffold "Database=autotaz;Host=localhost;Username=postgres;Password=123" Npgsql.EntityFrameworkCore.PostgreSQL --force --context ATContext --context-dir Model --output-dir Model --no-onconfiguring

*/