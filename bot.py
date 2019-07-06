# Настройки
from telegram.ext import Updater, CommandHandler, MessageHandler, Filters
updater = Updater(token='848577923:AAHlsUHjNBWB6QprMt9HSQ79ZA9HJLvgssU') # Токен API к Telegram
dispatcher = updater.dispatcher
# Обработка команд
def startCommand(bot, update):
    bot.send_message(chat_id=update.message.chat_id, text='Hello, niga')
def textMessage(bot, update):
    response = 'Niga wassup: ' + update.message.text
    bot.send_message(chat_id=update.message.chat_id, text=response)
# Хендлеры
start_command_handler = CommandHandler('start', startCommand)
text_message_handler = MessageHandler(Filters.text, textMessage)
# Добавляем хендлеры в диспетчер
dispatcher.add_handler(start_command_handler)
dispatcher.add_handler(text_message_handler)
# Начинаем поиск обновлений
updater.start_polling(clean=True)
# Останавливаем бота, если были нажаты Ctrl + C
updater.idle()
