
namespace System
{
    public struct UInt64
    {
        public override string ToString()
        {
            return Convert.ToString(this);
        }

        private static string x2 = "x2";

        public string ToString(string format) 
        {
            if(format == x2) 
            {
                //format.Dispose();
                return Convert.ToString(this, true);
            }
            return Convert.ToString(this);
        }
    }
}