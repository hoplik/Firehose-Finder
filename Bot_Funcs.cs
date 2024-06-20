using FirehoseFinder.Properties;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace FirehoseFinder
{
    class Bot_Funcs
    {
        internal readonly long channel = -1001227261414;
        internal static ITelegramBotClient _botClient;
        // Это объект с настройками работы бота. Здесь мы будем указывать, какие типы Update мы будем получать, Timeout бота и так далее.
        private static ReceiverOptions _receiverOptions;
        internal static async Task BotWork()
        {
            _botClient = new TelegramBotClient(Resources.bot);
            _receiverOptions = new ReceiverOptions
            {
                AllowedUpdates = new[] // Тут указываем типы получаемых Update`ов, о них подробнее расказано тут https://core.telegram.org/bots/api#update
            {
                UpdateType.Message, // Сообщения (текст, фото/видео, голосовые/видео сообщения и т.д.)
                UpdateType.CallbackQuery, //Inline кнопки
            },
                // Параметр, отвечающий за обработку сообщений, пришедших за то время, когда ваш бот был оффлайн
                // True - не обрабатывать, False (стоит по умолчанию) - обрабаывать
                ThrowPendingUpdates = true,
            };
            var cts = new CancellationTokenSource();
            // UpdateHander - обработчик приходящих Update`ов
            // ErrorHandler - обработчик ошибок, связанных с Bot API
            _botClient.StartReceiving(UpdateHandler, ErrorHandler, _receiverOptions, cts.Token); // Запускаем бота

            var me = await _botClient.GetMeAsync(); // Создаем переменную, в которую помещаем информацию о нашем боте.
            MessageBox.Show("Если у вас не получилость автоматически авторизоваться, то вы можете найти в Телеграм бота \"Hoplik-Bot\"" +
                " и при запущенном приложении FhF попробовать ввести после команды /start код авторизации:" + Environment.NewLine + Settings.Default.auth_code.ToString(), me.FirstName + " успешно подключён!");
            await Task.Delay(-1);
        }
        private static async Task UpdateHandler(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            // Обязательно ставим блок try-catch, чтобы наш бот не "падал" в случае каких-либо ошибок
            try
            {
                // Сразу же ставим конструкцию switch, чтобы обрабатывать приходящие Update
                switch (update.Type)
                {
                    case UpdateType.Message:
                        {
                            // эта переменная будет содержать в себе все связанное с сообщениями
                            var message = update.Message;
                            // From - это от кого пришло сообщение (или любой другой Update)
                            var user = message.From;
                            // Chat - содержит всю информацию о чате
                            var chat = message.Chat;
                            // Обрабатываем команду /старт
                            if (message.Text.StartsWith("/start"))
                            {
                                if (message.Text.Length > 6) //Обрабатываем код авторизации (не забываем про дубликаты!)
                                {
                                    if (Settings.Default.userID != 0)
                                    {
                                        await botClient.SendTextMessageAsync(
                                            chat.Id,
                                            "Не надо больше. Вы уже авторизованы",
                                            replyToMessageId: message.MessageId //"ответ" на сообщение
                                            );
                                    }
                                    else
                                    {
                                        string authcode = message.Text.Substring(6).Trim(' ');
                                        bool authok = authcode.Equals(Settings.Default.auth_code);
                                        if (authok)
                                        {
                                            Settings.Default.userID = user.Id;
                                            if (string.IsNullOrEmpty(user.FirstName)) Settings.Default.userFN = string.Empty; else Settings.Default.userFN = user.FirstName;
                                            if (string.IsNullOrEmpty(user.LastName)) Settings.Default.userSN = string.Empty; else Settings.Default.userSN = user.LastName;
                                            if (string.IsNullOrEmpty(user.Username)) Settings.Default.userN = string.Empty; else Settings.Default.userN = user.Username;
                                            //Авторизация прошла удачно. Перегружаемся.
                                            Application.Restart();
                                        }
                                        else
                                        {
                                            await botClient.SendTextMessageAsync(
                                                chat.Id,
                                                "Авторизация прошла неудачно. Попробуйте ещё раз, используя приложение FhF.",
                                                replyToMessageId: message.MessageId //"ответ" на сообщение
                                                );
                                        }
                                    }
                                }
                                else //Команда без параметров. Поднимаем клавиатуру, просим ввести код авторизации и пр.
                                {
                                    // Тут создаем нашу клавиатуру
                                    var inlineKeyboard = new InlineKeyboardMarkup(
                                        new List<InlineKeyboardButton[]>() // здесь создаем лист (массив), который содрежит в себе массив из класса кнопок
                                        {
                                        // Каждый новый массив - это дополнительные строки,
                                        // а каждая дополнительная кнопка в массиве - это добавление ряда
                                        new InlineKeyboardButton[] // тут создаем массив кнопок
                                        {
                                            InlineKeyboardButton.WithCallbackData("Авторизация", "button_auth"),
                                            InlineKeyboardButton.WithCallbackData("Рейтинг", "button_rate"),
                                        },
                                        });
                                    await botClient.SendTextMessageAsync(
                                        chat.Id,
                                        "Пожалуйста, выберите \"Авторизация\", если готовы ввести код из программы FhF или \"Рейтинг\", если хотите посмотреть текущий \"Рейтинг неравнодушных пользователей\"",
                                        replyMarkup: inlineKeyboard); // Все клавиатуры передаются в параметр replyMarkup
                                    return;
                                }
                            }
                            else
                            {
                                //Код авторизации верен
                                if (message.Text.Equals(Settings.Default.auth_code))
                                {
                                    Settings.Default.userID = user.Id;
                                    if (string.IsNullOrEmpty(user.FirstName)) Settings.Default.userFN = string.Empty; else Settings.Default.userFN = user.FirstName;
                                    if (string.IsNullOrEmpty(user.LastName)) Settings.Default.userSN = string.Empty; else Settings.Default.userSN = user.LastName;
                                    if (string.IsNullOrEmpty(user.Username)) Settings.Default.userN = string.Empty; else Settings.Default.userN = user.Username;
                                    //Авторизация прошла удачно. Перегружаемся.
                                    Application.Restart();
                                }
                                else //Ввели неподдерживаемую команду
                                {
                                    await botClient.SendTextMessageAsync(
                                        chat.Id,
                                        "Извините, не понимаю о чём вы. Может быть /start?",
                                        replyToMessageId: message.MessageId //"ответ" на сообщение
                                        );
                                }
                            }
                            return;
                        }
                    case UpdateType.CallbackQuery:
                        {
                            // Переменная, которая будет содержать в себе всю информацию о кнопке, которую нажали
                            var callbackQuery = update.CallbackQuery;
                            // Аналогично и с Message мы можем получить информацию о чате, о пользователе и т.д.
                            var user = callbackQuery.From;
                            // Вот тут нужно уже быть немножко внимательным и не путаться!
                            // Мы пишем не callbackQuery.Chat , а callbackQuery.Message.Chat , так как
                            // кнопка привязана к сообщению, то мы берем информацию от сообщения.
                            var chat = callbackQuery.Message.Chat;
                            // Добавляем блок switch для проверки кнопок
                            switch (callbackQuery.Data)
                            {
                                // Data - это придуманный нами id кнопки, мы его указывали в параметре
                                // callbackData при создании кнопок. У меня это button1, button2 и button3
                                case "button_auth":
                                    {
                                        // В этом типе клавиатуры обязательно нужно использовать следующий метод
                                        await botClient.AnswerCallbackQueryAsync(callbackQuery.Id, "При успешной авторизации ваш экземпляр приложения FhF перезагрузится автоматически!");
                                        // Для того, чтобы отправить телеграмму запрос, что мы нажали на кнопку

                                        await botClient.SendTextMessageAsync(
                                            chat.Id,
                                            "Отправьте 4 цифры кода авторизации из приложения FhF в формате ХХ-ХХ");
                                        return;
                                    }
                                case "button_rate":
                                    {
                                        // А здесь мы добавляем наш сообственный текст, который заменит слово "загрузка", когда мы нажмем на кнопку
                                        await botClient.AnswerCallbackQueryAsync(callbackQuery.Id, "Готовлю рейтинг...");

                                        await botClient.SendTextMessageAsync(
                                            chat.Id,
                                            $"Пока не научился :(");
                                        return;
                                    }
                                default:
                                    return;
                            }
                        }
                    default:
                        return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private static Task ErrorHandler(ITelegramBotClient botClient, Exception error, CancellationToken cancellationToken)
        {
            // Тут создадим переменную, в которую поместим код ошибки и её сообщение 
            ApiRequestException apiRequestException = new ApiRequestException("Telegram API Error:", error);
            string ErrorMessage = $"Telegram API Error:\n[{apiRequestException.ErrorCode}]\n{apiRequestException.Message}";
            MessageBox.Show(ErrorMessage);
            return Task.CompletedTask;
        }
    }
}
