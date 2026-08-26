#include "Zynth.hh"

float iPayloadTime = 10;

VOID
WINAPI
ExecuteLayeredShader(
	_In_ GDI_SHADER pGdiShader,
	_In_ FLOAT      fDuration,
	_In_ INT        iDelay
)
{
	clock_t startTime = clock();

	int w = GetSystemMetrics(SM_CXVIRTUALSCREEN);
	int h = GetSystemMetrics(SM_CYVIRTUALSCREEN);

	BITMAPINFO bmi = { 0 };
	bmi.bmiHeader.biSize = sizeof(bmi);
	bmi.bmiHeader.biWidth = w;
	bmi.bmiHeader.biHeight = -h;
	bmi.bmiHeader.biPlanes = 1;
	bmi.bmiHeader.biBitCount = 32;

	HINSTANCE hInstance = GetModuleHandleW(NULL);

	POINT ptSrc = { 0, 0 };
	POINT ptDst = { 0, 0 };
	SIZE szSize = { w, h };

	HWND hWnd = CreateWindowExW(WS_EX_LAYERED | WS_EX_TRANSPARENT | WS_EX_TOPMOST | WS_EX_TOOLWINDOW, L"static", L"", WS_POPUP, 0, 0, w, h, HWND_DESKTOP, NULL, hInstance, NULL);
	ShowWindow(hWnd, SW_SHOW);

	HDC hdcWnd = GetDC(hWnd);
	int iSize = w * h * sizeof(_RGBQUAD);

	PRGBQUAD dst = NULL;

	HDC hdcMemory = CreateCompatibleDC(hdcWnd);
	HBITMAP hbm = CreateDIBSection(hdcWnd, &bmi, DIB_RGB_COLORS, (void**)&dst, NULL, 0);
	SelectObject(hdcMemory, hbm);

	for (INT t = 0; ((FLOAT)(clock() - startTime) / CLOCKS_PER_SEC) <= fDuration; t++)
	{
		BitBlt(hdcMemory, 0, 0, w, h, hdcWnd, 0, 0, SRCCOPY);

		//if (src != NULL)
		//{
		//	GetBitmapBits(hbm, iSize, src);
		//}

		pGdiShader(t, w, h, dst, dst);

		//if (dst != NULL)
		//{
		//	SetBitmapBits(hbm, iSize, dst);
		//}

		BitBlt(hdcWnd, 0, 0, w, h, hdcMemory, 0, 0, SRCCOPY);

		SetWindowPos(hWnd, HWND_TOPMOST, 0, 0, w, h, SWP_NOMOVE | SWP_NOSIZE);
		UpdateLayeredWindow(hWnd, hdcWnd, &ptDst, &szSize, hdcMemory, &ptSrc, RGB(0, 0, 0), NULL, ULW_COLORKEY);

		if (iDelay)
		{
			Sleep(iDelay);
		}
	}

	DeleteObject(hbm);
	DeleteDC(hdcMemory);

	ReleaseDC(hWnd, hdcWnd);

	DestroyWindow(hWnd);
}

VOID
WINAPI
LayeredShader1(
	_In_		int				t,
	_In_ 		int				w,
	_In_		int				h,
	_In_		PRGBQUAD		prgbSrc,
	_Inout_		PRGBQUAD		prgbDest
)
{
	int k = Xorshift() & 1 | Xorshift() & 0x100 | Xorshift() & 0x10000;

	for (int y = 0; y < h; y++)
		for (int x = 0; x < w; x++)
		{
			int i = y * w + x;
			int j = AntiNegative(int(x + t * 3.75f) ^ int(y + t * 4.25f), w) + AntiNegative((int(x + t * 4.25f) ^ int(y + t * 3.75f)) * w, w * h);

			prgbDest[i].r ^= prgbSrc[j].r / 2 + prgbDest[i].r / 2;
			prgbDest[i].g ^= prgbSrc[j].g / 2 + prgbDest[i].g / 2;
			prgbDest[i].b ^= prgbSrc[j].b / 2 + prgbDest[i].b / 2;

			prgbDest[j].rgb += ((prgbDest[j].rgb ^ ((x ^ y) & 255) * k) & 0xFFFFFF) / 2 + prgbDest[j].rgb / 2;
			prgbDest[i].rgb += (i ^ j);
		}
}

VOID
WINAPI
LayeredShader2(
	_In_		int				t,
	_In_ 		int				w,
	_In_		int				h,
	_In_		PRGBQUAD		prgbSrc,
	_Inout_		PRGBQUAD		prgbDest
)
{
	int i, j, k;
	uint u, v;
	k = Xorshift() % 200 - 100;
	for (int x = 0; x < w; ++x) {
		for (int y = 0; y < h; ++y) {
			i = x + y * w;
			u = x + k;
			v = y -
				int(FastCosine(t / 16.f + (x / 4096.f - y / 4096.f) * 65 * t) * t / 16.f -
					FastSine(t / 16.f + (x / 4096.f - y / 4096.f) * 63 * t) * t / 16.f);
			u %= w;
			v %= h;
			j = (u + v * w);
			_RGBQUAD prgbTemp = prgbSrc[i];
			prgbTemp.r = prgbSrc[i].g;
			prgbTemp.g = prgbSrc[i].b;
			prgbTemp.b = prgbSrc[i].r;
			prgbSrc[j].rgb = prgbTemp.rgb ^ k * (Xorshift() & 0x10101);
			prgbDest[i] = prgbSrc[i];
			prgbDest[AntiNegative(i * t, w * h)].rgb ^= prgbSrc[j].rgb;
		}
	}
}

VOID
WINAPI
LayeredShader3(
	_In_		int				t,
	_In_ 		int				w,
	_In_		int				h,
	_In_		PRGBQUAD		prgbSrc,
	_Inout_		PRGBQUAD		prgbDest
)
{
	int i, j, k, l;
	uint u, v;
	k = Xorshift() + t & 1;
	l = Xorshift() & 0x10101;
	int ie = Xorshift() & 255;
	int thelist[4096];
	for (int ind = 0; ind < 4096; ++ind) {
		thelist[ind] = (int)Xorshift() & 255;
	}
	for (int x = 0; x < w; ++x) {
		if (k) {
			ie = Xorshift() & 255;
		}
		for (int y = 0; y < h; ++y) {
			if (!k) {
				ie = thelist[y];
			}
			i = (x + y * w);
			u = x;
			v = y;
			if (k) {
				u += FastSine(y / 100.f + t * h) * 100;
			}
			else {
				v += FastCosine(x / 100.f + t * w) * 100;
			}
			u %= w;
			v %= h;
			j = (u + v * w);
			prgbDest[i].rgb ^= prgbSrc[j].rgb + ie * l;
			prgbDest[j].rgb ^= prgbSrc[i].rgb;
		}
	}
}

