using Amazon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App1
{
    public class Constants
    {
        public const string COGNITO_IDENTITY_POOL_ID = "us-east-2:e8c4f25a-9af8-4c5a-b935-15aa5f6aea08";
        public static RegionEndpoint COGNITO_REGION = RegionEndpoint.USEast2;

        public static RegionEndpoint DYNAMODB_REGION = RegionEndpoint.USEast2;

    }
}
