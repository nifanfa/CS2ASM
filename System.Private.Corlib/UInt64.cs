
namespace System
{
    public struct UInt64
    {
        public override string ToString()
        {
            return Convert.ToString(this);
        }

        private static readonly string X2 = "x2";

        public string ToString(string format)
        {
            return format == X2 ? Convert.ToString(this, true) : Convert.ToString(this);
        }
    }
}