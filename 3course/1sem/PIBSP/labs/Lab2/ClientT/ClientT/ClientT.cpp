#include "stdafx.h"
#include "Winsock2.h"
#include <iostream>
#include <string>
#include <time.h>
#include <windows.h>
#pragma comment(lib, "WS2_32.lib")

using namespace std;

string GetErrorMsgText (int code)
{
	string msgText;

	switch (code)
	{
		case WSAEINTR:				 msgText = "������ ������� ��������\n";						  break;
		case WSAEACCES:				 msgText = "���������� ����������\n";						  break;
		case WSAEFAULT:				 msgText = "��������� �����\n";								  break;
		case WSAEINVAL:				 msgText = "������ � ���������\n";							  break;
		case WSAEMFILE:				 msgText = "������� ����� ������ �������\n";				  break;
		case WSAEWOULDBLOCK:		 msgText = "������ �������� ����������\n";					  break;
		case WSAEINPROGRESS:		 msgText = "�������� � �������� ��������\n";				  break;
		case WSAEALREADY: 			 msgText = "�������� ��� �����������\n";					  break;
		case WSAENOTSOCK:   		 msgText = "����� ����� �����������\n";						  break;
		case WSAEDESTADDRREQ:		 msgText = "��������� ����� ������������\n";				  break;
		case WSAEMSGSIZE:  			 msgText = "��������� ������� �������\n";				      break;
		case WSAEPROTOTYPE:			 msgText = "������������ ��� ��������� ��� ������\n";		  break;
		case WSAENOPROTOOPT:		 msgText = "������ � ����� ���������\n";					  break;
		case WSAEPROTONOSUPPORT:	 msgText = "�������� �� ��������������\n";					  break;
		case WSAESOCKTNOSUPPORT:	 msgText = "��� ������ �� ��������������\n";				  break;
		case WSAEOPNOTSUPP:			 msgText = "�������� �� ��������������\n";					  break;
		case WSAEPFNOSUPPORT:		 msgText = "��� ���������� �� ��������������\n";			  break;
		case WSAEAFNOSUPPORT:		 msgText = "��� ������� �� �������������� ����������\n";	  break;
		case WSAEADDRINUSE:			 msgText = "����� ��� ������������\n";						  break;
		case WSAEADDRNOTAVAIL:		 msgText = "����������� ����� �� ����� ���� �����������\n";	  break;
		case WSAENETDOWN:			 msgText = "���� ���������\n";								  break;
		case WSAENETUNREACH:		 msgText = "���� �� ���������\n";							  break;
		case WSAENETRESET:			 msgText = "���� ��������� ����������\n";					  break;
		case WSAECONNABORTED:		 msgText = "����������� ����� �����\n";						  break;
		case WSAECONNRESET:			 msgText = "����� �������������\n";							  break;
		case WSAENOBUFS:			 msgText = "�� ������� ������ ��� �������\n";				  break;
		case WSAEISCONN:			 msgText = "����� ��� ���������\n";							  break;
		case WSAENOTCONN:			 msgText = "����� �� ���������\n";							  break;
		case WSAESHUTDOWN:			 msgText = "������ ��������� send: ����� �������� ������\n";  break;
		case WSAETIMEDOUT:			 msgText = "���������� ���������� ��������  �������\n";		  break;
		case WSAECONNREFUSED:		 msgText = "���������� ���������\n";						  break;
		case WSAEHOSTDOWN:			 msgText = "���� � ����������������� ���������\n";			  break;
		case WSAEHOSTUNREACH:		 msgText = "��� �������� ��� �����\n";						  break;
		case WSAEPROCLIM:			 msgText = "������� ����� ���������\n";						  break;
		case WSASYSNOTREADY:		 msgText = "���� �� ��������\n";							  break;
		case WSAVERNOTSUPPORTED:	 msgText = "������ ������ ����������\n";					  break;
		case WSANOTINITIALISED:		 msgText = "�� ��������� ������������� WS2_32.DLL\n";		  break;
		case WSAEDISCON:			 msgText = "����������� ����������\n";						  break;
		case WSATYPE_NOT_FOUND:		 msgText = "����� �� ������\n";								  break;
		case WSAHOST_NOT_FOUND:		 msgText = "���� �� ������\n";								  break;
		case WSATRY_AGAIN:			 msgText = "������������������ ���� �� ������\n";			  break;
		case WSANO_RECOVERY:		 msgText = "�������������� ������\n";						  break;
		case WSANO_DATA:			 msgText = "��� ������ ������������ ����\n";				  break;
		case WSA_INVALID_HANDLE:	 msgText = "��������� ���������� �������  � �������\n";		  break;
		case WSA_INVALID_PARAMETER:	 msgText = "���� ��� ����� ���������� � �������\n";			  break;
		case WSA_IO_INCOMPLETE:		 msgText = "������ �����-������ �� � ���������� ���������\n"; break;
		case WSA_IO_PENDING:		 msgText = "�������� ���������� �����\n";					  break;
		case WSA_NOT_ENOUGH_MEMORY:	 msgText = "�� ���������� ������\n";						  break;
		case WSA_OPERATION_ABORTED:	 msgText = "�������� ����������\n";							  break;
		case WSAEINVALIDPROCTABLE:	 msgText = "��������� ������\n";							  break;
		case WSAEINVALIDPROVIDER:	 msgText = "������ � ������ �������\n";						  break;
		case WSAEPROVIDERFAILEDINIT: msgText = "���������� ���������������� ������\n";			  break;
		case WSASYSCALLFAILURE:		 msgText = "��������� ���������� ���������� ������\n";		  break;
		default:					 msgText = "Error\n";										  break;
	};
	return msgText;
}

