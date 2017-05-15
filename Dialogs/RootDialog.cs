using System;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using POC_Channel9_bot.Sanitizers;
using POC_Channel9_bot.Conversations;

namespace POC_Channel9_bot.Dialogs
{
    [Serializable]
    public class RootDialog : IDialog<object>
    {
        public Task StartAsync(IDialogContext context)
        {
            context.Wait(MessageReceivedAsync);

            return Task.CompletedTask;
        }

        private string SanitizeMessage(string botmessage)
        {
            string message = botmessage;
            if (botmessage == null || botmessage == string.Empty)
            {
                message = Resources.en_us.resources.defaultMessage;
            }
            var sanitizeFactory = new EscapeSanitizer();
            message = sanitizeFactory.Sanitize(botmessage);
            return message;
        }

        private string BuildResponse(string message)
        {
            string replyMessage = Resources.en_us.resources.defaultMessage;
            var conversationbuilder = new ConversationBuilder();
            try
            {
                if (conversationbuilder.Read(message) != string.Empty)
                {
                    replyMessage = conversationbuilder.Read(message);
                }
            }
            catch (Exception e)
            {
                throw (e);
            }
            return replyMessage;
        }

        private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<object> result)
        {
            var activity = await result as Activity;
            string message = SanitizeMessage(activity.Text);
            string replyMessage = BuildResponse(message.Trim().ToLower());

            // calculate something for us to return
            //int length = (activity.Text ?? string.Empty).Length;

            Activity reply = activity.CreateReply(replyMessage);
            // return our reply to the user
            //await context.PostAsync($"You sent {activity.Text} which was {length} characters");

            await context.PostAsync(reply);
            context.Wait(MessageReceivedAsync);
        }
    }
}