using Timba.Combat;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Timba.CardRoguelike {
    public class CharacterUI : MonoBehaviour {
        public Combatant combatant;

        public TextMeshProUGUI hpText;
        public Slider hpSlider;
        public TextMeshProUGUI armorText;
        public Image armorImage;
        
        private void Update() {
            hpText.text = combatant.hp.ToString();
            hpSlider.maxValue = combatant.stats.hp.maxValue;
            hpSlider.value = combatant.hp;
            armorText.text = combatant.stats.armor.Value.ToString();
            armorImage.gameObject.SetActive(combatant.stats.armor > 0);
        }
    }
}