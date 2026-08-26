#include "Zynth.hh"

DWORD _dwSeed;

VOID
WINAPI
SeedXorshift(
	_In_ DWORD Seed
)
{
	_dwSeed = Seed;
}

DWORD
Xorshift( VOID )
{
	_dwSeed ^= _dwSeed << 13;
	_dwSeed ^= _dwSeed >> 17;
	_dwSeed ^= _dwSeed << 5;

	return _dwSeed;
}

INT
AntiNegative(
	_In_ INT a,
	_In_ INT b
)
{
	return a < 0 ? ( b - abs( a % b ) ) : a % b;
}

FLOAT
FastSine(
	_In_ FLOAT f
)
{
	INT i = ( INT )( f / ( 2.f * PI ) * ( FLOAT )_countof( fastsv ) );
	return fastsv[ AntiNegative( i , _countof( fastsv ) ) ];
}

FLOAT
FastCosine(
	_In_ FLOAT f
)
{
	return FastSine( f + PI / 2.f );
}

VOID
InitializeSine( 
	VOID
)
{
	for ( INT i = 0; i < _countof( fastsv ); i++ )
	{
        fastsv[ i ] = sinf( ( FLOAT )i / ( FLOAT )_countof( fastsv ) * PI * 2.f );
    }
}