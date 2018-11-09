#include "SoundObs.h"

ObserverSounds::ObserverSounds(SoundSubject * soundsub)
{
	_SoundSub = soundsub;
	_SoundSub->attach(this);
}

SoundSubject * ObserverSounds::getSoundSub()
{
	return _SoundSub;
}

void SoundSubject::notify()
{
	for (int i = 0; i < List.size(); i++)
	{
		List[i]->Update();
	}
}