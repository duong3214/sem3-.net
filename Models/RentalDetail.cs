using System; // Có thể không cần nếu không sử dụng các thành phần từ System

namespace ComicSystem.Models
{
    public class RentalDetail
    {
        public int RentalDetailID { get; set; } // Khóa chính
        public int RentalID { get; set; } // Khóa ngoại liên kết tới bảng Rentals
        public int ComicBookID { get; set; } // Khóa ngoại liên kết tới bảng ComicBooks
        public int Quantity { get; set; } // Số lượng sách thuê
        public decimal PricePerDay { get; set; } // Giá thuê theo ngày

        // Navigation properties
        public Rental? Rental { get; set; } // Tham chiếu đến thông tin thuê
        public ComicBook? ComicBook { get; set; } // Tham chiếu đến thông tin sách
    }
}
