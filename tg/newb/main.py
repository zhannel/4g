import misc
import requests
import json
token = misc.token
URL1 = 'https://api.telegram.org/bot' + token + '/'
import json_info as jj

def get_updates():
    url = URL1 + 'getupdates'
    resp = requests.get(url)
    return resp.json()



def get_message():
    data = get_updates()
    chat_id = data['result'][-1]['message']['chat']['id']
    msg_text = data['result'][-1]['message']['text']

    message = {'chat_id': chat_id, 'text' : msg_text}
    return message


def main():
    # d = get_updates()
    #
    # with open('updates.json', 'w' ) as file:
    #     json.dump(d, file, indent=2, ensure_ascii=False)

    get_message()
    jj.get_json()


if __name__ == '__main__':
    main()

