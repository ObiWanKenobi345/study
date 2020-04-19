// ServerU.cpp: ���������� ����� ����� ��� ����������� ����������.
//

#include "stdafx.h"
#include"Winsock2.h"
#include "Windows.h"
#include<iostream>
#include<string>
#pragma comment(lib,"WS2_32.lib")
#pragma warning (disable:4996)
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
	WSADATA wsaData;
	SOCKET sS;
	try {
		if (WSAStartup(MAKEWORD(2, 0), &wsaData) != 0)
			throw SetErrorMsgText("Startup:", WSAGetLastError());

		if ((sS = socket(AF_INET, SOCK_DGRAM, NULL)) == INVALID_SOCKET)
			throw SetErrorMsgText("socket:", WSAGetLastError());

		SOCKADDR_IN serv;

		serv.sin_family = AF_INET;
		serv.sin_port = htons(2000);
		serv.sin_addr.s_addr = INADDR_ANY;

		if (bind(sS, (LPSOCKADDR)&serv, sizeof(serv)) == SOCKET_ERROR)
			throw SetErrorMsgText("bind:", WSAGetLastError());


		SOCKADDR_IN from;
		char buf[200];

		int lfrom = sizeof(from);
		int  libuf = 0, lobuf = 0;

		while (1) {
			if (libuf = recvfrom(sS, buf, sizeof(buf), 0, (LPSOCKADDR)&from, &lfrom) == SOCKET_ERROR)
				throw  SetErrorMsgText("recvfrom:", WSAGetLastError());

			//Sleep(2000);
			cout << buf << endl;

			if (lobuf = sendto(sS, buf, sizeof(buf), 0, (LPSOCKADDR)&from, sizeof(from)) == SOCKET_ERROR)
				throw  SetErrorMsgText("sendto:", WSAGetLastError());
		}

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