VOID
WINAPI
LayeredShader4(
	_In_		int				t,
	_In_ 		int				w,
	_In_		int				h,
	_In_		PRGBQUAD		prgbSrc,
	_Inout_		PRGBQUAD		prgbDest
)
{
	int i, j, k, l, m, n, u, v;
	l = Xorshift() % w;
	m = Xorshift() % h;
	k = Xorshift() % 3;
	n = Xorshift() % 100 + 1;
	for (int x = 0; x < w; ++x) {
		for (int y = 0; y < h; ++y) {
			i = (x + y * w);
			u = x + int(FastSine(t / 16.f + y / 1024.f * t) * t / 4);
			v = y + int(FastCosine(t / 16.f + y / 1024.f * t) * t / 4 + FastSine(t / 16.f + x / 1024.f * t) * t / 4);
			u = AntiNegative(u, w);
			v = AntiNegative(v, h);
			j = (u + v * w);
			int jj = AntiNegative(x + t * 15 ^ y - t * 15, w) + AntiNegative((x + y ^ t * 15), h) * w;
			prgbDest[i] = prgbSrc[i];
			prgbSrc[i] = prgbDest[j];
			if (k == 0) {
				prgbSrc[i].r ^= prgbSrc[j].r;
				prgbSrc[i].g |= prgbSrc[j].g;
				prgbSrc[i].b &= prgbSrc[j].b;
			}
			else if (k == 1) {
				prgbSrc[i].r |= prgbSrc[j].r;
				prgbSrc[i].g &= prgbSrc[j].g;
				prgbSrc[i].b ^= prgbSrc[j].b;
			}
			else {
				prgbSrc[i].r &= prgbSrc[j].r;
				prgbSrc[i].g ^= prgbSrc[j].g;
				prgbSrc[i].b |= prgbSrc[j].b;
			}
			prgbDest[i].rgb = prgbSrc[jj].rgb;
			prgbDest[j].rgb = prgbSrc[jj].rgb;
		}
	}
}

VOID
WINAPI
LayeredShader5(
	_In_		int				t,
	_In_ 		int				w,
	_In_		int				h,
	_In_		PRGBQUAD		prgbSrc,
	_Inout_		PRGBQUAD		prgbDest
)
{
	int i, j, k, l, m, n, u, v;
	l = Xorshift() % w;
	m = Xorshift() % h;
	k = Xorshift() % 3;
	n = Xorshift() % 100 + 1;
	for (int x = 0; x < w; ++x) {
		for (int y = 0; y < h; ++y) {
			i = x + y * w;
			u = x + int(FastSine(t / 16.f + x / 1024.f * t) * t / 4);
			v = y;
			u = AntiNegative(u, w);
			v = AntiNegative(v, h);
			j = (u + v * w);
			int jj = AntiNegative(x + t * 15 ^ y - t * 15, w) + AntiNegative((x + y ^ t * 15), h) * w;
			prgbDest[i] = prgbSrc[j];
			if (k == 0)
			{
				prgbSrc[i].r ^= prgbSrc[j].r;
				prgbSrc[i].g |= prgbSrc[j].g;
				prgbSrc[i].b &= prgbSrc[j].b;
			}
			else if (k == 1)
			{
				prgbSrc[i].r |= prgbSrc[j].r;
				prgbSrc[i].g &= prgbSrc[j].g;
				prgbSrc[i].b ^= prgbSrc[j].b;
			}
			else
			{
				prgbSrc[i].r &= prgbSrc[j].r;
				prgbSrc[i].g ^= prgbSrc[j].g;
				prgbSrc[i].b |= prgbSrc[j].b;
			}
			prgbDest[i].rgb ^= prgbSrc[jj].rgb;
			prgbDest[j].rgb ^= prgbSrc[jj].rgb;
		}
	}
}

/*
 og TijnAG07 code:
VOID
WINAPI
LayeredShader19(
	PSHADER_PARAMS SP
)
{
	INT y, x;
	//
#pragma omp parallel for num_threads( 4 )
	for (y = 0; y < SP->h; y++)
		for (x = 0; x < SP->width; x++)
		{

			FLOAT Tri1 = x & y + x | y;

			FLOAT fDistortion =


				(INT)Tri1 | SP->wth / (INT)FastSine(FastArcTangent2(FastCubicRoot(40.0f, SP->maxwh), 4)) * (SP->nTimer - SP->deltaTime);


			uint
				u = x + (uint)((FLOAT)SP->width * fDistortion),
				v = y + (uint)((FLOAT)SP->h * fDistortion);
			u %= SP->width, v %= SP->h;

			RGBQUAD rgbDst = SP->prgbSrc[v * SP->width + u];
			rgbDst.r &= SP->nTimer >> 2;
			rgbDst.r ^= SP->nTimer + rgbDst.b;
			rgbDst.b ^= rgbDst.r;

			SP->prgbDst[y * SP->width + x] = rgbDst;
		}
}
*/

VOID
WINAPI
LayeredShader6(
	_In_		int				t,
	_In_ 		int				w,
	_In_		int				h,
	_In_		PRGBQUAD		prgbSrc,
	_Inout_		PRGBQUAD		prgbDest
)
{
	int maxwh = max(w, h);
	// Code by TijnAG07 + Voltizer normalized
//#pragma omp parallel for num_threads( 4 ) 
	for (int y = 0; y < h; y++) {
		for (int x = 0; x < w; x++)
		{
			FLOAT Tri1 = x & y + x | y;
			FLOAT fDistortion = (int)Tri1 | int(w / FastSine(atan2f(cbrtf(40.0f / (float)maxwh), 4)) * (t - 4.0f));
			//i think that was what it was dividing or multiplying it by so example 3, 7 = 3 * 7 = 21
			// test the code and see if it does anything different the code is supposed to be doing zooming in trianglewaves that have like a fractal pattern with some weird as RGBQUAD (hsl) ish shit
			// so its like cbrt(40 * maxwh)?
			uint u = x + uint((FLOAT)w * fDistortion);
			uint v = y + uint((FLOAT)h * fDistortion);
			u = AntiNegative(u, w);
			v = AntiNegative(v, h);
			u %= w, v %= h;

			_RGBQUAD rgbDst = prgbSrc[v * w + u];
			rgbDst.r &= t >> 2;
			rgbDst.r ^= t + rgbDst.b;
			rgbDst.b ^= rgbDst.r;

			prgbDest[y * w + x] = rgbDst;
		}
	}
}
VOID
WINAPI
LayeredShader7(
	_In_		int				t,
	_In_ 		int				w,
	_In_		int				h,
	_In_		PRGBQUAD		prgbSrc,
	_Inout_		PRGBQUAD		prgbDest
)
{
	int i, j, k, l, m, n, u, v;
	l = Xorshift() % w;
	m = Xorshift() % h;
	k = Xorshift() % 3;
	n = Xorshift() % 100 + 1;
	for (int x = 0; x < w; ++x) {
		for (int y = 0; y < h; ++y) {
			i = (x + y * w);
			u = x + int(FastSine(t / 16.f + x / 1024.f * t) * t / 4);
			v = y + int(FastCosine(t / 16.f + y / 1024.f * t) * t / 4);
			u = AntiNegative(u, w);
			v = AntiNegative(v, h);
			j = (u + v * w);
			int jj = AntiNegative(x + t * 15 & y - t * 15, w) + AntiNegative((x + y & t * 15), h) * w;
			prgbDest[i] = prgbSrc[j];
			if (k == 0)
			{
				prgbSrc[i].r ^= prgbSrc[j].r;
				prgbSrc[i].g ^= prgbSrc[j].g;
				prgbSrc[i].b ^= prgbSrc[j].b;
			}
			else if (k == 1)
			{
				prgbSrc[i].r &= prgbSrc[j].r;
				prgbSrc[i].g &= prgbSrc[j].g;
				prgbSrc[i].b &= prgbSrc[j].b;
			}
			else
			{
				prgbSrc[i].r |= prgbSrc[j].r;
				prgbSrc[i].g |= prgbSrc[j].g;
				prgbSrc[i].b |= prgbSrc[j].b;
			}
			prgbDest[i].rgb -= prgbSrc[jj].rgb;
			prgbDest[j].rgb += prgbSrc[jj].rgb;
		}
	}
}


