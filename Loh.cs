using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// <summary>
/// <right>لوح</right>
/// <right>نسخه: 0.5.0</right>
/// <right>تاریخ: 1403.07.11</right>
/// </summary>
namespace HJafr.loh
{
    class Loh
    {
        public static void loh3()
        {
            int zel_int = 3;
            string[,,] zel = new string[3,3,3];

            int loh_khane = (int)Math.Pow(zel_int, 2);          //  تعداد خانه‌های لوح
            int loh_kol = (loh_khane + 1) * loh_khane / 2;  //  جمع کل لوح
            int line_any = loh_kol / zel_int;       //  عدد هر خط یا ضلع
            int line_fasele = line_any;             //  فاصله بین جمع کمترین عدد ممکن و عدد دلخواه
            for (int i = 0; i < zel_int; i++)
                line_fasele -= i * zel_int + 1;

            List<int[]>[] line = new List<int[]>[zel_int];           //  متغیر خطوط صحیح
            for (int i = 0; i < zel_int; i++)
                line[i] = new List<int[]>();
            List<string> line_final = new List<string>();

            for (int[] i = new int[zel_int]; i[0] < zel_int; i[zel_int - 1]++)
            {
                // تنظیم اعداد در گردش
                if (i[zel_int - 1] == zel_int)
                    i = gardesh_adad(i, zel_int);
                if (i[0] >= zel_int)
                    break;

                int i_jame = 0;
                for (int j = 0; j < zel_int; j++)
                    i_jame += i[j];
                if (i_jame == line_fasele)     //  ورود درست بودن مقدار مورد نیاز
                {
                    while (i[zel_int - 1] >= 0 && i[zel_int - 2] < zel_int)
                    {
                        string tmp = "";
                        for (int j = 0; j < zel_int; j++)
                            tmp += i[j].ToString() + ",";
                        line_final.Add(tmp);

                        line[i[0]].Add(i);
                        i[zel_int - 1]--;
                        i[zel_int - 2]++;
                    }
                    i = gardesh_adad(i, zel_int);
                }
            }

            //  تبدیل لیست به فایل خروجی
            System.IO.File.WriteAllLines("c:\\" + zel_int.ToString() + ".txt", line_final.ToArray());
        }

        static int[] gardesh_adad(int[] i, int zel_int)
        {
            for (int j = zel_int - 1; j > 0; j--)
                if (i[j] >= zel_int)
                {
                    i[j] = 0;
                    i[j - 1]++;
                }
            return i;
        }

    }

    class Jaygasht
    {
        static public void sortchar(char[] buffer, int len)
        {
            for (int i = 1; i < len; i++)
            {
                for (int j = 0; j < len - i; j++)
                {
                    if (buffer[j] > buffer[j + 1])
                    {
                        char temp = buffer[j];
                        buffer[j] = buffer[j + 1];
                        buffer[j + 1] = temp;
                    }
                }
            }
        }

        static public bool NextPermuation(char[] p, int len)
        {
            for (int k = len - 1; k > 0; k--)
            {
                if (p[k - 1] >= p[k])
                    continue;
                else
                {
                    if (k <= len - 3)
                    {
                        char newchar = p[k - 1];
                        int anchor = -1;
                        for (int j = len - 1; j >= k; j--)
                        {
                            if (newchar < p[j])
                            {
                                anchor = j;
                                break;
                            }
                        }
                        if (anchor == -1)
                            return false;
                        char ch = p[k - 1];
                        p[k - 1] = p[anchor];
                        p[anchor] = ch;

                        char[] tbuffer = new char[len - k];
                        for (int m = 0; m < len - k; m++)
                            tbuffer[m] = p[k + m];
                        sortchar(tbuffer, len - k);
                        for (int n = 0; n < len - k; n++)
                            p[k + n] = tbuffer[n];
                        return true;
                    }
                    else
                    {
                        char[] tempptr = new char[3];
                        tempptr[0] = p[p.Length - 3];
                        tempptr[1] = p[p.Length - 2];
                        tempptr[2] = p[p.Length - 1];

                        int count = 3;
                        for (int i = count - 1; i > 0; i--)
                        {
                            if (tempptr[i - 1] >= tempptr[i])
                                continue;
                            else
                            {
                                if (i <= count - 2)
                                {
                                    if (tempptr[i + 1] > tempptr[i - 1])
                                    {
                                        char ch = tempptr[i + 1];
                                        tempptr[i + 1] = tempptr[i];
                                        tempptr[i] = tempptr[i - 1];
                                        tempptr[i - 1] = ch;
                                    }
                                    else
                                    {
                                        char ch = tempptr[i - 1];
                                        tempptr[i - 1] = tempptr[i];
                                        tempptr[i] = tempptr[i + 1];
                                        tempptr[i + 1] = ch;
                                    }
                                }
                                else
                                {
                                    char ch = tempptr[i];
                                    tempptr[i] = tempptr[i - 1];
                                    tempptr[i - 1] = ch;
                                }
                                p[p.Length - 3] = tempptr[0];
                                p[p.Length - 2] = tempptr[1];
                                p[p.Length - 1] = tempptr[2];
                                return true;
                            }
                        }
                        return false;
                    }
                }
            }
            return false;
        }

        public static void start(string start, string[] args)
        {
            string str = "";
            char[] buffer = start.ToCharArray();
            // sortchar(buffer, buffer.Length); // use it only if you require

            int count = 0;
            while (true)
            {
                str += string.Join(",", buffer)+"\n";
                count++;
                if (NextPermuation(buffer, buffer.Length) == false)
                    break;
            }

            str += "\nCount: " + count;

            System.IO.File.WriteAllText("c:\\" + start + ".txt", str);
        }
    }
}
