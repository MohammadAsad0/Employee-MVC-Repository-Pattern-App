using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class ResponseDTO
    {
        public ResponseDTO()
        {
            Message = new List<Message>();
        }

        public bool Result { get; set; }
        public List<Message> Message { get; set; }
    }

    public class Message
    {
        public string Key { get; set; }
        public string ErrorMsg { get; set; }

        public Message(string key, string errorMsg)
        {
            Key = key;
            ErrorMsg = errorMsg;
        }
    }

    public class IDDto
    {
        public long ID { get; set; }
    }
}
