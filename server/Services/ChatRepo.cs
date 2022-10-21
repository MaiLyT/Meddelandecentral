// using Meddelandecentral.Models;

// namespace Meddelandecentral.Services
// {
//     public interface IChatRepo
//     {
//         IEnumerable<ChatMessage>GetALl(); 
//         void AddChat(ChatMessage msg);
//     }

//     public class ChatRepo
//     {
//         private readonly List<ChatMessage> chats = new List<ChatMessage>();

//         public IEnumerable<ChatMessage> GetAll()
//         {
//             return chats;
//         } 

//         public void AddChat(ChatMessage msg)
//         {
//             //msg.Id = Guid.NewGuid();
//             chats.Add(msg);
//         } 
//     }
// }