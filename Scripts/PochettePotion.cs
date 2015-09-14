using UnityEngine

public class PochettePotion : ComposantPersonnage{
	public int nbPotionMax = 8;
	private Potion[] _potions;
	
	public void Awake(){
		super.Awake();
		_potions = new Potion[nbPotionMax];
	}
	
	public bool ajouterPotion(Potion p){
		for (int i = 0; i < nbPotionMax; i++)
			if (_potions[i] == null){
				_potions[i] = p;
				return true;
			}
		return false;
	}
	public void utiliserPotion(int i, Personnage p){
		if (i >= 0 && i < nbPotionMax && _potions[i] != null){
			// appliquer l'effet
			_potions[i] = null;
		}
		// rien ne se passe autrement
	}
}