using System.Runtime.Serialization;
using System.ServiceModel;

namespace WCFSimplex
{
    [ServiceContract]
    public interface IWCFSimplex
    {
        [OperationContract]
        int Add(int x, int y);

        [OperationContract]
        string Concat(string s, double d);

        [OperationContract]
        A Sum(A a1, A a2);
    }

    [DataContract]
    public class A
    {
        string s = "";
        int k = 0;
        float f = 0.0F;

        [DataMember]
        public string SValue
        {
            get { return s; }
            set { s = value; }
        }

        [DataMember]
        public int KValue
        {
            get { return k; }
            set { k = value; }
        }

        [DataMember]
        public float FValue
        {
            get { return f; }
            set { f = value; }
        }
    }
}