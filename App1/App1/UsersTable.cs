using System.Collections.Generic;
using Amazon.DynamoDBv2.DataModel;

namespace App1
{
    [DynamoDBTable("Users")]
    public class User
    {
        [DynamoDBHashKey]
        public string username { get; set; }

        [DynamoDBProperty]
        public string firstName { get; set; }

        [DynamoDBProperty]
        public string lastName { get; set; }

        public override string ToString()
        {
            return string.Format(@"{0}: {1}, {2}", username, lastName, firstName);
        }

    }

}

