using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardUI : MonoBehaviour
{
    public Image background;      
    public Image charImage;       // <-- MỚI THÊM: Chỗ để gắn ảnh tướng vào
    public TextMeshProUGUI nameText; 
    public TextMeshProUGUI powerText; 

    public void Setup(CardData data)
    {
        // --- GÀI MÁY NGHE LÉN ---
    Debug.Log($"Đang setup lá bài: {data.displayName}");
    if (data.artwork == null) Debug.LogError("Lá bài này KHÔNG CÓ ẢNH TƯỚNG (Artwork is Null)!");
    else Debug.Log("Có ảnh tướng: " + data.artwork.name);
    // ------------------------

        nameText.text = data.displayName;
    powerText.text = "SM: " + data.power;
    
    // Kiểm tra an toàn trước khi gán
    if (charImage != null)
    {
        charImage.sprite = data.artwork;
    }
    else
    {
        Debug.LogError("Lỗi: Biến charImage chưa được gắn vào CardUI!");
    }
        // Giữ nguyên phần đổi màu nền (để làm viền)
        switch (data.faction)
        {
            case Faction.Thuc_Do:
                background.color = new Color(0.8f, 0.2f, 0.2f); // Đỏ đậm
                break;
            case Faction.Ngo_Vang:
                background.color = new Color(0.8f, 0.6f, 0f);   // Vàng
                break;
            case Faction.Nguy_Xanh:
                background.color = new Color(0.2f, 0.4f, 0.8f); // Xanh
                break;
            case Faction.QuanHung_Den:
                background.color = new Color(0.4f, 0.4f, 0.4f); // Xám
                break;
        }
    }
}