VOID
WINAPI
LayeredShader8(
	_In_		int				t,
	_In_ 		int				w,
	_In_		int				h,
	_In_		PRGBQUAD		prgbSrc,
	_Inout_		PRGBQUAD		prgbDest
)
{
	int i, j, jj, u, v, uu, vv;
	for (int x = 0; x < w; ++x) {
		for (int y = 0; y < h; ++y) {
			i = x + y * w;
			u = SineW(x - w / 2 + t * 16, 1, w * 2) * w / 2 + w / 2;
			v = SineW(y - h / 2 + t * 16, 1, h * 2) * h / 2 + h / 2;
			u = AntiNegative(u, w);
			v = AntiNegative(v, h);
			uu = x + t * 16;
			vv = y + t * 16;
			uu = AntiNegative(uu, w);
			vv = AntiNegative(vv, h);
			j = (u + v * w);
			jj = (uu + vv * w);
			prgbDest[j].rgb += prgbSrc[jj].rgb;
			prgbDest[i].rgb -= prgbSrc[j].rgb;
		}
	}
}

VOID
WINAPI
LayeredShader9(
	_In_		int				t,
	_In_ 		int				w,
	_In_		int				h,
	_In_		PRGBQUAD		prgbSrc,
	_Inout_		PRGBQUAD		prgbDest
)
{
	int i;
	for (int x = 0; x < w; ++x) {
		for (int y = 0; y < h; ++y) {
			i = x + y * w;
			HSVTRIPLE hsvTemp = RGBtoHSV(prgbDest[i]);
			hsvTemp.h *= (x ^ y + x ^ y) / PI + t * PI * 128;
			hsvTemp.s *= TriangleW(x + t, 1, w) * 127 + 128;
			hsvTemp.v *= TriangleW(y + t, 1, h) * 127 + 128;
			prgbDest[i].rgb ^= HSVtoRGB(hsvTemp).rgb;
		}
	}
}

VOID
WINAPI
LayeredShader10(
	_In_		int				t,
	_In_ 		int				w,
	_In_		int				h,
	_In_		PRGBQUAD		prgbSrc,
	_Inout_		PRGBQUAD		prgbDest
)
{
	int i, j, nDiv, u, v;
	nDiv = fabsf(SineW(t, 1, 256) * 256) + 2;

	for (int x = 0; x < w; ++x) {
		for (int y = 0; y < h; ++y) {
			i = x + y * w;
			u = x + FastSine(t / 8.f + (y - y % (h / nDiv)) * PI * 2 / (float)h) * 64;
			v = y + FastSine(t / 8.f + (x - x % (w / nDiv)) * PI * 2 / (float)w) * 64;
			u = AntiNegative(u, w);
			v = AntiNegative(v, h);
			j = u + v * w;
			HSVTRIPLE hsvTemp = RGBtoHSV(prgbSrc[i]);
			hsvTemp.h ^= int((x ^ y + x ^ y) / PI + t * PI * 128);
			hsvTemp.s ^= int(TriangleW(x + t, 1, w) * 127 + 128);
			hsvTemp.v ^= int(TriangleW(y + t, 1, h) * 127 + 128);
			prgbSrc[i].rgb ^= HSVtoRGB(hsvTemp).rgb;
			prgbDest[i] = prgbSrc[j];
		}
	}
}

VOID
WINAPI
LayeredShader11(
	_In_		int				t,
	_In_ 		int				w,
	_In_		int				h,
	_In_		PRGBQUAD		prgbSrc,
	_Inout_		PRGBQUAD		prgbDest
)
{
	for (int y = 0; y < h; ++y) {
		for (int x = 0; x < w; ++x) {
			int i = (x + y * w);
			int u = x + (abs((y + t * 100) % h - h / 2) - h / 2) * t / 100.f;
			int v = y + (abs((x + t * 100) % w - w / 2) - w / 2) * t / 100.f;
			u = AntiNegative(u, w);
			v = AntiNegative(v, h);
			int j = (u + v * w);
			HSVTRIPLE hsv = RGBtoHSV(prgbSrc[i]);
			hsv.h = ((i ^ x + t ^ y + t) + t * 16) / PI;
			hsv.s ^= x ^ y + t;
			hsv.v ^= x + t ^ y;
			prgbDest[i] = HSVtoRGB(hsv);
			prgbSrc[i] = prgbDest[i];
			prgbDest[i] = prgbSrc[j];
		}
	}
}
VOID
WINAPI
LayeredShader12(
	_In_		int				t,
	_In_ 		int				w,
	_In_		int				h,
	_In_		PRGBQUAD		prgbSrc,
	_Inout_		PRGBQUAD		prgbDest
)
{
	for ( int y = 0; y < h; ++y ) {
		for ( int x = 0; x < w; ++x ) {
			int i = ( x + y * w );
			int u = x + FastSine( ( y + t * 16 ) * PI * 2 / ( float )h ) * t;
			int v = y + FastCosine( ( x + t * 16 ) * PI * 2 / ( float )w ) * t;
			u = AntiNegative( u, w );
			v = AntiNegative( v, h );
			int j = ( u + v * w );
			HSVTRIPLE hsv = RGBtoHSV( prgbSrc[ i ] );
			hsv.h = ( ( i ^ x + t ^ y + t ) + t * 16 ) / PI;
			hsv.s ^= x ^ y + t;
			hsv.v ^= x + t ^ y;
			prgbDest[ i ] = HSVtoRGB( hsv );
			prgbSrc[ i ] = prgbDest[ i ];
			prgbDest[ i ] = prgbSrc[ j ];
		}
	}
}

VOID
WINAPI
LayeredShader13(
	_In_        int                t,
	_In_         int                w,
	_In_        int                h,
	_In_        PRGBQUAD        prgbSrc,
	_Inout_        PRGBQUAD        prgbDest
)
{
	// done by Tijn
	for ( int y = 0; y < h; ++y ) {
		for ( int x = 0; x < w; ++x ) {
			int i = ( x + y * w );
			int u = x + fmod( ( y + t * 16 ), ( 0.33 * PI ) * PI * 3 / ( float )h ) * t * 0.85;
			int v = y + fmod( ( x + t * 16 ), ( 0.66 * PI ) * PI * 2 / ( float )w ) * t * 0.85;
			u = AntiNegative( ( u + ceilf( w ) ), w );
			v = AntiNegative( ( v / sqrt(FastSine( 72.0f ) * 20 / PI ) + 1 ), h );
			int j = ( u + v * w );
			HSVTRIPLE hsv = RGBtoHSV( prgbSrc[ i ] );
			hsv.h = TriangleW( t + 5 * 10, 3.0f, 0.33f ) * 9 + x + 8.0f + t;
			hsv.s ^= x ^ y + t + 4;
			hsv.v ^= x + t ^ y + t;
			hsv.h += t + 4000;
			prgbDest[ i ] = HSVtoRGB( hsv );
		}
	}
}

