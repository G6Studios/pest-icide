#pragma once
#include <unordered_map>
#include <iostream>
#include "Sound Manager.h"
using namespace std;
class LIB_API SoundLoader
{
public:
	SoundManager manage;
	FMOD_RESULT result;

	//sound file
	FMOD::Sound *sound;
	//place the sound and give it a velocity
	FMOD_VECTOR pos;
	FMOD_VECTOR vel;
	//sound Channel
	FMOD::Channel *channel = 0;

	unordered_map<int, const char*> soundMap;// creates the map 
	void initializeSound();
	void loadSound(int key);
	void playSound();

};