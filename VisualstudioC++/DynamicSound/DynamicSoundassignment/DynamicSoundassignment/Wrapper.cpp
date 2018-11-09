#include "Wrapper.h"

SoundManager soundmanager;
SoundSubject soundsubject;

bool Init()
{
	soundmanager.Init();
}

void CleanUp()
{
	soundmanager.CleanUp();
}

