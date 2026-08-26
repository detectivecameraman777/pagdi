#pragma once
#include <Windows.h>

#include "defs.hh"
#include "Utilities.hh"
#include "Math.hh"
#include "Payloads.hh"
#include "ExtraPayloads.hh"
#include "Color.hh"

#define _USE_MATH_DEFINES 1
#include <stdio.h>
#include <math.h>
#include <cstdint>
#include <time.h>
#pragma comment(lib, "winmm.lib")

#pragma region Global Variables
extern POINT ptScreen;
extern SIZE szScreen;
#pragma endregion Global Variables
