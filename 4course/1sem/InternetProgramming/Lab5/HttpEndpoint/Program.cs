using System;

namespace HttpEndpoint
{
    class Program
    {
        static void Main(string[] args)
        {
            WCFSimplex.WCFSimplexClient client = new WCFSimplex.WCFSimplexClient("BasicHttpBinding_IWCFSimplex");
            var result = client.Add(55, 22);
            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}