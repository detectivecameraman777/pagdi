#pragma once
#include "Zynth.hh"

HSVTRIPLE
RGBtoHSV(
	_RGBQUAD rgb
);

_RGBQUAD
HSVtoRGB(
	HSVTRIPLE hsv
);