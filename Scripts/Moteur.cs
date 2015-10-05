using UnityEngine;

public class Moteur : ComposantPersonnage{

	public float vitesseDeplacementNormal = 1f;
	public float vitesseDeplacementVisee = 1f;

	private Transform _t;

	override public void Awake(){
		base.Awake();
		_t = transform;
	}

	public void FixedUpdate(){
		InputBundle input = _perso.input;
		if (input != null){
			Vector3 devant = _perso.cam.devant;
			Vector3 droite = new Vector3(devant.z, 0, -devant.x);
			_t.Translate((input.direction.x * droite + input.direction.y * devant) *
		             (_perso.state == BehaviourState.NORMAL ? vitesseDeplacementNormal : vitesseDeplacementVisee) * 
		             Time.deltaTime);
		}
	}
}