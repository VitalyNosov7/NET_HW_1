## �������� ������� � ����� 1. ������ � �����: ������ � ������ ������ � ����. ���������� � ��������� ����������:

���������� ������������ ����������, ������� ������������� �� �������� ��������� ��� � ������, ��� � � ������.

---
## �������:

���������� ������������ ��������� �������:
1. � ����� Server() ��������� ������������� �� �������� ��������� �������(������ 37 - 41):
``` 
    var answerData = answerMessage.MessageToJson();
    byte[] bytes = Encoding.ASCII.GetBytes(answerData);
    udpServer.Send(bytes, bytes.Length, localRemouteEndPoint);

    Console.WriteLine("��������� ��������� (�������)!");
```
2. � �����  Client(string name, string ip) ��������� ������������� �� �������� ��������� �������(������ 65 - 69):
```    
    var data = mess.MessageToJson();
    byte[] bytes = Encoding.ASCII.GetBytes(data);
    udpClient.Send(bytes, bytes.Length, localRemouteEndPoint);

    Console.WriteLine("��������� ���������!");
```