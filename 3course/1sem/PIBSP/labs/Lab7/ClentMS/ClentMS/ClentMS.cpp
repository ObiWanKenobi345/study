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
	
	cout << "ClientMS" << endl << endl;
	
	try
	{
		HANDLE hMS;
		double t1, t2;

		if((hMS = CreateFile(
			L"\\\\.\\mailslot\\Box", // name
			GENERIC_WRITE, // access mode
			FILE_SHARE_READ | FILE_SHARE_WRITE, // share access
			NULL, // security attributes 
			OPEN_EXISTING, // creation
			NULL, // gile attributes
			NULL)) == INVALID_HANDLE_VALUE) // handle template
			throw SetErrorMail("CreateFile: ", GetLastError());

		char wbuf[50] = "Hello from mailslot-client ";
		DWORD wms;

		t1 = clock();
		
		for(int i=0; i<10; i++)
		{
			char q[6];
			sprintf_s(q,"%d",i+1);
			char buf[sizeof(wbuf)+sizeof(q)];
			strcpy_s(buf,wbuf);
			strcat_s(buf,q);

			Sleep(1000);

			if(!WriteFile(hMS, buf, sizeof(wbuf), &wms, NULL))
				throw SetErrorMail("WriteFile: ", GetLastError());
			
			cout << "Message " << i +1  << endl;
		}
		
		t2 = clock();
		
		if(!WriteFile(hMS, " ", sizeof(" "), &wms, NULL))
			throw SetErrorMail("WriteFile: ", GetLastError());
		
		if(!CloseHandle(hMS))
			throw "Error: CloseHandle";

		cout << endl << "Время передачи: " << (t2 - t1) / 1000 << " сек." << endl << endl;
	}
	catch(string e)
	{
		cout << e << endl;
	}
	
	return 0;
}