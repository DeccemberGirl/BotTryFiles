using BotTry.Enums;
using Telegram.BotAPI;
using Telegram.BotAPI.AvailableMethods;
using Telegram.BotAPI.AvailableMethods.FormattingOptions;
using Telegram.BotAPI.AvailableTypes;
using Telegram.BotAPI.Stickers;
using Telegram.BotAPI.UpdatingMessages;
using static System.Net.WebRequestMethods;
using File = System.IO.File;

namespace BotTry.UnitsTutorials
{
    public static class ButtonTypesTutorial
    {

        public static async Task ExplainSingleRowReplyButton(BotClient botClient, CallbackQuery query, CancellationToken cancellationToken = default)
        {
            if (query.Message?.Chat == null)
            {
                return;
            }

            botClient.AnswerCallbackQuery(query.Id, ButtonType.SINGLE_ROW_REPLY.ToString());
            botClient.EditMessageText(new EditMessageTextArgs(Constants.SingleRowReplyButtonMessage)
            {
                ChatId = query.Message.Chat.Id,
                MessageId = query.Message.MessageId
            });

            await botClient.SendMessageAsync(
                chatId: query.Message.Chat.Id,
                text: string.Format(Constants.ExampleButton, ButtonType.SINGLE_ROW_REPLY.ToString().ToLower()),
                cancellationToken: cancellationToken);

            var replyKeyboardMarkup = new ReplyKeyboardMarkup(new[]
                {
                    new KeyboardButton[] {
                        new KeyboardButton(Constants.ExampleCallBackWow),
                        new KeyboardButton(Constants.ExampleCallBackHm) },
                })
            {
                ResizeKeyboard = true
            };

            await botClient.SendMessageAsync(
                chatId: query.Message.Chat.Id,
                text: Constants.ExampleChoiceMessage,
                replyMarkup: replyKeyboardMarkup,
                cancellationToken: cancellationToken);
        }

        public static async Task ExplainMultiRowReplyButton(BotClient botClient, CallbackQuery query, CancellationToken cancellationToken = default)
        {
            if (query.Message?.Chat == null)
            {
                return;
            }

            botClient.AnswerCallbackQuery(query.Id, ButtonType.MULTI_ROW_REPLY.ToString());
            botClient.EditMessageText(new EditMessageTextArgs(Constants.MultiRowReplyButtonMessage)
            {
                ChatId = query.Message.Chat.Id,
                MessageId = query.Message.MessageId
            });

            await botClient.SendMessageAsync(
                chatId: query.Message.Chat.Id,
                text: string.Format(Constants.ExampleButton, ButtonType.MULTI_ROW_REPLY.ToString().ToLower()),
                cancellationToken: cancellationToken);

            var replyKeyboardMarkup = new ReplyKeyboardMarkup(new[]
                {
                    new KeyboardButton[] { 
                        new KeyboardButton(Constants.ExampleCallBackWow), 
                        new KeyboardButton(Constants.ExampleCallBackHm)},
                    new KeyboardButton[] { 
                        new KeyboardButton(Constants.ExampleCallBackGreat) },
                })
            {
                ResizeKeyboard = true
            };

            await botClient.SendMessageAsync(
                chatId: query.Message.Chat.Id,
                text: Constants.ExampleChoiceMessage,
                replyMarkup: replyKeyboardMarkup,
                cancellationToken: cancellationToken);
        }

        public static async Task ExplainRequestReplyButton(BotClient botClient, CallbackQuery query, CancellationToken cancellationToken = default)
        {
            if (query.Message?.Chat == null)
            {
                return;
            }

            botClient.AnswerCallbackQuery(query.Id, ButtonType.REQUEST_REPLY.ToString());
            botClient.EditMessageText(new EditMessageTextArgs(Constants.RequestReplyButtonMessage)
            {
                ChatId = query.Message.Chat.Id,
                MessageId = query.Message.MessageId
            });

            await botClient.SendMessageAsync(
                chatId: query.Message.Chat.Id,
                text: string.Format(Constants.ExampleButton, ButtonType.REQUEST_REPLY.ToString().ToLower()),
                cancellationToken: cancellationToken);

            var replyKeyboardMarkup = new ReplyKeyboardMarkup(new[]
            {
                new KeyboardButton[]{
                    new KeyboardButton("Share Location")
                    {
                        RequestLocation = true
                    },
                    new KeyboardButton("Share Contact")
                    {
                        RequestContact = true
                    }
                }
            })
            {
                ResizeKeyboard = true
            };

            await botClient.SendMessageAsync(
                chatId: query.Message.Chat.Id,
                text: Constants.ExampleChoiceMessage,
                replyMarkup: replyKeyboardMarkup,
                cancellationToken: cancellationToken);
        }

