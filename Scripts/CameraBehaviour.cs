using UnityEngine;

public class CameraBehaviour : MonoBehaviour{

	public Personnage personnage{
		get{ return _personnage; }
		set{ _personnage = value; }
	}

	// propriétés
	#region
	private Personnage _personnage;

	public Transform pointFocusRepos;
	public Transform pointFocusVise;
	
	public float distanceMax;
	public float distanceMin;
	public float sensibilite = 1f;
	public float vitesseDeplacement = 1f;
	public float angleVerticalMax;
	public float angleVerticalMin;
	public float vitesseRotationHorizontal = 1f;
	public float vitesseRotationVertical = -1f;
	public float vitesseZoom = 1f;
	public float distanceMur = 0.1f; // distance minimal entre la caméra et un mur
	public int[] layers = {8};
	public float distanceViseMax = 3f;
	public float distanceViseMin = 1f;
	public float distanceMaxFocus = 10;
	
	private float distanceRepos = 10f;
	private float distanceVise = 2f;
	private Vector2 rot = Vector2.zero;
	private Transform _transform;
	private float _vitesseDeplacementCarre;
	#endregion
	
	// Use this for initialization
	void Start () {
//		_personnage = GameObject.FindGameObjectWithTag("Player").GetComponent<Cerveau>();
//		_personnage.cam = this;
		_transform = transform;
		_vitesseDeplacementCarre = vitesseDeplacement*vitesseDeplacement;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 dep = Vector2.zero;
		InputBundle input = _personnage.input;

		if (_personnage.state == BehaviourState.NORMAL && pointFocusRepos){
			Vector2 d = input.mouseDelta;
			rot += new Vector2(d.x * vitesseRotationHorizontal, d.y * vitesseRotationVertical);
			if (rot.y > angleVerticalMax)
				rot.y = angleVerticalMax;
			else if (rot.y < angleVerticalMin)
				rot.y = angleVerticalMin;
			rot.x %= 360;
			Vector3 pos = new Vector3();
			pos.x = Mathf.Cos(Mathf.Deg2Rad*rot.x);
			pos.z = Mathf.Sin(Mathf.Deg2Rad*rot.x);
			pos.y = Mathf.Sin(Mathf.Deg2Rad*rot.y);
			pos.Normalize();
			
			distanceRepos += input.scrollWheelDelta * vitesseZoom;
			if (distanceRepos < distanceMin)
				distanceRepos = distanceMin;
			else if (distanceRepos > distanceMax)
				distanceRepos = distanceMax;
			
			pos = ajusterPosition(pointFocusRepos.position, pos, distanceRepos);
			pos += pointFocusRepos.position;
			
			// pos est la position désiré de la caméra. il faut effectuer une translation douce jusqu'à ce point
			dep = (pos-_transform.position);
			//			Debug.DrawLine(_transform.position, _transform.position+dep, Color.yellow);
			//			Debug.Log("pos: " + _transform.position + "; pos2: " + pos + "; dep: " + dep + "; dist²: " + dep.sqrMagnitude + "; distM: " + _vitesseDeplacementCarre + "; distT: " + (_vitesseDeplacementCarre*Time.deltaTime));
			if (dep.sqrMagnitude > _vitesseDeplacementCarre*Time.deltaTime){
				dep = dep.normalized * vitesseDeplacement*Time.deltaTime;
			}
			
			//Debug.Log(pos);
		}
		else if (_personnage.state == BehaviourState.VISEE && pointFocusVise){
			distanceVise += input.scrollWheelDelta * vitesseZoom;
			if (distanceVise > distanceViseMax)
				distanceVise = distanceViseMax;
			else if (distanceVise < distanceViseMin)
				distanceVise = distanceViseMin;
			
			
			
			dep = Vector3.zero;
		}
		
		_transform.position += dep;
		_transform.LookAt(pointFocusRepos);
	}
	
	protected Vector3 ajusterPosition(Vector3 point, Vector3 direction, float distance){
		RaycastHit hit;
		//			Debug.DrawLine(__personnage.Centre, newPos);
		int layerMask = 0;
		foreach (int i in layers)
			layerMask = layerMask | (1 << i);
		if (Physics.Raycast(point, direction, out hit, distance, layerMask)){
			return direction * (hit.distance - distanceMur);
		}
		return direction * distance;
	}
	
	public Vector3? pointFocus{
		get{
			if (_personnage.state == BehaviourState.NORMAL)
				return null;
			RaycastHit hit;
			if (Physics.Raycast(_transform.position, _transform.forward, out hit, distanceMaxFocus))
				return hit.point;
			else
				return null;
		}
	}
	
	public Vector3 devant{
		get{
			Vector3 f = _transform.forward;
			f.y = 0;
			f.Normalize();
			return f;
		}
	}
	
}
/*
 * public float rotXMax = 160f;
	public float rotXMin = 30f;
	public float vitesseRotNormale = 1f;
	public float vitesseRotVisee = 1f;
	public float sensibilite = 1f;

	public float distanceNormaleMin = 5f;
	public float distanceNormaleMax = 5f;
	public float distanceVisee = 2f;
	public float vitesseNormale = 2f;
	public float vitesseVisee = 3f;
*/