namespace System
{
    public static unsafe class Convert
	{
		//Preventing memory overflow
		private static string Result = "                     ";

		public static string ToString(ulong val)
        {
			Result.Length = 21;

			ulong len = 0;
			ulong val0 = val;

			do
			{
				var d = val0 % 10;
				val0 /= 10;
				len++;
			} while (val0 > 0);

			Result.Length = len;
			val0 = val;

			do
			{
				var d = val0 % 10;
				val0 /= 10;

				d += 0x30;
				len = len - 1;
				Result[len] = (char)d;
			} while (val0 > 0);


			return Result;
        }
    }
}
