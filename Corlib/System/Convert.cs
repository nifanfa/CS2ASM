namespace System
{
    public static unsafe class Convert
    {
        public static string ToString(ulong val)
        {
			string s = "                     ";
			int i = 19;

			do
			{
				var d = val % 10;
				val /= 10;

				d += 0x30;
				i = i - 1;
				s.Value[i] = (char)d;
			} while (val > 0);

			i++;


			return s;
        }
    }
}
