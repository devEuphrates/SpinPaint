using Euphrates;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;
using Input = UnityEngine.Input;

public class TutorialHandler : MonoBehaviour
{
    private Animator _tutorialAnimator;
    [SerializeField] IntSO _levelIndex;
    [SerializeField] TriggerChannelSO _drawingPhase;
    // Start is called before the first frame update
    void Start()
    {
        _tutorialAnimator = GetComponent<Animator>();

    }
    private void OnEnable()
    {
        _drawingPhase.AddListener(ChangeAnimation);
    }

    private void OnDisable()
    {
        _drawingPhase.RemoveListener(ChangeAnimation);
    }


    // Update is called once per frame
    void ChangeAnimation()
    {
        if (_levelIndex == 0) 
        {
            while (_tutorialAnimator.GetInteger("count") < 4)
            {
                if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
                {

                    _tutorialAnimator.SetInteger("count", _tutorialAnimator.GetInteger("count") + 1);

                }
            }
        }

    }

}
