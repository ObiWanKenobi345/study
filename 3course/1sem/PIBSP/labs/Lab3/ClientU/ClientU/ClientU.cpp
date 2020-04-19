// ClientU.cpp: ���������� ����� ����� ��� ����������� ����������.
//

/*UDP � ���� �� �������� ��������� TCP / IP, ������ ������� ���������� ��� ���������.
� UDP ������������ ���������� ����� �������� ��������� ������ ������ �� IP - ���� ��� ������������� 
���������������� ��������� ��� ��������� ����������� ������� �������� ��� ����� ������.*/
/*
+ - ������� ������� ������, ��������� ����� ����������������� ��������
- - �� ����������� �������� ������, ��������� ����� ������������ �����
*/

#include "stdafx.h"
#include "Winsock2.h"
#include<iostream>
#include<string>
#include<ctime>
#pragma comment (lib,"WS2_32.lib")
#pragma warning (disable: 4996)
using namespace std;

string GetErrorMsgText(int code)
{
	string msgText;
	switch (code)                     
	{
		case WSAEINTR: msgText = "������ ������� �������� "; break;
		case WSAEACCES: msgText = "���������� ����������"; break;
		case WSAEFAULT: msgText = "��������� �����"; break;
		case WSAEINVAL: msgText = "������ � ��������� "; break;
		case WSAEMFILE: msgText = "������� ����� ������ �������"; break;
		case WSAEWOULDBLOCK: msgText = "������ �������� ����������"; break;
		case WSAEINPROGRESS: msgText = "�������� � �������� ��������"; break;
		case WSAEALREADY: msgText = "�������� ��� ����������� "; break;
		case WSAENOTSOCK: msgText = "����� ����� ����������� "; break;
		case WSAEDESTADDRREQ: msgText = "��������� ����� ������������ "; break;
		case WSAEMSGSIZE: msgText = "��������� ������� �������  "; break;
		case WSAEPROTOTYPE: msgText = "������������ ��� ��������� ��� ������ "; break;
		case WSAENOPROTOOPT: msgText = "������ � ����� ���������"; break;
		case WSAEPROTONOSUPPORT: msgText = "�������� �� �������������� "; break;
		case WSAESOCKTNOSUPPORT: msgText = "��� ������ �� �������������� "; break;
		case WSAEOPNOTSUPP: msgText = "�������� �� �������������� "; break;
		case WSAEPFNOSUPPORT: msgText = "��� ���������� �� �������������� "; break;
		case WSAEAFNOSUPPORT: msgText = "��� ������� �� �������������� ����������"; break;
		case WSAEADDRINUSE: msgText = "����� ��� ������������ "; break;
		case WSAEADDRNOTAVAIL: msgText = "����������� ����� �� ����� ���� �����������"; break;
		case WSAENETDOWN: msgText = "���� ��������� "; break;
		case WSAENETUNREACH: msgText = "���� �� ���������"; break;
		case WSAENETRESET: msgText = "���� ��������� ����������"; break;
		case WSAECONNABORTED: msgText = "����������� ����� ����� "; break;
		case WSAECONNRESET: msgText = "����� ������������� "; break;
		case WSAENOBUFS: msgText = "�� ������� ������ ��� �������"; break;
		case WSAEISCONN: msgText = "����� ��� ���������"; break;
		case WSAENOTCONN: msgText = "����� �� ���������"; break;
		case WSAESHUTDOWN: msgText = "������ ��������� send: ����� �������� ������"; break;
		case WSAETIMEDOUT: msgText = "���������� ���������� ��������  �������"; break;
		case WSAECONNREFUSED: msgText = "���������� ���������  "; break;
		case WSAEHOSTDOWN: msgText = "���� � ����������������� ���������"; break;
		case WSAEHOSTUNREACH: msgText = "��� �������� ��� ����� "; break;
		case WSAEPROCLIM: msgText = "������� ����� ��������� "; break;
		case WSASYSNOTREADY: msgText = "���� �� �������� "; break;
		case WSAVERNOTSUPPORTED: msgText = "������ ������ ���������� "; break;
		case WSANOTINITIALISED: msgText = "�� ��������� ������������� WS2_32.DLL"; break;
		case WSAEDISCON: msgText = "����������� ����������"; break;
		case WSATYPE_NOT_FOUND: msgText = "����� �� ������ "; break;
		case WSAHOST_NOT_FOUND: msgText = "���� �� ������"; break;
		case WSATRY_AGAIN: msgText = "������������������ ���� �� ������ "; break;
		case WSANO_RECOVERY: msgText = "��������������  ������ "; break;
		case WSANO_DATA: msgText = "��� ������ ������������ ���� "; break;
		case WSA_INVALID_HANDLE: msgText = "��������� ���������� �������  � �������   "; break;
		case WSA_INVALID_PARAMETER: msgText = "���� ��� ����� ���������� � �������   "; break;
		case WSA_IO_INCOMPLETE: msgText = "������ �����-������ �� � ���������� ���������"; break;
		case WSA_IO_PENDING: msgText = "�������� ���������� �����  "; break;
		case WSA_NOT_ENOUGH_MEMORY: msgText = "�� ���������� ������ "; break;
		case WSA_OPERATION_ABORTED: msgText = "�������� ���������� "; break;
		default: msgText = "***ERROR***"; break;
	};

	return msgText;
}

