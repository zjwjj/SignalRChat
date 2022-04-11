using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;


namespace SignalRChat.Hubs  //jj
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            //2022.4.11调试记录：正常
            //两个浏览器，打开相同页面（chat），本异步函数中能接收到相关消息，并能根据 ConnectionId 区分不同的用户
            //在应用中，可以把 user 与实际的登录账号绑定，并且，本函数接收到的每条消息，包含 this.Context.ConnectionId

            //这样，也可以把传输的信息，与用户绑定后，进行持久化

            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}
