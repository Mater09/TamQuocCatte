using UnityEngine;
using System.Collections.Generic;

public class DeckManager : MonoBehaviour
{
    public static DeckManager Instance;
    public List<CardData> allCards = new List<CardData>();

    [Header("UI References")]
    public GameObject cardPrefab; 
    public Transform handArea;    

    [Header("Card Sprites")] // <-- MỚI: Chỗ để bạn kéo 4 cái ảnh vào Inspector
    public Sprite spriteThuc;
    public Sprite spriteNgo;
    public Sprite spriteNguy;
    public Sprite spriteQuanHung;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    private void Start()
    {
        CreateDeck();
        ShuffleDeck();
        DealCards(6); 
    }

    void CreateDeck()
    {
        allCards.Clear();
        int cardID = 0;

        foreach (Faction f in System.Enum.GetValues(typeof(Faction)))
        {
            // Chọn ảnh đại diện cho Phe này
            Sprite factionSprite = null;
            switch(f) {
                case Faction.Thuc_Do: factionSprite = spriteThuc; break;
                case Faction.Ngo_Vang: factionSprite = spriteNgo; break;
                case Faction.Nguy_Xanh: factionSprite = spriteNguy; break;
                case Faction.QuanHung_Den: factionSprite = spriteQuanHung; break;
            }

            for (int p = 2; p <= 14; p++)
            {
                string name = GetGeneralName(f, p);
                
                // MỚI: Truyền thêm factionSprite vào hàm tạo
                CardData newCard = new CardData(cardID, f, p, name, factionSprite);
                
                allCards.Add(newCard);
                cardID++;
            }
        }
    }

    // Hàm phụ trợ: Đặt tên cho ngầu
    string GetGeneralName(Faction f, int p)
    {
        string rankName = "Lính";
        if (p >= 11 && p <= 13) rankName = "Đại Tướng";
        if (p == 14) rankName = "Thần Tướng";
        
        return $"{rankName} ({f}) - SM:{p}";
    }

    // Chức năng 2: Xào bài (Thuật toán Fisher-Yates chuẩn quốc tế)
    public void ShuffleDeck()
    {
        // Code cũ giữ nguyên, thêm dòng dưới để xóa bài cũ nếu có
        foreach (Transform child in handArea) Destroy(child.gameObject);

        for (int i = 0; i < allCards.Count; i++)
        {
            CardData temp = allCards[i];
            int randomIndex = Random.Range(i, allCards.Count);
            allCards[i] = allCards[randomIndex];
            allCards[randomIndex] = temp;
        }
    }

    // --- HÀM MỚI: CHIA BÀI ---
    public void DealCards(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            // 1. Lấy dữ liệu lá bài trên đầu bộ bài
            CardData data = allCards[i];

            // 2. Sinh ra (Instantiate) lá bài visual từ Prefab
            GameObject newCardObj = Instantiate(cardPrefab, handArea);

            // 3. Đổ dữ liệu vào lá bài vừa sinh ra
            CardUI ui = newCardObj.GetComponent<CardUI>();
            ui.Setup(data);
        }
        Debug.Log("Đã chia xong " + amount + " lá bài!");
    }
}