using UnityEngine;

public class CubeView : SpawnerView<Cube>
{
    [SerializeField] private Spawner<Cube> _spawner;

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
