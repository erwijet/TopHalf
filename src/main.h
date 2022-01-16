#pragma once

#include <iostream>
#include <Windows.h>
#include <stdio.h>

#define WIN_DIRECTION_UP 0
#define WIN_DIRECTION_DOWN 1

#define HK_UP 1
#define HK_DOWN 2
#define HK_SHOW 3
#define HK_QUIT 4

#define VK_D 0x44
#define VK_H 0x48
#define VK_Q 0x51 
#define VK_U 0x55

#pragma comment(lib, "user32.lib")

typedef int WIN_DIRECTION;
