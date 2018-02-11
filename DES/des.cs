using System;
using System.Text;

namespace DES
{
    class DES
    {
        byte[,] arrIP=new byte [,] {
            {58,50,42,34,26,18,10,2},
            {60,52,44,36,28,20,12,4},
            {62,54,46,38,30,22,14,6},
            {64,56,48,40,32,24,16,8},
            {57,49,41,33,25,17,9 ,1},
            {59,51,43,35,27,19,11,3},
            {61,53,45,37,29,21,13,5},
            {63,55,47,39,31,23,15,7},
        };

      //  {},
      //  byte[,] arrIP=new byte [,] {{
    private  static int rounds = 2;
    public  void feist(int[] a, bool reverse)
    {
        int round = reverse? rounds: 1;
        int l = a[0];
        int r = a[1];
        for (int i = 0; i < rounds; i++)
        {
            if (i < rounds-1) // если не последний раунд
            {
                int t = l;
                l = r ^ f(l, round);
                r = t;
            }
            else // последний раунд
            {
                r = r ^ f(l, round);
            }
            round += reverse? -1: 1;
        }
        a[0] = l;
        a[1] = r;
    }
    private int f(int b, int k)
    {
        return b + k;
    }

    //----------------------
    //str - исходная строка, key - ключ (не менее 8 символов)
    public static string feistel_crypt(string str, string key)
        {
            if (key.Length < 8)
                throw new ArgumentException("Very small key! (min = 8 symbols)");

            byte[] str_arr = Encoding.Default.GetBytes(str);
            byte[] key_arr = Encoding.Default.GetBytes(key);

            //если длина не кратна 64 битам (8 байтам)
            str_arr = CompleteToFullBlocks(str_arr);

            byte[] res_arr = new byte[str_arr.Length];

            //шифруем по блокам
            for (int i = 0; i < str_arr.Length; i = i + 8)
            {
                byte[] block = new byte[8];
                Array.Copy(str_arr, i, block, 0, 8);

                for (int j = 0; j <= rounds; j++)
                {
                    //создаем 2 подблока
                    byte[] subblock_left_arr = new byte[4];
                    Array.Copy(block, subblock_left_arr, 4);
                    byte[] subblock_right_arr = new byte[4];
                    Array.Copy(block, 4, subblock_right_arr, 0, 4);

                    //создаем раундовый ключ
                    byte[] subblock_key_arr = new byte[4];
                    Array.Copy(key_arr, subblock_key_arr, 4);
                    subblock_key_arr = shift_key_left(key_arr, j);

                    if (j != rounds)//если j = rounds, то не надо поблоки менять местами
                        block = crypt_block(subblock_left_arr, subblock_right_arr, subblock_key_arr, false);
                    else
                        block = crypt_block(subblock_left_arr, subblock_right_arr, subblock_key_arr, true);
                }
                //скидываем блок в результирующий массив
                Array.Copy(block, 0, res_arr, i, block.Length);
            }
            return Encoding.Default.GetString(res_arr);
        }
        
        private static byte[] CompleteToFullBlocks(byte[] str_arr)
        {
            int diff = str_arr.Length % 8;
            if (diff != 0)
            {
                byte[] temp = new byte[str_arr.Length + (8 - diff)];
                Array.Copy(str_arr, temp, str_arr.Length);
                str_arr = temp;
            }
            return str_arr;
        }

        private static byte[] crypt_block(byte[] subblock_left_arr, byte[] subblock_right_arr, byte[] subblock_key_arr, bool isLast)
    {
        int subblock_left = BitConverter.ToInt32(subblock_left_arr, 0);
        int subblock_right = BitConverter.ToInt32(subblock_right_arr, 0);
        int subblock_key = BitConverter.ToInt32(subblock_key_arr, 0);

        //xor
        subblock_left = subblock_left ^ subblock_key;
        subblock_left_arr = BitConverter.GetBytes(subblock_left);

        byte[] tmp = new byte[2];
        Array.Copy(subblock_left_arr, tmp, 2);
        Int16 left = BitConverter.ToInt16(tmp, 0);
        Array.Copy(subblock_left_arr, 2, tmp, 0, 2);
        Int16 right = BitConverter.ToInt16(tmp, 0);

        //xor
        subblock_right = f(left, right) ^ subblock_right;
        subblock_right_arr = BitConverter.GetBytes(subblock_right);

        //меняем или не меняем подблоки местами при объединении
        byte[] res_arr = new byte[8];
        if (!isLast)
        {
            Array.Copy(subblock_right_arr, res_arr, 4);
            Array.Copy(subblock_left_arr, 0, res_arr, 4, 4);
        }
        else
        {
            Array.Copy(subblock_left_arr, res_arr, 4);
            Array.Copy(subblock_right_arr, 0, res_arr, 4, 4);
        }
        return res_arr;
    }

