using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ReferenceValues;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public bool IsEncrypt = false;
        public byte[,] byteCipherTxt;
        public byte[,] savedKeyCode=new byte[16,6];
        int blockNumber;
        public Form1()
        {
            InitializeComponent();
        }
        public string ResultOut(byte printOut)
        {
            string txtOut="";
            for (int i = 7; i >=0; i--)
            {
                if ((int)(((uint)printOut >> i) & 0x01) == 1)
                {
                    txtOut += "1";
                }
                else
                {
                    txtOut += "0";
                }
            }
            return txtOut;
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        
        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            txtResult.Text = "";
            if (txtPlainText.Text != "" && txtKeyCode.Text != "")
            {
                byte[] bytePlainTxt;
                byte[] byteKeyCode;
                byte[] byte8BlockTxt=new byte[8];
                byte[] tmpKeyCode;
                //byte[] byteCipherTxt;
                int blockCount;

                IsEncrypt = true;
                bytePlainTxt = Encoding.UTF8.GetBytes(txtPlainText.Text);
                byteKeyCode = Encoding.UTF8.GetBytes(txtKeyCode.Text);

                blockNumber = WindowsFormsApplication1.TxtPadding.GetBlockSize(bytePlainTxt);
                bytePlainTxt = WindowsFormsApplication1.TxtPadding.DoPadding(bytePlainTxt);
                byteKeyCode = WindowsFormsApplication1.TxtPadding.DoKeyPadding(byteKeyCode);

                byteCipherTxt = new byte[blockNumber,8];
                //saving 16round keys
                //Key Initial Permutation
                byteKeyCode = Permutation.DoPermute(byteKeyCode, RefVal.PermutedChoice1, 56); //64bits -> 56bits, book page92 pc-1
                for (int round = 1; round <= 16;round++ )
                {
                    //Key generating
                    byteKeyCode = BitShifting.DoLeftShift(byteKeyCode, RefVal.KeyRotation[round - 1]);
                    tmpKeyCode = Permutation.DoPermute(byteKeyCode, RefVal.PermutedChoice2, 48);
                    for (int i = 0; i < 6; i++)
                    {
                        savedKeyCode[round - 1, i] = byteKeyCode[i];
                    }
                }
                //encrypting each 8byte block
                for (blockCount = 1; blockCount <= blockNumber; blockCount++)
                {
                    txtResult.Text += blockCount + "번째 Block DES Encryption Phase\r\n";
                    for (int i = 0; i < 8; i++)
                    {
                        byte8BlockTxt[i] = bytePlainTxt[(blockCount - 1) * 8 + i];
                    }
                    DesEncrypt(byte8BlockTxt,byteCipherTxt,blockCount-1);
                    //byteCipherTxt에 암호화값 저장까지 함수내에서 해결
                }
            }
            else
            {
                txtResult.Text = " You have to input Plain Text and Key Code together. \r\n Try again.";
            }
        }

        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            if (IsEncrypt)
            {
                txtDecryptResult.Text = "";
                for (int blockCount = 1; blockCount <= blockNumber; blockCount++)
                {
                    DesDecrypt(byteCipherTxt,blockCount-1);
                }
            }
            else
            {
                txtDecryptResult.Text += "You have to encrypt first. there is no data in Cipher text";
            }
        }
    }
}