
namespace System
{
    public struct UInt64
    {
        public override string ToString(ulong Argument = 0)
        {
            return Convert.ToString(this, Argument == 16);
        }
    }
}