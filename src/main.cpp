/*
* TopDown
* 
* Author: Tyler Holewinski (tsh6656@rit.edu)
* GitHub: https://github.com/erwijet/topdown
* Created: Sat 01/15/2022
*/

#include "main.h"

using namespace std;

BOOL GetDesktopResolution(int& horiz, int& vert) {
	RECT desktop;
	const HWND hDesktop = GetDesktopWindow();
	GetWindowRect(hDesktop, &desktop);

	horiz = desktop.right;
	vert = desktop.bottom;

	return TRUE;
}

BOOL ResizeWindow(HWND hwnd, WIN_DIRECTION direc) {
	int width, height;
	GetDesktopResolution(width, height);

	int y = (direc == 1) ? height / 2 : 0;
	SetWindowPos(hwnd, HWND_TOP, 0, y, width, height / 2, SWP_SHOWWINDOW);

	return TRUE;
}

BOOL MoveCurWindow(WIN_DIRECTION direc) {
	HWND hCurWin = GetForegroundWindow();

	cout << "moving window @" << hCurWin << "\t\t" << (direc == WIN_DIRECTION_UP ? "UP" : "DOWN") << "\t\t\t";
	return ResizeWindow(hCurWin, direc);
}

int GracefullyExit(void) {
	ShowWindow(FindWindowA("ConsoleWindowClass", NULL), true);
	cout << "Unregistering Hotkeys...";

	BOOL _hk_up_unregistered = UnregisterHotKey(NULL, HK_UP);
	BOOL _hk_down_unregisterd = UnregisterHotKey(NULL, HK_DOWN);
	BOOL _hk_show_unregistered = UnregisterHotKey(NULL, HK_SHOW);
	BOOL _hk_quit_unregisted = UnregisterHotKey(NULL, HK_QUIT);

	cout << "\t\t\t\t\t" << (
		_hk_up_unregistered &&
		_hk_down_unregisterd &&
		_hk_show_unregistered &&
		_hk_quit_unregisted ? "done" : "fail") << endl << "Press <enter> to exit...";
	cin.get();

	return 0;
}

void _RegisterHotkey(int id, UINT vk, char* desc, char* instr) {
	cout << "Registering Hotkey " << instr << "\t(" << desc << ")\t\t";
	cout << (RegisterHotKey(NULL, id, MOD_ALT | MOD_NOREPEAT, vk) ? "done" : "fail") << endl;
}

int main() {
	int toggleVisibility = 1;

	_RegisterHotkey(HK_UP, VK_U, "Move Window Up", "ALT+U");
	_RegisterHotkey(HK_DOWN, VK_D, "Move Window Down", "ALT+D");
	_RegisterHotkey(HK_QUIT, VK_Q, "Gracefully Quit", "ALT+Q");
	_RegisterHotkey(HK_SHOW, VK_H, "Hide/Show Window", "ALT+H");

	cout << endl << "TopHalf is ready!" << endl;

	MSG msg = { 0 };
	while (GetMessage(&msg, NULL, 0, 0) != 0) {
		if (msg.message == WM_HOTKEY) {
			switch (msg.wParam)
			{
			case HK_SHOW:
				ShowWindow(FindWindowA("ConsoleWindowClass", NULL), (toggleVisibility *= -1) > 0);
				break;
			case HK_UP:
				cout << (MoveCurWindow(WIN_DIRECTION_UP) ? "done" : "fail") << endl;
				break;
			case HK_DOWN:
				cout << (MoveCurWindow(WIN_DIRECTION_DOWN) ? "done" : "fail") << endl;
				break;
			case HK_QUIT:
				return GracefullyExit();
			default:
				break;
			}
		}
	}
}
