using System;
using System.Collections.Generic;

namespace ComicSystem.Models
{
    public class Rental
    {
        public int RentalID { get; set; } // Khóa chính
        public int CustomerID { get; set; } // Khóa ngoại liên kết tới bảng Customers
        public DateTime RentalDate { get; set; } // Ngày thuê
        public DateTime ReturnDate { get; set; } // Ngày trả
        public string? Status { get; set; } // Trạng thái (đã trả, đang thuê, v.v.)

        // Navigation property
        public Customer? Customer { get; set; } // Tham chiếu đến thông tin khách hàng
        public ICollection<RentalDetail>? RentalDetails { get; set; } // Danh sách chi tiết thuê
    }
}
