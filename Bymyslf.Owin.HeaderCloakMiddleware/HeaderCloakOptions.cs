namespace Bymyslf.Owin.HeaderCloakMiddleware
{
    using System.Collections.Generic;

    public class HeaderCloakOptions
    {
        public HeaderCloakOptions()
        {
            this.HeadersToCloak = new List<string>();
        }

        public ICollection<string> HeadersToCloak { get; set; }
    }
}