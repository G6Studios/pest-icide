#include "SoundStorage.h"
#include "Logger.h"

void SoundLoader::initializeSound()
{
	Output2FILE::Stream() = _fsopen("logs.txt", "w", SH_DENYNO);

	manage.Init();

	 
	// registering sound files to map
	//Frog Sounds
	soundMap[1] = "media/Attacks/frog attack.mp3";
	soundMap[2] = "media/Idle sounds/ribbit.mp3";
	soundMap[3] = "media/movement/Frog hop.mp3";
	soundMap[4] = "media/Taunts/ Frog Taunt.mp3";
				   
	//Mouse sounds 
	soundMap[11] = "media/Attacks/Mouse_Attack.mp3";
	soundMap[12] = "media/Attacks/Mouse_2nd Attack.mp3";
	soundMap[13] = "media/Idle sounds/Squeak.mp3";
	soundMap[14] = "media/movement/Mouse run.mp3";
	soundMap[15] = "media/Taunts/Mouse taunt.mp3";
				  
	// Spider Sounds
	soundMap[21] = "media/Attacks/Spider thwip.mp3";
	soundMap[22] = "media/Idle sounds/ Spider click.mp3";
	soundMap[23] = "media/movement/Spider Walk.mp3";
	soundMap[24] = "media/Taunts/Spider Taunt.mp3";
				   
	//Snake sounds 
	soundMap[31] = "media/Attacks/ Snake bite.mp3";
	soundMap[32] = "media/movement/Snake movement.mp3";
	soundMap[33] = "media/Taunts/Snake Taunt.mp3";



}

void SoundLoader::loadSound(int key)
{
	//loading the sound to play
	result = manage.system->createSound(soundMap[key], FMOD_3D, 0, &sound);
	FmodErrorCheck(result);
	result = sound->set3DMinMaxDistance(0.5f, 300.0f);
	FmodErrorCheck(result);
	result = sound->setMode(FMOD_3D);
	FmodErrorCheck(result);
}

void SoundLoader::playSound()
{
	//play sound
	result = manage.system->playSound(sound, 0, true, &channel);
	FmodErrorCheck(result);
	result = channel->set3DAttributes(&pos, &vel);
	FmodErrorCheck(result);
	result = channel->setPaused(false);
	FmodErrorCheck(result);
	FILE_LOG(logINFO) << "Playsound Called (" << sound << ") @ " << 
		pos.x << "," << pos.y << "," << pos.z << " vel: " <<
		vel.x << "," << vel.y << "," << vel.z;;
	//system("pause"); //only use in C++ LEAVE COMENTED OUT FOR UNITY!!!

	//clean up
	FmodErrorCheck(result);
}

void SoundLoader::destroySound()
{
	result = sound->release();
}