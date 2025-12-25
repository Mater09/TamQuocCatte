using UnityEngine;
using UnityEngine.EventSystems; // Thư viện bắt buộc để nhận biết click chuột

// Thêm dòng ", IPointerClickHandler" để lá bài biết lắng nghe cú click
public class CardInteraction : MonoBehaviour, IPointerClickHandler
{
    public bool isSelected = false; // Biến kiểm tra: Có đang chọn không?
    public float moveDistance = 30f; // Khoảng cách nhô lên (30 đơn vị)

    // Hàm này tự động chạy khi người chơi click chuột (hoặc chạm tay) vào lá bài
    public void OnPointerClick(PointerEventData eventData)
    {
        // 1. Đảo ngược trạng thái (Đang chọn -> Bỏ chọn, và ngược lại)
        isSelected = !isSelected;

        // 2. Xử lý vị trí
        if (isSelected)
        {
            // Nếu chọn: Nhô lên
            transform.localPosition += new Vector3(0, moveDistance, 0);
            Debug.Log("Đã chọn bài!");
        }
        else
        {
            // Nếu bỏ chọn: Tụt xuống về chỗ cũ
            transform.localPosition -= new Vector3(0, moveDistance, 0);
            Debug.Log("Đã bỏ chọn!");
        }
    }
}