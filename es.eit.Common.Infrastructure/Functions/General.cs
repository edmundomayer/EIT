using System;
using System.Net;
using System.Net.Sockets;

namespace es.eit.Common.Infrastructure.Functions
{
    public class General
    {
        public static string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry( Dns.GetHostName() );

            foreach ( var ip in host.AddressList )
            {
                if ( ip.AddressFamily == AddressFamily.InterNetwork )
                {
                    return ip.ToString();
                }
            }
            throw new Exception( "Local IP Address Not Found!" );
        }

        public static string GetUserName()
        {
            return Environment.UserName;
        }
    }
}
