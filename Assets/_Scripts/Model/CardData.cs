using UnityEngine;
using System;

[Serializable]
public class CardData 
{
    public int id;
    public Faction faction;
    public int power;
    public string displayName;
    public Sprite artwork; // <-- MỚI THÊM: Biến chứa hình ảnh

    public CardData(int _id, Faction _faction, int _power, string _name, Sprite _art)
    {
        this.id = _id;
        this.faction = _faction;
        this.power = _power;
        this.displayName = _name;
        this.artwork = _art; // <-- Lưu ảnh vào dữ liệu
    }
}