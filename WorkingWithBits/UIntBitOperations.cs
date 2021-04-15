using System;
using System.Collections.Generic;
using System.Text;

namespace WorkingWithBits
{
    public class UIntBitOperations
    {
        public bool IsOdd(int value)
        {
            // last bit if 1 means odd
            //
            return (value & 1) == 1;
        }

        /*
         * Pack means get fours bytes and set them side by side
         * to make a 32-bit(4 bytes) int type.
         * */
        public uint Pack(byte[] bytes)
        {
            uint result = 0;
            byte one = bytes[0];
            byte two = bytes[1];
            byte three = bytes[2];
            byte four = bytes[3];

            /*
            byte four = 10101010
            uint uint_four = (uint)four (00000000 00000000 00000000 10101010)
            
            uint_four << 24 = 10101010 00000000 00000000 00000000
            
            [SAME IDEA FOR ALL BYTES]

            uint_three << 16 = 00000000 20202020 00000000 00000000
            etc..
             */

            result = ((uint)four << 24) + ((uint)three << 16) + ((uint)two << 8) + one;

            return result;
        }

        /*
         * UnPack means extract 4-bytes from the unit 32-bit
         * */
        public byte[] Unpack(uint number)
        {
            byte[] result = new byte[4];
            for (int i = 0; i < result.Length; i++)
            {
                // 1111111 22222222 33333333 44444444
                // 0000000 11111111 22222222 33333333
                // 0000000 00000000 11111111 22222222
                // 0000000 00000000 00000000 11111111
                result[i] = (byte)(number >> (8 * i));
            }
            return result;
        }

        /*
         * Display (value) bits as a string
         * */
        public string ToBinary(uint value)
        {
            string res = string.Empty;
            for (int i = 31; i >= 0; i--)
            {
                // working
                //if ((value & 1) == 1)
                //{
                //    res = 1 + res;
                //}
                //else
                //{
                //    res = 0 + res;
                //}
                //value = value >> 1;

                // working
                //res = ((value & 1) == 1 ? 1 : 0) + res;
                //value = value >> 1;

                //working
                //res = (value & 1) + res;
                //value = value >> 1;

                //working
                res = res + ((value >> i) & 1);
            }
            return res;
        }
    }
}
