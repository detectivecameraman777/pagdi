#pragma once
#include "Zynth.hh"

typedef unsigned int uint;

typedef union tag_RGBQUAD
{
	COLORREF rgb;
	struct
	{
		byte r;
		byte g;
		byte b;
		byte reserved;
	};
} _RGBQUAD, *PRGBQUAD;

typedef struct tagHSVTRIPLE
{
	byte h;
	byte s;
	byte v;
} HSVTRIPLE, *PHSVTRIPLE;

typedef void( __stdcall GDI_SHADER )(
	_In_		int				t,
	_In_ 		int				w,
	_In_		int				h,
	_In_		PRGBQUAD		prgbSrc,
	_Inout_		PRGBQUAD		prgbDest
), *PGDI_SHADER;

typedef void( __stdcall SHORTBEAT )(
	_In_		int			nSamplesPerSec,
	_In_		int			nSampleCount,
	_Inout_		short*		psSamples
), *PSHORTBEAT;

typedef struct tagGDISHADER_PARAMS
{
	float			fDuration;
	PGDI_SHADER		pGdiShader;
} GDISHADER_PARAMS, *PGDISHADER_PARAMS;

typedef struct tagSHORTBEAT_PARAMS
{
	int				nSamplesPerSec;
	int				nSampleCount;
	PSHORTBEAT		pShortbeat;
} SHORTBEAT_PARAMS, *PSHORTBEAT_PARAMS;
