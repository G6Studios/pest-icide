#include "Sound Manager.h"
//#include "Logger.h"

SoundManager::SoundManager()
{
	init = false;
}

SoundManager::~SoundManager()
{
	CleanUp();
}

bool SoundManager::Init()
{
	if (!init)
	{
		init = true;
		result = FMOD::System_Create(&system);
		FmodErrorCheck(result);
		if (result != FMOD_OK) {init = false;}

		result = system->getVersion(&version);
		FmodErrorCheck(result);
		if (result != FMOD_OK) { init = false; }

		result = system->init(100, FMOD_INIT_NORMAL, extradriverdata);
		FmodErrorCheck(result);
		if (result != FMOD_OK) { init = false; }
	}
	return init;
}

void SoundManager::CleanUp()
{
	result = system->close();
	FmodErrorCheck(result);
	result = system->release();
	FmodErrorCheck(result);
	init = false;
}

void FmodErrorCheck(FMOD_RESULT result)
{
	if (result != FMOD_OK)
	{
		cout << "Fmod error: " << FMOD_ErrorString(result) << endl;
		//FILE_LOG(logINFO) << "FMOD failure: " << FMOD_ErrorString(result);
		//system("pause"); // for C++ use only
	}
}
