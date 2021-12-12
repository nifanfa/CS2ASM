
namespace System.Platform.Amd64
{
    public static class PS2Keyboard
    {
        static PS2Keyboard()
        {
            PIC.ClearMask(0x21);
        }

        public static char KeyPressed = ' ';

        public static void OnInterrupt() 
        {
            KeyPressed = ProcessKey();
        }

        private static char ProcessKey()
        {
            // TODO: Use switch
            byte KeyData = x64.In8(0x60);
                 if (KeyData == 0x1E) return 'A';
            else if (KeyData == 0x30) return 'B';
            else if (KeyData == 0x2E) return 'C';
            else if (KeyData == 0x20) return 'D';
            else if (KeyData == 0x12) return 'E';
            else if (KeyData == 0x21) return 'F';
            else if (KeyData == 0x22) return 'G';
            else if (KeyData == 0x23) return 'H';
            else if (KeyData == 0x17) return 'I';
            else if (KeyData == 0x24) return 'J';
            else if (KeyData == 0x25) return 'K';
            else if (KeyData == 0x26) return 'L';
            else if (KeyData == 0x32) return 'M';
            else if (KeyData == 0x31) return 'N';
            else if (KeyData == 0x18) return 'O';
            else if (KeyData == 0x19) return 'P';
            else if (KeyData == 0x10) return 'Q';
            else if (KeyData == 0x13) return 'R';
            else if (KeyData == 0x1F) return 'S';
            else if (KeyData == 0x14) return 'T';
            else if (KeyData == 0x16) return 'U';
            else if (KeyData == 0x2F) return 'V';
            else if (KeyData == 0x11) return 'W';
            else if (KeyData == 0x2D) return 'X';
            else if (KeyData == 0x15) return 'Y';
            else if (KeyData == 0x2C) return 'Z';
            else if (KeyData == 0x02) return '1';
            else if (KeyData == 0x03) return '2';
            else if (KeyData == 0x04) return '3';
            else if (KeyData == 0x05) return '4';
            else if (KeyData == 0x06) return '5';
            else if (KeyData == 0x07) return '6';
            else if (KeyData == 0x08) return '7';
            else if (KeyData == 0x09) return '8';
            else if (KeyData == 0x0A) return '9';
            else if (KeyData == 0x0B) return '0';
            else return '?';
        }
    }
}
