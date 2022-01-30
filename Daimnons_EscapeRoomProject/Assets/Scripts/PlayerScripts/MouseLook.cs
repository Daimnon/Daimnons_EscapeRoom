using UnityEngine;

public class MouseLook : MonoBehaviour
{
    #region Serialized Fields
    [SerializeField]
	private GameObject _transitionButtons;

	[SerializeField] [Range(0.1f, 9f)]
	private float _sensitivity; //sensetivty 2 is best
    #endregion

    #region Fields
    //strings in direct code generate garbage, storing and re-using them doesn't garbage
    private const string xAxis = "Mouse X";
	private const string yAxis = "Mouse Y";
    #endregion

    #region Public Fields
    [HideInInspector]
	public Vector2 rotation = Vector2.zero;
    #endregion

    #region Unity Callbacks
    private void Update()
	{
		Cursor.visible = true;
		_transitionButtons.SetActive(true);

		if (Input.GetKey(KeyCode.LeftShift))
			LookAround();
	}
    #endregion

    #region Methods
    public void LookAround()
	{
		Cursor.visible = false;
		_transitionButtons.SetActive(false);

        //calculate sensetivity
        rotation.x += Input.GetAxis(xAxis) * _sensitivity;
		rotation.y += Input.GetAxis(yAxis) * _sensitivity;

        //get directions
        Quaternion xQuat = Quaternion.AngleAxis(rotation.x, Vector3.up);
        Quaternion yQuat = Quaternion.AngleAxis(rotation.y, Vector3.left);

        //Quaternions seem to rotate more consistently than EulerAngles. sensitivity seemed to change slightly at certain degrees using "Euler.transform.localEulerAngles = new Vector3(-rotation.y, rotation.x, 0)"
        transform.localRotation = xQuat * yQuat;

        Debug.Log(new Vector2(transform.localRotation.x, transform.localRotation.y));
    }
    #endregion
}

