using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerEvent : MonoBehaviour {

    //public ParticleSystem effect;
    public List<ParticleSystem> particleEffects;

    private void Start() {
        EffectDisable();
    }

    void EffectPlay() {
        if (particleEffects.Count > 0) {
            for (int i = 0; i < particleEffects.Count; i++) {
                // effects[i].Play();
                if (!particleEffects[i].transform.gameObject.activeSelf) {
                    particleEffects[i].transform.gameObject.SetActive(true);
                }
            }
        }
    }

    void EffectDisable() {
        if (particleEffects.Count > 0) {
            for (int i = 0; i < particleEffects.Count; i++) {
                if (particleEffects[i].transform.gameObject.activeSelf) {
                    particleEffects[i].transform.gameObject.SetActive(false);
                }
            }
        }
    }
}
