#include "SoundSub.h"
#include "SoundObs.h"
int SoundSubject::getPosition()
{
	return position;
}

void SoundSubject::setPosition(int newPos)
{
	position = newPos;
	notify();
}

void SoundSubject::attach(ObserverSounds * obs)
{
	List.push_back(obs);
}

void SoundSubject::detach(ObserverSounds * obs)
{
	for (int i = 0; i < List.size(); i++)
	{
		if (List[i] == obs)
		{
			List.erase(List.begin() + i);
			break;
		}
	}
}

void SoundSubject::notify()
{
	for (int i = 0; i < List.size(); i++)
	{
		List[i]->Update();
	}
}
