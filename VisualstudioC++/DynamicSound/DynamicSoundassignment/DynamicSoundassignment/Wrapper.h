#pragma once
#include "LibSettings.h"
#include "Sound Manager.h"
#include "SoundObs.h"
#include "SoundSub.h"


#ifdef __cplusplus
extern "C"
{
#endif

	LIB_API void FmodErrorCheck(FMOD_RESULT resut);
	LIB_API bool Init();
	LIB_API void CleanUp();
	LIB_API int getPosition();
	LIB_API void setPosition(int newPos);
	LIB_API ObserverSounds(SoundSubject *soundsub);
	LIB_API virtual void Update();
	LIB_API SoundSubject* getSoundSub();
	LIB_API FrogAttack(SoundSubject *sound);
}
#ifdef  _cplusplus


#endif