string SetErrorMsgText (string msgText, int code)
{
	return msgText + GetErrorMsgText(code);
};

int _tmain(int argc, _TCHAR* argv[])
{	setlocale(LC_CTYPE, "Russian");
	
	string IP = "127.0.0.1";

	int count = 0,
		accepted = 0,
		sent = 0;

	cout << "ClientT" << endl;
	cout << "Enter count of messages: ";
	cin  >> count;

	clock_t t1 = 0,
			t2 = 0;

	try
	{
		SOCKET cS;
		WSADATA wsaData;
		
		if (WSAStartup(MAKEWORD(2,0), &wsaData) != 0) // init libs; 1- version windows socket
			throw SetErrorMsgText("Startup: ", WSAGetLastError());
		
		if ((cS = socket(AF_INET, SOCK_STREAM, NULL)) == INVALID_SOCKET) // create socket; 1-format; 2-type; 3-protocol
			throw SetErrorMsgText("Socket: ", WSAGetLastError());
		  
		SOCKADDR_IN serv;
		serv.sin_family  = AF_INET;
		serv.sin_port = htons(2000); // converts a u_short values from host to TCP/IP network byte order
		serv.sin_addr.s_addr = inet_addr(IP.c_str()); // from string to char

		char obuf[255] = "Hello from client ";
		
		int  libuf = 0,
			 lobuf = 0;
		char ibuf[50];

		if ((connect(cS, (sockaddr*)&serv, sizeof(serv))) == SOCKET_ERROR) // create channel with server socket
			throw SetErrorMsgText("Connect_Client: ", WSAGetLastError());
		
		t1 = clock();
		
		for (int i = 0; i < count; i++)
		{
			char inum[6];
			sprintf(inum, "%d", i+1); // Write formatted data to string
			char buf[sizeof(obuf)+sizeof(inum)];
			strcpy(buf, obuf);
			strcat(buf, inum); // copy string and will add to end

			if ((lobuf = send(cS, buf, strlen(buf)+1, NULL)) == SOCKET_ERROR)
				throw SetErrorMsgText("Send_Client: ", WSAGetLastError());

			if ((libuf = recv(cS, ibuf, sizeof(ibuf), NULL)) == SOCKET_ERROR) 
				throw SetErrorMsgText("Recv_Client: ", WSAGetLastError());

			cout << "Server: " << ibuf << endl;

			accepted += libuf;
			sent += lobuf;
		}
		
		t2 = clock();
		
		if (send(cS, "Dispose", strlen("Dispose")+1, NULL) == SOCKET_ERROR)
			throw SetErrorMsgText("Send_Client: ", WSAGetLastError());
        
		if (closesocket(cS) == SOCKET_ERROR)
			throw SetErrorMsgText("Closesocket: ", WSAGetLastError());

		if (WSACleanup() == SOCKET_ERROR)         
			throw SetErrorMsgText("Cleanup: ", WSAGetLastError());
	}
	catch (string errorMsgText)
	{
		cout << endl << errorMsgText;
	}

	cout << endl;
	cout << "����� �������: " << accepted << " ����" << endl;
	cout << "����� ����������: " << sent << " ����" << endl;
	cout << "����� ��������: " << (t2-t1)/CLOCKS_PER_SEC << " ���" << endl;
	cout << endl;

	return 0;
}