/*VOID WINAPI LayeredShader13(
	_In_        int                t,
	_In_        int                w,
	_In_        int                h,
	_In_        PRGBQUAD        prgbSrc,
	_Inout_     PRGBQUAD        prgbDest
)
{	// Done by Tijn.... I think?
	for ( int y = 0; y < h; y++ )
		for ( int x = 0; x < w; x++ )
		{
			int i = ( y * w + x );

			int mathShit = FastSine( ( x * y / .42 ) * y / fabsf( t * x ) + ( 5 - y + 16.f ) * ( float )x + ( int )t * x / 5 );

			int u = x + mathShit;						// FastSine( ( y + t * 16 ) * PI * 2 / ( float )h ) * t;
			int v = y | mathShit - ( mathShit ^ 3 );	// FastCosine( ( x + t * 16 ) * PI * 2 / ( float )w ) * t;
			u = FastCosine( u * w ) * 25.f;		// AntiNegative( u, w );
			v = FastSine( v * y ) * 32.5f;		// AntiNegative( v, h );

			int j = ( v * w + u ); // I can barely read in this dumb editor smh
			// ( ( FastCosine( 4000.f ) ) + i ) + ( cbrtf( 20.f * x + y ) );

			HSVTRIPLE hsv = RGBtoHSV( prgbSrc[ i ] );
			hsv.h += x ^ y ^ t; // ( ( i ^ x + t ^ y + t ) + t * 16 ) / PI;

			hsv.s += x ^ y | i + t; // ^= x ^ y + t;
			// hsv.v; // ^= x + t ^ y;

			prgbDest[ i ] = HSVtoRGB( hsv );

			prgbSrc[ i ] = prgbDest[ i ];
			prgbDest[ i ] = prgbSrc[ j ]; // Yes I used to use it and i still do and this editor sucks
		}
}*/
VOID
WINAPI
LayeredShader14(
	_In_		int				t,
	_In_ 		int				w,
	_In_		int				h,
	_In_		PRGBQUAD		prgbSrc,
	_Inout_		PRGBQUAD		prgbDest
)
{
	PRGBQUAD prgbCopy = new _RGBQUAD[ w * h ];
	memcpy( prgbCopy, prgbSrc, w * h * sizeof( _RGBQUAD ) );
	for ( int y = 0; y < h; ++y ) {
		FLOAT ny = ( ( FLOAT )y / ( FLOAT )h ) * 2.0f - 1.0f;
		FLOAT fs = FastSine( ( ny + t / 16.f ) * PI * 2 );
		for ( int x = 0; x < w; ++x ) {
			FLOAT nx = ( ( FLOAT )x / ( FLOAT )w ) * 2.0f - 1.0f;
			FLOAT fcs = FastCosine( ( nx + t / 16.f ) * PI * 2 );
		    int i = ( x + y * w );
			int u = x + ( fs + fcs ) * t;
			int v = y + ( fcs - fs ) * t;
			u = AntiNegative( u, w );
			v = AntiNegative( v, h );
			int j = ( u + v * w );
			HSVTRIPLE hsv = RGBtoHSV( prgbCopy[ j ] );
			hsv.h += ( fs + fcs ) * t;
			hsv.s -= ( fs + fcs ) * t;
			hsv.v -= ( fcs - fs ) * t;
			prgbDest[ i ] = HSVtoRGB( hsv );
		}
	}
	delete[ ] prgbCopy;
}
VOID
WINAPI
LayeredShaderThread(
	VOID
) {
	GDISHADER_PARAMS pGdiShaderParams[ 14 ] = {
		{ iPayloadTime, LayeredShader13 }/*,
		{ iPayloadTime, LayeredShader2 },
		{ iPayloadTime, LayeredShader3 },
		{ iPayloadTime, LayeredShader4 },
		{ iPayloadTime, LayeredShader5 },
		{ iPayloadTime, LayeredShader6 },
		{ iPayloadTime, LayeredShader7 },
		{ iPayloadTime, LayeredShader8 },
		{ iPayloadTime, LayeredShader9 },
		{ iPayloadTime, LayeredShader10 },
		{ iPayloadTime, LayeredShader11 },
		{ iPayloadTime, LayeredShader12 },
		{ iPayloadTime, LayeredShader13 },
		{ iPayloadTime, LayeredShader14 },*/

	};
	while (!bTrigger)
	{
		GDISHADER_PARAMS gShaderParam = pGdiShaderParams[ Xorshift( ) % _countof( pGdiShaderParams ) ];
		ExecuteLayeredShader( ( GDI_SHADER* )gShaderParam.pGdiShader, gShaderParam.fDuration, 5 );
	}
}
VOID
WINAPI
ExecuteShader(
	_In_ GDI_SHADER pGdiShader,
	_In_ FLOAT       fDuration,
	_In_ INT         iDelay
)
{
	clock_t startTime = clock( );
	int w = GetSystemMetrics( SM_CXVIRTUALSCREEN );
	int h = GetSystemMetrics( SM_CYVIRTUALSCREEN );

	BITMAPINFO bmi = { 0 };
	bmi.bmiHeader.biSize = sizeof( bmi );
	bmi.bmiHeader.biWidth = w;
	bmi.bmiHeader.biHeight = -h;
	bmi.bmiHeader.biPlanes = 1;
	bmi.bmiHeader.biBitCount = 32;

	int iSize = w * h * sizeof( _RGBQUAD );
	HANDLE heap = GetProcessHeap( );
	PRGBQUAD src = ( PRGBQUAD )HeapAlloc( heap, HEAP_ZERO_MEMORY, iSize );
	PRGBQUAD dst = NULL;

	for ( INT t = 0; ( ( FLOAT )( clock( ) - startTime ) / CLOCKS_PER_SEC ) <= fDuration; t++ ) {

		HWND hWnd = HWND_DESKTOP;
		HDC hdc = GetDC( hWnd );

		HDC hdcMemory = CreateCompatibleDC( hdc );
		HBITMAP hbm = CreateDIBSection( hdc, &bmi, DIB_RGB_COLORS, ( void** )&dst, NULL, 0 );
		HGDIOBJ hOldBitmap = SelectObject( hdcMemory, hbm ); // used to do this in my FIRST EVER GDIwares

		BitBlt( hdcMemory, 0, 0, w, h, hdc, 0, 0, SRCCOPY );
		if (src != NULL) {
			GetBitmapBits( hbm, iSize, src );
		}

		pGdiShader( t, w, h, src, dst );

		if (dst != NULL) {
			SetBitmapBits( hbm, iSize, dst );
		}
		BitBlt( hdc, 0, 0, w, h, hdcMemory, 0, 0, SRCCOPY );

		SelectObject( hdcMemory, hOldBitmap );
		DeleteObject( hbm );
		DeleteDC( hdcMemory );
		ReleaseDC( hWnd, hdc );

		if (iDelay) {
			Sleep( iDelay );
		}
	}

	if (src != NULL) HeapFree( heap, 0, src );
}
VOID
WINAPI
LayerlessShader1(
	INT t,
	INT w,
	INT h,
	PRGBQUAD prgbSrc,
	PRGBQUAD prgbDest
) {
	int i, j, u, v;
	float fst = SineW( t, 1, 100 ) * 100;
	float fs = -FastSine( .01 * fst );
	float fcs = -FastCosine( .01 * fst );
	int ws = w / 2;
	int hs = h / 2;
	for ( int x = 0; x < w; ++x ) {
		for ( int y = 0; y < h; ++y ) {
			i = ( x + y * w );
			int cx = x - ws;
			int cy = y - hs;
			u = fcs * cx + fs * cy + ws;
			v = fs * cx - fcs * cy + hs;
			u = AntiNegative( u, w );
			v = AntiNegative( v, h );
			j = ( u + v * w );
			_RGBQUAD temp = prgbSrc[ i ];
			temp.b -= clamp( 0, BLEND( temp.b, prgbSrc[ j ].b, fst / 2.f + .5f ), 255 );
			temp.g -= clamp( 0, BLEND( temp.g, prgbSrc[ j ].g, fst / 2.f + .5f ), 255 );
			temp.r -= clamp( 0, BLEND( temp.r, prgbSrc[ j ].r, fst / 2.f + .5f ), 255 );
			prgbDest[ i ].rgb += temp.rgb;
		}
	}
}
VOID
WINAPI
LayerlessShader2(
	INT t,
	INT w,
	INT h,
	PRGBQUAD prgbSrc,
	PRGBQUAD prgbDest
) {
	int i, j, k, l, m, n;
	l = Xorshift( ) % w;
	m = Xorshift( ) % h;
	k = Xorshift( ) % 3;
	n = Xorshift( ) % 100 + 1;
	unsigned int u, v;
	for ( int x = 0; x < w; ++x ) {
		for ( int y = 0; y < h; ++y ) {
			i = ( x + y * w );
			u = x + FastSine( t / 16.f + y / 1024.f * t ) * t / 4;
			v = y;
			u %= w;
			v %= h;
			j = ( u + v * w );
			int jj = ( x + t ^ y ) % w + ( ( x + y ^ t ) % h ) * w;
			if (k == 0) {
				prgbSrc[ i ].r ^= prgbSrc[ j ].r;
				prgbSrc[ i ].g |= prgbSrc[ j ].g;
				prgbSrc[ i ].b &= prgbSrc[ j ].b;
			}
			else if (k == 1) {
				prgbSrc[ i ].r |= prgbSrc[ j ].r;
				prgbSrc[ i ].g &= prgbSrc[ j ].g;
				prgbSrc[ i ].b ^= prgbSrc[ j ].b;
			}
			else {
				prgbSrc[ i ].r &= prgbSrc[ j ].r;
				prgbSrc[ i ].g ^= prgbSrc[ j ].g;
				prgbSrc[ i ].b |= prgbSrc[ j ].b;
			}
			prgbDest[ i ].rgb ^= prgbSrc[ jj ].rgb;
			if ( x <= l + n && x >= l - n || y <= m + n && y >= m - n ) {
				prgbDest[ i ].rgb = 0;
			}
		}
	}
}
VOID
WINAPI
LayerlessShader3(
	INT t,
	INT w,
	INT h,
	PRGBQUAD prgbSrc,
	PRGBQUAD prgbDest
) {
	int i, j;
	unsigned int u, v;
	for ( int x = 0; x < w; ++x ) {
		for ( int y = 0; y < h; ++y ) {
			i = ( x + y * w );
			u = x + FastSine( FastSine( ( y + t ) * PI / 64.f ) * t / 128.f + ( y + t ) * PI / 256.f ) * 16;
			v = ( y + t ) % h;
			u %= w;
			v %= h;
			j = ( u + v * w );
			unsigned int uu = u + FastSine( FastSine( ( y + t ) * PI / 64.f ) * t / 128.f + ( y + t ) * PI / 256.f ) * 16;
			unsigned int vv = ( v + t ) % h;
			uu %= w;
			vv %= h;
			int jj = ( uu + vv * w );
			prgbDest[ jj ].rgb ^= prgbSrc[ jj ].rgb ^ prgbSrc[ i ].rgb;
		}
	}
}
VOID
WINAPI
LayerlessShader4(
	INT t,
	INT w,
	INT h,
	PRGBQUAD prgbSrc,
	PRGBQUAD prgbDest
) {
	int i, j, k, l, m, n, o;
	o = 100;
	k = FastSine( t * PI / 64.f ) * 10;
	l = FastCosine( t * PI / 64.f ) * 10;
	m = Xorshift( ) % ( w - o ) + o / 2;
	n = Xorshift( ) % ( h - o ) + o / 2;
	unsigned int u, v;
	for ( int x = 0; x < w; ++x ) {
		for ( int y = 0; y < h; ++y ) {
			i = ( x + y * w );
			u = x + k;
			v = y + l;
			u %= w;
			v %= h;
			j = ( u + v * w );
			prgbDest[ i ] = prgbSrc[ j ];
			if ( x <= m + o / 2 && x >= m - o / 2 && y <= n + o / 2 && y >= n - o / 2 ) {
				prgbDest[ j ].rgb = prgbSrc[ i ].rgb;
			}
		}
	}
}
VOID
WINAPI
LayerlessShader5(
	INT t,
	INT w,
	INT h,
	PRGBQUAD prgbSrc,
	PRGBQUAD prgbDest
) {
	int i;
	unsigned int u, v;

	for ( int x = 0; x < w; ++x ) {
		for ( int y = 0; y < h; ++y ) {
			i = ( x + y * w );

			u = x ^ y + t;
			v = y ^ x + t;

			u %= w;
			v %= h;

			HSVTRIPLE hsv = RGBtoHSV( prgbSrc[ i ] );

			hsv.h += ( byte )( 256 / 3 );
			hsv.s = x + t ^ y + t;

			prgbDest[ i ].rgb ^= HSVtoRGB( hsv ).rgb;
			prgbDest[ v * w + u ].rgb ^= HSVtoRGB( hsv ).rgb;
		}
	}
}

