namespace Api.Extensions
{

    public static class IHostEnvironmentExtensions
    {
        public static bool IsLocal(this IHostEnvironment environment)
        {
            return environment.EnvironmentName == "Local";
        }

        public static bool IsDev(this IHostEnvironment environment)
        {
            return environment.EnvironmentName == "Development";
        }

        public static bool IsTest(this IHostEnvironment environment)
        {
            return environment.EnvironmentName == "Test";
        }

        public static bool IsProd(this IHostEnvironment environment)
        {
            return environment.EnvironmentName == "Prod";
        }
    }

}
