using System;

namespace WorkingWithBits
{
    class Program
    {
        static void Main(string[] args)
        {
            UIntBitOperations op = new UIntBitOperations();
            Console.WriteLine(op.ToBinary((uint) 10));
        }
    }










    //class s
    //{
    //    static bool isOdd(int value)
    //    {
    //        // last bit if 1 means odd
    //        //
    //        return (value & 1) == 1;
    //    }

    //    static uint pack(byte[] bytes)
    //    {
    //        uint result = 0;
    //        byte one = bytes[0];
    //        byte two = bytes[1];
    //        byte three = bytes[2];
    //        byte four = bytes[3];

    //        result = ((uint)four << 24) + ((uint)three << 16) + ((uint)two << 8) + one;

    //        return result;
    //    }

    //    static byte[] Unpack(uint number)
    //    {
    //        byte[] result = new byte[4];
    //        for (int i = 0; i < result.Length; i++)
    //        {
    //            result[i] = (byte)(number >> (8 * i));
    //        }
    //        return result;
    //    }

    //    static string toBinary(uint value)
    //    {
    //        string res = string.Empty;
    //        for (int i = 32; i > 0; i--)
    //        {
    //            if ((value & 1) == 1)
    //            {
    //                res = 1 + res;
    //            }
    //            else
    //            {
    //                res = 0 + res;
    //            }
    //            value = value >> 1;
    //        }
    //        return res;
    //    }

    //    static void Main(string[] args)
    //    {
    //        //uint colors = 0; // RGB: xx010

    //        ////set
    //        //colors = colors | 3;     //00000000000011
    //        //colors = colors & (~1U); //11111111111110
    //        //colors = colors >> 1;    //00000000000001


    //        Console.WriteLine("To binary : " + toBinary(8));
    //        byte[] values = new byte[]
    //        {
    //            5,8,201,25
    //        };
    //        Console.WriteLine("Pack : " + pack(values));

    //        Console.WriteLine("First byte : " + Unpack(pack(values))[0]);
    //        Console.WriteLine("Second byte : " + Unpack(pack(values))[1]);
    //        Console.WriteLine("Three byte : " + Unpack(pack(values))[2]);
    //        Console.WriteLine("Four byte : " + Unpack(pack(values))[3]);

    //        Console.WriteLine("Is 10 odd : " + isOdd(10));
    //        Console.WriteLine("Is 7 odd : " + isOdd(7));
    //    }
    //}

}
