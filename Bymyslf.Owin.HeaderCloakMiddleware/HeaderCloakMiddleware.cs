namespace Bymyslf.Owin.HeaderCloakMiddleware
{
    using System;
    using System.Threading.Tasks;
    using Microsoft.Owin;

    public class HeaderCloakMiddleware : OwinMiddleware
    {
        private readonly HeaderCloakOptions options;

        public HeaderCloakMiddleware(OwinMiddleware next, HeaderCloakOptions options)
            : base(next)
        {
            if (options == null)
            {
                throw new ArgumentNullException("options cannot be null");
            }

            if (options.HeadersToCloak == null)
            {
                throw new ArgumentNullException("HeadersToCloak cannot be null");
            }

            this.options = options;
        }

        public override async Task Invoke(IOwinContext context)
        {
            context.Response.OnSendingHeaders(state =>
            {
                var response = ((OwinResponse)state);
                foreach (var header in this.options.HeadersToCloak)
                {
                    response.Headers.Remove(header);
                }
            }, context.Response);

            await this.Next.Invoke(context).ConfigureAwait(false);
        }
    }
}