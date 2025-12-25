using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    // Khai báo các khu vực
    public Transform handArea;  // Khu vực cầm bài
    public Transform tableArea; // Khu vực bài đã đánh
    public Button playButton;   // Nút đánh bài

    void Start()
    {
        // Gắn sự kiện: Khi bấm nút thì gọi hàm OnPlayCard
        playButton.onClick.AddListener(OnPlayCard);
    }

    // Hàm xử lý khi bấm nút Đánh
    void OnPlayCard()
    {
        // 1. Tìm xem lá bài nào đang được chọn trong tay
        // Duyệt qua tất cả con của HandArea
        foreach (Transform card in handArea) 
        {
            // Lấy script tương tác của lá bài đó
            CardInteraction interaction = card.GetComponent<CardInteraction>();

            // Nếu lá bài đó đang được chọn (isSelected == true)
            if (interaction != null && interaction.isSelected)
            {
                // 2. Chuyển nó sang khu vực bàn (TableArea)
                card.SetParent(tableArea);

                // 3. Reset trạng thái lá bài
                interaction.isSelected = false; // Tắt chọn
                card.localPosition = Vector3.zero; // Đặt về vị trí chuẩn trong bàn
                
                // 4. (Quan trọng) Chỉ đánh 1 lá thôi rồi dừng, không đánh hết
                // Nếu game Catte cho đánh nhiều lá thì bỏ dòng break này
                break; 
            }
        }
    }
}