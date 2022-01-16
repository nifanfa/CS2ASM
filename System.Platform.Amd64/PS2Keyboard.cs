
namespace System.Platform.Amd64
{
    public static class PS2Keyboard
    {
        static PS2Keyboard()
        {
            PIC.ClearMask(0x21);
        }

        private static char Key = '?';

        public static char GetKey()
        {
            char c = Key;
            Key = '?';
            return c;
        }

        public static void OnInterrupt() 
        {
            Key = ProcessKey();
        }

        private static char ProcessKey()
        {
            // TODO: Use switch when implemented
            byte KeyData = Native.In8(0x60);
            if (false) return '?';
            else if (KeyData == 0x1E) return 'a';
            else if (KeyData == 0x30) return 'b';
            else if (KeyData == 0x2E) return 'c';
            else if (KeyData == 0x20) return 'd';
            else if (KeyData == 0x12) return 'e';
            else if (KeyData == 0x21) return 'f';
            else if (KeyData == 0x22) return 'g';
            else if (KeyData == 0x23) return 'h';
            else if (KeyData == 0x17) return 'i';
            else if (KeyData == 0x24) return 'j';
            else if (KeyData == 0x25) return 'k';
            else if (KeyData == 0x26) return 'l';
            else if (KeyData == 0x32) return 'm';
            else if (KeyData == 0x31) return 'n';
            else if (KeyData == 0x18) return 'o';
            else if (KeyData == 0x19) return 'p';
            else if (KeyData == 0x10) return 'q';
            else if (KeyData == 0x13) return 'r';
            else if (KeyData == 0x1F) return 's';
            else if (KeyData == 0x14) return 't';
            else if (KeyData == 0x16) return 'u';
            else if (KeyData == 0x2F) return 'v';
            else if (KeyData == 0x11) return 'w';
            else if (KeyData == 0x2D) return 'x';
            else if (KeyData == 0x15) return 'y';
            else if (KeyData == 0x2C) return 'z';
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
            else if (KeyData == 0x1C) return '\n'; //Enter
            else if (KeyData == 0x0E) return '\b';
            else if (KeyData == 0x39) return ' ';
            else return '?';
        }
    }
}

//When switch implemented:
/*          switch (KeyData)
            {
                case 0x1E: return 'A';
                case 0x30: return 'B';
                case 0x2E: return 'C';
                case 0x20: return 'D';
                case 0x12: return 'E';
                case 0x21: return 'F';
                case 0x22: return 'G';
                case 0x23: return 'H';
                case 0x17: return 'I';
                case 0x24: return 'J';
                case 0x25: return 'K';
                case 0x26: return 'L';
                case 0x32: return 'M';
                case 0x31: return 'N';
                case 0x18: return 'O';
                case 0x19: return 'P';
                case 0x10: return 'Q';
                case 0x13: return 'R';
                case 0x1F: return 'S';
                case 0x14: return 'T';
                case 0x16: return 'U';
                case 0x2F: return 'V';
                case 0x11: return 'W';
                case 0x2D: return 'X';
                case 0x15: return 'Y';
                case 0x2C: return 'Z';
                case 0x02: return '1';
                case 0x03: return '2';
                case 0x04: return '3';
                case 0x05: return '4';
                case 0x06: return '5';
                case 0x07: return '6';
                case 0x08: return '7';
                case 0x09: return '8';
                case 0x0A: return '9';
                case 0x0B: return '0';
                default: return '?';
            }
*/