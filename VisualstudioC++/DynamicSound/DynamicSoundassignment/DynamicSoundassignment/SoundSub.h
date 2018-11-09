#pragma once
#include "Sound Manager.h"
#include <string>
#include <vector>
class LIB_API ObserverSounds;
class LIB_API SoundSubject
{
	int position;
	std::vector <ObserverSounds*> List;
public:
	int getPosition();
	void setPosition(int newPos);
	void attach(ObserverSounds *obs);
	void detach(ObserverSounds *obs);
	void notify();

};
