// https://sirohood.exp.jp/20190113-1725/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetVoice : MonoBehaviour {
    AudioSource audios;
	
	void Start () {
		StartCoroutine(Connect());
	}
	
    private IEnumerator Connect(){
        
        
        string url = "https://amps.gosho.red/amps-lab/assets/music/univ1342.wav";

        WWW www = new WWW(url);
        yield return www;
        
        audios=GetComponent<AudioSource>();
        audios.clip = www.GetAudioClip(false, true);//二つ目の引数がturueで読込中の再生可能
        audios.Play();

    }
}