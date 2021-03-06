﻿

namespace BFBC2Toolkit.Functions
{
    public class Reverse
    {
        //Not sure if taking and returning the whole data is efficient in general. Probably not, but it is good enough for our case. Might improve it later.
        public static byte[] TwoByteBlock(byte[] data, int offset)
        {
            byte temp0 = data[offset],
                 temp1 = data[offset + 1];

            data[offset] = temp1;
            data[offset + 1] = temp0;

            return data;
        }

        public static byte[] FourByteBlock(byte[] data, int offset)
        {
            byte temp0 = data[offset],
                 temp1 = data[offset + 1],
                 temp2 = data[offset + 2],
                 temp3 = data[offset + 3];

            data[offset] = temp3;
            data[offset + 1] = temp2;
            data[offset + 2] = temp1;
            data[offset + 3] = temp0;

            return data;
        }
    }
}