VOID
WINAPI
LayerlessShader6(
	INT t,
	INT w,
	INT h,
	PRGBQUAD prgbSrc,
	PRGBQUAD prgbDest
) {
	int i, j;
	unsigned int u, v;
	float angle = t / 100.f;
	float fs = FastSine( angle * PI * 2 );
	float fcs = FastCosine( angle * PI * 2 );
	for ( int y = 0; y < h; ++y ) {
		for ( int x = 0; x < w; ++x ) {
			i = ( x + y * w );
			u = x + fs * 32;
			v = y + fcs * 32;
			u = AntiNegative( u, w );
			v = AntiNegative( v, h );
			j = ( u + v * w );
			prgbDest[ i ].rgb = prgbSrc[ j ].rgb;
			u = x ^ i;
			v = y ^ i;
			u = AntiNegative( u, w );
			v = AntiNegative( v, h );
			j = ( u + v * w );

			if (Xorshift() & 1) {
				prgbDest[ i ].r = prgbDest[ j ].b;
				prgbDest[ i ].g = prgbDest[ j ].g;
				prgbDest[ i ].b = prgbDest[ j ].r;
			}
			else {
				prgbDest[ i ].r = prgbDest[ j ].r;
				prgbDest[ i ].g = prgbDest[ j ].g;
				prgbDest[ i ].b = prgbDest[ j ].b;
			}
			prgbDest[i].rgb += 0x7f7f7f;
		}
	}
}

