using UnityEngine;

[RequireComponent(typeof(IRayCaster), typeof(IColorer))]
public class Draw : MonoBehaviour
{
    [SerializeField] InputReaderSO _inputs;
    [SerializeField] CamHolderSO _camHolder;
    Camera _mainCamera;

    IRayCaster _rayCaster;
    IColorer _colorer;

    Plate _plate;

    bool _touching = false;
    Vector2 _touchPos = Vector2.zero;

    private void Awake()
    {
        _rayCaster = GetComponent<IRayCaster>();
    }

    private void OnEnable()
    {
        _camHolder.OnCameraSet += OnMainCameraSet;

        _inputs.OnTouchDown += OnTouchDown;
        _inputs.OnTouchMove += OnTouchMove;
        _inputs.OnTouchUp += OnTouchUp;
    }

    private void OnDisable()
    {
        _camHolder.OnCameraSet -= OnMainCameraSet;

        _inputs.OnTouchDown -= OnTouchDown;
        _inputs.OnTouchMove -= OnTouchMove;
        _inputs.OnTouchUp -= OnTouchUp;
    }

    private void Start()
    {
        _plate = GameObject.FindObjectOfType<Plate>();
    }

    void OnMainCameraSet() => _mainCamera = _camHolder.Cam;

    void OnTouchDown(Vector2 touchPos)
    {
        _touching = true;
        _touchPos = touchPos;
    }

    void OnTouchMove(Vector2 touchPos) => _touchPos = touchPos;

    void OnTouchUp(Vector2 _) => _touching = false;

    void PaintOn()
    {
        if (_mainCamera == null)
            return;

        Ray ray = _mainCamera.ScreenPointToRay(_touchPos);

        if (!_rayCaster.TryCastRay(ray.direction, out var hit))
            return;

        _plate.Paint(hit.textureCoord);
    }

    float _timePassed = 0f;
    float _timeTreshold = .01f;
    private void Update()
    {
        _timePassed += Time.deltaTime;

        if (!_touching || _timePassed < _timeTreshold)
            return;

        _timePassed = 0f;
        PaintOn();
    }
}