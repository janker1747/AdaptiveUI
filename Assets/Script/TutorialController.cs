using UnityEngine;
using UnityEngine.Playables;

public class TutorialController : MonoBehaviour
{
    [SerializeField] private PlayableDirector _director;
    [SerializeField] private GameObject _tutorialUI;

    private bool _waitingForInput;

    private void Start()
    {
        _director.Play();
    }

    public void PauseTimeline()
    {
        _director.playableGraph.GetRootPlayable(0).SetSpeed(0);
        _waitingForInput = true;
    }

    public void OnPlayerPressedButton()
    {
        if (!_waitingForInput)
            return;

        _waitingForInput = false;

        var root = _director.playableGraph.GetRootPlayable(0);
        root.SetSpeed(1);

        _director.Evaluate();
        _tutorialUI.SetActive(false);
    }
}