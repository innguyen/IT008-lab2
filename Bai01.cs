using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai01
{
    internal class Bai01
    {
        static public void Run()
        {
            int month, year; // Biến lưu tháng và năm

            // Nhập tháng hợp lệ (1 - 12)
            while (true)
            {
                Console.Write("Nhập tháng (1-12): ");
                string inputMonth = Console.ReadLine(); // Đọc dữ liệu người dùng nhập

                // Kiểm tra có phải số nguyên hay không
                if (int.TryParse(inputMonth, out month))
                {
                    // Kiểm tra phạm vi hợp lệ
                    if (month >= 1 && month <= 12)
                        break; // Hợp lệ → thoát vòng lặp
                    else
                        Console.WriteLine("Tháng phải trong khoảng 1 đến 12. Hãy nhập lại.\n");
                }
                else
                {
                    // Nếu không phải số nguyên → thông báo lỗi
                    Console.WriteLine("Dữ liệu không hợp lệ! Vui lòng nhập số nguyên.\n");
                }
            }

            // Nhập năm hợp lệ (> 0)
            while (true)
            {
                Console.Write("Nhập năm (>0): ");
                string inputYear = Console.ReadLine(); // Đọc dữ liệu năm

                // Kiểm tra có phải số nguyên hay không
                if (int.TryParse(inputYear, out year))
                {
                    if (year > 0)
                        break; // Năm hợp lệ → thoát vòng lặp
                    else
                        Console.WriteLine("Năm phải là số nguyên dương. Hãy nhập lại.\n");
                }
                else
                {
                    // Nếu nhập sai định dạng
                    Console.WriteLine("Dữ liệu không hợp lệ! Vui lòng nhập số nguyên.\n");
                }
            }

            // Tạo đối tượng DateTime đại diện cho ngày đầu tiên của tháng đó
            DateTime date = new DateTime(year, month, 1);

            // Lấy thứ của ngày đầu tiên trong tháng (0 = Chủ nhật, 1 = Thứ hai, …)
            int thu = (int)date.DayOfWeek;

            // Lấy số ngày trong tháng đó (tự động xử lý năm nhuận)
            int days = DateTime.DaysInMonth(year, month);

            // In tiêu đề các ngày trong tuần
            Console.WriteLine("\nSun\tMon\tTue\tWed\tThu\tFri\tSat\n");

            int c7 = 0; // Đếm số ô đã in trên 1 dòng (tối đa 7 cột tương ứng 7 ngày)

            // In khoảng trống trước khi bắt đầu in ngày 1 (tùy thứ của ngày đầu tiên)
            for (int i = 0; i < thu; i++)
            {
                Console.Write("\t");
                c7++;
            }

            // In các ngày trong tháng
            for (int i = 1; i <= days; i++)
            {
                Console.Write(i + "\t"); // In ngày hiện tại
                c7++;

                // Nếu đủ 7 ngày (1 tuần) → xuống dòng
                if (c7 == 7)
                {
                    Console.WriteLine();
                    c7 = 0; // Reset bộ đếm cho tuần mới
                }
            }
        }
    }
}
