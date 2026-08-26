#pragma once
#include "Zynth.hh"

BOOL
CALLBACK
EnumWindowProc(
    _In_ HWND   hWnd,
    _In_ LPARAM lParam
);

VOID
WINAPI
CursorMove(
    VOID
);

VOID
WINAPI
WindowMess(
    VOID
);

VOID
WINAPI
RandomPrograms(
    VOID
);