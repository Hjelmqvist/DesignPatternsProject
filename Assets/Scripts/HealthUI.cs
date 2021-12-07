using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    [SerializeField] Image[] _hearts;
    [SerializeField] Sprite _emptyHeart, _fullHeart;

    public void HealthChanged(HealthChangedArgs args)
    {
        int health = args.CurrentHealth;
        for (int i = 0; i < _hearts.Length; i++)
            _hearts[i].sprite = i < health ? _fullHeart : _emptyHeart;
    }
}