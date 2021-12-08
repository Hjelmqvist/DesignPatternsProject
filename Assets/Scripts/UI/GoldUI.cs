using UnityEngine;
using TMPro;

public class GoldUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _goldText;

    public void GoldChanged(int gold)
    {
        _goldText.text = gold.ToString();
    }
}