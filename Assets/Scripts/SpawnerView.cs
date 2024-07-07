using TMPro;
using UnityEngine;

public abstract class SpawnerView<T> : MonoBehaviour where T : MonoBehaviour
{
    [SerializeField] protected TMP_Text TextObjectCreate;
    [SerializeField] protected TMP_Text TextObjectActive;

    protected void OnCreatedValue(int value, string name)
    {
        TextObjectCreate.text = value.ToString($"Количество созданных {name}: {value}");
    }

    protected void OnActivetedValue(int value, string name)
    {
        TextObjectActive.text = value.ToString($"Количество активных {name}: {value}");
        Debug.Log($"Количество активных {name}: {value}");
    }
}
