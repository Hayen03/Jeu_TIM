using UnityEngine;

public enum BehaviourState {NORMAL, VISEE};

[RequireComponent (typeof(Moteur))]
[RequireComponent (typeof(Sante))]
[RequireComponent (typeof(Magie))]
[RequireComponent (typeof(Sac))]
[RequireComponent (typeof(PochettePotion))]
public class Personnage : MonoBehaviour {
	// accesseurs
	public Sante vie{
		get{ return _vie; }
	}
	public Magie mana{
		get{ return _mana; }
	}
	public Moteur moteur{
		get{ return _moteur; }
	}
	public PochettePotion potions{
		get{ return _potions; }
	}
	public Sac sac{
		get{ return _sac; }
	}
	public bool isInit{
		get{ return _isInit; }
	}
	public InputBundle input{
		get{ return _inputs; }
	}
	public BehaviourState state{
		get{ return _state; }
	}
	
	// cache
	public CameraBehaviour cam;
	private Sante _vie;
	private Magie _mana;
	private Moteur _moteur;
	private PochettePotion _potions;
	private Sac _sac;
	
	// propriété
	private bool _isInit = false;
	private InputBundle _inputs = null;
	private BehaviourState _state = BehaviourState.NORMAL;
	
	public void init(){
		_isInit = true;
	
		_vie = GetComponent<Sante>();
		_vie.setPersonnage(this);
		_mana = GetComponent<Magie>();
		_mana.setPersonnage(this);
		_moteur = GetComponent<Moteur>();
		_moteur.setPersonnage(this);
		_potions = GetComponent<PochettePotion>();
		_potions.setPersonnage(this);
		_sac = GetComponent<Sac>();
		_sac.setPersonnage(this);
		
//		_cam = Camera.current.GetComponent<CameraBehaviour>();
		cam.personnage = this;
	}
	
	public void Awake(){
		if (!_isInit)
			init();
	}

	public void Update(){
		_inputs = new InputBundle();
	}
	
}