using UnityEngine;

public class ActorAI : MonoBehaviour
{
    private Actor _actor;
    [SerializeField] private Vector3 _destination;

    void Start()
    {
        _actor = GetComponent<Actor>();
        if (_actor.Commanding != null)
            _actor.Commanding.OnCommandComplete += NextCommand;
            _actor.FlyToCommand(_destination);
    }

    void OnDestroy()
    {
        if (_actor.Commanding != null)
            _actor.Commanding.OnCommandComplete -= NextCommand;
    }

    private void NextCommand()
    {
        _destination = new Vector3(
            UnityEngine.Random.Range(-10, 10),
            UnityEngine.Random.Range(-10, 10),
            UnityEngine.Random.Range(-10, 10)
        );
        _actor.FlyToCommand(_destination);
    }
}
