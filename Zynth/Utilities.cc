#include "Zynth.hh"

PWSTR
GenUnicodeString(
    _In_ int iLength
)
{
    // Code by Sapphire and/or ChrisRM_380 / Voltizer
    HANDLE hHeap = GetProcessHeap( );
    PWSTR szRandom = ( PWSTR )HeapAlloc( hHeap, HEAP_ZERO_MEMORY, ( iLength + 1 ) * sizeof( WCHAR ) );

    for ( INT i = 0; i < iLength; i++ )
    {
        szRandom[ i ] = ( Xorshift( ) % 256 ) + 1024;
    }

    szRandom[ iLength ] = L'\0';
	HeapFree( hHeap, 0, szRandom ); 
	return szRandom;
}
CONST
PPOINT
RandPoints(
    _In_ int nPoints,
    _In_ int w,
    _In_ int h
) {
    // Code by ChrisRM_380 / Voltizer
    HANDLE hHeap = GetProcessHeap( );
    PPOINT pRand = ( POINT * )HeapAlloc( hHeap, HEAP_ZERO_MEMORY, ( nPoints + 1 ) * sizeof( POINT ) );

    for ( INT i = 0; i < nPoints; i++ ) {
        pRand[ i ] = { ( LONG )AntiNegative( Xorshift( ) , w ), ( LONG )AntiNegative( Xorshift( ) , h ) };
    }

    HeapFree( hHeap, 0, pRand );
    return pRand;
}