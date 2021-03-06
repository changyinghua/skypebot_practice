﻿using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using System;
using Bot_Application1.Dialogs;

namespace Bot_Application1 {
    [BotAuthentication]
    public class MessagesController : ApiController {
        /// <summary>
        /// POST: api/Messages
        /// Receive a message from a user and reply to it
        /// </summary>
        public async Task<HttpResponseMessage> Post([FromBody]Activity activity) {
            if (activity.Type == ActivityTypes.Message) {

                string userName = "";
                string id = "";
                if (activity.From.Name != null)
                {
                    userName = activity.From.Name;//Here we are getting user name
                    id = activity.From.Id;
                }
                ConnectorClient connector = new ConnectorClient(new Uri(activity.ServiceUrl));
                Activity reply = activity.CreateReply(userName);
                activity.TextFormat = "markdown";
                Activity reply2 = activity.CreateReply(id);
              //  await connector.Conversations.ReplyToActivityAsync(reply);
              //  await connector.Conversations.ReplyToActivityAsync(reply2);
                Contact.Id = id;
                Contact.Name = userName;
                await Conversation.SendAsync(activity, () => new Dialogs.RootDialog());
            } else {
                HandleSystemMessage(activity);
            }
            var response = Request.CreateResponse(HttpStatusCode.OK);
            return response;
        }

        private Activity HandleSystemMessage(Activity message) {
            if (message.Type == ActivityTypes.DeleteUserData) {
                // Implement user deletion here
                // If we handle user deletion, return a real message
            } else if (message.Type == ActivityTypes.ConversationUpdate) {
                // Handle conversation state changes, like members being added and removed
                // Use Activity.MembersAdded and Activity.MembersRemoved and Activity.Action for info
                // Not available in all channels
            } else if (message.Type == ActivityTypes.ContactRelationUpdate) {
                // Handle add/remove from contact lists
                // Activity.From + Activity.Action represent what happened
            } else if (message.Type == ActivityTypes.Typing) {
                // Handle knowing tha the user is typing
            } else if (message.Type == ActivityTypes.Ping) {
            }

            return null;
        }
    }
}