        public static async Task ExplainCallbackInlineButton(BotClient botClient, CallbackQuery query, CancellationToken cancellationToken = default)
        {
            if (query.Message?.Chat == null)
            {
                return;
            }

            botClient.AnswerCallbackQuery(query.Id, ButtonType.CALLBACK_INLINE.ToString());
            botClient.EditMessageText(new EditMessageTextArgs(Constants.CallbackInlineButtonMessage)
            {
                ChatId = query.Message.Chat.Id,
                MessageId = query.Message.MessageId
            });

            await botClient.SendMessageAsync(
                chatId: query.Message.Chat.Id,
                text: string.Format(Constants.ExampleButton, ButtonType.CALLBACK_INLINE.ToString().ToLower()),
                cancellationToken: cancellationToken);

            var inlineKeyboard = new InlineKeyboardMarkup(new[]
            {
                // first row
                new []
                {
                    InlineKeyboardButton.SetCallbackData(text: Constants.ExampleCallBackWow, callbackData: Constants.ExampleCallBackWow),
                    InlineKeyboardButton.SetCallbackData(text: Constants.ExampleCallBackHm, callbackData: Constants.ExampleCallBackHm)
                },
                // second row
                new []
                {
                    InlineKeyboardButton.SetCallbackData(text: Constants.ExampleCallBackGreat, callbackData: Constants.ExampleCallBackGreat)
                }
            });

            await botClient.SendMessageAsync(
                chatId: query.Message.Chat.Id,
                text: Constants.ExampleChoiceMessage,
                replyMarkup: inlineKeyboard,
                cancellationToken: cancellationToken);
        }

        public static async Task ExplainUrlInlineButton(BotClient botClient, CallbackQuery query, CancellationToken cancellationToken = default)
        {
            if (query.Message?.Chat == null)
            {
                return;
            }

            botClient.AnswerCallbackQuery(query.Id, ButtonType.URL_INLINE.ToString());
            botClient.EditMessageText(new EditMessageTextArgs(Constants.UrlInlineButtonMessage)
            {
                ChatId = query.Message.Chat.Id,
                MessageId = query.Message.MessageId
            });

            await botClient.SendMessageAsync(
                chatId: query.Message.Chat.Id,
                text: string.Format(Constants.ExampleButton, ButtonType.URL_INLINE.ToString().ToLower()),
                cancellationToken: cancellationToken);

            var inlineKeyboard = new InlineKeyboardMarkup(new[]
            {
                new InlineKeyboardButton("Link to the Repository")
                {
                    Url = "https://github.com/DeccemberGirl/BotTryFiles"
                }
            });

            await botClient.SendMessageAsync(
                chatId: query.Message.Chat.Id,
                text: Constants.ExampleChoiceMessage,
                replyMarkup: inlineKeyboard,
                cancellationToken: cancellationToken);
        }

        public static async Task ExplainSwitchInlineButton(BotClient botClient, CallbackQuery query, CancellationToken cancellationToken = default)
        {
            if (query.Message?.Chat == null)
            {
                return;
            }

            botClient.AnswerCallbackQuery(query.Id, ButtonType.SWITCH_INLINE.ToString());
            botClient.EditMessageText(new EditMessageTextArgs(Constants.SwitchInlineButtonMessage)
            {
                ChatId = query.Message.Chat.Id,
                MessageId = query.Message.MessageId
            });

            await botClient.SendMessageAsync(
                chatId: query.Message.Chat.Id,
                text: string.Format(Constants.ExampleButton, ButtonType.SWITCH_INLINE.ToString().ToLower()),
                cancellationToken: cancellationToken);

            var inlineKeyboard = new InlineKeyboardMarkup(new[]
            {
                new InlineKeyboardButton("Share with")
                {
                    SwitchInlineQuery = Constants.ExampleCallBackWow
                },
                new InlineKeyboardButton("Share in the current chat")
                {
                    SwitchInlineQueryCurrentChat = Constants.ExampleCallBackGreat
                }
            });

            await botClient.SendMessageAsync(
                chatId: query.Message.Chat.Id,
                text: Constants.ExampleChoiceMessage,
                replyMarkup: inlineKeyboard,
                cancellationToken: cancellationToken);
        }
    }
}
