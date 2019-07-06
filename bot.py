import telebot;


import telepot
import urllib3
proxy_url = "http://proxy.server:3128"
telepot.api._pools = {'default': urllib3.ProxyManager(proxy_url=proxy_url, num_pools=3,maxsize=10, retries=False, timeout=30),}
telepot.api._onetime_pool_spec = (urllib3.ProxyManager, dict(proxy_url=proxy_url, num_pools=1, maxsize=1, retries=False, timeout=30))

bot = telebot.TeleBot('%887578648:AAFIGPEzk31SkgqIXp1cjtaJRbKNKQtFg04%');
@bot.message_handler(content_types=['text', 'document', 'audio'])
def get_text_messages(message):
    if message.text == "Hello":
        bot.send_message(message.from_user.id, "Hello, can i help you?")
    elif message.text == "/help":
        bot.send_message(message.from_user.id, "Write Hello")
    else:
        bot.send_message(message.from_user.id, "I can't udestand you. Write /help")
