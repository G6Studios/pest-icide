#pragma once
// Code Formatting inspired by Brent Cowan
//Code written by Moishe Grosh Nov, 6th, 2018
#pragma comment (lib, "lib/fmod_vc.lib")
#include <Windows.h>
#include <math.h>
#include <iostream>
#include "inc/fmod.hpp"
#include "inc/fmod_errors.h"
using namespace std;

void FmodErrorCheck(FMOD_RESULT result);

class SoundManager
{
public:
	SoundManager();
	~SoundManager();
	bool Init();
	void CleanUp();

	FMOD::System *system;
	unsigned int version;
	void *extradriverdata = 0;
private:
	bool init;
	FMOD_RESULT result;
};