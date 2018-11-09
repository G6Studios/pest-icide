#pragma once
#include "SoundSub.h"

class LIB_API ObserverSounds
{
	
public:
	const char* soundLoaded;
	SoundSubject *_SoundSub;
	ObserverSounds(SoundSubject *soundsub);
	virtual void Update() = 0;
protected:
	SoundSubject* getSoundSub();


};

class LIB_API  FrogAttack :public ObserverSounds
{
public:

	FrogAttack(SoundSubject *sound) :ObserverSounds(sound)
	{
		_SoundSub = sound;
		_SoundSub->attach(this);
	}
	void Update()
	{
		int pos = getSoundSub()->getPosition();
		if (pos < 0)
		{
			soundLoaded = "media/ frog attack.mp3";
			cout << "Frog attack loaded" << endl;
		}
	}
};