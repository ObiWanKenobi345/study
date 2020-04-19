namespace WCFSimplex
{
    public class WCFSimplex : IWCFSimplex
    {
        public int Add(int x, int y)
        {
            return x + y;
        }

        public string Concat(string s, double d)
        {
            return s + d;
        }

        public A Sum(A a1, A a2)
        {
            A result = new A();
            result.SValue = a1.SValue + a2.SValue;
            result.KValue = a1.KValue + a2.KValue;
            result.FValue = a1.FValue + a2.FValue;
            return result;
        }
    }
}