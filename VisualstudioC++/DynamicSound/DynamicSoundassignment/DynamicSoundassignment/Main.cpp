#include "Sound Manager.h"
#include "SoundStorage.h"

int main(int argc, char** argv)
{
	SoundLoader soundName;
	soundName.initializeSound();
	soundName.loadSound(13);
	soundName.playSound();
	system("pause");
	return 0;
}