# #import misc
# import requests
#
# # token = misc.token
# #https://api.telegram.org/bot843393510:AAG6xZH86ktw46Mn3U2K7X5WDiusFYpLmXY/sendmessage?chat_id=319888936&text=hi
#
# token = '843393510:AAG6xZH86ktw46Mn3U2K7X5WDiusFYpLmXY'
# # print(token)
# URL1 = 'https://api.telegram.org/bot' + token + '/'
#
#
# def get_updates():
#     url = URL1 + 'getupdates'
#     resp = requests.get(url)
#     print("hi")
#
#
# def main():
#     get_updates()
#
#
# if __name__ == '__main__':
#     main()




# import telepot
# import urllib3
# proxy_url = "http://proxy.server:3128"
# telepot.api._pools = {'default': urllib3.ProxyManager(proxy_url=proxy_url, num_pools=3,maxsize=10, retries=False, timeout=30),}
# telepot.api._onetime_pool_spec = (urllib3.ProxyManager, dict(proxy_url=proxy_url, num_pools=1, maxsize=1, retries=False, timeout=30))


import asyncio
from aiogram import Bot, Dispatcher, executor
from aiogram.contrib.fsm_storage.memory import MemoryStorage
from config import BOT_TOKEN

loop = asyncio.get_event_loop()
bot = Bot(BOT_TOKEN, parse_mode="HTML")
storage = MemoryStorage()
dp = Dispatcher(bot, storage=storage, loop=loop)

if __name__ == '__main__':
    from handlers import *
    executor.start_polling(dp, on_startup=send_to_admin)

