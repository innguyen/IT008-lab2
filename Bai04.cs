using System;
using System.Collections.Generic;

namespace Bai01
{
    // Lớp PhanSo biểu diễn một phân số với tử và mẫu, hỗ trợ các phép toán +, -, *, / và so sánh
    internal class PhanSo : IComparable<PhanSo>
    {
        private int tu, mau; // Tử số và mẫu số

        // Thuộc tính cho tử số
        public int Tu
        {
            get { return tu; }
            set { tu = value; }
        }

        // Thuộc tính cho mẫu số, kiểm tra không được bằng 0
        public int Mau
        {
            get { return mau; }
            set
            {
                if (value == 0)
                    throw new ArgumentException("Mẫu không được bằng 0!");
                mau = value;
            }
        }

        // Hàm khởi tạo, có giá trị mặc định (0/1)
        public PhanSo(int tu = 0, int mau = 1)
        {
            Tu = tu;
            Mau = mau;
            RutGon(); // Rút gọn phân số ngay khi khởi tạo
        }

        // Hàm tìm ước chung lớn nhất (dùng để rút gọn)
        private int UCLN(int a, int b) => b == 0 ? a : UCLN(b, a % b);

        // Hàm rút gọn phân số
        private void RutGon()
        {
            int g = UCLN(Math.Abs(Tu), Math.Abs(Mau)); // Lấy UCLN của tử và mẫu
            Tu /= g;
            Mau /= g;
        }

        // Toán tử cộng hai phân số
        public static PhanSo operator +(PhanSo a, PhanSo b)
            => new PhanSo(a.Tu * b.Mau + b.Tu * a.Mau, a.Mau * b.Mau);

        // Toán tử trừ hai phân số
        public static PhanSo operator -(PhanSo a, PhanSo b)
            => new PhanSo(a.Tu * b.Mau - b.Tu * a.Mau, a.Mau * b.Mau);

        // Toán tử nhân hai phân số
        public static PhanSo operator *(PhanSo a, PhanSo b)
            => new PhanSo(a.Tu * b.Tu, a.Mau * b.Mau);

        // Toán tử chia hai phân số
        public static PhanSo operator /(PhanSo a, PhanSo b)
        {
            if (b.Tu == 0)
                throw new DivideByZeroException("Không thể chia cho phân số có tử = 0!");
            return new PhanSo(a.Tu * b.Mau, a.Mau * b.Tu);
        }

        // So sánh hai phân số để phục vụ sắp xếp (theo giá trị thực)
        public int CompareTo(PhanSo other)
        {
            double val1 = (double)Tu / Mau;
            double val2 = (double)other.Tu / other.Mau;
            return val1.CompareTo(val2);
        }

        // Xuất phân số dưới dạng chuỗi "tu/mau"
        public override string ToString() => $"{Tu}/{Mau}";
    }

    internal class Bai04
    {
        static public void Run()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8; // Đảm bảo hiển thị tiếng Việt

            // Nhập hai phân số để thực hiện các phép tính cơ bản
            PhanSo a = NhapPhanSo("Nhập phân số thứ nhất:");
            PhanSo b = NhapPhanSo("Nhập phân số thứ hai:");

            // Hiển thị kết quả các phép toán
            Console.WriteLine($"\nTổng: {a + b}");
            Console.WriteLine($"Hiệu: {a - b}");
            Console.WriteLine($"Tích: {a * b}");
            try
            {
                Console.WriteLine($"Thương: {a / b}");
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine("Lỗi khi chia: " + ex.Message);
            }

            // Nhập danh sách phân số
            Console.Write("\nNhập số lượng phân số: ");
            int n = int.Parse(Console.ReadLine());
            List<PhanSo> ds = new List<PhanSo>();

            // Nhập từng phân số vào danh sách
            for (int i = 0; i < n; i++)
                ds.Add(NhapPhanSo($"Phân số thứ {i + 1}:"));

            // Sắp xếp danh sách tăng dần theo giá trị
            ds.Sort();

            // In danh sách sau khi sắp xếp
            Console.WriteLine("\nDanh sách sắp xếp tăng dần:");
            foreach (var ps in ds) Console.WriteLine(ps);

            // In phân số lớn nhất trong danh sách
            Console.WriteLine($"\nPhân số lớn nhất: {ds[n - 1]}");
        }

        // Hàm nhập một phân số hợp lệ (kiểm tra tử và mẫu)
        static PhanSo NhapPhanSo(string message)
        {
            Console.WriteLine(message);
            int tu, mau;
            while (true)
            {
                Console.Write("Nhập tử: ");
                if (!int.TryParse(Console.ReadLine(), out tu))
                {
                    Console.WriteLine("Tử phải là số nguyên!");
                    continue;
                }
                Console.Write("Nhập mẫu: ");
                if (!int.TryParse(Console.ReadLine(), out mau) || mau == 0)
                {
                    Console.WriteLine("Mẫu phải khác 0!");
                    continue;
                }
                break;
            }
            return new PhanSo(tu, mau);
        }
    }
}

