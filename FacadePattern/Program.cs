using System;

namespace FacadePattern
{
    internal static class Program
    {
        private static void Main(string[] args)
        {

            Authorize authorize = new();
            Caching caching = new();
            Logging logging = new();
            Validation validation = new();

            Facade facade = new(authorize, caching, logging, validation);

            Console.WriteLine(facade.UseAll());
        }
    }

    public class Facade
    {
        public Facade(Authorize authorize, Caching caching, Logging logging, Validation validation)
        {
            _authorize = authorize;
            _caching = caching;
            _logging = logging;
            _validation = validation;
        }

        private readonly Authorize _authorize;

        private readonly Caching _caching;

        private readonly Logging _logging;

        private readonly Validation _validation;

        public string UseAll()
        {
            string result = null;

            result += _authorize.CheckUser();
            result += _caching.Cache();
            result += _logging.Log();
            result += _validation.Validate();

            return result;
        }
    }

    public class Authorize
    {
        public string CheckUser() => "User autherized\n";
    }

    public class Caching
    {
        public string Cache() => "User cached\n";
    }

    public class Logging
    {
        public string Log() => "User logged\n";
    }

    public class Validation
    {
        public string Validate() => "User validated\n";
    }

}
