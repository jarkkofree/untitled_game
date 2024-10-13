using UnityEngine;

public class ActorUI : MonoBehaviour
{
    private Actor _actor;
    [SerializeField] private Vector3 _destination;

    void Start()
    {
        _actor = GetComponent<Actor>();
        if (_actor.Commanding != null)
            _actor.Commanding.OnCommandComplete += NotifyOnCommandComplete;
    }

    void OnDestroy()
    {
        if (_actor.Commanding != null)
            _actor.Commanding.OnCommandComplete -= NotifyOnCommandComplete;
    }

    public void ExecuteFlyToCommand()
    {
        _actor.FlyToCommand(_destination);
    }

    private void NotifyOnCommandComplete()
    {
        Debug.Log("Command completed");
    }
}