    public static string feistel_decrypt(string str, string key)
    {
        if (key.Length < 8)
            throw new ArgumentException("Very small key! (min = 8 symbols)");

        byte[] str_arr = Encoding.Default.GetBytes(str);
        byte[] key_arr = Encoding.Default.GetBytes(key);
        byte[] res_arr = new byte[str_arr.Length];

      //  если длина не кратна 64 битам (8 байтам)
        int diff = str_arr.Length % 8;
        if (diff != 0)
            throw new ArgumentException("Incorrect input string!");
        //начинаем с конца
        for (int i = str_arr.Length - 8; i >= 0; i = i - 8)
        {
            byte[] block = new byte[8];
            Array.Copy(str_arr, i, block, 0, 8);
            //применяем раундовые ключи в обратном порядке
            for (int j = rounds; j >= 0; j--)
            {
                //создаем 2 подблока
                byte[] subblock_left_arr = new byte[4];
                Array.Copy(block, subblock_left_arr, 4);
                byte[] subblock_right_arr = new byte[4];
                Array.Copy(block, 4, subblock_right_arr, 0, 4);

                //создаем раундовый ключ
                byte[] subblock_key_arr = new byte[4];
                Array.Copy(key_arr, subblock_key_arr, 4);
                subblock_key_arr = shift_key_left(key_arr, j);

                if (j != 0)//если j = 0, то не надо поблоки менять местами
                    block = decrypt_block(subblock_left_arr, subblock_right_arr, subblock_key_arr, false);
                else
                    block = decrypt_block(subblock_left_arr, subblock_right_arr, subblock_key_arr, true);
            }
            //скидываем блок в результирующий массив
            Array.Copy(block, 0, res_arr, i, block.Length);
        }
        return Encoding.Default.GetString(res_arr);
    }

    private static byte[] decrypt_block(byte[] subblock_left_arr, byte[] subblock_right_arr, byte[] subblock_key_arr, bool isLast)
    {
        int subblock_left = BitConverter.ToInt32(subblock_left_arr, 0);
        int subblock_right = BitConverter.ToInt32(subblock_right_arr, 0);
        int subblock_key = BitConverter.ToInt32(subblock_key_arr, 0);

        byte[] tmp = new byte[2];
        Array.Copy(subblock_left_arr, tmp, 2);
        Int16 left = BitConverter.ToInt16(tmp, 0);
        Array.Copy(subblock_left_arr, 2, tmp, 0, 2);
        Int16 right = BitConverter.ToInt16(subblock_left_arr, 2);

        //xor
        subblock_right = f(left, right) ^ subblock_right;

        //xor
        subblock_left = subblock_left ^ subblock_key;
        subblock_left_arr = BitConverter.GetBytes(subblock_left);

        subblock_right_arr = BitConverter.GetBytes(subblock_right);

        //меняем или не меняем подблоки местами при объединении
        byte[] res_arr = new byte[8];
        if (!isLast)
        {
            Array.Copy(subblock_right_arr, res_arr, 4);
            Array.Copy(subblock_left_arr, 0, res_arr, 4, 4);
        }
        else
        {
            Array.Copy(subblock_left_arr, res_arr, 4);
            Array.Copy(subblock_right_arr, 0, res_arr, 4, 4);
        }
        return res_arr;
    }

    private static int f(Int16 left, Int16 right)
    {
        //циклический сдвиг влево на 7
        int l = left << 7;
        int r = l >> 16;
        left = (Int16)(l + r);

        //циклический сдвиг вправо на 5
        l = right >> 5;
        r = l << 11;//16-5
        right = (Int16)(l + r);

        //меняем части местами
        int res = (int)left << 16;
        return res + right;
    }

    //возвращает интересующую нас левую половину ключа
    private static byte[] shift_key_left(byte[] key_arr, int i)
    {
        byte[] tmp = new byte[4];
        Array.Copy(key_arr, tmp, 4);
        int left = BitConverter.ToInt32(tmp, 0);
        Array.Copy(key_arr, 4, tmp, 0, 4);
        int right = BitConverter.ToInt32(tmp, 0);

        //циклический сдвиг влево на i * 3
        int l_l = left << (i * 3);
        int r_r = right >> (32 - i * 3);
        left = l_l + r_r;

        return BitConverter.GetBytes(left);
    }
        //*****************
    }
}
