﻿using System;
using System.Collections.Generic;
using System.Text;

namespace EFCoreConsoleApp.Utilities
{
    public class RandomHelper
    {
        /// <summary>
        /// 数字随机字母
        /// </summary>
        /// <param name="length">默认4位数</param>
        /// <returns></returns>
        public static string GetRadLetter(int length = 4)
        {
            string Vchar = "A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z";
            string[] VcArray = Vchar.Split(',');
            string checkCode = string.Empty;
            Random rand = new Random();
            for (int i = 0; i < length; i++)
            {
                int t = rand.Next(VcArray.Length);// The exclusive upper bound of the random number to be generated. maxValue must be greater than or equal to zero，下标从0开始
                checkCode += VcArray[t];
            }
            return checkCode;
        }
        /// <summary>
        /// 数字随机数
        /// </summary>
        /// <param name="length">默认4位数</param>
        /// <returns></returns>
        public static string GetRadNum(int length = 4)
        {
            string code = string.Empty;
            Random random = new Random();
            for (int i = 0; i < length; i++)
            {
                code = code + random.Next(9).ToString();
            }
            return code;
        }


        /// <summary>
        /// 数字随机数
        /// </summary>
        /// <param name="min">最小位数</param>
        /// <param name="max">最大位数</param>
        /// <returns></returns>
        public static int GetRandom(int min = 0, int max = 100)
        {
            Random Rdm = new Random();
            int rand = Rdm.Next(min, max);
            return rand;
        }


        //②字符串随机数
        /// <summary>
        /// 字符串验证码
        /// </summary>
        /// <returns></returns>
        public static string GetRndStr()
        {
            string Vchar = "A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z";
            string[] VcArray = Vchar.Split(',');
            string checkCode = string.Empty;
            Random rand = new Random();
            for (int i = 0; i < 4; i++)
            {
                rand = new Random(unchecked((int)DateTime.Now.Ticks));//为了得到不同的随机序列
                int t = rand.Next(VcArray.Length);// The exclusive upper bound of the random number to be generated. maxValue must be greater than or equal to zero，下标从0开始
                checkCode += VcArray[t];
            }
            return checkCode;
        }
        /// <summary>
        /// 产生随机中文汉字编码
        /// </summary>
        /// <param name="strlength"></param>
        /// <returns></returns>
        private static object[] CreateRegionCode(int strlength)
        {
            //定义一个字符串数组储存汉字编码的组成元素
            string[] rBase = new String[16] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "a", "b", "c", "d", "e", "f" };
            Random rnd = new Random();
            object[] bytes = new object[strlength];

            for (int i = 0; i < strlength; i++)
            {
                //区位码第1位
                int r1 = rnd.Next(11, 14);
                string str_r1 = rBase[r1].Trim();

                //区位码第2位
                rnd = new Random(r1 * unchecked((int)DateTime.Now.Ticks) + i);
                int r2;
                if (r1 == 13)
                {
                    r2 = rnd.Next(0, 7);
                }
                else
                {
                    r2 = rnd.Next(0, 16);
                }
                string str_r2 = rBase[r2].Trim();

                //区位码第3位
                rnd = new Random(r2 * unchecked((int)DateTime.Now.Ticks) + i);//更换随机种子
                int r3 = rnd.Next(10, 16);
                string str_r3 = rBase[r3].Trim();

                //区位码第4位
                rnd = new Random(r3 * unchecked((int)DateTime.Now.Ticks) + i);
                int r4;
                if (r3 == 10)
                {
                    r4 = rnd.Next(1, 16);
                }
                else if (r3 == 15)
                {
                    r4 = rnd.Next(0, 15);
                }
                else
                {
                    r4 = rnd.Next(0, 16);
                }
                string str_r4 = rBase[r4].Trim();

                //定义两个字节变量存储产生的随机汉字区位码
                byte byte1 = Convert.ToByte(str_r1 + str_r2, 16);
                byte byte2 = Convert.ToByte(str_r3 + str_r4, 16);

                //将两个字节变量存储在字节数组中
                byte[] str_r = new byte[] { byte1, byte2 };

                //将产生的一个汉字的字节数组放入object数组中
                bytes.SetValue(str_r, i);
            }
            return bytes;
        }
    }
}
