#include "Sound Manager.h"
#include "SoundStorage.h"

int main(int argc, char** argv)
{
	SoundLoader soundName;
	soundName.initializeSound();

	system("pause");
	return 0;
}