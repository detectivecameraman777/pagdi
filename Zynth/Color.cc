#include "Zynth.hh"

HSVTRIPLE RGBtoHSV(_RGBQUAD rgb) {
	HSVTRIPLE hsv;

	byte r = rgb.r;
	byte g = rgb.g;
	byte b = rgb.b;

	byte maxim = max(max(r, g), b);

	byte minim = min(min(r, g), b);

	byte del = maxim - minim;

	hsv.v = maxim;

	if (maxim == 0 || del == 0) {
		hsv.h = 0;
		hsv.s = 0;
		return hsv;
	}

	hsv.s = (byte)((255 * del) / maxim);

	int huetemp = 0;
	if (maxim == r) {
		huetemp = ((g - b) * 43) / del;
		if (huetemp < 0) huetemp += 256;
	}
	else if (maxim == g) {
		huetemp = 85 + (((b - r) * 43) / del);
	}
	else {
		huetemp = 171 + (((r - g) * 43) / del);
	}

	hsv.h = (byte)huetemp;
	return hsv;
}
_RGBQUAD HSVtoRGB(HSVTRIPLE hsv) {
	_RGBQUAD rgb;
	rgb.reserved = 0;

	BYTE v = hsv.v;
	BYTE s = hsv.s;

	if (s == 0) {
		rgb.r = v;
		rgb.g = v;
		rgb.b = v;
		return rgb;
	}

	unsigned int reg = (hsv.h * 6) / 256;
	unsigned int rem = (hsv.h * 6) - (reg * 256);

	unsigned int p = (v * (255 - s)) >> 8;
	unsigned int q = (v * (255 - ((s * rem) >> 8))) >> 8;
	unsigned int t = (v * (255 - ((s * (256 - rem)) >> 8))) >> 8;

	switch (reg) {
	case 0:  rgb.r = v; rgb.g = t; rgb.b = p; break;
	case 1:  rgb.r = q; rgb.g = v; rgb.b = p; break;
	case 2:  rgb.r = p; rgb.g = v; rgb.b = t; break;
	case 3:  rgb.r = p; rgb.g = q; rgb.b = v; break;
	case 4:  rgb.r = t; rgb.g = p; rgb.b = v; break;
	default: rgb.r = v; rgb.g = p; rgb.b = q; break;
	}

	return rgb;
}