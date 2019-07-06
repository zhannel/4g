<<<<<<< HEAD
import requests
import misc #тут токен
# import json #to output russian text properly
# https://api.telegram.org/bot848577923:AAHlsUHjNBWB6QprMt9HSQ79ZA9HJLvgssU/sendmessage?chat_id=389181251&text=pidor

token = misc.token
URL = 'https://api.telegram.org/bot' + token + '/'

def get_updates():
    url = URL + 'getupdates'
    r = requests.get(url)
    return r.json()




def get_message():
    data = get_updates()
    chat_id = data['result'][-1]['message']['chat']['id']
    message_text = data['result'][-1]['message']['text']

    message = {'chat_id': chat_id,
               'text': message_text}
    return message


def send_message(chat_id, text='go kill tourself'):
    url = URL + 'sendmessage?chat_id={}&text={}'.format(chat_id, text)
    requests.get(url)
    
def main():
    answer = get_message()
    chat_id = answer['chat_id']
    text = answer['text']

    if 'sam pidor' in text:
        send_message(chat_id, 'pidora otvet')
   

if __name__ == '__main__':
    main()


    

=======
import requests
import misc #тут токен
import json #to output russian text properly
# https://api.telegram.org/bot848577923:AAHlsUHjNBWB6QprMt9HSQ79ZA9HJLvgssU/sendmessage?chat_id=389181251&text=pidor

token = misc.token
URL = 'https://api.telegram.org/bot' + token + '/'

def get_updates():
    url = URL + 'getupdates'
    r = requests.get(url)
    return r.json()




def get_message():
    data = get_updates()
    chat_id = data['result'][-1]['message']['chat']['id']
    message_text = data['result'][-1]['message']['text']

    message = {'chat_id': chat_id,
               'text': message_text}
    return message

    
def main():
    print(get_message())
   # d = get_updates()

   # with open('updates.json', 'w') as file:
        # json.dump(d, file, indent=2, ensure_ascii=False) #write to file
        # indent eto otstupy



    



if __name__ == '__main__':
    main()


    

>>>>>>> 0c640e4b8dd3aa354071250fb55297c6648e13cb
