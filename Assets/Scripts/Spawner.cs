using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Pool;

public abstract class Spawner<T> : MonoBehaviour where T : MonoBehaviour, IColorable
{
    [SerializeField] private T _object;

    private ObjectPool<T> _pool;

    private int _countObjectCreate;
    private int _countObjectActive;

    public event UnityAction<int, string> OnCreated;
    public event UnityAction<int, string> OnActiveted;

    private void Awake()
    {
        _pool = new ObjectPool<T>(
        createFunc: Create,
        actionOnGet: ReceiveObject,
        actionOnRelease: (gameObject) => gameObject.gameObject.SetActive(false));
    }

    public virtual void ReceiveObject(T obj)
    {
        obj.gameObject.SetActive(true);
        obj.SetStartColor();
    }

    public virtual T Create()
    {
        T obj = Instantiate(_object);
        InitializeObject(obj, Vector3.zero);
        _countObjectCreate++;
        OnCreated?.Invoke(_countObjectCreate, GetObjectName());
        return obj;
    }

    public virtual void ReturnItem(T obj)
    {
        _pool.Release(obj);
        _countObjectActive--;
        OnActiveted?.Invoke(_countObjectActive, GetObjectName());
    }

    public T GetObject()
    {
        _countObjectActive++;
        OnActiveted?.Invoke(_countObjectActive, GetObjectName());
        return _pool.Get();
    }

    protected abstract string GetObjectName();
    protected abstract void InitializeObject(T obj, Vector3 position);
}