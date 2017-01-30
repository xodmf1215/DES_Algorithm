using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ReferenceValues;


namespace WindowsFormsApplication1
{
    partial class Form1
    {
        public void DesEncrypt(byte[] bytePlainTxt, byte[,] byteCipherTxt, int blockCount)
        {
            int round;
            byte[] leftPTxt = new byte[4];
            byte[] rightPTxt = new byte[4];
            byte[] tmp = new byte[8];
            byte[] keyCode = new byte[6];
            /*/Key Initial Permutation
            keyCode = Permutation.DoPermute(keyCode, RefVal.PermutedChoice1, 56); //64bits -> 56bits, book page92 pc-1*/
            //Plain text initial Permutation
            bytePlainTxt = Permutation.DoPermute(bytePlainTxt, RefVal.InitialPermuteMap, 64);
            for (int i = 0; i < 4; i++)
            {
                leftPTxt[i] = bytePlainTxt[i];
                rightPTxt[i] = bytePlainTxt[i + 4];
            }
            for (round = 1; round <= 16; round++)
            {
                tmp[0] = rightPTxt[0]; tmp[1] = rightPTxt[1]; tmp[2] = rightPTxt[2]; tmp[3] = rightPTxt[3];
                keyCode[0] = savedKeyCode[round - 1, 0]; keyCode[1] = savedKeyCode[round - 1, 1]; keyCode[2] = savedKeyCode[round - 1, 2];
                keyCode[3] = savedKeyCode[round - 1, 3]; keyCode[4] = savedKeyCode[round - 1, 4]; keyCode[5] = savedKeyCode[round - 1, 5];
                /*/Key generating
                keyCode = BitShifting.DoLeftShift(keyCode, RefVal.KeyRotation[round - 1]);*/
                //R[round] -> Expansion -> xor with key -> Sboxing -> Permutation -> xor with L[round] -> R[round+1]
                rightPTxt = BitShifting.DoXor
                    (leftPTxt,
                    Sbox.DoSubstitution(BitShifting.DoXor(keyCode, Expansioning.DoExpansion(rightPTxt), 6)), 4);
                //R[round]->L[round+1]
                leftPTxt[0] = tmp[0]; leftPTxt[1] = tmp[1]; leftPTxt[2] = tmp[2]; leftPTxt[3] = tmp[3];
                //process result out
                txtResult.Text += String.Format("round {8}\r\n{0} {1} {2} {3} {4} {5} {6} {7}\r\n",
                    ResultOut(leftPTxt[0]), ResultOut(leftPTxt[1]), ResultOut(leftPTxt[2]), ResultOut(leftPTxt[3])
                    , ResultOut(rightPTxt[0]), ResultOut(rightPTxt[1]), ResultOut(rightPTxt[2]), ResultOut(rightPTxt[3]), round);

            }
            //swaping L[round16] to R[round16] -> Inverse Permutation -> Cipher Text
            tmp[4] = leftPTxt[0]; tmp[5] = leftPTxt[1]; tmp[6] = leftPTxt[2]; tmp[7] = leftPTxt[3];
            tmp[0] = rightPTxt[0]; tmp[1] = rightPTxt[1]; tmp[2] = rightPTxt[2]; tmp[3] = rightPTxt[3];

            tmp = Permutation.DoPermute(tmp, RefVal.InversePermuteMap, 64);
            //cipher txt result out
            txtResult.Text += String.Format("최종변환 후\r\n{0} {1} {2} {3} {4} {5} {6} {7}\r\n", tmp[0], tmp[1], tmp[2], tmp[3],
                    tmp[4], tmp[5], tmp[6], tmp[7]);
            //cipherTxt save per each block
            byteCipherTxt[blockCount, 0] = tmp[0]; byteCipherTxt[blockCount, 1] = tmp[1]; byteCipherTxt[blockCount, 2] = tmp[2]; byteCipherTxt[blockCount, 3] = tmp[3];
            byteCipherTxt[blockCount, 4] = tmp[4]; byteCipherTxt[blockCount, 5] = tmp[5]; byteCipherTxt[blockCount, 6] = tmp[6]; byteCipherTxt[blockCount, 7] = tmp[7];
        }
        public void DesDecrypt(byte[,] byteCipherTxt, int blockCount)
        {
            int round;
            byte[] leftPTxt = new byte[4];
            byte[] rightPTxt = new byte[4];
            byte[] tmp = new byte[8];
            byte[] keyCode = new byte[6];

            for (int i = 0; i < 4; i++)
            {
                leftPTxt[i] = byteCipherTxt[blockCount,i];
                rightPTxt[i] = byteCipherTxt[blockCount, i + 4];
            }
            for (round = 16; round >= 1; round--)
            {
                tmp[0] = rightPTxt[0]; tmp[1] = rightPTxt[1]; tmp[2] = rightPTxt[2]; tmp[3] = rightPTxt[3];
                keyCode[0] = savedKeyCode[round - 1, 0]; keyCode[1] = savedKeyCode[round - 1, 1]; keyCode[2] = savedKeyCode[round - 1, 2];
                keyCode[3] = savedKeyCode[round - 1, 3]; keyCode[4] = savedKeyCode[round - 1, 4]; keyCode[5] = savedKeyCode[round - 1, 5];
                //R[round] -> Expansion -> xor with key -> Sboxing -> Permutation -> xor with L[round] -> R[round+1]
                rightPTxt = BitShifting.DoXor
                    (leftPTxt,
                    Sbox.DoSubstitution(BitShifting.DoXor(keyCode, Expansioning.DoExpansion(rightPTxt), 6)), 4);
                //R[round]->L[round+1]
                leftPTxt[0] = tmp[0]; leftPTxt[1] = tmp[1]; leftPTxt[2] = tmp[2]; leftPTxt[3] = tmp[3];
                //process result out
                txtDecryptResult.Text += String.Format("round {8}\r\n{0} {1} {2} {3} {4} {5} {6} {7}\r\n",
                    ResultOut(leftPTxt[0]), ResultOut(leftPTxt[1]), ResultOut(leftPTxt[2]), ResultOut(leftPTxt[3])
                    , ResultOut(rightPTxt[0]), ResultOut(rightPTxt[1]), ResultOut(rightPTxt[2]), ResultOut(rightPTxt[3]), round);

            }
            //swaping L[round16] to R[round16] -> Inverse Permutation -> Cipher Text
            tmp[4] = leftPTxt[0]; tmp[5] = leftPTxt[1]; tmp[6] = leftPTxt[2]; tmp[7] = leftPTxt[3];
            tmp[0] = rightPTxt[0]; tmp[1] = rightPTxt[1]; tmp[2] = rightPTxt[2]; tmp[3] = rightPTxt[3];

            //tmp = Permutation.DoPermute(tmp, RefVal.InversePermuteMap, 64);
            //cipher txt result out
            txtDecryptResult.Text += String.Format("최종변환 후\r\n{0} {1} {2} {3} {4} {5} {6} {7}\r\n", tmp[0], tmp[1], tmp[2], tmp[3],
                    tmp[4], tmp[5], tmp[6], tmp[7]);
            txtDecryptResult.Text += Encoding.UTF8.GetString(tmp);
            //cipherTxt save per each block
            byteCipherTxt[blockCount, 0] = tmp[0]; byteCipherTxt[blockCount, 1] = tmp[1]; byteCipherTxt[blockCount, 2] = tmp[2]; byteCipherTxt[blockCount, 3] = tmp[3];
            byteCipherTxt[blockCount, 4] = tmp[4]; byteCipherTxt[blockCount, 5] = tmp[5]; byteCipherTxt[blockCount, 6] = tmp[6]; byteCipherTxt[blockCount, 7] = tmp[7];
        }
    }
}
