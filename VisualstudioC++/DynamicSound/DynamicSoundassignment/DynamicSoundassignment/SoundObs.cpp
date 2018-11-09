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

