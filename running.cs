using Lab2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Bai01
{
    internal class running
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            int n;

            while (true)
            {
                Console.WriteLine("===== MENU CHỌN BÀI =====");
                Console.WriteLine("1. Bài 01 - In lịch tháng");
                Console.WriteLine("2. Bài 02 - Liệt kê thư mục");
                Console.WriteLine("3. Bài 03 - Ma trận số nguyên");
                Console.WriteLine("4. Bài 04 - Phân số");
                Console.WriteLine("5. Bài 05 - Quản lý bất động sản");
                Console.Write("Nhập số bài muốn chạy (1–5): ");

                if (!int.TryParse(Console.ReadLine(), out n) || n < 1 || n > 5)
                {
                    Console.WriteLine(" Lựa chọn không hợp lệ, vui lòng nhập lại!\n");
                    continue;
                }
                break;
            }
            Console.WriteLine();
            switch (n)
            {
                case 1:
                    Bai01.Run();
                    break;
                case 2:
                    Bai02.Run();
                    break;
                case 3:
                    Bai03.Run();
                    break;
                case 4:
                    Bai04.Run();
                    break;
                case 5:
                    Bai05.Run();
                    break;
                default:
                    Console.WriteLine("Không có bài này!");
                    break;
            }
        }

    }
}
