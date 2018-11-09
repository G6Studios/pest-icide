#include "SoundSub.h"

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
	List.erase(std::remove(List.begin(), List.end(), obs), List.end());
}

void SoundSubject::notify()
{
}
