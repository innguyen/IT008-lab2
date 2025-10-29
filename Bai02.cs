using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai01
{
    internal class Bai02
    {
        // Hàm chính chạy bài 2: liệt kê thư mục và tập tin trong đường dẫn nhập vào
        public static void Run()
        {
            string path;

            //  Nhập và kiểm tra đường dẫn hợp lệ 
            while (true)
            {
                Console.Write("Nhập đường dẫn thư mục: ");
                path = Console.ReadLine();

                // Kiểm tra chuỗi rỗng hoặc chỉ chứa khoảng trắng
                if (string.IsNullOrWhiteSpace(path))
                {
                    Console.WriteLine("Đường dẫn không được để trống! Vui lòng nhập lại.\n");
                    continue;
                }

                // Kiểm tra thư mục có tồn tại hay không
                if (!Directory.Exists(path))
                {
                    Console.WriteLine("Không tìm thấy thư mục này! Vui lòng nhập lại.\n");
                    continue;
                }

                break;
            }

            //  Liệt kê nội dung thư mục
            try
            {
                string[] files = Directory.GetFiles(path);        // Lấy danh sách tập tin
                string[] dirs = Directory.GetDirectories(path);   // Lấy danh sách thư mục con

                Console.WriteLine("\nDanh sách thư mục con:");
                if (dirs.Length > 0)
                {
                    foreach (string dir in dirs)
                        Console.WriteLine($"   {dir}");
                }
                else
                    Console.WriteLine("   (Không có thư mục con)");

                Console.WriteLine("\nDanh sách tập tin:");
                if (files.Length > 0)
                {
                    foreach (string file in files)
                    {
                        FileInfo info = new FileInfo(file);
                        // Hiển thị tên, kích thước (KB) và thời gian chỉnh sửa gần nhất
                        Console.WriteLine($"   {info.Name,-30} | {info.Length / 1024.0:F2} KB | {info.LastWriteTime}");
                    }
                }
                else
                    Console.WriteLine("(Không có tập tin nào trong thư mục)");
            }
            //  Xử lý các lỗi có thể xảy ra 
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("Không có quyền truy cập vào một số tệp hoặc thư mục.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi: {ex.Message}");
            }
        }
    }
}
