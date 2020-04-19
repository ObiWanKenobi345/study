#include "stdafx.h"
#include <string>
#include "iostream"
#include "windows.h"
#include "time.h"

using namespace std;

string GetErrorMail(int code)
{
	string msgText = "";
	
	switch (code)
	{
		case WSAEINTR: msgText = "WSAEINTR"; break;
	    case WSAEACCES:	msgText = "WSAEACCES"; break;
	    case WSAEFAULT:	msgText = "WSAEFAULT"; break;
		default: msgText = "Error";
	};

	return msgText;
}

string SetErrorMail(string msgText,int code)
{
	return msgText + GetErrorMail(code);
}

int _tmain(int argc, _TCHAR* argv[])
{	setlocale(LC_CTYPE, "Russian");
	
	cout << "ServerMS" << endl;
	
	try
	{
		HANDLE hMS;
		double t1, t2;

		while(true)
		{
			int i=0;
			
			cout << "Ожидание сообщения 3 минуты...\n";
			if((hMS = CreateMailslot(
				L"\\\\.\\mailslot\\Box", // name
				500, // maxMesageSize
				180000, // timeout
				NULL)) == INVALID_HANDLE_VALUE) // security attributes
				throw SetErrorMail("CreateMailslot", GetLastError());
			
			char rbuf[50];
			DWORD rms;
			
			do
			{
				i++;

				if(!ReadFile(hMS, rbuf, sizeof(rbuf), &rms, NULL))
					throw SetErrorMail("ReadFile", GetLastError());
				
				if(i == 1)
					t1 = clock();

				cout << rbuf << endl;
			}
			while(strcmp(rbuf, " ")!=0);
			
			t2 = clock();

			cout << "Время передачи: " << (t2 - t1) / 1000 << " сек." << endl;
			cout << "Количество сообщений: " << i - 1 << endl << endl;

			if(!CloseHandle(hMS))
				throw "Error: CloseHandle";
		}
	}
	catch(string e)
	{
		cout << e << endl;
	}
	
	return 0;
}