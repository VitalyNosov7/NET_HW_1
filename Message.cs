﻿using System.Text.Json;

namespace task_1
{
    public class Message
    {
        public string NickName { get; set; }
        public DateTime DateMessage { get; set; }
        public string TextMessage { get; set; }

        public  string MessageToJson()
        {
            return JsonSerializer.Serialize(this);
        }

        public static Message MessageFromJson(string json)
        {
            return JsonSerializer.Deserialize<Message>(json) ?? new Message();
        }
    }
}