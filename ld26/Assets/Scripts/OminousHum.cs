using UnityEngine;
using System.Collections;

public class OminousHum : MonoBehaviour {
	public double frequencyOne = 440;
	public double frequencyTwo = 440;
	public double gainOne = 0.05;
	public double gainTwo = 1;
	public double offset = 0.5;
	private double phaseOne = 0;
	private double phaseTwo = 0;
	private double sampleRate = 48000;
	
	void Update() {
		sampleRate = AudioSettings.outputSampleRate;
	}
	
	public void OnAudioFilterRead(float[] data, int channels) {
		int i;
		double stepOne = 2 * Mathf.PI * frequencyOne / sampleRate;
		double stepTwo = 2 * Mathf.PI * frequencyTwo / sampleRate;
		for (i = 0; i < data.Length; i += channels) {
			data[i] = (float)(gainOne * Mathf.Sin((float)phaseOne) * (offset + gainTwo*Mathf.Sin((float)phaseTwo)));
			int j;
			for (j = 1; j < channels; j++) {
				data[i+j] = data[i];
			}
			phaseOne = (phaseOne + stepOne) % (2*Mathf.PI);
			phaseTwo = (phaseTwo + stepTwo) % (2*Mathf.PI);
		}
	}
}
