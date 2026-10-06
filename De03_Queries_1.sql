-- ĐỀ THI 03 - QLTAPGYM

--1. Tìm tất cả các huấn luyện viên làm việc tại Phòng Gym Hà Nội (0.5đ)
SELECT HL.*
FROM HuanLuyenVien AS HL
JOIN PhongTap AS PT ON HL.MaPhong = PT.MaPhong
WHERE PT.TenPhong = N'Phòng Gym Hà Nội';

--2. Liệt kê tất cả các chế độ tập luyện có mô tả chứa từ 'giảm' (1đ)
SELECT *
FROM CheDoTap
WHERE MoTa LIKE N'%giảm%';

--3. Hãy cho biết thông tin huấn luyện viên được nhiều hơn hai khách hàng đăng ký (1đ)
SELECT HL.MaPT, HL.HoTen, HL.ChuyenMon, HL.SoDienThoai, HL.Email, HL.MaPhong, COUNT(DK.MaKH) AS SoLuongKhachHang
FROM HuanLuyenVien AS HL
JOIN DangKyTap AS DK ON HL.MaPT = DK.MaPT
GROUP BY HL.MaPT, HL.HoTen, HL.ChuyenMon, HL.SoDienThoai, HL.Email, HL.MaPhong
HAVING COUNT(DK.MaKH) > 2;

--4. Liệt kê danh sách các chế độ tập được đăng ký nhiều nhất, sắp xếp theo số lượng giảm dần (1đ)
SELECT CD.MaCheDo, CD.TenCheDo, CD.MoTa, COUNT(DK.MaDangKy) AS SoLuongDangKy
FROM CheDoTap AS CD
JOIN DangKyTap AS DK ON CD.MaCheDo = DK.MaCheDo
GROUP BY CD.MaCheDo, CD.TenCheDo, CD.MoTa
ORDER BY COUNT(DK.MaDangKy) DESC;

--5. Liệt kê thông tin chi tiết khách hàng đã đăng ký "Zumba nâng cao" nhưng không đăng ký tại "Phòng Gym Hà Nội", sắp xếp tuổi tăng dần (1,5đ)
SELECT DISTINCT KH.MaKH, KH.HoTen, KH.NgaySinh, KH.GioiTinh, KH.DiaChi, KH.SoDienThoai, KH.Email
FROM KhachHang AS KH
JOIN DangKyTap AS DK ON KH.MaKH = DK.MaKH
JOIN CheDoTap AS CD ON DK.MaCheDo = CD.MaCheDo
JOIN HuanLuyenVien AS HL ON DK.MaPT = HL.MaPT
JOIN PhongTap AS PT ON HL.MaPhong = PT.MaPhong
WHERE CD.TenCheDo = N'Zumba nâng cao'
AND KH.MaKH NOT IN (
    SELECT D2.MaKH
    FROM DangKyTap AS D2
    JOIN HuanLuyenVien AS H2 ON D2.MaPT = H2.MaPT
    JOIN PhongTap AS P2 ON H2.MaPhong = P2.MaPhong
    WHERE P2.TenPhong = N'Phòng Gym Hà Nội'
)
ORDER BY KH.NgaySinh DESC;

--6. Tính tổng thời gian tập luyện của từng khách hàng (0.5đ)
SELECT KH.MaKH, KH.HoTen, SUM(DATEDIFF(MINUTE, LT.GioBatDau, LT.GioKetThuc)) AS TongThoiGianPhut
FROM KhachHang AS KH
JOIN DangKyTap AS DK ON KH.MaKH = DK.MaKH
JOIN LichTap AS LT ON DK.MaDangKy = LT.MaDangKy
GROUP BY KH.MaKH, KH.HoTen;

--7. Tìm phòng tập không có khách hàng nào đăng ký (1đ)
SELECT PT.*
FROM PhongTap AS PT
WHERE PT.MaPhong NOT IN (
    SELECT DISTINCT HL.MaPhong
    FROM HuanLuyenVien AS HL
    JOIN DangKyTap AS DK ON HL.MaPT = DK.MaPT
);

--8. Tìm tất cả các khách hàng đã đăng ký chế độ "Yoga cơ bản" và "Giảm cân" (2đ)
SELECT KH.*
FROM KhachHang AS KH
WHERE KH.MaKH IN (
    SELECT D1.MaKH
    FROM DangKyTap AS D1
    JOIN CheDoTap AS C1 ON D1.MaCheDo = C1.MaCheDo
    WHERE C1.TenCheDo = N'Yoga cơ bản'
)
AND KH.MaKH IN (
    SELECT D2.MaKH
    FROM DangKyTap AS D2
    JOIN CheDoTap AS C2 ON D2.MaCheDo = C2.MaCheDo
    WHERE C2.TenCheDo = N'Giảm cân'
);
