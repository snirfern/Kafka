using Aerospike.Client;
using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
   
    class Program
    {

        static String[] imagesArr1 = { "https://i.ebayimg.com/thumbs/images/m/mLcOcwt9ss784quDOid463g/s-l225.jpg", "https://i.ebayimg.com/thumbs/images/m/mdmUDy2JgtQq-conePwldfQ/s-l225.jpg", "https://i.ebayimg.com/thumbs/images/m/mghwoL421YKCbpnkL4E9Kxg/s-l225.jpg", "https://i.ebayimg.com/thumbs/images/m/mqRj3D34rswtvJqTxLHQAQg/s-l225.jpg" };

        static void Main(string[] args)
        {


            // Establish connection the server
            AerospikeClient client = new AerospikeClient("127.0.0.1", 3000);

            // Create key
            Key key = new Key("test", "myset", "mykey");

            var map1 = new Dictionary<string, Boolean>();
            for (int i = 0; i < imagesArr1.Length; i++)
            {
                map1.Add(imagesArr1[i].ToString(), false);
            }

            Bin bin1 = new Bin("data", map1);


            // Write record
            client.Put(null, key, bin1);


            Record record = client.Get(null, key);
           

            // Close connection
            client.Close();
            Console.WriteLine(record);
            Console.WriteLine("Hello World!");
        }
    }
}