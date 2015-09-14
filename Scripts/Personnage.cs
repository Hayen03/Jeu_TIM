using UnityEngine;

[RequireComponent (typeof(Moteur))]
[RequireComponent (typeof(Sante))]
[RequireComponent (typeof(Magie))]
[RequireComponent (typeof(Sac))]
[RequireComponent (typeof(PochettePotion))]
public class Personnage : MonoBehaviour {
	// accesseurs
	public CameraBehaviour cam{
		get{ return _cam; }
	};
	public Sante vie{
		get{ return _vie; }
	};
	public Magie mana{
		get{ return _mana; }
	};
	public Moteur moteur{
		get{ return _moteur; }
	};
	public PochettePotion potions{
		get{ return _potions; }
	};
	public Sac _sac{
		get{ return _sac; }
	};
	public bool isInit{
		get{ return _isInit; }
	};
	
	// cache
	private CameraBehaviour _cam;
	private Sante _vie;
	private Magie _mana;
	private Moteur _moteur;
	private PochettePotion _potions;
	private Sac _sac;
	
	// propriété
	private bool _isInit = false;
	
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
	}
	
	public void Awake(){
		if (!_isInit)
			init();
	}
	
}