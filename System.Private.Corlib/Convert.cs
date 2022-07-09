namespace System
{
    public static class Convert
	{
		//Preventing memory overflow
		private static string Result = "                     ";

		public static string ToString(ulong val,bool hex = false)
        {
            if (hex) 
			{

				Result.Length = 16;

				ulong len = 0;
				ulong val0 = val;

				do
				{
					var d = val0 % 16;
					val0 /= 16;
					len++;
				} while (val0 > 0);

				Result.Length = len;
				val0 = val;

				do
				{
					var d = val0 % 16;
					val0 /= 16;

					if (d > 9)
					{
						d += 0x37;
					}
					else
					{
						d += 0x30;
					}

					len--;
					Result[len] = (char)d;
				} while (val0 > 0);


				return Result;
            }
            else 
			{
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
					len--;
					Result[len] = (char)d;
				} while (val0 > 0);


				return Result;
			}
		}
    }
}
