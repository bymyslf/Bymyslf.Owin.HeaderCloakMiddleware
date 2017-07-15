namespace Bymyslf.Owin.HeaderCloakMiddleware
{
    using global::Owin;
    using Microsoft.Owin.Extensions;

    public static class HeaderCloakExtensions
    {
        public static IAppBuilder UseHeaderCloak(this IAppBuilder builder)
        {
            var options = new HeaderCloakOptions();

            options.HeadersToCloak.Add(HeadersConstants.Server);
            options.HeadersToCloak.Add(HeadersConstants.XSourceFiles);
            options.HeadersToCloak.Add(HeadersConstants.XPoweredBy);
            options.HeadersToCloak.Add(HeadersConstants.XAspNetVersion);
            options.HeadersToCloak.Add(HeadersConstants.XAspNetMvcVersion);

            return builder.UseHeaderCloak(options);
        }

        public static IAppBuilder UseHeaderCloak(this IAppBuilder builder, HeaderCloakOptions options)
        {
            builder.Use<HeaderCloakMiddleware>(options);
            builder.UseStageMarker(PipelineStage.PostAcquireState);

            return builder;
        }
    }
}