VOID
WINAPI
LayerlessShader7(
	INT t,
	INT w,
	INT h,
	PRGBQUAD prgbSrc,
	PRGBQUAD prgbDest
) {
	for ( int y = 0; y < h; ++y ) {
		for ( int x = 0; x < w; ++x ) {
			int i = ( x + y * w );
			int u = x + ( abs( ( y + t * 100 ) % h - h / 2 ) - h / 2 ) * t / 100.f;
			int v = y + ( abs( ( x + t * 100 ) % w - w / 2 ) - w / 2 ) * t / 100.f;
			u = AntiNegative( u, w );
			v = AntiNegative( v, h );
			int j = ( u + v * w );
			HSVTRIPLE hsv = RGBtoHSV( prgbSrc[ i ] );
			hsv.h = ( ( i ^ x + t ^ y + t ) + t * 16 ) / PI;
			hsv.s ^= x ^ y + t;
			hsv.v ^= x + t ^ y;
			prgbDest[ i ] = HSVtoRGB( hsv );
			prgbSrc [ i ] = prgbDest[ i ];
			prgbDest[ i ] = prgbSrc[ j ];
		}
	}
}
VOID
WINAPI
LayerlessShader8(
	INT t,
	INT w,
	INT h,
	PRGBQUAD prgbSrc,
	PRGBQUAD prgbDest
) {
	int i;
	unsigned int u, v;

	for (  int x = 0; x < w; ++x ) {
		for (int y = 0; y < h; ++y ) {
			i = ( x + y * w );

			u = x ^ y + t + x ^ y + t;
			v = y ^ x + t + y ^ x + t;

			u %= w;
			v %= h;

			HSVTRIPLE hsv = RGBtoHSV( prgbSrc[ i ] );
			HSVTRIPLE hsv2 = RGBtoHSV( prgbSrc[ u + v * w ] );

			hsv.h += ( byte )( 256 / 3 );
			hsv.s = BLEND( hsv.s, hsv2.s, TriangleW( t, 1, 10 ) );
			hsv.v = BLEND( hsv.v, hsv2.v, TriangleW( t, 1, 10 ) );

			prgbDest[ i ] = HSVtoRGB( hsv );
		}
	}
}

VOID
WINAPI
Redrawer(
	VOID
) {
	while ( true )
	{
		InvalidateRect( HWND_DESKTOP, 0, 0 );
		RedrawWindow( HWND_DESKTOP, 0, 0, RDW_ALLCHILDREN | RDW_ERASE | RDW_INVALIDATE );
		Sleep( 3000 );
	}
}


VOID
WINAPI
ExecuteShortbeatTemp(
	_In_ INT nSamplerate,
	_In_ INT nSamples,
	_In_ SHORTBEAT pAudioSequence
)
{   // Code by ChrisRM_380 / Voltizer + Sapphire
	HANDLE       hHeap = GetProcessHeap( );
	PSHORT       psSamples;
	SYSTEM_INFO  systemInfo;

    GetSystemInfo( &systemInfo );

	/* If dwAllocationGraduality is lower than nSamplerate then it's going use HeapAlloc which is better for low RAM */
    if ( nSamples < systemInfo.dwAllocationGranularity )
    {
        psSamples = ( PSHORT )HeapAlloc( hHeap, 0, nSamplerate );
    }
    else
    {
        psSamples = ( PSHORT )VirtualAlloc( NULL, nSamplerate, MEM_COMMIT | MEM_RESERVE, PAGE_READWRITE );
    }

	WAVEFORMATEX waveFormat = { WAVE_FORMAT_PCM, 1, nSamplerate, nSamplerate * 2, 2, 16, 0 };
	WAVEHDR waveHdr = { ( PCHAR )psSamples, nSamples * 2, 0, 0, 0, 0, NULL, 0 };

	HWAVEOUT hWaveOut;

	waveOutOpen( &hWaveOut, WAVE_MAPPER, &waveFormat, 0, 0, 0 );

	pAudioSequence( nSamplerate, nSamples, psSamples );
	waveOutPrepareHeader( hWaveOut, &waveHdr, sizeof( waveHdr ) );
	waveOutWrite( hWaveOut, &waveHdr, sizeof( waveHdr ) );

	while ( !( waveHdr.dwFlags & WHDR_DONE ) )
		Sleep( 1 );

	waveOutReset( hWaveOut );
	waveOutUnprepareHeader( hWaveOut, &waveHdr, sizeof( waveHdr ) );
	waveOutClose( hWaveOut );

	if ( nSamples < systemInfo.dwAllocationGranularity )
	{
		HeapFree( hHeap, 0, psSamples );
	}
	else
	{
		VirtualFree( psSamples, 0, MEM_RELEASE );
	}
}

bool bTrigger = false;
VOID
WINAPI
ExecuteShortbeat(
	SHORTBEAT_PARAMS params
)
{
	ExecuteShortbeatTemp( params.nSamplesPerSec, params.nSampleCount, ( SHORTBEAT* )params.pShortbeat );
}
VOID
WINAPI
ShortbeatThread(
	VOID
)
{
	SHORTBEAT_PARAMS pShortbeats[ ] = {
		   { 48000, 48000 * 30, AudioSequence1 },
		   { 48000, 48000 * 30, AudioSequence2 },
		   { 36000, 36000 * 30, AudioSequence3 },
		   { 48000, 48000 * 30, AudioSequence4 },
		   { 44100, 44100 * 30, AudioSequence5 },
		   { 9000, 9000 * 30, AudioSequence6 },
		   { 36000, 36000 * 30, AudioSequence7 },
		   { 18000, 18000 * 30, AudioSequence8 },
		   { 40000, 1048576, AudioSequence9 },
		   { 20000, 524288, AudioSequence10 },
		   { 16000, 16000 * 30, AudioSequence11 },
		   { 48000, 48000 * 30, AudioSequence12 },
		   { 48000, 48000 * 30, AudioSequence13 },
		   { 40960, 1048576, AudioSequence14 },
		   { 40960, 1048576 / 2, AudioSequence15 },
		   { 40960, 1048576, AudioSequence16 },
	};
	for ( INT i = 0; i < _countof( pShortbeats ); i++ )
	{
		ExecuteShortbeat( pShortbeats[ i ] );
	}
	bTrigger = true;
}