string SetErrorMsgText(string msgText, int code)
{
	return msgText + GetErrorMsgText(code);
}

int main()
{
	setlocale(LC_ALL,"Russian");

	WSADATA wsaData;
	SOCKET sS;
	try {
		if (WSAStartup(MAKEWORD(2, 0), &wsaData) != 0)
			throw SetErrorMsgText("Startup:", WSAGetLastError());
		
		if ((sS = socket(AF_INET, SOCK_DGRAM, NULL)) == INVALID_SOCKET)
			throw SetErrorMsgText("socket:", WSAGetLastError());

		SOCKADDR_IN to;              // ���������  ������ �������
			
		to.sin_family = AF_INET;    // ������������ ip-���������  
		to.sin_port = htons(2000);   // ���� 2000
		to.sin_addr.s_addr = inet_addr("127.0.0.1"); // ����� �������  
					 	
		int lto = sizeof(to);
							 		
		char ptr[200] = "", ibuf[50], obuf[50] = "Hello from ClientU", str[50] = "";
		int lobuf = 0, iobuf=0, count;
		
		cout << "Enter count of messages:" << endl;
		cin >> count;
		
		clock_t time;
		time = clock();
		for (int i = 1; i <=count; i++)
		{
		 	_itoa(i, str, 10); // ����������� ����� ����� value � ������ string � ������� radix
			strcpy(ptr, obuf);
			strcat(ptr, str);
				
			if (lobuf = sendto(sS, ptr, sizeof(ptr), 0, (LPSOCKADDR)&to, sizeof(to)) == SOCKET_ERROR)
			{
				throw  SetErrorMsgText("sendto:", WSAGetLastError());
			}
		
			cout << ptr << endl;

			if (iobuf = recvfrom(sS, ptr, sizeof(ptr), 0, (LPSOCKADDR)&to, &lto) == SOCKET_ERROR) 
			{
				throw  SetErrorMsgText("recvfrom:", WSAGetLastError());
					
			}		
		}
		time = clock() - time;

		cout << (double)time / CLOCKS_PER_SEC << endl;

		if (closesocket(sS) == SOCKET_ERROR)
			throw SetErrorMsgText("Cleanup:", WSAGetLastError());
		if (WSACleanup() == SOCKET_ERROR)
			throw SetErrorMsgText("Cleanup:", WSAGetLastError());
	}

	catch (string errorMsgText)
	{
		cout << endl << errorMsgText;
	}
	return 0;
}
