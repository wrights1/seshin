using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Collections.Generic;
using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DocumentModel;
using Amazon.Runtime;
using CloudPatterns.AWS.Contracts;

namespace App1
{
    public class DynamoService //: ITableDataService
    {
        public DynamoDBContext DbContext;
        public AmazonDynamoDBClient DynamoClient;
        public static string AWSAccessKey = "AKIAIJ6FHKOGH6JXN5NQ";
        public static string AWSSecretKey = "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";

        public DynamoService()
        {
            DynamoClient = new AmazonDynamoDBClient(AWSAccessKey, AWSSecretKey, Amazon.RegionEndpoint.USEast2);
            DbContext = new DynamoDBContext(DynamoClient, new DynamoDBContextConfig
            {
                //Setting the Consistent property to true ensures that you'll always get the latest 
                ConsistentRead = true,
                SkipVersionCheck = true
            });
        }

        /// The Store method allows you to save a POCO to DynamoDb
        public async Task Store<T>(T item) where T : new()
        { 
            await DbContext.SaveAsync(item);
        }

        /// The BatchStore Method allows you to store a list of items of type T to dynamoDb
        public void BatchStore<T>(IEnumerable<T> items) where T : class
        {
            var itemBatch = DbContext.CreateBatchWrite<T>();

            foreach (var item in items)
            {
                itemBatch.AddPutItem(item);
            }

            itemBatch.ExecuteAsync();
        }
       
        /// GetAll
        /// Uses the scan operator to retrieve all items in a table
        /// <remarks>[CAUTION] This operation can be very expensive if your table is large</remarks>
        public List<Document> GetAll<T>() where T : class
        {
            Table tableGet = DbContext.GetTargetTable<T>();
            Search search = tableGet.Scan(new Amazon.DynamoDBv2.DocumentModel.ScanOperationConfig());
            var searchResponse = search.GetRemainingAsync();
            List<Document> searchList = searchResponse.Result;
            //foreach (var s in searchList)
            //{
            //    Debug.WriteLine(s.ToString()); // does this actually work?
            //}
            return searchList;

        }
        /*
        /// <summary>
        /// Retrieves an item based on a search key
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public T GetItem<T>(string key) where T : class
        {
            return DbContext.LoadAsync<T>(key);
        }
        
        /// <summary>
        /// Method Updates and existing item in the table
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="item"></param>
        public void UpdateItem<T>(T item) where T : class
        {
            T savedItem = DbContext.Load(item);

            if (savedItem == null)
            {
                throw new AmazonDynamoDBException("The item does not exist in the Table");
            }

            DbContext.SaveAsync(item);
        }

        /// <summary>
        /// Deletes an Item from the table.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="item"></param>
        public void DeleteItem<T>(T item)
        {
            var savedItem = DbContext.Load(item);

            if (savedItem == null)
            {
                throw new AmazonDynamoDBException("The item does not exist in the Table");
            }

            DbContext.DeleteAsync(item);
        }
        */
    }
}