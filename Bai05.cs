using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    // Lớp KhuDat: lớp cơ sở cho các loại bất động sản
    internal class KhuDat
    {
        public string DiaDiem { get; set; } // Địa điểm
        public decimal GiaBan { get; set; }  // Giá bán
        public double DienTich { get; set; } // Diện tích (m2)

        // Nhập thông tin cơ bản
        public virtual void Nhap()
        {
            Console.Write("Địa điểm: ");
            DiaDiem = Console.ReadLine();
            GiaBan = ReadDecimal("Giá bán (VND): ");
            DienTich = ReadDouble("Diện tích (m2): ");
        }

        // Xuất thông tin cơ bản
        public virtual void Xuat()
        {
            Console.WriteLine($"Địa điểm: {DiaDiem}, Giá: {GiaBan:N0} VND, DT: {DienTich} m2");
        }

        // Hàm hỗ trợ nhập số thập phân
        protected decimal ReadDecimal(string message)
        {
            while (true)
            {
                Console.Write(message);
                if (decimal.TryParse(Console.ReadLine(), out decimal value)) return value;
                Console.WriteLine("Giá trị không hợp lệ, nhập lại!");
            }
        }

        // Hàm hỗ trợ nhập số thực
        protected double ReadDouble(string message)
        {
            while (true)
            {
                Console.Write(message);
                if (double.TryParse(Console.ReadLine(), out double value)) return value;
                Console.WriteLine("Giá trị không hợp lệ, nhập lại!");
            }
        }
    }

    // Lớp Nhà Phố kế thừa KhuDat, bổ sung thông tin riêng
    internal class NhaPho : KhuDat
    {
        public int NamXayDung { get; set; } // Năm xây dựng
        public int SoTang { get; set; }     // Số tầng

        // Nhập thông tin Nhà Phố
        public override void Nhap()
        {
            base.Nhap(); // Gọi phương thức nhập của lớp cơ sở
            NamXayDung = (int)ReadDecimal("Năm xây dựng: ");
            SoTang = (int)ReadDecimal("Số tầng: ");
        }

        // Xuất thông tin Nhà Phố
        public override void Xuat()
        {
            base.Xuat();
            Console.WriteLine($"Năm XD: {NamXayDung}, Số tầng: {SoTang}");
        }
    }

    // Lớp Chung Cư kế thừa KhuDat, bổ sung thông tin riêng
    internal class ChungCu : KhuDat
    {
        public int Tang { get; set; } // Tầng

        // Nhập thông tin Chung Cư
        public override void Nhap()
        {
            base.Nhap();
            Tang = (int)ReadDecimal("Tầng: ");
        }

        // Xuất thông tin Chung Cư
        public override void Xuat()
        {
            base.Xuat();
            Console.WriteLine($"Tầng: {Tang}");
        }
    }

    // Lớp quản lý danh sách bất động sản
    internal class QuanLyBDS
    {
        private List<KhuDat> dsBDS = new List<KhuDat>(); // Danh sách các bất động sản

        // Nhập dữ liệu cho các loại BĐS
        public void NhapDuLieu()
        {
            // Nhập Khu Đất
            Console.Write("Nhập số lượng Khu Đất: ");
            int nKhuDat = int.Parse(Console.ReadLine());
            for (int i = 0; i < nKhuDat; i++)
            {
                Console.WriteLine($"\nNhập Khu Đất thứ {i + 1}:");
                KhuDat kd = new KhuDat();
                kd.Nhap();
                dsBDS.Add(kd);
            }

            // Nhập Nhà Phố
            Console.Write("Nhập số lượng Nhà Phố: ");
            int nNhaPho = int.Parse(Console.ReadLine());
            for (int i = 0; i < nNhaPho; i++)
            {
                Console.WriteLine($"\nNhập Nhà Phố thứ {i + 1}:");
                NhaPho np = new NhaPho();
                np.Nhap();
                dsBDS.Add(np);
            }

            // Nhập Chung Cư
            Console.Write("Nhập số lượng Chung Cư: ");
            int nChungCu = int.Parse(Console.ReadLine());
            for (int i = 0; i < nChungCu; i++)
            {
                Console.WriteLine($"\nNhập Chung Cư thứ {i + 1}:");
                ChungCu cc = new ChungCu();
                cc.Nhap();
                dsBDS.Add(cc);
            }
        }

        // Xuất tổng giá bán theo loại bất động sản
        public void XuatTongGiaBan()
        {
            decimal tongKhuDat = dsBDS.OfType<KhuDat>().Where(x => x.GetType() == typeof(KhuDat)).Sum(x => x.GiaBan);
            decimal tongNhaPho = dsBDS.OfType<NhaPho>().Sum(x => x.GiaBan);
            decimal tongChungCu = dsBDS.OfType<ChungCu>().Sum(x => x.GiaBan);

            Console.WriteLine("\n=== Tổng giá bán ===");
            Console.WriteLine($"Khu Đất: {tongKhuDat:N0} VND");
            Console.WriteLine($"Nhà Phố: {tongNhaPho:N0} VND");
            Console.WriteLine($"Chung Cư: {tongChungCu:N0} VND");
        }

        // Xuất danh sách theo điều kiện
        public void XuatDanhSachTheoDieuKien()
        {
            Console.WriteLine("\n=== Danh sách Khu Đất >100m2 ===");
            foreach (var kd in dsBDS.OfType<KhuDat>().Where(x => x.GetType() == typeof(KhuDat) && x.DienTich > 100))
                kd.Xuat();

            Console.WriteLine("\n=== Danh sách Nhà Phố DT>60 & Năm XD>=2019 ===");
            foreach (var np in dsBDS.OfType<NhaPho>().Where(x => x.DienTich > 60 && x.NamXayDung >= 2019))
                np.Xuat();
        }

        // Tìm kiếm Nhà Phố hoặc Chung Cư theo địa điểm, giá và diện tích
        public void TimKiem()
        {
            Console.WriteLine("\n=== Tìm kiếm Nhà Phố hoặc Chung Cư ===");
            Console.Write("Nhập địa điểm cần tìm (có thể chứa chuỗi): ");
            string timDiaDiem = Console.ReadLine();

            decimal timGia;
            while (true)
            {
                Console.Write("Nhập giá tối đa (VND): ");
                if (decimal.TryParse(Console.ReadLine(), out timGia)) break;
                Console.WriteLine("Giá không hợp lệ, nhập lại!");
            }

            double timDienTich;
            while (true)
            {
                Console.Write("Nhập diện tích tối thiểu (m2): ");
                if (double.TryParse(Console.ReadLine(), out timDienTich)) break;
                Console.WriteLine("Diện tích không hợp lệ, nhập lại!");
            }

            // Kết quả tìm kiếm Nhà Phố
            Console.WriteLine("\n=== Kết quả tìm kiếm Nhà Phố ===");
            foreach (var np in dsBDS.OfType<NhaPho>().Where(x =>
                x.DiaDiem.IndexOf(timDiaDiem, StringComparison.OrdinalIgnoreCase) >= 0 &&
                x.GiaBan <= timGia &&
                x.DienTich >= timDienTich))
            {
                np.Xuat();
            }

            // Kết quả tìm kiếm Chung Cư
            Console.WriteLine("\n=== Kết quả tìm kiếm Chung Cư ===");
            foreach (var cc in dsBDS.OfType<ChungCu>().Where(x =>
                x.DiaDiem.IndexOf(timDiaDiem, StringComparison.OrdinalIgnoreCase) >= 0 &&
                x.GiaBan <= timGia &&
                x.DienTich >= timDienTich))
            {
                cc.Xuat();
            }
        }
    }

    // Lớp chạy chương trình
    internal class Bai05
    {
        static public void Run()
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;

            QuanLyBDS ql = new QuanLyBDS();
            ql.NhapDuLieu();         // Nhập dữ liệu
            ql.XuatTongGiaBan();     // Xuất tổng giá bán
            ql.XuatDanhSachTheoDieuKien(); // Xuất danh sách theo điều kiện
            ql.TimKiem();            // Tìm kiếm theo yêu cầu

            Console.WriteLine("\n=== Kết thúc chương trình ===");
        }
    }
}
