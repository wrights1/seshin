using System.Collections.Generic;
using Amazon.DynamoDBv2.DataModel;

namespace App1
{
    [DynamoDBTable("Events")]
    public class Event
    {
        [DynamoDBHashKey]
        public int eventID { get; set; }

        [DynamoDBProperty]
        public string title { get; set; }

        [DynamoDBProperty]
        public string descritpion { get; set; }

        [DynamoDBProperty]
        public float latitude { get; set; }

        [DynamoDBProperty]
        public float longitude { get; set; }

        [DynamoDBProperty]
        public string hostname { get; set; }

        [DynamoDBProperty]
        public int starttime { get; set; }

        [DynamoDBProperty]
        public int stoptime { get; set; }

        public override string ToString()
        {
            return string.Format(@"{0}: {1}, {2}", eventID, title, hostname);
        }

    }

}

