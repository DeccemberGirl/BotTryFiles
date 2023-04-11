﻿namespace BotTry
{
    public static class Constants
    {
        public const string AccessToken = "5553149217:AAFC39X9dwMiyRtfFJEBmHkKfq7hvSS7FeQ";
        public const string BotIntroduction = "Hello, World! I am user with id {0} and my name is {1}.\nI was created to help you with creating your own bots! Let me show you how to use Telegram.BotAPI library and C#, there`s nothing difficult :)\nJust type '/help'!";
        public const string CommandsListMessage = "/start - the very beginning \n/help - commands reminding \n/learn - bots tutorial \n/units - choose a concreate unit to learn\n\nRemember that you can type these commands anytime to switch between content or return back.";
        public const string LinkIsPressedButtonCallbackData = "Link is pressed";
        public const string MessageReceivedNotification = "Received message '{0}' in chat {1}.";
        public const string NiceWeatherMessage = "Hi! What a nice weather, eh?";
        public const string UnitsListMessage = "/message_types - learn how to send different types of media, text etc. \n/buttons - lets look at buttons markups \n/getting_updates - methods of getting responses from user \n/files - how to work with files and documents \n/security - proxy, passport, decryption and so on";
        public const string UnknownMessage = "I`m too young to understand all words you know. Please use my standart commands yet :)";

        // Teacher commands and keywords
        public const string TutorialStartMessage = "Cool! Let`s learn how to create bots step by step, unit by unit.\nFirst of all let ne show you how to send diiferent types of data. ";
        public const string ChoiceMessage = "Choose which one you want me to explain: ";
        public const string FurtherMessage = "\n\nLet`s go further!";
        public const string ExampleMessage = "The next message is an example of the {0} message.";
        public const string MessageTypes = "There are many different types of message that a bot can send. Fortunately, methods for sending such messages are similar. Choose which one you`d like to try first: ";
        public const string TextMessage = "To send a text message you can use this code snippet:\n\nvar message = await botClient.SendMessageAsync(\r\n    chatId: chatId,\r\n    text: \"Hello, World!\",\r\n    cancellationToken: cancellationToken);\n\nChat id can be got from your 'update' message when you start your bot.";
        public const string PhotoMessage = "To send a photo message you can use this code snippet:\n\nvar message = await botClient.SendPhotoAsync(\r\n   chatId: chatId,\r\n    photo: \"https://raw.githubusercontent.com/DeccemberGirl/BotTryFiles/master/Resources/GopherPhoto.jpg\",\r\n    caption: \"<b>Gopher</b>. <i>State</i>: <a>Hungry</a>\",\r\n    parseMode: ParseMode.HTML,\r\n     cancellationToken: cancellationToken);\n\nChat id can be got from your 'update' message when you start your bot.";
        public const string StickerMessage = "To send a sticker message you can use this code snippet:\n\nvar message = await botClient.SendStickerAsync(\r\n    chatId: chatId,\r\n    sticker: \"https://raw.githubusercontent.com/DeccemberGirl/BotTryFiles/master/Resources/Otter.webp\",\r\n     cancellationToken: cancellationToken);\n\nChat id can be got from your 'update' message when you start your bot.";
        public const string AudioMessage = "To send an audio message you can use this code snippet:\n\nvar message = await botClient.SendAudioAsync(\r\n    chatId: chatId,\r\n    audio: \"https://raw.githubusercontent.com/DeccemberGirl/BotTryFiles/master/Resources/SurzhykMstyslavKrupenya.mp3\",\r\n    performer: \"Mstyslav Krupenya\",\r\n    title: \"Surzhyk\",\r\n    duration: 124, \r\n    cancellationToken: cancellationToken);\n\nChat id can be got from your 'update' message when you start your bot.";
        public const string VoiceMessage = "To send a voice message you can use this code snippet:\n\nawait using (var stream = File.OpenRead(\"Resources\\\\CatTalking.ogg\"))\r\n    {\r\n     await botClient.SendVoiceAsync(\r\n    chatId: chatId,\r\n     voice: new InputFile(new StreamContent(stream!), \"CatTalking.ogg\"),\r\n     duration: 22,\r\n     cancellationToken: cancellationToken);\r\n    }\n\nChat id can be got from your 'update' message when you start your bot.";
        public const string VideoMessage = "To send a video message you can use this code snippet:\n\nvar message = await botClient.SendVideoAsync(\r\n    chatId: query.Message.Chat.Id,\r\n    video: \"https://raw.githubusercontent.com/DeccemberGirl/BotTryFiles/master/Resources/TNMK_Proyihaly.mp4\",\r\n     thumbnail: \"https://raw.githubusercontent.com/DeccemberGirl/BotTryFiles/master/Resources/TNMK_Proyihaly.png\",\r\n     supportsStreaming: true,\r\n    cancellationToken: cancellationToken);\n\nChat id can be got from your 'update' message when you start your bot.";
        public const string VideoNoteMessage = "To send a video-note message you can use this code snippet:\n\nawait using (var stream = File.OpenRead(\"Resources\\\\ASAFATOV_YaDavnoNeVmykavTelefon.mp4\"))\r\n     {\r\n   await botClient.SendVideoNoteAsync(\r\n     chatId: query.Message.Chat.Id,\r\n     videoNote: new InputFile(new StreamContent(stream!), \"ASAFATOV_YaDavnoNeVmykavTelefon.mp4\"),\r\n     duration: 19,\r\n     length: 360, \r\n    cancellationToken: cancellationToken);\r\n    }\n\nChat id can be got from your 'update' message when you start your bot.";
        public const string AlbumMessage = "To send an album message you can use this code snippet:\n\nvar message = await botClient.SendMediaGroupAsync(\r\n    chatId: query.Message.Chat.Id,\r\n    media: new List<InputMedia>\r\n    {\r\n    new InputMediaPhoto(\"https://raw.githubusercontent.com/DeccemberGirl/BotTryFiles/master/Resources/Fish1.jpg\"),\r\n    new InputMediaPhoto(\"https://raw.githubusercontent.com/DeccemberGirl/BotTryFiles/master/Resources/Fish2.jpg\"),\r\n    },\r\n    cancellationToken: cancellationToken);\n\nChat id can be got from your 'update' message when you start your bot.";
        public const string DocumentMessage = "To send a document message you can use this code snippet:\n\nvar message = await botClient.SendDocumentAsync(\r\n    chatId: query.Message.Chat.Id,\r\n    document: \"https://raw.githubusercontent.com/DeccemberGirl/BotTryFiles/master/Resources/TextDoc.txt\",\r\n    caption: \"<b>Weather question</b>. <i>Umbrella</i>: <a>To take or not?</a>\",\r\n     parseMode: ParseMode.HTML,\r\n    cancellationToken: cancellationToken);\n\nChat id can be got from your 'update' message when you start your bot.";
        public const string AnimationMessage = "To send an animation message you can use this code snippet:\n\nvar message = await botClient.SendAnimationAsync(\r\n    chatId: query.Message.Chat.Id,\r\n    animation: \"https://raw.githubusercontent.com/DeccemberGirl/BotTryFiles/master/Resources/SmileGIF.mp4\",\r\n     caption: \"SmileGIF\",\r\n    cancellationToken: cancellationToken);\n\nChat id can be got from your 'update' message when you start your bot.";
        public const string PollMessage = "To send a poll message you can use this code snippet:\n\nvar message = await botClient.SendPollAsync(\r\n   chatId: query.Message.Chat.Id,\r\n    question: \"Hey?\",\r\n    options: new[]\r\n    {\r\n    \"Ho!\",\r\n    \"Heee...\"\r\n    },\r\n    cancellationToken: cancellationToken);\n\nTo stop poll you can use this code:\nawait botClient.StopPollAsync(\r\n    chatId: message.Chat.Id,\r\n    messageId: message.MessageId,\r\n     cancellationToken: cancellationToken);\n\nChat id can be got from your 'update' message when you start your bot.";
        public const string ContactMessage = "To send a contact message you can use this code snippet:\n\nvar message = await botClient.SendContactAsync(\r\n     chatId: query.Message.Chat.Id,\r\n    phoneNumber: \"+1234567890\",\r\n    firstName: \"Stepan\",\r\n    lastName: \"Bandera\",\r\n    cancellationToken: cancellationToken);\n\nChat id can be got from your 'update' message when you start your bot.";
        public const string VenueMessage = "To send a venue message you can use this code snippet:\n\nvar message = await botClient.SendVenueAsync(\r\n    chatId: query.Message.Chat.Id,\r\n    latitude: 50.0840172f,\r\n    longitude: 14.418288f,\r\n    title: \"Man Hanging out\",\r\n    address: \"Husova, 110 00 Staré Město, Czechia\",\r\n    cancellationToken: cancellationToken);\n\nChat id can be got from your 'update' message when you start your bot.";
        public const string LocationMessage = "To send a location message you can use this code snippet:\n\nvar message = await botClient.SendLocationAsync(\r\n    chatId: query.Message.Chat.Id,\r\n    latitude: 33.747252f,\r\n    longitude: -112.633853f,\r\n    cancellationToken: cancellationToken);\n\nChat id can be got from your 'update' message when you start your bot.";
    }
}
