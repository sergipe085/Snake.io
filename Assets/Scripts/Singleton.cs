using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour {
    public static T Instance = null;

    protected virtual void Awake() {
        if (Instance) {
            Destroy(Instance.gameObject);
        }

        Instance = this as T;
    }
}