VOID
WINAPI
AudioSequence1(
	_In_ int nSampleRate,
	_In_ int nSamples,
	_Inout_ PSHORT psSamples
)
{
	int nSqrt = (int)sqrtf((FLOAT)nSamples) + 1;
	for (int y = 0; y < nSqrt; y++)
	{
		for (int x = 0; x < nSqrt; x++)
		{
			int t = y * nSqrt + x;
			if (t >= nSamples)
				continue;
			byte s = int(SineW(TriangleW(x * (y >> 1 | 1), 2, 49) * SineW(y >> 1, x, 4800) * x, y >> 1, 48000) * 127) + 128 & 255;
			psSamples[t] = SHORT(s * 256);
		}
	}
}
VOID
WINAPI
AudioSequence2(
	_In_ int nSampleRate,
	_In_ int nSamples,
	_Inout_ PSHORT psSamples
)
{
	int nSqrt = (int)sqrtf((FLOAT)nSamples) + 1;
	for (int y = 0; y < nSqrt; y++)
	{
		for (int x = 0; x < nSqrt; x++)
		{
			int t = y * nSqrt + x;
			if (t >= nSamples)
				continue;
			byte s = (x >> 2) * (y >> 2 ^ x >> 2) + (x >> 2) + ((x + y ^ y) * 5 & y) * y & 255;
			psSamples[t] = SHORT(s * 256);
		}
	}
}
VOID
WINAPI
AudioSequence3(
	_In_ int nSampleRate,
	_In_ int nSamples,
	_Inout_ PSHORT psSamples
)
{
	for (int t = 0; t < nSamples; t++)
	{
		if (t >= nSamples)
			continue;
		byte s = int(FastSine(t * (t & t >> 13) / 128.f + t) * 127 - FastSine(t) * 127) + 128 & 255;
		psSamples[t] = SHORT(s * 256);
	}
}
VOID
WINAPI
AudioSequence4(
	_In_ int nSampleRate,
	_In_ int nSamples,
	_Inout_ PSHORT psSamples
)
{
	int nSqrt = (int)sqrtf((FLOAT)nSamples) + 1;
	for (int y = 0; y < nSqrt; y++)
	{
		for (int x = 0; x < nSqrt; x++)
		{
			int t = y * nSqrt + x;
			if (t >= nSamples)
				continue;
			psSamples[t] = SHORT(y * (x & y >> 1) * x >> 2 ^ x << 8);
		}
	}
}
VOID
WINAPI
AudioSequence5(
	_In_ int nSampleRate,
	_In_ int nSamples,
	_Inout_ PSHORT psSamples
)
{
	int nSqrt = (int)sqrtf((FLOAT)nSamples) + 1;
	for (int y = 0; y < nSqrt; y++)
	{
		for (int x = 0; x < nSqrt; x++)
		{
			int t = y * nSqrt + x;
			if (t >= nSamples)
				continue;
			byte s = int(SineW((x + y) * y, TriangleW(x, 1, 4410), 4410) * 64) + 128 & 255;
			psSamples[t] = SHORT(s * 256);
		}
	}
}
VOID
WINAPI
AudioSequence6(
	_In_ int nSampleRate,
	_In_ int nSamples,
	_Inout_ PSHORT psSamples
)
{
	int nCbrt = (int)cbrtf((FLOAT)nSamples);
	for (int z = 0; z < nCbrt; z++) {
		for (int y = 0; y < nCbrt; y++)
		{
			for (int x = 0; x < nCbrt; x++)
			{
				int t = z * nCbrt * nCbrt + y * nCbrt + x;
				if (t >= nSamples)
					continue;
				byte s = int(TriangleW(x, y & z, x + y + z + 1) * 127 + (x & y & z) + x * (z + 1)) + 128 & 255;
				psSamples[t] = SHORT(s * 256);
			}
		}
	}
}
VOID
WINAPI
AudioSequence7(
	_In_ int nSampleRate,
	_In_ int nSamples,
	_Inout_ PSHORT psSamples
)
{
	int nSqrt = (int)sqrtf((FLOAT)nSamples) + 1;
	for (int y = 0; y < nSqrt; y++)
	{
		for (int x = 0; x < nSqrt; x++)
		{
			int t = y * nSqrt + x;
			if (t >= nSamples)
				continue;
			byte s = ((t | y * 2) * 203 / 32 ^ x + y * 2) & 255;
			psSamples[t] = SHORT(s * 256);
		}
	}
}
VOID
WINAPI
AudioSequence8(
	_In_ int nSampleRate,
	_In_ int nSamples,
	_Inout_ PSHORT psSamples
)
{
	for (int t = 0; t < nSamples; t++)
	{
		if (t >= nSamples)
			continue;
		byte s = (t * (t >> 9 | t) | t / (abs((t & 255) - 128) + 1)) + 128 & 255;
		psSamples[t] = SHORT(s * 256);
	}
}
VOID
WINAPI
AudioSequence9(
	_In_ int nSampleRate,
	_In_ int nSamples,
	_Inout_ PSHORT psSamples
)
{
	for (int t = 0; t < nSamples; t++)
	{
		if (t >= nSamples)
			continue;
		byte s = ((t ^ 63) * (t >> 11 | t >> 2)) & 255;
		psSamples[t] = SHORT(s * 256);
	}
}
VOID
WINAPI
AudioSequence10(
	_In_ int nSampleRate,
	_In_ int nSamples,
	_Inout_ PSHORT psSamples
)
{
	for (int t = 0; t < nSamples; t++)
	{
		if (t >= nSamples)
			continue;
		byte s = t * (t + (t >> 10) ^ t) >> 5 & 255;
		psSamples[t] = SHORT(s * 256);
	}
}

VOID
WINAPI
AudioSequence11(
	_In_ int nSampleRate,
	_In_ int nSamples,
	_Inout_ PSHORT psSamples
)
{
	int nSqrt = (int)sqrtf((FLOAT)nSamples) + 1;
	for (int y = 0; y < nSqrt; y++)
	{
		for (int x = 0; x < nSqrt; x++)
		{
			int t = y * nSqrt + x;
			if (t >= nSamples)
				continue;
			byte s = int(SineW(x % max(y, 1), x, 8000) * 127 + 128) & 255;
			psSamples[t] = SHORT(s * 256);
		}
	}
}
VOID
WINAPI
AudioSequence12(
	_In_ int nSampleRate,
	_In_ int nSamples,
	_Inout_ PSHORT psSamples
)
{
	for (int t = 0; t < nSamples; t++)
	{
		if (t >= nSamples)
			continue;
		byte s = (int(tan(t / 512.f * t / 1048576.f) * 100 + 500) * t >> 14) + 128 & 255;
		psSamples[t] = SHORT(s * 256);
	}
}
VOID
WINAPI
AudioSequence13(
	_In_ int nSampleRate,
	_In_ int nSamples,
	_Inout_ PSHORT psSamples
)
{
	int nSqrt = (int)sqrtf((FLOAT)nSamples) + 1;
	for (int y = 0; y < nSqrt; y++)
	{
		for (int x = 0; x < nSqrt; x++)
		{
			int t = y * nSqrt + x;
			if (t >= nSamples)
				continue;
			byte s = SineW(x ^ y, x - y & x * y >> 9, 48000) * 127;
			psSamples[t] = SHORT(s * 256);
		}
	}
}
VOID
WINAPI
AudioSequence14(
	_In_ int nSampleRate,
	_In_ int nSamples,
	_Inout_ PSHORT psSamples
)
{
	for (int t = 0; t < nSamples; t++)
	{
		if (t >= nSamples)
			continue;
		int list1[] = { 0, 0, 0, 0, -4, -4, -2, -5 };
		int listlist1[][3] = { {0, 5, 7},{0, 5, 12},{0, 5, 7},{0, 5, 12},{0, 9, 11},{0, 9, 16}, {0, 7, 9}, {0, 10, 17} };
		int aaa = t * 35 * pow(pow(2, 1 / 12.0), ((list1[t >> 16 & 7]) + listlist1[t >> 16 & 7][(t >> 13 & 7) % 3])) / 48;
		byte s = (int(powf(pow(2, 1 / 12.f), (int)floor(((float)AntiNegative(((t >> 12 & 63) ^ (t >> 12 & 63) - 5) - (t >> 17 & 2), 15) * 12) / 7 + .24)) * 35 * t / 32) & 128) + ((aaa ^ aaa / 2) & 127);
		psSamples[t] = SHORT(s * 256);
	}
}
VOID
WINAPI
AudioSequence15(
	_In_ int nSampleRate,
	_In_ int nSamples,
	_Inout_ PSHORT psSamples
)
{
	for (int t = 0; t < nSamples; t++)
	{
		if (t >= nSamples)
			continue;
		int list1[] = { 0, 0, 0, 0, -4, -4, -2, -5 };
		int listlist1[][3] = { {0, 5, 7},{0, 5, 12},{0, 5, 7},{0, 5, 12},{0, 9, 11},{0, 9, 16}, {0, 7, 9}, {0, 10, 17} };
		int aaa = t * 35 * pow(pow(2, 1 / 12.0), ((list1[t >> 16 & 7]) + listlist1[t >> 16 & 7][(t >> 13 & 7) % 3])) / 48;
		int bbb = t * 35 * pow(pow(2, 1 / 12.0), list1[t >> 16 & 7]) / 48;
		byte s = ((int(powf(pow(2, 1 / 12.f), (int)floor(((float)AntiNegative(((t >> 12 & 63) ^ (t >> 12 & 63) - 5) - (t >> 17 & 2), 15) * 12) / 7 + .24)) * 35 * t / 32) & 128) // melody
			+ ((aaa ^ aaa / 2) & 127) // bass
			+ ((bbb ^ (bbb & 255) * (t >> 12 & 127) >> 5) >> 1 & 255)) // bass 2
			/ 2 * max(min(128, (t >> 5 & 511) - 64), 0) / 256 // sidechain
			+ SquareW(sqrt(t & 16383), 1, 8) * (~t & 16383) / 256 - 64; // kick
		psSamples[t] = SHORT(s * 256);
	}
}
static FLOAT ffvals[512];

