using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Text;

namespace limo_droid_v4.Data
{
    public class NetworkCheck
    {
        public static bool IsInternet()
        {
            if (CrossConnectivity.Current.IsConnected)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
