#include "Zynth.hh"

static
LONG
WINAPI
GlobalCrashHandler(
	_In_ PEXCEPTION_POINTERS pExceptionInfo
)
{
#ifdef _M_AMD64
	pExceptionInfo->ContextRecord->Rip += 1;
#else
	pExceptionInfo->ContextRecord->Eip += 1;
#endif

	return EXCEPTION_CONTINUE_EXECUTION;
}

BOOL
WINAPI
Initialize( VOID )
{
    DWORD dwSeed = ( DWORD )ReadTimeStampCounter( );
    SeedXorshift( dwSeed );

    SetUnhandledExceptionFilter( GlobalCrashHandler );

    InitializeSine( );
    initializefasth3wf( );

    return TRUE;
}

INT WINAPI wWinMain(
    _In_            HINSTANCE   hInstance,
    _In_opt_        HINSTANCE   hPrevInstance,
    _In_            LPWSTR      lpCmdLine,
    _In_            INT         nShowCmd
)
{
    SetUnhandledExceptionFilter( GlobalCrashHandler );
    UNREFERENCED_PARAMETER( hInstance );
    UNREFERENCED_PARAMETER( hPrevInstance );
    UNREFERENCED_PARAMETER( lpCmdLine );
    UNREFERENCED_PARAMETER( nShowCmd );

    if ( !Initialize( ) )
    {
        return 1;
    }
    LayeredShaderThread();
    if ( MessageBoxW( HWND_DESKTOP, L" Xwidwowia :3 ( Please Laugh!!!!!1111 ) - Sapphire (DEBUG MODE) ", L" Zynth.exe ", MB_YESNO | MB_ICONWARNING ) == IDNO )
        ExitProcess( EXIT_SUCCESS );
    if ( MessageBoxW( HWND_DESKTOP, L" Are You A Xoltus? ", L" Zynth.exe ", MB_YESNO | MB_ICONWARNING ) == IDNO )
        ExitProcess( EXIT_SUCCESS );

    // This part was migrated, refer to Payloads.cc "LayeredShaderThread"

    GDISHADER_PARAMS pGdiPayloadParams[ ] = {
        { 5, LayerlessShader1 },
        { 5, LayerlessShader2 },
        { 5, LayerlessShader3 },
        { 5, LayerlessShader4 },
        { 5, LayerlessShader5 },
        { 5, LayerlessShader6 },
        { 5, LayerlessShader7 },
        { 5, LayerlessShader8 }
    };
    HANDLE Shortbeats = CreateThread( NULL, 0, ( PTHREAD_START_ROUTINE )ShortbeatThread, NULL, 0, NULL );
    CreateThread( NULL, 0, ( PTHREAD_START_ROUTINE ) WindowMess, NULL, 0, NULL );
    //CreateThread( NULL, 0, ( PTHREAD_START_ROUTINE ) RandomPrograms, NULL, 0, NULL );
    //CreateThread( NULL, 0, ( PTHREAD_START_ROUTINE ) CursorMove, NULL, 0, NULL );
    CreateThread( NULL, 0, ( PTHREAD_START_ROUTINE ) LayeredShaderThread, NULL, 0, NULL );
    CreateThread( NULL, 0, ( PTHREAD_START_ROUTINE ) Redrawer, NULL, 0, NULL );
    while ( ! bTrigger ) { 
        GDISHADER_PARAMS gShaderParam = pGdiPayloadParams[Xorshift( ) % _countof(pGdiPayloadParams)];
        ExecuteShader((GDI_SHADER*)gShaderParam.pGdiShader, gShaderParam.fDuration, 5);
    }
    TerminateThread( Shortbeats, EXIT_SUCCESS );
    ExitProcess( EXIT_SUCCESS );

    return 0;
}
