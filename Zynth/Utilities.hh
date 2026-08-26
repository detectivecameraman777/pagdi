#pragma once
#include "Zynth.hh"
#define BLEND( x, y, z ) x * ( 1 - z ) + y * z
#define clamp( minz, v, maxz ) v < minz ? minz : ( v > maxz ? maxz : v )

PWSTR
GenUnicodeString(
    _In_ int iLength
);

CONST
PPOINT
RandPoints(
    _In_ int nPoints,
    _In_ int w,
    _In_ int h
);