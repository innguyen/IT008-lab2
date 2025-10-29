using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai01
{
    class MaTran
    {
        private int[,] a; // Mảng 2 chiều lưu các phần tử của ma trận
        private int m;    // Số dòng
        private int n;    // Số cột

        // Hàm kiểm tra 1 số có phải là số nguyên tố hay không
        private bool LaSoNguyenTo(int x)
        {
            if (x < 2) return false;
            for (int i = 2; i <= Math.Sqrt(x); i++)
                if (x % i == 0) return false;
            return true;
        }

        // Hàm nhập ma trận với kiểm tra tính hợp lệ của dữ liệu
        public void Nhap()
        {
            // Nhập số dòng m
            while (true)
            {
                Console.Write("Nhập số dòng: ");
                if (int.TryParse(Console.ReadLine(), out m) && m > 0)
                    break;
                Console.WriteLine("Vui lòng nhập số nguyên dương!");
            }

            // Nhập số cột n
            while (true)
            {
                Console.Write("Nhập số cột: ");
                if (int.TryParse(Console.ReadLine(), out n) && n > 0)
                    break;
                Console.WriteLine("Vui lòng nhập số nguyên dương!");
            }

            a = new int[m, n]; // Khởi tạo ma trận m x n

            Console.WriteLine("\nNhập các phần tử của ma trận:");
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    while (true)
                    {
                        Console.Write($"a[{i},{j}] = ");
                        if (int.TryParse(Console.ReadLine(), out a[i, j]))
                            break;
                        Console.WriteLine("Dữ liệu không hợp lệ, hãy nhập lại số nguyên!");
                    }
                }
            }
        }

        // Hàm xuất ma trận ra màn hình
        public void Xuat()
        {
            Console.WriteLine("\nMa trận:");
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                    Console.Write(a[i, j] + "\t");
                Console.WriteLine();
            }
        }

        // Hàm tìm kiếm giá trị x trong ma trận
        public void TimKiem(int x)
        {
            bool found = false;
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (a[i, j] == x)
                    {
                        Console.WriteLine($"Tìm thấy {x} tại vị trí dòng {i+1}, cột {j+1}");
                        found = true;
                    }
                }
            }
            if (!found)
                Console.WriteLine($"Không tìm thấy {x} trong ma trận.");
        }

        // Hàm xuất ra các phần tử là số nguyên tố trong ma trận
        public void XuatNguyenTo()
        {
            Console.WriteLine("\nCác phần tử là số nguyên tố:");
            bool coSoNguyenTo = false;

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (LaSoNguyenTo(a[i, j]))
                    {
                        Console.Write(a[i, j] + "\t");
                        coSoNguyenTo = true;
                    }
                }
            }

            if (!coSoNguyenTo)
                Console.WriteLine("Không có số nguyên tố nào.");
            else
                Console.WriteLine();
        }

        // Hàm tìm và in ra dòng có nhiều số nguyên tố nhất
        public void DongNhieuNguyenToNhat()
        {
            int[] counts = new int[m]; // Mảng lưu số lượng số nguyên tố của từng dòng
            int maxCount = 0;          // Biến lưu giá trị lớn nhất của số lượng số nguyên tố

            // Đếm số nguyên tố từng dòng
            for (int i = 0; i < m; i++)
            {
                int count = 0;
                for (int j = 0; j < n; j++)
                    if (LaSoNguyenTo(a[i, j]))
                        count++;

                counts[i] = count; // Lưu số lượng vào mảng
                if (count > maxCount)
                    maxCount = count;
            }

            // Nếu không có số nguyên tố nào trong toàn bộ ma trận
            if (maxCount == 0)
            {
                Console.WriteLine("\nKhông có dòng nào chứa số nguyên tố.");
                return;
            }

            // Xuất các dòng có số lượng số nguyên tố lớn nhất
            Console.WriteLine($"\nDòng có nhiều số nguyên tố nhất (có {maxCount} số nguyên tố):");
            for (int i = 0; i < m; i++)
            {
                if (counts[i] == maxCount)
                {
                    Console.Write($"- Dòng {i + 1}: ");
                    for (int j = 0; j < n; j++)
                        if (LaSoNguyenTo(a[i, j]))
                            Console.Write(a[i, j] + "\t");
                    Console.WriteLine();
                }
            }
        }
    }

    internal class Bai03
    {
        static public void Run()
        {
            Console.OutputEncoding = Encoding.UTF8;

            // Tạo đối tượng ma trận
            MaTran mt = new MaTran();

            // Nhập và xuất ma trận
            mt.Nhap();
            mt.Xuat();

            // Nhập giá trị cần tìm và thực hiện tìm kiếm
            Console.Write("\nNhập giá trị cần tìm: ");
            int x;
            while (!int.TryParse(Console.ReadLine(), out x))
            {
                Console.WriteLine("Vui lòng nhập số nguyên!");
                Console.Write("Nhập lại giá trị cần tìm: ");
            }
            mt.TimKiem(x);

            // Xuất các số nguyên tố và dòng có nhiều số nguyên tố nhất
            mt.XuatNguyenTo();
            mt.DongNhieuNguyenToNhat();
        }
    }
}
