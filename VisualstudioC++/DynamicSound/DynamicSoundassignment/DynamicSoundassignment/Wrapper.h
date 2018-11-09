#pragma once
#include "LibSettings.h"
#include "Sound Manager.h"
#include "SoundObs.h"
#include "SoundSub.h"



#ifdef __cplusplus
extern "C"
{
#endif

	LIB_API bool Init();
	LIB_API void CleanUp();
	LIB_API int getPosition();
	LIB_API void setPosition(int newPos);
	LIB_API void attach();
	LIB_API void detach();
	LIB_API void notify();
}
#ifdef  _cplusplus


#endif
