#include "Wrapper.h"
#include <vector>
SoundManager soundmanager;
SoundLoader soundloader;


bool Init()
{
	soundmanager.Init();
	return true; 
}

void CleanUp()
{
	soundmanager.CleanUp();
}

void initializeSound()
{
	soundloader.initializeSound();
}

void loadSound(int key)
{
	soundloader.loadSound(key);
}

void playSound()
{
	soundloader.playSound();
}

void destroySound()
{
	soundloader.destroySound();
}


