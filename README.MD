## Домашнее задание к Уроку 1. Работа с сетью: чтение и запись данных в сеть. Клиентские и серверные приложения:

Попробуйте переработать приложение, добавив подтверждение об отправке сообщений как в сервер, так и в клиент.

---
## Решение:

Приложение переработано следующим образом:
1. В метод Server() добавлено подтверждение об отправке сообщения клиенту(строки 37 - 41):
``` 
    var answerData = answerMessage.MessageToJson();
    byte[] bytes = Encoding.ASCII.GetBytes(answerData);
    udpServer.Send(bytes, bytes.Length, localRemouteEndPoint);

    Console.WriteLine("Сообщение отпавлено (клиенту)!");
```
2. В метод  Client(string name, string ip) добавлено подтверждение об отправке сообщения серверу(строки 65 - 69):
```    
    var data = mess.MessageToJson();
    byte[] bytes = Encoding.ASCII.GetBytes(data);
    udpClient.Send(bytes, bytes.Length, localRemouteEndPoint);

    Console.WriteLine("Сообщение отпавлено!");
```