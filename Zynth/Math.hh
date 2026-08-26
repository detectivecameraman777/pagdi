#pragma once
#include "Zynth.hh"

#define PI 3.141592f

extern DWORD _dwSeed;
static FLOAT fastsv[ 4096 ];

extern
VOID
WINAPI
SeedXorshift(
	_In_ DWORD Seed
);

extern
DWORD
Xorshift( VOID );

extern
INT
AntiNegative(
	_In_ INT a,
	_In_ INT b
);

extern
FLOAT
FastSine(
	_In_ FLOAT f
);

extern
FLOAT
FastCosine(
	_In_ FLOAT f
);

extern
VOID
InitializeSine(
	VOID
);