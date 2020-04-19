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
		case WSAEINTR:				 msgText = "Работа функции прервана\n";						  break;
		case WSAEACCES:				 msgText = "Разрешение отвергнуто\n";						  break;
		case WSAEFAULT:				 msgText = "Ошибочный адрес\n";								  break;
		case WSAEINVAL:				 msgText = "Ошибка в аргументе\n";							  break;
		case WSAEMFILE:				 msgText = "Слишком много файлов открыто\n";				  break;
		case WSAEWOULDBLOCK:		 msgText = "Ресурс временно недоступен\n";					  break;
		case WSAEINPROGRESS:		 msgText = "Операция в процессе развития\n";				  break;
		case WSAEALREADY: 			 msgText = "Операция уже выполняется\n";					  break;
		case WSAENOTSOCK:   		 msgText = "Сокет задан неправильно\n";						  break;
		case WSAEDESTADDRREQ:		 msgText = "Требуется адрес расположения\n";				  break;
		case WSAEMSGSIZE:  			 msgText = "Сообщение слишком длинное\n";				      break;
		case WSAEPROTOTYPE:			 msgText = "Неправильный тип протокола для сокета\n";		  break;
		case WSAENOPROTOOPT:		 msgText = "Ошибка в опции протокола\n";					  break;
		case WSAEPROTONOSUPPORT:	 msgText = "Протокол не поддерживается\n";					  break;
		case WSAESOCKTNOSUPPORT:	 msgText = "Тип сокета не поддерживается\n";				  break;
		case WSAEOPNOTSUPP:			 msgText = "Операция не поддерживается\n";					  break;
		case WSAEPFNOSUPPORT:		 msgText = "Тип протоколов не поддерживается\n";			  break;
		case WSAEAFNOSUPPORT:		 msgText = "Тип адресов не поддерживается протоколом\n";	  break;
		case WSAEADDRINUSE:			 msgText = "Адрес уже используется\n";						  break;
		case WSAEADDRNOTAVAIL:		 msgText = "Запрошенный адрес не может быть использован\n";	  break;
		case WSAENETDOWN:			 msgText = "Сеть отключена\n";								  break;
		case WSAENETUNREACH:		 msgText = "Сеть не достижима\n";							  break;
		case WSAENETRESET:			 msgText = "Сеть разорвала соединение\n";					  break;
		case WSAECONNABORTED:		 msgText = "Программный отказ связи\n";						  break;
		case WSAECONNRESET:			 msgText = "Связь восстановлена\n";							  break;
		case WSAENOBUFS:			 msgText = "Не хватает памяти для буферов\n";				  break;
		case WSAEISCONN:			 msgText = "Сокет уже подключен\n";							  break;
		case WSAENOTCONN:			 msgText = "Сокет не подключен\n";							  break;
		case WSAESHUTDOWN:			 msgText = "Нельзя выполнить send: сокет завершил работу\n";  break;
		case WSAETIMEDOUT:			 msgText = "Закончился отведенный интервал  времени\n";		  break;
		case WSAECONNREFUSED:		 msgText = "Соединение отклонено\n";						  break;
		case WSAEHOSTDOWN:			 msgText = "Хост в неработоспособном состоянии\n";			  break;
		case WSAEHOSTUNREACH:		 msgText = "Нет маршрута для хоста\n";						  break;
		case WSAEPROCLIM:			 msgText = "Слишком много процессов\n";						  break;
		case WSASYSNOTREADY:		 msgText = "Сеть не доступна\n";							  break;
		case WSAVERNOTSUPPORTED:	 msgText = "Данная версия недоступна\n";					  break;
		case WSANOTINITIALISED:		 msgText = "Не выполнена инициализация WS2_32.DLL\n";		  break;
		case WSAEDISCON:			 msgText = "Выполняется отключение\n";						  break;
		case WSATYPE_NOT_FOUND:		 msgText = "Класс не найден\n";								  break;
		case WSAHOST_NOT_FOUND:		 msgText = "Хост не найден\n";								  break;
		case WSATRY_AGAIN:			 msgText = "Неавторизированный хост не найден\n";			  break;
		case WSANO_RECOVERY:		 msgText = "Неопределенная ошибка\n";						  break;
		case WSANO_DATA:			 msgText = "Нет записи запрошенного типа\n";				  break;
		case WSA_INVALID_HANDLE:	 msgText = "Указанный дескриптор события  с ошибкой\n";		  break;
		case WSA_INVALID_PARAMETER:	 msgText = "Один или более параметров с ошибкой\n";			  break;
		case WSA_IO_INCOMPLETE:		 msgText = "Объект ввода-вывода не в сигнальном состоянии\n"; break;
		case WSA_IO_PENDING:		 msgText = "Операция завершится позже\n";					  break;
		case WSA_NOT_ENOUGH_MEMORY:	 msgText = "Не достаточно памяти\n";						  break;
		case WSA_OPERATION_ABORTED:	 msgText = "Операция отвергнута\n";							  break;
		case WSAEINVALIDPROCTABLE:	 msgText = "Ошибочный сервис\n";							  break;
		case WSAEINVALIDPROVIDER:	 msgText = "Ошибка в версии сервиса\n";						  break;
		case WSAEPROVIDERFAILEDINIT: msgText = "Невозможно инициализировать сервис\n";			  break;
		case WSASYSCALLFAILURE:		 msgText = "Аварийное завершение системного вызова\n";		  break;
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
	cout << "Всего принято: " << accepted << " байт" << endl;
	cout << "Всего отправлено: " << sent << " байт" << endl;
	cout << "Время передачи: " << (t2-t1)/CLOCKS_PER_SEC << " сек" << endl;
	cout << endl;

	return 0;
}