FLOAT
fasth3wf(
	int t
)
{
	return ffvals[t & 511];
}
VOID
WINAPI
initializefasth3wf(
	VOID
)
{
	for (int t = 0; t < 512; t++)
		ffvals[t] = FastSine(t / 128.f * PI + atan(FastCosine(t / 64.f * PI)) * sin((t >> 6) * PI / 4.f) * 3); // Specifically for AudioSequence15!
}
VOID
WINAPI
AudioSequence16(
	_In_ int nSampleRate,
	_In_ int nSamples,
	_Inout_ PSHORT psSamples
)
{
	float S = Xorshift() % 100 / 10.f;
	for (int t = 0; t < nSamples; t++)
	{
		if (t >= nSamples)
			continue;
		int list1[] = { 0, 0, 0, 0, -4, -4, -2, -5 };
		int bt = list1[t >> 16 & 7];
		int listlist1[][3] = { {0, 5, 7},{0, 5, 12},{0, 5, 7},{0, 5, 12},{0, 9, 11},{0, 9, 16}, {0, 7, 9}, {0, 10, 17} };
		float meltones = powf(pow(2, 1 / 12.f), (int)floor(((float)AntiNegative(((t >> 12 & 63) ^ (t >> 12 & 63) - 5) - (t >> 17 & 2), 15) * 12) / 7 + .24));
		int melody = int(t * meltones * 35 / 32.f);
		int bass1 = t * 35 * pow(pow(2, 1 / 12.0), bt + listlist1[t >> 16 & 7][(t >> 13 & 7) % 3]) / 48;
		int bass2 = t * 35 * pow(pow(2, 1 / 12.0), bt) / 48;
		int d = pow(2, 12);
		int d2 = pow(2, 14);
		if (!(t & 31)) {
			S = Xorshift() % 100 / 10.f;
		}
		int H = t & 2;
		float list2[] = { 1, d, H, d, S, d, H, 1, 1, d, S, d, 2, 2, 1, H, 1, d, H, d, S, d, H, d, 1, 1, 2 + H * (t >> 17 & 1), 1, 2 + H * (t >> 17 & 1), 1, (t * 4) / 3 & 42, (t * 4) / 3 & 55 };
		int dee = list2[t >> 12 & 31];
		int kick = dee == 0 ? 0 : FastSine(5 * cbrt(t & (d / dee) - 1)) * 500;
		int list3[] = { 1,0,1,1,0,1,1,0,1,0,1,1,1,1,1,1 };
		int list4temp[] = { 12, 7 };
		int list4[] = { bt, bt, bt, bt, 7, bt, 6, 5, -6000, t >> 17 & 1 ? list4temp[t >> 12 & 1] : 5, 5, 7, 3, t >> 10 & 2, 2, 3 };
		int melody2 = t * pow(pow(2, 1 / 12.f), ((list4[t >> 13 & 15]))) * (~(t >> 11 + list3[t >> 13 & 15] & ~t >> 15) & 1) * 35 / 24;
		int list5[] = { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,3,3,3,3,3,3,5,5,2,2,2,2,-2,-2,-2,-2,7,7,7,7,7,7,5,5,5,5,5,5,3,3,3,3,10,10,10,10,10,10,2,2,2,2,2,2,3,3,3,3 };
		int list6[] = { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,3,5,5,5,5,5,5,7,7,3,3,3,3,-2,-2,-2,-2,8,8,8,8,8,8,7,7,7,7,7,7,3,3,3,3,12,12,12,12,12,12,4,4,4,4,4,4,3,3,3,3 };
		int melody3a = t * pow(pow(2, 1 / 12.f), list5[t >> 13 & 63]) * 35 / 6;
		int melody3b = t * pow(pow(2, 1 / 12.f), list6[t >> 13 & 63]) * 35 / 8;
		int melody3 = (fasth3wf(melody3a) + fasth3wf(melody3b)) * 33;
		int list7[] = { 2, 4, 1, 15, 4, 2, 4, 17, 1, 2, 4, 15, 1, 8 >> (t >> 11 & 2), 8 >> (t >> 11 & 2), t & t >> 4 & 31 };
		int dee2 = list7[t >> 13 & 15];
		int otherkick = dee2 == 0 ? 0 : 128 - abs((int(3e5 / (t & (d2 / dee2) - 1)) & 255) - 128) * 2;
		byte s = max(0, min(255, (
			((((melody & 255) - 128) * max(min(~t >> 4 & 255, max(~t >> 11 & 255, 128)), ~t >> 4 & 255) * (t >> 12 & 127) >> 13) & 255) / 2 +
			((((melody2 * 2 & 255) - 128) * (~(t >> 5 + list3[t >> 13 & 15]) & 127) * ((t >> 11 & 255) * 2 + 256) >> 14 & 255) - 128) / 2 +
			melody3 * 2 +
			((bass1 ^ bass1 / 2) & 127) +
			(((bass2 ^ (bass2 & 255) * (t >> 12 & 127) >> 5) >> 1 & 255))) / 2 +
			kick +
			otherkick)
		) + 128;
		psSamples[t] = SHORT(s * 256);
	}
}