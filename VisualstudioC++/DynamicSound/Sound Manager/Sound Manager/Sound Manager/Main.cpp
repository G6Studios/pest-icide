// Code Formatting Inspired by Brent Cowan
//Code written by Moishe Grosh Nov, 6th, 2018

#include "SoundObs.h"
#include "Sound Manager.h"
#include "SoundSub.h"
float Random(float a, float b)
{
	return (float(rand()) / float(RAND_MAX) * abs(b - a) + min(a, b));
}



int main(int argc, char** argv)
{
	SoundSubject *_sound = new SoundSubject();
	 

	SoundManager manage;
	manage.Init();
	
	//sound file
	FMOD::Sound *sound;
	//sound Channel
	FMOD::Channel *channel = 0;

	FMOD_RESULT result;

	//load sound
	char pressedbutton;
	bool Breakloop = false;
	while (!Breakloop)
	{
		cin >> pressedbutton;
		switch(pressedbutton)
			case 113:
		{
			
		}
	}
	
	result = manage.system->createSound(soundLoaded, FMOD_3D, 0, &sound);
	FmodErrorCheck(result);
	result = sound->set3DMinMaxDistance(0.5f, 300.0f);
	FmodErrorCheck(result);
	result = sound->setMode(FMOD_LOOP_NORMAL);
	FmodErrorCheck(result);
	
	//place the sound and give it a velocity
	FMOD_VECTOR frogpos;
	FMOD_VECTOR frogvel;

	frogpos.x = 0.0f;
	frogpos.y = 0.0f;
	frogpos.z = 0.0f;

	frogvel.x = Random(14.0f, 83.0f);
	frogvel.y = 0.0f;
	frogvel.z = 0.0f;

	
	//play sound
	result = manage.system->playSound(sound, 0, true, &channel);
	FmodErrorCheck(result);
	result = channel->set3DAttributes(&frogpos, &frogvel);
	FmodErrorCheck(result);
	result = channel->setPaused(false);
	FmodErrorCheck(result);

	//clean up
	result = sound->release();
	FmodErrorCheck(result);
	manage.CleanUp();
	system("pause");
	return 0;
}