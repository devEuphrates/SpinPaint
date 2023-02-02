using Euphrates;
using UnityEngine;

[RequireComponent(typeof(IRayCaster))]
public class TapDraw : MonoBehaviour
{
    Plate _plate;
    IRayCaster _rayCaster;

    [Header("Events")]
    [SerializeField] TriggerChannelSO _tapStart;
    [SerializeField] TriggerChannelSO _tapEnd;

    [Space]
    [SerializeField] DrawDataSO _drawingData;

    bool _tapStarted = false;

    private void Awake()
    {
        _rayCaster = GetComponent<IRayCaster>();
    }

    private void OnEnable()
    {
        _tapStart.AddListener(OnTapStarted);
        _tapEnd.AddListener(OnTapEnded);
    }

    private void OnDisable()
    {
        _tapStart.RemoveListener(OnTapStarted);
        _tapEnd.RemoveListener(OnTapEnded);
    }

    private void Start()
    {
         _plate = GameObject.FindObjectOfType<Plate>();
    }

    void OnTapStarted() => _tapStarted = true;

    void OnTapEnded() => _tapStarted = false;

    void PaintOn()
    {
        if (!_rayCaster.TryCastRay(Vector3.down, out RaycastHit hit))
            return;

        _plate.Paint(hit.textureCoord);
    }

    float _timePassed = 0f;
    float _timeTreshold = .01f;
    private void Update()
    {
        _timePassed += Time.deltaTime;

        if (!_tapStarted || _timePassed < _timeTreshold)
            return;

        _timePassed = 0f;
        PaintOn();
    }
}

