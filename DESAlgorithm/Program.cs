using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ReferenceValues;

namespace WindowsFormsApplication1
{ 
    static class Program
    {
        /// <summary>
        /// 해당 응용 프로그램의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }

    static class TxtPadding
    {
        public static byte[] DoPadding(byte[] unpaddedPlainTxt)
        {
            //byte[] paddedPlainTxt=null;
            int originSize=unpaddedPlainTxt.Length;
            if (originSize % 8 != 0)
            {
                int i, newSize = ((originSize / 8) + 1) * 8;
                byte[] paddedPlainTxt = new byte[newSize];
                for (i = 0; i < originSize; i++)
                {
                    paddedPlainTxt[i] = unpaddedPlainTxt[i];
                }
                for (i = originSize; i < newSize; i++)
                {
                    paddedPlainTxt[i] = 0;
                }
                return paddedPlainTxt;
            }
            else
            {
                return unpaddedPlainTxt;
            }
        }
        public static byte[] DoKeyPadding(byte[] unpaddedKey)
        {
            int i;
            //byte[] tmp = new byte[8];
            byte[] paddedKey = new byte[8];

            for (i = 0; i < unpaddedKey.Length; i++)//if input key is less than 64 bit do padding
            {
                paddedKey[i] = unpaddedKey[i];
            }
            for (i = unpaddedKey.Length; i < 8; i++)
            {
                paddedKey[i] = 0;
            }
            return paddedKey;
        }
        public static int GetBlockSize(byte[] unpaddedPlainTxt)
        {
            int originSize = unpaddedPlainTxt.Length;
            if (originSize % 8 != 0)
            {
                return ((originSize / 8) + 1);
            }
            else
            {
                return originSize / 8;
            }
        }
    }
    static class Permutation
    {
        public static byte[] DoPermute(byte[] objectBits, int[] permuteMap,int bitSize)
        {
            int i,pm;
            byte[] resultBits = new byte[bitSize/8];
            for (i = 0; i < bitSize / 8; i++)
            {
                resultBits[i] = 0;
            }
            for (i = 0; i < bitSize; i++)
            {
                pm = permuteMap[i];
                //if (pm%8 > i%8)
                //{
                    resultBits[i / 8] = (byte)((uint)resultBits[i / 8] | ((uint) (( ( (uint)objectBits[pm / 8]>>(pm%8) ) & 0x01)) << (i%8)));
                //}
                //else
                //{
                //    resultBits[i / 8] = (byte)((uint)resultBits[i / 8] | ((uint)((uint)objectBits[pm / 8] & (1 << pm%8))) >> ((i%8) - pm%8));
                //}
            }
            return resultBits;
        }
    }
    static class BitShifting
    {
        public static byte[] DoLeftShift(byte[] objectBits, int shiftNum)
        {
            int i,pos;
            byte[] resultBits=new byte[7];
            for(i=0;i<7;i++)
            {
                resultBits[i]=0;
            }
            for (i = 0; i < 28; i++)
            {
                pos = (i + shiftNum) % 28;
                resultBits[(pos) / 8] = (byte) ((uint)resultBits[(pos) / 8] | (((uint)objectBits[i / 8] >> (i % 8)) & 0x01) << ((pos) % 8));
            }
            for(i=28;i<56;i++)
            {
                pos=((i+shiftNum) % 28) + 28;
                resultBits[(pos) / 8] = (byte) ((uint)resultBits[(pos) / 8] | (((uint)objectBits[i / 8] >> (i % 8)) & 0x01) << ((pos) % 8));
            }
            return resultBits;
        }
        public static byte[] DoXor(byte[] objectBits1, byte[] objectBits2,int byteSize)
        {
            byte[] resultBits=new byte[byteSize];
            for (int i = 0; i < byteSize; i++)
            {
                resultBits[i]=(byte)((uint)objectBits1[i] ^ (uint)objectBits2[i]);
            }
            return resultBits;
        }
    }
    static class Sbox
    {
        public static byte[] DoSubstitution(byte[] objectBits)
        {//48bit=6byte
            uint cnt=0,sb=0,cnt2=0,j=0;
            uint pos1=0,pos2;
            byte[] resultBits = {0,0,0,0};

            do
            {
                //pos1 = pos1 | (((uint)objectBits[j / 8] >> (int)(j % 8) & 0x01) << (int)cnt);
                //pos1 = pos1 | (((uint)objectBits[(cnt * 6+5) / 8] >> (int)((cnt * 6+5) % 8) & 0x01) << 1);
                switch(cnt)
                {
                    case 0 :
                        pos1 = pos1 | (((uint)objectBits[j / 8] >> (int)(j % 8) & 0x01) << 4);
                        break;
                    case 1:
                        pos1 = pos1 | (((uint)objectBits[j / 8] >> (int)(j % 8) & 0x01) << 0);
                        break;
                    case 2:
                        pos1 = pos1 | (((uint)objectBits[j / 8] >> (int)(j % 8) & 0x01) << 1);
                        break;
                    case 3:
                        pos1 = pos1 | (((uint)objectBits[j / 8] >> (int)(j % 8) & 0x01) << 2);
                        break;
                    case 4:
                        pos1 = pos1 | (((uint)objectBits[j / 8] >> (int)(j % 8) & 0x01) << 3);
                        break;
                    case 5:
                        pos1 = pos1 | (((uint)objectBits[j / 8] >> (int)(j % 8) & 0x01) << 5);
                        break;
                }
                cnt++;
                if (cnt == 6)
                {
                    //Insert 4bits to resultbits and Need another counter cnt2
                    pos2 = RefVal.SBox[sb, pos1];
                    resultBits[cnt2 / 8] = (byte)((uint)resultBits[cnt2 / 8] | (uint)(((pos2 >> 0) & 0x01) << (int)(cnt2 % 8)));
                    cnt2++;
                    resultBits[cnt2 / 8] = (byte)((uint)resultBits[cnt2 / 8] | (uint)(((pos2 >> 1) & 0x01) << (int)(cnt2 % 8)));
                    cnt2++;
                    resultBits[cnt2 / 8] = (byte)((uint)resultBits[cnt2 / 8] | (uint)(((pos2 >> 2) & 0x01) << (int)(cnt2 % 8)));
                    cnt2++;
                    resultBits[cnt2 / 8] = (byte)((uint)resultBits[cnt2 / 8] | (uint)(((pos2 >> 3) & 0x01) << (int)(cnt2 % 8)));
                    cnt2++;
                    //Initialize
                    sb++;
                    cnt=0;
                    pos1 = 0;
                }
                j++;
            } while (j < 48);
            return resultBits;
        }
    }
    static class Expansioning
    {
        public static byte[] DoExpansion(byte[] objectBits)
        {
            byte[] resultBits = new byte[6];
            int EM;
            for (int i = 0; i < 48; i++)
            {
                EM=RefVal.DataExpansion[i];
                resultBits[i / 8] = (byte)((uint)resultBits[i / 8] | (((uint)objectBits[EM / 8] >> EM % 8) & 0x01) << i % 8);
            }
            return resultBits;
        }
    }

}