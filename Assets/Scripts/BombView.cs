using UnityEngine;

public class BombView : SpawnerView<Bomb>
{
    [SerializeField] private Spawner<Bomb> _spawner;

    private void OnEnable()
    {
        _spawner.OnCreated += OnCreatedValue;
        _spawner.OnActiveted += OnActivetedValue;
    }

    private void OnDisable()
    {
        _spawner.OnCreated -= OnCreatedValue;
        _spawner.OnActiveted -= OnActivetedValue;
    }
}
