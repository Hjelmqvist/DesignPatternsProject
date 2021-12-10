using UnityEngine;
using TMPro;

public class GoldUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _goldText;

    private void OnEnable()
    {
        Wallet.Instance.OnGoldChanged += Instance_OnGoldChanged;
    }

    private void OnDisable()
    {
        Wallet.Instance.OnGoldChanged -= Instance_OnGoldChanged;
    }

    private void Instance_OnGoldChanged(int gold)
    {
        _goldText.text = gold.ToString();
    }
}