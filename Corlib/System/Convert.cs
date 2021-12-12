namespace System
{
    public static unsafe class Convert
	{
		//Preventing memory overflow
		private static string Result = "                     ";

		public static string ToString(ulong val)
        {
			for(ulong idx = 0; idx < 21; idx++) 
			{
				Result[idx] = ' ';
			}

			ulong i = 21;

			do
			{
				var d = val % 10;
				val /= 10;

				d += 0x30;
				i = i - 1;
				Result[i] = (char)d;
			} while (val > 0);

			i++;


			return Result;
        }
    }
}
