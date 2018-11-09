#include "Wrapper.h"
#include <vector>
SoundManager soundmanager;
SoundSubject soundsubject;
static std::vector<> vector;

bool Init()
{
	soundmanager.Init();
}

void CleanUp()
{
	soundmanager.CleanUp();
}

int getPosition()
{
	soundsubject.getPosition();
}
void setPosition(int newPos)
{
	soundsubject.setPosition(newPos);
}

void attach()
{
	soundsubject.attach();
}

void detach()
{
	soundsubject.detach();
}

void notify()
{
	soundsubject.notify();
}



