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
		_t.Translate(new Vector3(input.direction.x, 0, input.direction.y) * 
		             (_perso.state == BehaviourState.NORMAL ? vitesseDeplacementNormal : vitesseDeplacementVisee) * 
		             Time.deltaTime);
		}
	}
}