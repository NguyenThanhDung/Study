#include <iostream>
#include <conio.h>
#include <windows.h>

using namespace std;

enum State
{
	READY,
	SHOW_MENU,
	WAITING_FOR_INPUT,
	MENU1,
	MENU2,
	MENU3,
	WAITING_FOR_SERVER_RESPONSE,
	RECEIVED_SERVER_RESPONSE,
	QUIT
};

int g_lastTime = 0;
int g_requestTime = 0;
State g_state = State::READY;

int OS_GetTime(void)
{
	LARGE_INTEGER ticks;
	LARGE_INTEGER time;

	QueryPerformanceFrequency(&ticks);
	QueryPerformanceCounter(&time);

	static LONGLONG old_time = time.QuadPart;

	return (int)(((time.QuadPart - old_time) * 1000) / ticks.QuadPart);
}

void ShowMenu()
{
	cout << "1. One" << endl;
	cout << "2. Two" << endl;
	cout << "3. Three" << endl;
}

bool Update()
{
	switch (g_state)
	{
	case State::READY:
	{
		g_state = State::SHOW_MENU;
		break;
	}
	case State::SHOW_MENU:
	{
		ShowMenu();
		g_state = State::WAITING_FOR_INPUT;
		break;
	}
	case State::WAITING_FOR_INPUT:
	{
		if (_kbhit())
		{
			switch (_getch())
			{
			case 49:
				g_state = State::MENU1;
				break;
			case 50:
				g_state = State::MENU2;
				break;
			case 51:
				g_state = State::MENU3;
				break;
			case 27:
				g_state = State::QUIT;
				break;
			}
		}
		break;
	}
	case State::MENU1:
	{
		cout << "Action 1" << endl;
		g_state = State::SHOW_MENU;
		break;
	}
	case State::MENU2:
	{
		cout << "Action 2" << endl;
		g_state = State::SHOW_MENU;
		break;
	}
	case State::MENU3:
	{
		cout << "Action 3" << endl;
		g_state = State::WAITING_FOR_SERVER_RESPONSE;
		g_lastTime = OS_GetTime();
		g_requestTime = g_lastTime;
		break;
	}
	case State::WAITING_FOR_SERVER_RESPONSE:
	{
		int thisTime = OS_GetTime();
		if (thisTime - g_requestTime > 7000)
		{
			g_state = State::RECEIVED_SERVER_RESPONSE;
		}
		else if (thisTime - g_lastTime > 1000)
		{
			g_lastTime = thisTime;
			cout << "Waiting for server response..." << endl;
		}
		break;
	}
	case State::RECEIVED_SERVER_RESPONSE:
	{
		cout << "Received server response" << endl;
		g_state = State::SHOW_MENU;
		break;
	}
	case State::QUIT:
	{
		return false;
	}
	}
	return true;
}

void main()
{
	while (Update()) {}
	cout << "Finished." << endl;
}