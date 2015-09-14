using UnityEngine;

[RequireComponent (typeof(Personnage))]
public class ComposantPersonnage : MonoBehaviour{
	protected Personnage _perso;
	
	public bool setPersonnage(Personnage perso){
		if (_perso != null)
			return false;
		_perso = perso;
		return true;
	}
	
	public void Awake(){
		Personnage p = GetComponent<Personnage>();
		if (!p.isInit)
			p.init();
	}
	
}