#pragma once
#include "Zynth.hh"

#define SineW(t, freq, div) FastSine(2.f * PI * (float(freq) * float(t) / float(div)))
#define SquareW(t, freq, div) (((byte)(2.f * float(freq) * (t / float(div))) % 2) == 0 ? 1.f : -1.f)
#define TriangleW(t, freq, div) (4.f * fabsf((float(t) / (float(div) / float(freq))) - floorf((float(t) / (float(div) / float(freq)))) - .5f) - 1.f)
#define SawtoothW(t, freq, div) (fmodf((float(t) / float(div)), (1.f / float(freq))) * float(freq) * 2.f - 1.f)

VOID
WINAPI
ExecuteLayeredShader(
	_In_ GDI_SHADER pGdiShader,
	_In_ FLOAT      fDuration,
	_In_ INT        iDelay
);

VOID
WINAPI
ExecuteShader(
	_In_ GDI_SHADER pGdiPayload,
	_In_ FLOAT       fDuration,
	_In_ INT         iDelay
);


VOID
WINAPI
ExecuteShortbeatTemp(
	_In_ INT nSamplerate,
	_In_ INT nSamples,
	_In_ SHORTBEAT pAudioSequence
);

VOID
WINAPI
ExecuteShortbeat(
	SHORTBEAT_PARAMS params
);

extern bool bTrigger;

VOID
WINAPI
ShortbeatThread(
	VOID
);

SHORTBEAT AudioSequence1;
SHORTBEAT AudioSequence2;
SHORTBEAT AudioSequence3;
SHORTBEAT AudioSequence4;
SHORTBEAT AudioSequence5;
SHORTBEAT AudioSequence6;
SHORTBEAT AudioSequence7;
SHORTBEAT AudioSequence8;
SHORTBEAT AudioSequence9;
SHORTBEAT AudioSequence10;
SHORTBEAT AudioSequence11;
SHORTBEAT AudioSequence12;
SHORTBEAT AudioSequence13;
SHORTBEAT AudioSequence14;
SHORTBEAT AudioSequence15;
SHORTBEAT AudioSequence16;

VOID
WINAPI
initializefasth3wf(
	VOID
);

GDI_SHADER LayeredShader1;
GDI_SHADER LayeredShader2;
GDI_SHADER LayeredShader3;
GDI_SHADER LayeredShader4;
GDI_SHADER LayeredShader5;
GDI_SHADER LayeredShader6;
GDI_SHADER LayeredShader7;
GDI_SHADER LayeredShader8;
GDI_SHADER LayeredShader9;
GDI_SHADER LayeredShader10;
GDI_SHADER LayeredShader11;
GDI_SHADER LayeredShader12;
GDI_SHADER LayeredShader13;


VOID
WINAPI
LayeredShaderThread(
	VOID
);

GDI_SHADER LayerlessShader1;
GDI_SHADER LayerlessShader2;
GDI_SHADER LayerlessShader3;
GDI_SHADER LayerlessShader4;
GDI_SHADER LayerlessShader5;
GDI_SHADER LayerlessShader6;
GDI_SHADER LayerlessShader7;
GDI_SHADER LayerlessShader8;

VOID
WINAPI
Redrawer(
	VOID
);