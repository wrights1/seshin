using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Threading.Tasks;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DocumentModel;
using Amazon.DynamoDBv2.Model;

namespace App1
{
    public class DvdLibrary
    {
        private readonly DynamoService _dynamoService;

        public DvdLibrary()
        {
            try
            {
                _dynamoService = new DynamoService();
            }
            catch (AmazonDynamoDBException e) { Debug.WriteLine(e.Message); }
            //catch (AmazonServiceException e) { Console.WriteLine(e.Message); }
            catch (Exception e) { Debug.WriteLine(e.Message); }
        }

        /// <summary>
        ///  AddDVD will accept a DVD object and creates an Item on Amazon DynamoDB
        /// </summary>
        /// <param name="dvd"></param>
        public async Task AddDvd(DVD dvd)
        {
            await _dynamoService.Store(dvd);
        }

        /// <summary>
        /// ModifyDVD  tries to load an existing DVD, modifies and saves it back. If the Item doesn’t exist, it raises an exception
        /// </summary>
        /// <param name="dvd"></param>
        /*
        public void ModifyDvd(DVD dvd)
        {
            _dynamoService.UpdateItem(dvd);
        }
        */

        /// <summary>
        /// GetALllDvds will perform a Table Scan operation to return all the DVDs
        /// </summary>
        /// <returns></returns>
        /*
        public IEnumerable<DVD> GetAllDvds()
        {
            return _dynamoService.GetAll<DVD>();
        }
        */

        /*
        public IEnumerable<DVD> SearchDvds(string title, int releaseYear)
        {
            IEnumerable<DVD> filteredDvds = _dynamoService.DbContext.QueryAsync<DVD>(title, QueryOperator.Equal, releaseYear);

             Task QueryAsync(AWSCredentials credentials, RegionEndpoint region)

                var search = DynamoService.DbContext.FromQueryAsync<DVD>(new Amazon.DynamoDBv2.DocumentModel.QueryOperationConfig()
                {
                    IndexName = "Author-Title-index",
                    Filter = new Amazon.DynamoDBv2.DocumentModel.QueryFilter(title, Amazon.DynamoDBv2.DocumentModel.QueryOperator.Equal, releaseYear)
                });

                Console.WriteLine("items retrieved");

                var searchResponse = await search.GetRemainingAsync();
                searchResponse.ForEach((s) = > {
                    Console.WriteLine(s.ToString());
                });

               return filteredDvds;
        }
        */

        
        /// <summary>
        /// Delete DVD will remove an item from DynamoDb
        /// </summary>
        /// <param name="dvd"></param>
        /*
        public void DeleteDvd(DVD dvd)
        {
            _dynamoService.DeleteItem(dvd);
        }
        */

        #region TODO
        //public List<DVD> SearchDvdByTitle(string title)
        //{
        //    // Define item hash-key
        //    var hashKey = new AttributeValue { S = title };

        //    // Create the key conditions from hashKey
        //    var keyConditions = new Dictionary<string, Condition>
        //    {
        //        // Hash key condition. ComparisonOperator must be "EQ".
        //        { 
        //            "Title",
        //            new Condition
        //            {
        //                ComparisonOperator = "EQ",
        //                AttributeValueList = new List<AttributeValue> { hashKey }
        //            }
        //        }
        //    };

        //    // Define marker variable
        //    Dictionary<string, AttributeValue> startKey = null;

        //    do
        //    {
        //        // Create Query request
        //        var request = new QueryRequest
        //        {
        //            TableName = "DVD",
        //            ExclusiveStartKey = startKey,
        //            KeyConditions = keyConditions
        //        };

        //        // Issue request
        //        var result = _dynamoService.DynamoClient.Query(request);

        //        // View all returned items
        //        List<Dictionary<string, AttributeValue>> items = result.Items;
        //        foreach (Dictionary<string, AttributeValue> item in items)
        //        {
        //            foreach (var keyValuePair in item)
        //            {
        //                Console.WriteLine("{0} : S={1}, N={2}, SS=[{3}], NS=[{4}]",
        //                    keyValuePair.Key,
        //                    keyValuePair.Value.S,
        //                    keyValuePair.Value.N,
        //                    string.Join(", ", keyValuePair.Value.SS ?? new List<string>()),
        //                    string.Join(", ", keyValuePair.Value.NS ?? new List<string>()));
        //            }
        //        }

        //        // Set marker variable
        //        startKey = result.LastEvaluatedKey;
        //    } while (startKey != null && startKey.Count > 0);

        //    return new List<DVD>();

        //}
        #endregion

    }
}