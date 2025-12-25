// File: GameEnums.cs
// Không cần : MonoBehaviour vì đây chỉ là file định nghĩa
public enum Faction 
{
    Thuc_Do,     // 0: Phe Thục (Tương ứng Cơ - Đỏ)
    Ngo_Vang,    // 1: Phe Ngô (Tương ứng Rô - Vàng/Cam)
    Nguy_Xanh,   // 2: Phe Ngụy (Tương ứng Chuồn - Xanh)
    QuanHung_Den // 3: Phe Quần Hùng (Tương ứng Bích - Đen)
}

public enum CardRank 
{
    Linh = 0,    // Nhóm lính tốt (2,3,4...)
    Tuong = 1,   // Nhóm tướng nhỏ
    DaiTuong = 2,// Nhóm J, Q, K
    ThanTuong = 3 // Nhóm Át
}